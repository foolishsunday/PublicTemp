using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCar.Common
{
    public class KeyConst
    {
        public class SkinConfig
        {
            public const string Skin = @"\..\Config\Skins\XPSilver.ssk";
        }
        public class Punctuation
        {
            public const string Space = " ";
            public const string Colon = ":";
        }
        public class Machine
        {
            public const string EQ = "充电机报文";
            //public const string Car = "车辆报文";
            public const string Bms = "BMS报文";
        }
        public class CanMsgId
        {
            public const string CHM = "CHM";
            public const string BHM = "BHM";
            public const string CRM = "CRM";
            public const string BRM = "BRM";
            public const string BCP = "BCP";

            public const string CML = "CML";
            public const string CTS = "CTS";
            public const string BRO = "BRO";
            public const string CRO = "CRO";
            public const string BCL = "BCL";

            public const string BCS = "BCS";
            public const string BMV = "BMV";
            public const string BSM = "BSM";
            public const string CCS = "CCS";
            public const string BST = "BST";

            public const string CST = "CST";
            public const string BSD = "BSD";
            public const string CSD = "CSD";
            public const string BEM = "BEM";
            public const string CEM = "CEM";

            public const string BMT = "BMT";
            public const string BSP = "BSP";

            public const string MUTI_PACKAGE_HEAD = "MUTI_PACKAGE_HEAD";
            public const string MUTI_PACKAGE_READY = "MUTI_PACKAGE_READY";
            public const string MUTI_PACKAGE_TEXT = "MUTI_PACKAGE_TEXT";

            public const string UNDEFINED = "UNDEFINED";
        }

        public class PGN
        {
            public const string BRM = "02";
            public const string BCS = "11";
            public const string BMV = "15";
            public const string BMT = "16";
            public const string BCP = "06";
            public const string BSP = "17";
        }

        public class TextFormat
        {
            public const string Date = "yyyyMMdd HH:mm:ss fff";

        }
        public class MdiText_Common
        {
            public const string Illegal = "输入的数值不合法！请输入正确的数值！";
        }
        public class MdiText_Calc
        {
            public const string Calculating = "计算中...";
            public const string CalcFinish = "计算完成";
        }

        public class BatteryType
        {
            public const string H01 = "01";
            public const string H02 = "02";
            public const string H03 = "03";
            public const string H04 = "04";
            public const string H05 = "05";
            public const string H06 = "06";
            public const string H07 = "07";
            public const string H08 = "08";
            public const string HFF = "FF";
        }

        public class SPN
        {
            public enum StateName
            {
                SPN3090,
                SPN3091,
                SPN3092,
                SPN3093,
                SPN3094,
                SPN3095,
                SPN3096,

                SPN3511_12,
                SPN3511_34,
                SPN3511_56,
                SPN3511_78,

                SPN3512_12,
                SPN3512_34,
                SPN3512_56,
                SPN3512_78,
                SPN3512_9,
                SPN3512_11,
                SPN3512_13,
                SPN3512_15,

                SPN3513_12,
                SPN3513_34,

                SPN3521_12,
                SPN3521_34,
                SPN3521_56,
                SPN3521_78,

                SPN3522_12,
                SPN3522_34,
                SPN3522_56,
                SPN3522_78,
                SPN3522_9,
                SPN3522_11,

                SPN3523_12,
                SPN3523_34,

                SPN3901,
                SPN3902,
                SPN3903,
                SPN3904,
                SPN3905,
                SPN3906,
                SPN3907,

                SPN3921,
                SPN3922,
                SPN3923,
                SPN3924,
                SPN3925,
                SPN3926,
                SPN3927
            }
            public class StateType
            {
                public const string Normal = "正常";
                public const string TooHigh = "过高";
                public const string TooLow = "过低";
                public const string OverCurrent = "过流";
                public const string OverTemp = "过温";
                public const string TimeOut = "超时";
                public const string Untrusted = "不可信状态";
                public const string Forbid = "禁止";
                public const string Permit = "允许";

                public const string Abnormal = "不正常";
                public const string Undefined = "Undefined SPN";

                public const string NotAchievedSoc = "未达到所需SOC目标值";
                public const string AchievedSoc = "达到所需SOC目标值";

                public const string NotAchievedTotalVolt = "未达到总电压设定值";
                public const string AchievedTotalVolt = "达到总电压设定值";

                public const string NotAchievedSingleVolt = "未达到单体电压的设定值";
                public const string AchievedSingleVolt = "达到单体电压的设定值";

                public const string AchievedConditionPaused = "达到充电机设定条件中止";

                public const string ChargePaused = "充电机中止(收到CST帧)";

                public const string Trouble = "故障";
                public const string OverReq = "超过需求值";
                public const string Unusual = "异常";

                public const string Paused = "中止";
                public const string ManPaused = "人工中止";
                public const string TroublePaused = "故障中止";
                public const string BSTPaused = "故障中止(收到BST帧)";
                public const string BmsPaused = "BMS主动中止";
                public const string CannotTransfer = "不能传送";
                public const string EmergencyStop = "急停";

                public const string Matched = "匹配";
                public const string Mismatched = "不匹配";
            }
            public enum SPN2560
            {
                Recognized,
                Unrecognized
            }
            public enum SPN2829
            {
                BeReady,
                NotReady,
                Invalid
            }
            public enum SPN3929
            {
                Permit,
                Pause
            }
        }
        public class MatchClass
        {
            public enum StateName
            {
                HighLow,
                OverI,
                TooHigh,
                Abnormal,
                Permit,
                Achieved,
                Pause,
                Trouble,
                ExceedingDemand,
                Unusual,
                AchievedConditionPaused,
                ManPaused,
                TroublePaused,
                BMSPaused,
                HighTemp,
                EnergyTransfer,
                EmergencyStop,
                Mismatched
            }
            public class StateType
            {
                public const string Normal = "正常";
                public const string TooHigh = "过高";
                public const string TooLow = "过低";
                public const string OverCurrent = "过流";
                public const string OverTemp = "过温";
                public const string TimeOut = "超时";
                public const string Untrusted = "不可信状态";
                public const string Forbid = "禁止";
                public const string Permit = "允许";

                public const string Abnormal = "不正常";
                public const string Undefined = "Undefined SPN";

                public const string NotAchievedSoc = "未达到所需SOC目标值";
                public const string AchievedSoc = "达到所需SOC目标值";

                public const string NotAchievedTotalVolt = "未达到总电压设定值";
                public const string AchievedTotalVolt = "达到总电压设定值";

                public const string NotAchievedSingleVolt = "未达到单体电压的设定值";
                public const string AchievedSingleVolt = "达到单体电压的设定值";

                public const string NotAchieved = "未达到";
                public const string Achieved = "达到";

                public const string AchievedConditionPaused = "达到充电机设定条件中止";

                public const string ChargePaused = "充电机中止(收到CST帧)";

                public const string Trouble = "故障";
                public const string OverReq = "超过需求值";
                public const string Unusual = "异常";

                public const string Paused = "中止";
                public const string ManPaused = "人工中止";
                public const string TroublePaused = "故障中止";
                public const string BSTPaused = "故障中止(收到BST帧)";
                public const string BmsPaused = "BMS主动中止";
                public const string CannotTransfer = "不能传送";
                public const string EmergencyStop = "急停";

                public const string Matched = "匹配";
                public const string Mismatched = "不匹配";
            }
        }
        public class SwitchSource
        {
            public enum Source
            {
                Light,
                Total,
                Moment
            }
        }
        public class HeaderText
        {
            public const string OBJECT_NO = "帧序号";
            public const string DIRECTION = "收发标志";
            public const string CREATE_TIME = "接收时间";
            public const string TIME_INCREMENT = "时间增量";//add for 时间增量
            public const string MSG_ID = "帧ID";
            public const string DLC = "DLC";
            public const string MSG_DATA = "数据";
            public const string MSG_TEXT = "BMS报文翻译";

            public const string INTEROP_NO = "序号";
            public const string INTEROP_NAME = "测试项目";
            public const string INTEROP_PURPOSE = "测试目的";
            public const string INTEROP_STEP = "测试步骤";
            public const string INTEROP_JUDGE = "合格评判";

            public const string MSG_NAME = "报文名称";
            public const string MSG_COUNT = "报文总数";
            public const string MIN_INTERVAL = "最小间隔(ms)";
            public const string MAX_INTERVAL = "最大间隔(ms)";
            public const string AVG_INTERVAL = "平均间隔(ms)";
            public const string BeginDate = "开始时间";
            public const string EndDate = "结束时间";

            public const string CURVE_CHARGE_V = "充电电压(1V/div)";
            public const string CURVE_CHARGE_I = "充电电流(0.3A/div)";
            public const string CURVE_CC1 = "CC1电压(0.3V/div)";
            public const string CURVE_CC2 = "CC2电压(0.3V/div)";
            public const string CURVE_ASSIST = "辅源电压(0.3V/div)";
        }



        public class Consist
        {
            public class ItemId
            {
                //public const string BP1001 = "BP1001";
                //public const string BP1002 = "BP1002";
                //public const string BP1003 = "BP1003";

                //public const string BN1001 = "BN1001";
                //public const string BN1002 = "BN1002";
                //public const string BN1003 = "BN1003";
                //public const string BN1004 = "BN1004";
                //public const string BN1005 = "BN1005";
                //public const string BN1006 = "BN1006";
                //public const string BN1007 = "BN1007";
                //public const string BN1008 = "BN1008";
                //public const string BN1009 = "BN1009";
                //public const string BN1010 = "BN1010";
                //public const string BP2001 = "BP2001";
                //public const string BP2002 = "BP2002";
                //public const string BP2003 = "BP2003";
                //public const string BN2001 = "BN2001";
                //public const string BN2002 = "BN2002";
                //public const string BN2003 = "BN2003";
                //public const string BN2004 = "BN2004";
                //public const string BN2005 = "BN2005";
                //public const string BN2006 = "BN2006";
                //public const string BN2007 = "BN2007";
                //public const string BP3001 = "BP3001";
                //public const string BP3002 = "BP3002";
                //public const string BP3003 = "BP3003";
                //public const string BP3004 = "BP3004";
                //public const string BP3005 = "BP3005";
                //public const string BN3001 = "BN3001";
                //public const string BN3002 = "BN3002";
                //public const string BN3003 = "BN3003";
                //public const string BN3004 = "BN3004";
                //public const string BN3005 = "BN3005";
                //public const string BN3006 = "BN3006";
                //public const string BN3007 = "BN3007";
                //public const string BN3008 = "BN3008";
                //public const string BP4001 = "BP4001";
                //public const string BP4002 = "BP4002";
                //public const string BP4003 = "BP4003";
                //public const string BN4001 = "BN4001";
                //public const string BN4002 = "BN4002";
                //public const string BN4003 = "BN4003";

                public const string DP1001 = "DP1001";
                public const string DP1002 = "DP1002";
                public const string DP1003 = "DP1003";
                public const string DN1001 = "DN1001";
                public const string DN1002 = "DN1002";
                public const string DN1003 = "DN1003";
                public const string DN1004 = "DN1004";
                public const string DP2001 = "DP2001";
                public const string DP2002 = "DP2002";
                public const string DP2003 = "DP2003";
                public const string DN2001 = "DN2001";
                public const string DN2002 = "DN2002";
                public const string DN2003 = "DN2003";
                public const string DN2004 = "DN2004";
                public const string DN2005 = "DN2005";
                public const string DN2006 = "DN2006";
                public const string DN2007 = "DN2007";
                public const string DN2008 = "DN2008";
                public const string DN2009 = "DN2009";
                public const string DN2010 = "DN2010";
                public const string DP3001 = "DP3001";
                public const string DP3002 = "DP3002";
                public const string DP3003 = "DP3003";
                public const string DP3004 = "DP3004";
                public const string DP3005 = "DP3005";
                public const string DP3006 = "DP3006";
                public const string DP3007 = "DP3007";
                public const string DN3001 = "DN3001";
                public const string DN3002 = "DN3002";
                public const string DN3003 = "DN3003";
                public const string DN3004 = "DN3004";
                public const string DN3005 = "DN3005";
                public const string DN3006 = "DN3006";
                public const string DN3007 = "DN3007";
                public const string DN3008 = "DN3008";
                public const string DN3009 = "DN3009";
                public const string DN3010 = "DN3010";
                public const string DP4001 = "DP4001";
                public const string DP4002 = "DP4002";
                public const string DN4001 = "DN4001";
                public const string DN4002 = "DN4002";
                public const string DN4003 = "DN4003";
                public const string DN4004 = "DN4004";
            }
            public class TestItemName
            {
                public const string Format = "报文格式";
                public const string Length = "长度";
                public const string Content = "内容";
                public const string Period = "周期";
                public const string Interval = "间隔";
                public const string MaxInterval = "最大间隔";
                public const string MinInterval = "最小间隔";
            }
            public class Result
            {
                public const string Qualified = "合格";
                public const string Unqualified = "不合格";
            }
            public class TimeError
            {
                public const int Std1s_Positive200ms = 200;
                public const int Std5s_Positive500ms = 500;
                public const int Std10s_Positive3000ms = 3000;
                public const int Std10ms_PositiveNegative3ms = 3;
                public const double Std50ms_PositiveNegative10Per = 0.1;

                public const long Std250ms_PositiveNegative = 25;
            }

        }
        public class HexState
        {
            public const string READY = "AA";
            public const string UNREADY = "00";
            public const string INVALID = "55";
        }
        public class TimeToSend
        {
            public enum Page
            {
                BaseInfo,
                Alarm,
                Handshake,
                ChargeParaGet,
                ChargingGet,
                ChargeStop,
                DCGet,
                ACGet,
                ACInterop,
                VersionGet
            }
        }
        public class ACTest
        {
            public enum Gun
            {
                Single,
                Dual
            }
        }
        public class WavePara
        {
            public const int CurveCnt = 23;
            public const int LineCnt = 5;
        }
        public class WinLabel
        {
            public const string ST9980AP = "充电桩测试系统ST-9980A+";
            public const string ST9980A = "充电桩测试系统ST-9980A";
            public const string ST9980AP_AC = "充电桩交流测试系统";
            public const string ST990 = "充电桩交流测试系统ST-990";
        }

        //传输协议功能的状态：同意并准备接收，完成接收，拒绝接收
        public enum TransitState
        {
            Ready,
            Finish,
            Reject
        }
    }
}
