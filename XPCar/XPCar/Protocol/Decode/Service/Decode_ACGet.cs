using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Prj.Model;
namespace XPCar.Protocol.Decode.Service
{
    public class Decode_ACGet : DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            try
            {
                List<byte> buf = package.Buffer;
                List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.AC_GET);
                string[] arr = Function.SplitMsgData(content);
                int i = 0;
                 
                GetAC data = new GetAC();
                data.A_APhaseV = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.A_BPhaseV = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.A_CPhaseV = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.A_APhaseI = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.A_BPhaseI = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.A_CPhaseI = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);

                data.A_ChargeP = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);
                data.A_ChargeQuantity = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);
                data.A_DutyCycle = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);
                data.A_CPVolt = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);

                string[] strsFrq = new string[] { arr[i++], arr[i++], arr[i++], arr[i++] };
                data.A_Frequency = Function.DecodeCommonShrinkmKeepn(strsFrq, 100, 2);

                string[] strsRes = new string[] { arr[i++], arr[i++], arr[i++], arr[i++] };
                data.A_CCRes = Function.DecodeCommonShrinkmKeepn(strsRes, 100, 2);

                data.A_PermitI = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);
                data.A_RatedI = DecodeValue(arr[i++], arr[i++]);
                data.A_GunTemp = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);
                data.A_ConnState = DecodeGunConnState(arr[i++]);
                data.A_SysState = DecodeSysState(arr[i++]);

                /****************************************************************/
                data.B_APhaseV = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.B_BPhaseV = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.B_CPhaseV = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.B_APhaseI = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.B_BPhaseI = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.B_CPhaseI = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);

                data.B_ChargeP = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);
                data.B_ChargeQuantity = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);
                data.B_DutyCycle = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);
                data.B_CPVolt = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);

                strsFrq = new string[] { arr[i++], arr[i++], arr[i++], arr[i++] };
                data.B_Frequency = Function.DecodeCommonShrinkmKeepn(strsFrq, 100, 2);

                strsRes = new string[] { arr[i++], arr[i++], arr[i++], arr[i++] };
                data.B_CCRes = Function.DecodeCommonShrinkmKeepn(strsRes, 100, 2);

                data.B_PermitI = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);
                data.B_RatedI = DecodeValue(arr[i++], arr[i++]);
                data.B_GunTemp = DecodeCommonShrink100Keep2(arr[i++], arr[i++]);
                data.B_ConnState = DecodeGunConnState(arr[i++]);
                data.B_SysState = DecodeSysState(arr[i++]);

                Prj.Prj.GeneralController.RefreshUpdateAC(data);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private string DecodeValue(string high, string low)
        {
            int val = BaseConvert.HexStr2Int32(high + low);
            return val.ToString();
        }
        private string DecodeCommonShrink10Keep1(string high, string low)
        {
            double result = Function.Shrink10Keep1ByStr(low, high);
            return result.ToString("f1");
        }
        private string DecodeCommonShrink100Keep2(string high, string low)
        {
            double result = Function.Shrink100Keep2ByStr(low, high);
            return result.ToString("f2");
        }
        private string DecodeGunConnState(string state)
        {
            if (state == "01")
                return "已连接";
            else
                return "未连接";
        }
        private string DecodeSysState(string state)
        {
            switch (state.ToUpper())
            {
                case "00":
                    return "充电过压";
                case "01":
                    return "充电欠压";
                case "02":
                    return "充电过流";
                case "03":
                    return "系统待机中";
                case "04":
                    return "系统充电中";
                case "05":
                    return "24V故障";
                case "06":
                    return "连接超时";
                case "07":
                    return "电表故障";
                case "08":
                    return "A相过压";
                case "09":
                    return "B相过压";
                case "0A":
                    return "C相过压";
                case "0B":
                    return "A相过流";
                case "0C":
                    return "B相过流";
                case "0D":
                    return "C相过流";
                case "0E":
                    return "温度故障";
                case "10":
                    return "急停";
                case "11":
                    return "A枪CC电阻异常";
                case "12":
                    return "B枪CC电阻异常";
                default:
                    return "Undefined";

            }
        }
    }
}

