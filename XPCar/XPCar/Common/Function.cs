using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using XPCar.Prj.Model;
using static XPCar.Common.KeyConst;

namespace XPCar.Common
{
    public class Function
    {
        public static string GetMsgFlow(string msgid)
        {
            string id = msgid.ToUpper().Trim();
            string flow;
            switch (id)
            {
                case "1826F456":
                    flow = KeyConst.CanMsgId.CHM;
                    break;
                case "182756F4":
                    flow = KeyConst.CanMsgId.BHM;
                    break;
                case "1801F456":
                    flow = KeyConst.CanMsgId.CRM;
                    break;
                case "1CEC56F4":
                    flow = KeyConst.CanMsgId.MUTI_PACKAGE_HEAD;
                    break;
                case "1CECF456":
                    flow = KeyConst.CanMsgId.MUTI_PACKAGE_READY;
                    break;
                case "1CEB56F4":
                    flow = KeyConst.CanMsgId.MUTI_PACKAGE_TEXT;
                    break;
                case "1808F456":
                    flow = KeyConst.CanMsgId.CML;
                    break;
                case "1807F456":
                    flow = KeyConst.CanMsgId.CTS;
                    break;
                case "100956F4":
                    flow = KeyConst.CanMsgId.BRO;
                    break;
                case "100AF456":
                    flow = KeyConst.CanMsgId.CRO;
                    break;
                case "181056F4":
                    flow = KeyConst.CanMsgId.BCL;
                    break;
                case "181356F4":
                    flow = KeyConst.CanMsgId.BSM;
                    break;
                case "1812F456":
                    flow = KeyConst.CanMsgId.CCS;
                    break;
                case "101956F4":
                    flow = KeyConst.CanMsgId.BST;
                    break;
                case "101AF456":
                    flow = KeyConst.CanMsgId.CST;
                    break;
                case "181C56F4":
                    flow = KeyConst.CanMsgId.BSD;
                    break;
                case "181DF456":
                    flow = KeyConst.CanMsgId.CSD;
                    break;
                case "081E56F4":
                    flow = KeyConst.CanMsgId.BEM;
                    break;
                case "081FF456":
                    flow = KeyConst.CanMsgId.CEM;
                    break;
                default:
                    flow = KeyConst.CanMsgId.UNDEFINED;
                    break;
            }
            return flow;
        }

        public static string AppendTextToMsgHead(string symbol, string item)
        {
            string headText = string.Empty;
            switch (symbol)
            {
                case KeyConst.CanMsgId.BHM:
                case KeyConst.CanMsgId.BCL:
                case KeyConst.CanMsgId.BCP:
                case KeyConst.CanMsgId.BCS:
                case KeyConst.CanMsgId.BEM:
                case KeyConst.CanMsgId.BMT:
                case KeyConst.CanMsgId.BMV:
                case KeyConst.CanMsgId.BRM:
                case KeyConst.CanMsgId.BRO:
                case KeyConst.CanMsgId.BSD:
                case KeyConst.CanMsgId.BSM:
                case KeyConst.CanMsgId.BSP:
                case KeyConst.CanMsgId.BST:
                    headText = KeyConst.Machine.Bms;
                    break;
                case KeyConst.CanMsgId.CCS:
                case KeyConst.CanMsgId.CEM:
                case KeyConst.CanMsgId.CHM:
                case KeyConst.CanMsgId.CML:
                case KeyConst.CanMsgId.CRM:
                case KeyConst.CanMsgId.CRO:
                case KeyConst.CanMsgId.CSD:
                case KeyConst.CanMsgId.CST:
                case KeyConst.CanMsgId.CTS:
                    headText = KeyConst.Machine.EQ;
                    break;
            }
            return headText + symbol + KeyConst.Punctuation.Colon+ item + KeyConst.Punctuation.Space;
        }
        public static bool CompareBytesEqual(byte[] bytes1, byte[] bytes2)
        {
            if (Enumerable.SequenceEqual(bytes1, bytes2))
                return true;
            else
                return false;
        }
        public static string AppendSpaceIn2Char(string src, int dlc)
        {
            StringBuilder sb = new StringBuilder();
            src = src.Substring(0, dlc * 2);
            for (int i = 0; i < src.Length; i += 2)
            {
                sb.Append(src.Substring(i, 2));
                sb.Append(" ");
            }
            return sb.ToString();
        }
        public static string GetSymbolByPgn(string pgn)
        {

            switch (pgn)
            {
                case KeyConst.PGN.BCP:
                    return KeyConst.CanMsgId.BCP;
                case KeyConst.PGN.BCS:
                    return KeyConst.CanMsgId.BCS;
                case KeyConst.PGN.BMV:
                    return KeyConst.CanMsgId.BMV;
                case KeyConst.PGN.BMT:
                    return KeyConst.CanMsgId.BMT;
                case KeyConst.PGN.BRM:
                    return KeyConst.CanMsgId.BRM;
                case KeyConst.PGN.BSP:
                    return KeyConst.CanMsgId.BSP;
                default:
                    return KeyConst.CanMsgId.UNDEFINED;
            }
        }
        public static string TextAddColonSpace(string testItem, string testResult)
        {
            return testItem + Punctuation.Colon + testResult + Punctuation.Space;
        }

