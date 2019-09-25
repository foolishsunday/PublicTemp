using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;
using XPCar.Protocol.Decode.Msg;

namespace XPCar.Protocol.Decode.Service
{
    public class Decode_CanMsg : DecodePackageCommon
    {
        private string _Direction = "读取";
        //private int _Dlc = 8;
        public override void DecodePackage(EachFrameModel package)
        {
            CanMsgRich canGridRich;

            try
            {
                List<byte> buf = package.Buffer;
                int dlc;
                dlc = DecodeDlc(buf);
                //dlc = 8;
                List<byte> contentBytes = new List<byte>();

                string msgId = CutMsgId(buf);
                string msgData = CutMsgData(buf, ref contentBytes);
                string flowId = Function.GetMsgFlow(msgId);    //"1CECF456" -> PACKAGE_READY

                MsgManager msgManager = new MsgManager();

                canGridRich = msgManager.DecodeMsgData(flowId, contentBytes);
                canGridRich.Direction = this._Direction;
                canGridRich.Dlc = dlc;
                canGridRich.CreateTime = DateTime.Now;
                canGridRich.Id = msgId;
                canGridRich.MsgData = Function.AppendSpaceIn2Char(msgData, dlc);
                canGridRich.CreateTimestamp = canGridRich.CreateTime.ToString(KeyConst.TextFormat.Date);

                //时间增量
                if (Prj.Prj.ValueManager.PreMsgCreateTime.Year <= 2000) //说明该报文为第一条报文
                {
                    canGridRich.TimeIncrement = "0";
                }
                else
                {
                    TimeSpan span = canGridRich.CreateTime - Prj.Prj.ValueManager.PreMsgCreateTime;
                    canGridRich.TimeIncrement = span.Hours.ToString().PadLeft(2, '0') + KeyConst.Punctuation.Colon
                                        + span.Minutes.ToString().PadLeft(2, '0') + KeyConst.Punctuation.Colon
                                        + span.Seconds.ToString().PadLeft(2, '0') + KeyConst.Punctuation.Space
                                        + span.Milliseconds.ToString("f0");

                }
                Prj.Prj.ValueManager.PreMsgCreateTime = canGridRich.CreateTime;

                canGridRich.ConsistMsg.Dlc = dlc;
                canGridRich.ConsistMsg.CreateTimestamp = canGridRich.CreateTimestamp;

                Prj.Prj.CanMsgController.AddModel(canGridRich);//加入显示buffer
                Prj.Prj.CSVManager.AddModel(canGridRich);   //加入写CSV buffer

                canGridRich.ConsistMsg.ObjectNo = canGridRich.ObjectNo;

                Prj.Prj.RepositoryManager.AddToStocker(canGridRich);//加入写DB buffer
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private int DecodeDlc(List<byte> buf)
        {
            byte[] dlcs = BaseConvert.CutLists(buf, 9, 2);
            string str= BaseConvert.AsciiBytes2String(dlcs);
            int dlc = BaseConvert.HexStr2Int32(str);
            return dlc;
        }
        private string CutMsgId(List<byte> buf)
        {
            byte[] idBytes = BaseConvert.CutLists(buf, 9 + ConstCmd.FrameLen.DLC_LEN, 8);   //截取byte
            string msgId = BaseConvert.AsciiBytes2String(idBytes); //byte[]转string
            return msgId;
        }
        private string CutMsgData(List<byte> buf,ref List<byte> contentBytes)
        {
            contentBytes = BaseConvert.CutLists2Lists(buf, 17 + ConstCmd.FrameLen.DLC_LEN, 16);    //截取msg内容
            string msgData = BaseConvert.AsciiBytes2String(BaseConvert.CutLists(contentBytes, 0, 16));
            return msgData;
        }
    }
}
