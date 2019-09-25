using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Service
{
    public class Decode_ChargeStopGet : DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            try
            {
                List<byte> buf = package.Buffer;
                List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.CHARGE_STOP_GET);
                string[] arr = Function.SplitMsgData(content);
                GetChargeStop data = new GetChargeStop();
                int i = 0;

                data.ChargeTime = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.Energy = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.EqNum = DecodeEqNum(arr[i++], arr[i++], arr[i++], arr[i++]);

                Prj.Prj.GeneralController.RefreshChargeStop(data);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private string DecodeCommonShrink100Keep2(string high, string low)
        {
            double result = Function.Shrink100Keep2ByStr(low, high);
            return result.ToString("f2");
        }
        private string DecodeCommonShrink10Keep1(string high, string low)
        {
            int result = BaseConvert.HexStr2Int32(high + low);
            return result.ToString("f1");
        }
        private string DecodeEqNum(string s1, string s2, string s3, string s4)
        {
            string hex = s1 + s2 + s3 + s4;
            int num = BaseConvert.HexStr2Int32(hex);
            return num.ToString();
        }
    }
}
