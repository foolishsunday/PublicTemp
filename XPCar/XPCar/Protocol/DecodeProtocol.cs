using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Data;
using XPCar.Prj.Model;
using XPCar.Protocol.Encode;

namespace XPCar.Protocol
{
    public class DecodeProtocol 
    {
        //private List<byte> _RawData;
        private int _State = 0;
        private int _Pos = 0;
        public List<EachFrameModel> VerifyProtocolFormat(ref List<byte> buf)
        {
            EachFrameModel model = new EachFrameModel();
            List<EachFrameModel> lists = new List<EachFrameModel>();
            string undecode = string.Empty;
            int undecodeLen = 0;
            int errorCode = 0;
            int deleteLen = 0;
            string error = string.Empty;
            try
            {
                byte CmdTypeHigh = 0;
                byte CmdTypeLow = 0;
                byte CmdHigh = 0;
                byte CmdLow = 0;


                for (int i = 0; i < buf.Count; i++)
                {
                    byte v = buf[i];
                    if (_State == 0)
                    {
                        i = 0;
                        v = buf[0];
                    }
                    #region 帧格式判断
                    switch (_State)
                    {
                        case 0:
                            if (v == ConstProtocol.HEAD_FLAG)
                            {
                                _Pos = 0;
                                _State = 1;
                                model.Reset();
                                model.Buffer.Add(v);
                            }
                            break;
                        case 1:
                            if (v == ConstProtocol.ADDR1_HIGH)
                            {
                                _State = 2;
                                model.Buffer.Add(v);
                            }
                            else
                            {
                                _State = -2;
                            }
                            break;
                        case 2:
                            if (v == ConstProtocol.ADDR1_LOW)
                            {
                                _State = 3;
                                model.Buffer.Add(v);
                            }
                            else
                            {
                                _State = -3;
                            }
                            break;
                        case 3:
                            if (v == ConstProtocol.ADDR2_HIGH)
                            {
                                _State = 4;
                                model.Buffer.Add(v);
                            }
                            else
                            {
                                _State = -4;
                            }
                            break;
                        case 4:
                            if (v == ConstProtocol.ADDR2_LOW)
                            {
                                _State = 5;
                                model.Buffer.Add(v);
                            }
                            else
                            {
                                _State = -5;
                            }
                            break;
                        case 5:
                            _State = 6;
                            CmdTypeHigh = v;
                            model.Buffer.Add(v);
                            break;
                        case 6:
                            _State = 7;
                            CmdTypeLow = v;
                            model.Buffer.Add(v);
                            break;
                        case 7:
                            _State = 8;
                            CmdHigh = v;
                            model.Buffer.Add(v);
                            break;
                        case 8:
                            _State = 9;
                            CmdLow = v;

                            DecodeEffectLen(CmdTypeHigh, CmdTypeLow, CmdHigh, CmdLow, ref model);//根据命令号，得到有效数据长度
                            if (buf.Count < model.Len + 12)  //长度不足
                            {
                                Reset(ref model);
                                return null;
                            }
                            else
                                model.Buffer.Add(v);
                            break;
                        case 9:
                            model.Len--;  //根据长度存数据
                            if (model.Len <= 0)
                            {
                                _State = 10;

                            }
                            model.Buffer.Add(v);//
                            break;
                        case 10:
                            if (v == ConstProtocol.END_FLAG)
                            {
                                _State = 11;
                                model.Buffer.Add(v);
                            }
                            else
                            {
                                _State = -10;

                            }
                            break;
                        case 11:
                            _State = 12;
                            model.Buffer.Add(v);
                            break;
                        case 12:

                            model.Buffer.Add(v);
                            if (ProtocolHelper.CheckSum(model.Buffer))
                            {
                                _State = 100;
                            }
                            else//校验失败
                            {
                                _State = -12;
                            }
                            break;
                        default:
                            _State = 0;
                            break;
                    }
                    #endregion 帧格式判断

                    _Pos++;
                    if (_State <= 0)
                    {
                        for (int j = 0; j < this._Pos; j++)
                        {
                            undecode += Convert.ToString(buf[j], 16).ToUpper().PadLeft(2, '0') + KeyConst.Punctuation.Space;
                            undecodeLen++;
                        }
                        errorCode = _State;
                        buf.RemoveRange(0, _Pos);  //清除不符合协议规范的数据
                        deleteLen += this._Pos;
                        Reset(ref model);
                        error += errorCode.ToString() + " ";
                    }
                    else if (_State == 100)
                    {
                        buf.RemoveRange(0, _Pos);
                        EachFrameModel temp = new EachFrameModel();
                        model.CopyData(ref temp);
                        lists.Add(temp);
                        Reset(ref model);
                    }

                }
                if (buf != null && buf.Count == 1)
                {
                    if (buf[0] != 0x7E)
                    {
                        undecode += Convert.ToString(buf[0], 16).ToUpper().PadLeft(2, '0') + KeyConst.Punctuation.Space;
                        buf.RemoveAt(0);
                    }
                }
                if (undecode != string.Empty)
                {
                    string warn = string.Format(" errorCode = {0}, Cannot decode Len = {1}, deleteLen = {2}, Data = {3}", error, undecodeLen, deleteLen, undecode);
                    Log.Warn(System.Reflection.MethodBase.GetCurrentMethod().Name, warn);
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

            return lists;
        }

        private void Reset(ref EachFrameModel model)
        {
            this._State = 0;
            this._Pos = 0;
            model.Reset();
        }

        #region 获取命令号及有效数据长度
        private void DecodeEffectLen(byte cmdtype1, byte cmdtype2, byte cmd1, byte cmd2, ref EachFrameModel model)
        {
            byte[] cmd = new byte[] { cmdtype1, cmdtype2, cmd1, cmd2 };
            if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.CAN))) //4350 len=20或36
            {
                //model.Len = 36;
                //model.Len -= 12;  //减去帧头帧尾数量
                //model.Cmd = ConstCmd.CmdAck.CAN;
                model.SetFrameName(ConstCmd.CmdAck.CAN, ConstCmd.FrameLen.CAN);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.BASE_INFO)))
            {
                model.SetFrameName(ConstCmd.CmdAck.BASE_INFO, ConstCmd.FrameLen.BASE_INFO);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.CHARGE_PARA_GET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.CHARGE_PARA_GET, ConstCmd.FrameLen.CHARGE_PARA_GET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.CHARGE_PARA_SET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.CHARGE_PARA_SET, ConstCmd.FrameLen.CHARGE_PARA_SET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.CHARGE_STOP_GET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.CHARGE_STOP_GET, ConstCmd.FrameLen.CHARGE_STOP_GET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.CHARGE_STOP_SET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.CHARGE_STOP_SET, ConstCmd.FrameLen.CHARGE_STOP_SET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.CHARGE_WRONG_GET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.CHARGE_WRONG_GET, ConstCmd.FrameLen.CHARGE_WRONG_GET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.CHARGE_WRONG_SET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.CHARGE_WRONG_SET, ConstCmd.FrameLen.CHARGE_WRONG_SET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.CHARGING_GET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.CHARGING_GET, ConstCmd.FrameLen.CHARGING_GET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.CHARGING_SET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.CHARGING_SET, ConstCmd.FrameLen.CHARGING_SET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.CONSIST)))
            {
                model.SetFrameName(ConstCmd.CmdAck.CONSIST, ConstCmd.FrameLen.CONSIST);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.HANDSHAKE_GET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.HANDSHAKE_GET, ConstCmd.FrameLen.HANDSHAKE_GET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.HANDSHAKE_SET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.HANDSHAKE_SET, ConstCmd.FrameLen.HANDSHAKE_SET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.SYS_START)))
            {
                model.SetFrameName(ConstCmd.CmdAck.SYS_START, ConstCmd.FrameLen.SYS_START);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.UPGRADE_ACK)))
            {
                model.SetFrameName(ConstCmd.CmdAck.UPGRADE_ACK, ConstCmd.FrameLen.UPGRADE_ACK);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.DC_GET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.DC_GET, ConstCmd.FrameLen.DC_GET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.DC_SET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.DC_SET, ConstCmd.FrameLen.DC_SET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.ALARM_GET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.ALARM_GET, ConstCmd.FrameLen.ALARM_GET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.AC_GET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.AC_GET, ConstCmd.FrameLen.AC_GET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.AC_SET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.AC_SET, ConstCmd.FrameLen.AC_SET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.AC_INTEROP_GET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.AC_INTEROP_GET, ConstCmd.FrameLen.AC_INTEROP_GET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.VER_GET)))
            {
                model.SetFrameName(ConstCmd.CmdAck.VER_GET, ConstCmd.FrameLen.VER_GET);
            }
            else if (Enumerable.SequenceEqual(cmd, ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdAck.TIME_SYNC)))//add for 实时时间
            {
                model.SetFrameName(ConstCmd.CmdAck.TIME_SYNC, ConstCmd.FrameLen.TIME_SYNC);
            }
            else
            {
                model.SetFrameName(ConstCmd.CmdAck.UNDEFINED, ConstCmd.FrameLen.UNDEFINED);
            }

        }
        #endregion 获取命令号及有效数据长度
        #region while写法，未测试
        //public enum DecodeStateStyle
        //{
        //    None,
        //    Head,
        //    Addr1High,
        //    Addr1Low,
        //    Addr2High,
        //    Addr2Low,
        //    AckCmdType1,
        //    AckCmdType2,
        //    AckCmd1,
        //    AckCmd2,
        //    AckContent,
        //    EndFlag,
        //    Chk1,
        //    Chk2,
        //    Finished,
        //    Error,
        //    Break
        //}
        //private DecodeStateStyle DecodeProtocolState(byte content, DecodeStateStyle preState, int contentLen,
        //                                        ref int breakLen, ref int remainLen)
        //{
        //    switch (preState)
        //    {
        //        case DecodeStateStyle.None:
        //        case DecodeStateStyle.Error:
        //        case DecodeStateStyle.Break:
        //            if (content == ConstProtocol.HEAD_FLAG)
        //                return DecodeStateStyle.Head;
        //            else
        //            {
        //                return DecodeStateStyle.Error;
        //            }

        //        case DecodeStateStyle.Head:
        //            if (content == ConstProtocol.ADDR1_HIGH)
        //                return DecodeStateStyle.Addr1High;
        //            else
        //            {
        //                breakLen = 2;
        //                return DecodeStateStyle.Break;
        //            }
        //        case DecodeStateStyle.Addr1High:
        //            if (content == ConstProtocol.ADDR1_LOW)
        //                return DecodeStateStyle.Addr1Low;
        //            else
        //            {
        //                breakLen = 3;
        //                return DecodeStateStyle.Break;
        //            }
        //        case DecodeStateStyle.Addr1Low:
        //            if (content == ConstProtocol.ADDR2_HIGH)
        //                return DecodeStateStyle.Addr2High;
        //            else
        //            {
        //                breakLen = 4;
        //                return DecodeStateStyle.Break;
        //            }
        //        case DecodeStateStyle.Addr2High:
        //            if (content == ConstProtocol.ADDR2_LOW)
        //                return DecodeStateStyle.Addr2Low;
        //            else
        //            {
        //                breakLen = 5;
        //                return DecodeStateStyle.Break;
        //            }
        //        case DecodeStateStyle.Addr2Low:
        //            breakLen = 6;
        //            return DecodeStateStyle.AckCmdType1;
        //        case DecodeStateStyle.AckCmdType1:
        //            breakLen = 7;
        //            return DecodeStateStyle.AckCmdType2;
        //        case DecodeStateStyle.AckCmdType2:
        //            breakLen = 8;
        //            return DecodeStateStyle.AckCmd1;
        //        case DecodeStateStyle.AckCmd1:
        //            breakLen = 9;
        //            return DecodeStateStyle.AckCmd2;
        //        case DecodeStateStyle.AckCmd2:
        //            breakLen = 10;
        //            return DecodeStateStyle.AckContent;
        //        case DecodeStateStyle.AckContent:
        //            remainLen--;
        //            if (remainLen > 0)
        //            {
        //                breakLen = 11;
        //                return DecodeStateStyle.AckContent;
        //            }
        //            else
        //                return DecodeStateStyle.EndFlag;
        //        case DecodeStateStyle.EndFlag:
        //            if (content == ConstProtocol.END_FLAG)
        //                return DecodeStateStyle.Chk1;
        //            else
        //            {
        //                breakLen = 12 + contentLen;
        //                return DecodeStateStyle.Break;
        //            }
        //        case DecodeStateStyle.Chk1:
        //            breakLen = 13 + contentLen;
        //            return DecodeStateStyle.Chk2;
        //        case DecodeStateStyle.Chk2:
        //            breakLen = 14 + contentLen;
        //            return DecodeStateStyle.Finished;
        //        default:
        //            return DecodeStateStyle.Error;
        //    }
        //}
        //public List<EachFrameModel> VerifyProtocolFormat(ref List<byte> buf)
        //{
        //    EachFrameModel model = new EachFrameModel();
        //    List<EachFrameModel> lists = new List<EachFrameModel>();
        //    //string undecode = string.Empty;
        //    DecodeStateStyle preState = DecodeStateStyle.None;
        //    byte[] cmds = new byte[4] { 0, 0, 0, 0 };
        //    int pos = 0;
        //    int contentLen = 0;
        //    int breakLen = 0;
        //    int remainLen = 0;
        //    try
        //    {
        //        if (buf == null)
        //            return null;
        //        while (buf.Count > 0)
        //        {
        //            byte val = buf[0];
        //            Prj.Prj.Unsolved.PreData.Add(val);
        //            buf.RemoveAt(0);

        //            if (preState == DecodeStateStyle.AckCmd2)//前一次接收到命令号
        //            {
        //                DecodeEffectLen(cmds[0], cmds[1], cmds[2], cmds[3], ref model);
        //                contentLen = model.Len;
        //                remainLen = model.Len;
        //            }
        //            preState = DecodeProtocolState(val, preState, contentLen, ref breakLen, ref remainLen);
        //            if (preState == DecodeStateStyle.Error)
        //            {
        //                buf.RemoveAt(0);
        //            }
        //            else if (preState == DecodeStateStyle.Break)
        //            {
        //                buf.RemoveRange(0, breakLen);
        //            }
        //            else if (preState == DecodeStateStyle.AckCmdType1)
        //            {
        //                cmds[0] = val;
        //            }
        //            else if (preState == DecodeStateStyle.AckCmdType2)
        //            {
        //                cmds[1] = val;
        //            }
        //            else if (preState == DecodeStateStyle.AckCmd1)
        //            {
        //                cmds[2] = val;
        //            }
        //            else if (preState == DecodeStateStyle.AckCmd2)
        //            {
        //                cmds[3] = val;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }

        //    return lists;
        //}
        #endregion
    }
}
