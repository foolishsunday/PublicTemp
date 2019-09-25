using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolChargingSet : EncodeProtocol
    {
        public EncodeProtocolChargingSet(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolChargingSet()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.CHARGING_SET);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];
        }
        public bool AddContent(SettingCharging data)
        {
            try
            {
                bool isSuccess = true;
                //X1-X2 电压需求
                isSuccess &= this.EncodeCommonStrMultiply10(data.ReqV);

                //X3-X4 电流需求
                isSuccess &= this.EncodeCommonStrMultiply10(data.ReqI);

                //X5 充电模式
                isSuccess &= this.EncodeCommon1HexStr(data.ChargeMode);

                //X6-X7 BCL报文周期
                isSuccess &= this.EncodeCommon2HexStr(data.BCLPeriod);

                //X8-X9 充电电压测量值
                isSuccess &= this.EncodeCommonStrMultiply10(data.MeasureV);

                //X10-X11 充电电流测量值
                isSuccess &= this.EncodeCommonStrMultiply10(data.MeasureI);

                //X12-X13 最高单体电池电压及组号
                isSuccess &= this.EncodeMaxSingleBatV_Num(data.MaxSingleBatV,data.MaxSingleBatGrpNum);

                //X14 当前荷电状态
                isSuccess &= this.EncodeCurSoc(data.CurSOC);

                //X15-X16 估算剩余充电时间
                isSuccess &= this.EncodeCommonStrMultiply10(data.RemainTime);

                //X17-X18 BCS报文周期
                isSuccess &= EncodeCommon2HexStr(data.BCSPeriod);

                //X19 单体最高电压编号
                isSuccess &= EncodeCommonMinus(data.MaxSingleBatVNum);

                //X20 最高电池温度
                isSuccess &= EncodeCommonPlus50(data.MaxBatTemp);

                //X21 最高温度编号
                isSuccess &= EncodeCommonMinus(data.MaxTempDetectionNum);

                //X22 最低电池温度
                isSuccess &= EncodeCommonPlus50(data.MinBatTemp);

                //X23 最低温度编号
                isSuccess &= EncodeCommonMinus(data.MinTempDetectionNum);

                //X24-X25 相关状态
                isSuccess &= EncodeState(data.BitStateSingleV,
                            data.BitStateSOC,
                            data.BitStateOverI,
                            data.BitStateOverTemp);

                isSuccess &= EncodeState(data.BitStateInsulate,
                                            data.BitStateConnState,
                                            data.BitStateChargePermit,
                                            "00");

                //X26-X27 BSM报文周期
                isSuccess &= EncodeCommon2HexStr(data.BSMPeriod);

                //X28 终止充电原因
                isSuccess &= EncodeState(data.AchievedSOC,
                                        data.AchievedTotalV,
                                        data.AchievedSingleV,
                                        data.BmsPause);


                //X29 BMS终止充电故障原因
                isSuccess &= EncodeState(data.BatOverTempTrouble,
                        data.RelayTrouble,
                        data.Detection2Trouble,
                        data.OtherTrouble);
                //X30 
                isSuccess &= EncodeState(data.InsulateTrouble,
                        data.OutputConnTrouble,
                        data.BmsConnTempTrouble,
                        data.ChargeConnTrouble);

                //X31 BMS终止充电错误原因
                isSuccess &= EncodeState(data.OverIError, 
                        data.UnusualVError, 
                        "00", 
                        "00");

                //X32-X33 BST报文周期
                isSuccess &= EncodeCommon2HexStr(data.BSTPeriod);

                return isSuccess;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }

        private bool EncodeMaxSingleBatV_Num(string v, string n)
        {
            try
            {
                int volt =(int)(Convert.ToDouble(v)*100);
                int num = Convert.ToInt32(n);

                num = num << 12;
                int total = volt + num;
                EncodeCommonIntUse2Byte(total);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeCurSoc(string str)
        {
            try
            {
                int volt = Convert.ToInt32(str);
                return EncodeCommon1Int(volt);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeCommonMinus(string str)
        {
            try
            {
                int volt = Convert.ToInt32(str) - 1;
                return EncodeCommon1Int(volt);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeCommonPlus50(string str)
        {
            try
            {
                int volt = Convert.ToInt32(str) + 50;
                return EncodeCommon1Int(volt);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }

        private bool EncodeState(string bits1, string bits2, string bits3, string bits4)
        {
            try
            {
                string bits = bits4 + bits3 + bits2 + bits1;
                int num = Convert.ToInt32(bits, 2);
                return EncodeCommon1Int(num);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
    }
}