        public static double ShrinkCntTimes(int num, int cnt)
        {
            double val = Convert.ToDouble(num);
            return val / cnt;
        }
        public static double KeepCntDecimalPlaces(double num, int cnt)
        {
            return Math.Round(num, cnt);
        }
        public static string DecodeCommonShrinkmKeepn(string[] strs, int shrink, int keep)
        {
            string text = "";
            foreach (string str in strs)
            {
                text += str;
            }
            int val = BaseConvert.HexStr2Int32(text);
            double shrinkV = Function.ShrinkCntTimes(val, shrink);
            double result = Function.KeepCntDecimalPlaces(shrinkV, keep);
            string format = "f" + keep.ToString();
            return result.ToString(format);
        }
        public static double Shrink10Keep1ByStr(string low, string high)
        {
            int volt = BaseConvert.HexStr2Int32(high + low);
            double shrinkV = Function.ShrinkCntTimes(volt, 10);
            double result = Function.KeepCntDecimalPlaces(shrinkV, 1);
            return result;
        }
        public static double Shrink100Keep2ByStr(string low, string high)
        {
            int volt = BaseConvert.HexStr2Int32(high + low);
            double shrinkV = Function.ShrinkCntTimes(volt, 100);
            double result = Function.KeepCntDecimalPlaces(shrinkV, 2);
            return result;
        }
        //public static string DecodeBatteryType(string content)
        //{
        //    string sType = content.Substring(8, 2);
        //    return GetBatteryType(sType);
        //}
        public static string GetBatteryType(string sType)
        {
            //string sType = total.Substring(8, 2);
            string bat = string.Empty;
            switch (sType)
            {
                case KeyConst.BatteryType.H01:
                    bat = "铅酸电池";
                    break;
                case KeyConst.BatteryType.H02:
                    bat = "镍氢电池";
                    break;
                case KeyConst.BatteryType.H03:
                    bat = "磷酸铁锂电池";
                    break;
                case KeyConst.BatteryType.H04:
                    bat = "锰酸锂电池";
                    break;
                case KeyConst.BatteryType.H05:
                    bat = "钴酸锂电池";
                    break;
                case KeyConst.BatteryType.H06:
                    bat = "三元材料电池";
                    break;
                case KeyConst.BatteryType.H07:
                    bat = "聚合物锂离子电池";
                    break;
                case KeyConst.BatteryType.H08:
                    bat = "钛酸锂电池";
                    break;
                case KeyConst.BatteryType.HFF:
                    bat = "其他电池";
                    break;
                default:
                    bat = "Undefined";
                    break;
            }
            return bat;
        }
        public static string[] SplitMsgData(List<byte> content)
        {
            string msgData = BaseConvert.AsciiBytes2String(content);
            List<string> strList = new List<string>();
            for (int i = 0; i < msgData.Length; i += 2)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(msgData[i]);
                sb.Append(msgData[i + 1]);
                strList.Add(sb.ToString());
            }
            return strList.ToArray();
        }
        public static string[] SplitMsgData(byte[] content)//add for 实时时间
        {
            string msgData = BaseConvert.AsciiBytes2String(content);
            List<string> strList = new List<string>();
            for (int i = 0; i < msgData.Length; i += 2)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(msgData[i]);
                sb.Append(msgData[i + 1]);
                strList.Add(sb.ToString());
            }
            return strList.ToArray();
        }
        public static double ShrinkKeepOffset(int num, int times, int keepCnt, int offset)
        {
            double shrink = ShrinkCntTimes(num, times);
            double keepV = KeepCntDecimalPlaces(shrink, keepCnt);
            double result = keepV - offset;
            return result;
        }
        public static string GetState(string bits, string val1, string val2, string val3)
        {
            if (bits == "00")
                return val1;
            else if (bits == "01")
                return val2;
            else
                return val3;

        }
        public static string MatchState(string bits, KeyConst.SPN.StateName spn)
        {
            switch (spn)
            {
                case SPN.StateName.SPN3090:
                case SPN.StateName.SPN3091:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.TooHigh, SPN.StateType.TooLow);                
                case SPN.StateName.SPN3092:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.OverCurrent, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3093:
                case SPN.StateName.SPN3512_9:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.TooHigh, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3094:
                case SPN.StateName.SPN3095:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.Abnormal, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3096:
                    return GetState(bits, SPN.StateType.Forbid, SPN.StateType.Permit, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3511_12:
                    return GetState(bits, SPN.StateType.NotAchievedSoc, SPN.StateType.AchievedSoc, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3511_34:
                    return GetState(bits, SPN.StateType.NotAchievedTotalVolt, SPN.StateType.AchievedTotalVolt, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3511_56:
                    return GetState(bits, SPN.StateType.NotAchievedSingleVolt, SPN.StateType.AchievedSingleVolt, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3511_78:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.ChargePaused, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3512_12:
                case SPN.StateName.SPN3512_34:
                case SPN.StateName.SPN3512_56:
                case SPN.StateName.SPN3512_78:
                case SPN.StateName.SPN3512_11:
                case SPN.StateName.SPN3512_13:
                case SPN.StateName.SPN3512_15:
                case SPN.StateName.SPN3522_11:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.Trouble, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3513_12:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.OverReq, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3513_34:
                case SPN.StateName.SPN3523_34:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.Unusual, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3521_12:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.AchievedConditionPaused, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3521_34:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.ManPaused, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3521_56:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.TroublePaused, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3521_78:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.BSTPaused, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3522_12:
                case SPN.StateName.SPN3522_56:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.OverTemp, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3522_34:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.Trouble, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3522_78:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.CannotTransfer, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3522_9:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.EmergencyStop, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3523_12:
                    return GetState(bits, SPN.StateType.Matched, SPN.StateType.Mismatched, SPN.StateType.Untrusted);
                case SPN.StateName.SPN3901:
                case SPN.StateName.SPN3902:
                case SPN.StateName.SPN3903:
                case SPN.StateName.SPN3904:
                case SPN.StateName.SPN3905:
                case SPN.StateName.SPN3906:
                case SPN.StateName.SPN3907:
                case SPN.StateName.SPN3921:
                case SPN.StateName.SPN3922:
                case SPN.StateName.SPN3923:
                case SPN.StateName.SPN3924:
                case SPN.StateName.SPN3925:
                case SPN.StateName.SPN3926:
                case SPN.StateName.SPN3927:
                    return GetState(bits, SPN.StateType.Normal, SPN.StateType.TimeOut, SPN.StateType.Untrusted);
                default:
                    return SPN.StateType.Undefined;

            }
        }
        public static string MatchStateText(string bits, KeyConst.MatchClass.StateName state)
        {
            switch (state)
            {
                case MatchClass.StateName.HighLow:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.TooHigh, MatchClass.StateType.TooLow);
                case MatchClass.StateName.OverI:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.OverCurrent, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.TooHigh:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.TooHigh, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.Abnormal:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.Abnormal, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.Permit:
                    return GetState(bits, MatchClass.StateType.Forbid, MatchClass.StateType.Permit, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.Achieved:
                    return GetState(bits, MatchClass.StateType.NotAchieved, MatchClass.StateType.Achieved, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.Pause:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.ChargePaused, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.Trouble:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.Trouble, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.ExceedingDemand:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.OverReq, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.Unusual:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.Unusual, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.AchievedConditionPaused:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.AchievedConditionPaused, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.ManPaused:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.ManPaused, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.TroublePaused:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.TroublePaused, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.BMSPaused:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.BmsPaused, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.HighTemp:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.OverTemp, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.EnergyTransfer:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.CannotTransfer, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.EmergencyStop:
                    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.EmergencyStop, MatchClass.StateType.Untrusted);
                case MatchClass.StateName.Mismatched:
                    return GetState(bits, MatchClass.StateType.Matched, MatchClass.StateType.Mismatched, MatchClass.StateType.Untrusted);
                //case SPN.StateName.SPN3521_78:
                //    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.BSTPaused, MatchClass.StateType.Untrusted);
                //case SPN.StateName.SPN3927:
                //    return GetState(bits, MatchClass.StateType.Normal, MatchClass.StateType.TimeOut, MatchClass.StateType.Untrusted);
                default:
                    return SPN.StateType.Undefined;

            }
        }
        public static DateTime StampToDatetime(string datetext)
        {
            string dateFormat = KeyConst.TextFormat.Date;
            DateTime dt = DateTime.ParseExact(datetext, dateFormat, System.Globalization.CultureInfo.CurrentCulture);
            return dt;
        }
        public static List<long> CalcInterval(List<ConsistMsg> lists)
        {
            List<long> intervalList = new List<long>();

            DateTime pre;
            DateTime next = DateTime.Now;
            if (lists != null && lists.Count != 0)
            {
                if (lists.Count == 1)
                {
                    intervalList.Add(0);
                    return intervalList;
                }
                else
                {
                    for (int i = 0; i < lists.Count; i++)
                    {
                        if (i == 0)
                        {
                            next = StampToDatetime(lists[i].CreateTimestamp);
                            continue;
                        }
                        else
                        {
                            pre = next;
                            next = StampToDatetime(lists[i].CreateTimestamp);
                            TimeSpan span = next.Subtract(pre);
                            long interval = (long)span.TotalMilliseconds;
                            if (interval <= 1000)
                                intervalList.Add(interval);
                        }
                    }
                }
                return intervalList;
            }
            return null;
        }
        public static long CalcIntervalByTwoPara(string stampActive, string stampPassive)
        {
            TimeSpan span = StampToDatetime(stampActive).Subtract(StampToDatetime(stampPassive));
            return (long)span.TotalMilliseconds;
        }
        public enum ConsistResult
        {
            Init,
            OK,
            NG,
            ERROR,
        }
        public static string AddSecondsToTimestamp(string time, int seconds)
        {
            DateTime dateTime = StampToDatetime(time);
            DateTime add = dateTime.AddSeconds(seconds);
            return add.ToString(KeyConst.TextFormat.Date);
        }
        public static string ReturnRegisterWarning(int ret)
        {
            string warning = "";
            if (ret == 0)
            {
                warning = "软件已注册！";
            }
            else if (ret == 1)
            {
                warning = "软件尚未注册，请注册软件！";
            }
            else if (ret == 2)
            {
                warning = "注册码与本机不一致,请联系管理员！";
            }
            else if (ret == 3)
            {
                warning = "软件试用已到期！";
            }
            else if (ret == 4)
            {
                warning = "请先注册软件！";
            }
            else
            {
                warning = "软件运行出错，请重新启动！";
            }
            return warning;
        }
        public static string RandomCodeReplaceBySpace(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append(' ');
                }
            }
            return sb.ToString();
        }

        public static string MapMsgIndex(double val)
        {
            switch (val)
            {
                case 1: return "BHM";
                case 2: return "CHM";
                case 3: return "BRM";
                case 4: return "CRM";
                case 5: return "BCP";
                case 6: return "BRO";
                case 7: return "CTS";
                case 8: return "CML";
                case 9: return "CRO";
                case 10: return "BCL";
                case 11: return "BCS";
                case 12: return "BSM";
                case 13: return "BST";
                case 14: return "CCS";
                case 15: return "CST";
                case 16: return "BSD";
                case 17: return "CSD";
                case 18: return "BEM";
                case 19: return "CEM";
                case 20: return "BSP";
                case 21: return "BMT";
                case 22: return "BMV";
                default: return "";
            }
        }
        public static int MapMsgName(string name)
        {
            switch (name)
            {
                case "BHM": return 1;
                case "CHM": return 2;
                case "BRM": return 3;
                case "CRM": return 4;
                case "BCP": return 5;
                case "BRO": return 6;
                case "CTS": return 7;
                case "CML": return 8;
                case "CRO": return 9;
                case "BCL": return 10;
                case "BCS": return 11;
                case "BSM": return 12;
                case "BST": return 13;
                case "CCS": return 14;
                case "CST": return 15;
                case "BSD": return 16;
                case "CSD": return 17;
                case "BEM": return 18;
                case "CEM": return 19;
                case "BSP": return 20;
                case "BMT": return 21;
                case "BMV": return 22;
                default:    return 0;
            }
        }
        public static Color MapMsgColor(double val)
        {
            switch (val + 1)
            {
                case 1: return Color.Blue;
                case 2: return Color.Red;
                case 3: return Color.Green;
                case 4: return Color.Cyan;
                case 5: return Color.Yellow;
                case 6: return Color.DarkBlue;
                case 7: return Color.Coral;
                case 8: return Color.Lime;
                case 9: return Color.Purple;
                case 10: return Color.Olive;
                case 11: return Color.DarkSeaGreen;
                case 12: return Color.DarkSlateBlue;
                case 13: return Color.DarkTurquoise;
                case 14: return Color.DeepPink;
                case 15: return Color.GreenYellow;
                case 16: return Color.Orchid;
                case 17: return Color.Sienna;
                case 18: return Color.SlateGray;
                case 19: return Color.Thistle;
                case 20: return Color.LightSalmon;
                case 21: return Color.LightSeaGreen;
                case 22: return Color.LightSkyBlue;
                default: return Color.White;
            }
        }

        public static string MapDatetime(double val)
        {
            long ticks = (long)val;
            DateTime date = new DateTime(2000, 1, 1, 0, 0, 0, 0).AddMilliseconds(ticks);
            string hour = date.Hour.ToString().PadLeft(2, '0');
            string minute = date.Minute.ToString().PadLeft(2, '0');
            string second = date.Second.ToString().PadLeft(2, '0');
            string ms = date.Millisecond.ToString().PadLeft(3, '0');
            return hour + KeyConst.Punctuation.Colon + minute + KeyConst.Punctuation.Colon + second + "." + ms;
                
        }
    }

}
