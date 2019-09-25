using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Service
{
    public class Deocde_ChargeParaGet : DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            try
            {
                List<byte> buf = package.Buffer;
                List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.CHARGE_PARA_GET);
                string[] arr = Function.SplitMsgData(content);
                int i = 0;

                GetChargePara data = new GetChargePara();
                data.DateYear = DecodeCommon2Byte(arr[i++], arr[i++]);
                data.DateMonth = DecodeCommon1Byte(arr[i++]);
                data.DateDay = DecodeCommon1Byte(arr[i++]);
                data.DateHour = DecodeCommon1Byte(arr[i++]);
                data.DateMinute = DecodeCommon1Byte(arr[i++]);
                data.DateSecond = DecodeCommon1Byte(arr[i++]);
                data.ReqSync = DecodeReqSync(arr[i++]);
                data.MaxOutputV = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.MinOutputV = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.MaxOutputI = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.MinOutputI = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.ReadyState = DecodeReady(arr[i++]);
                Prj.Prj.GeneralController.RefreshChargePara(data);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private string DecodeCommon2Byte(string high, string low)
        {
            int val = BaseConvert.HexStr2Int32(high + low);
            return val.ToString();
        }
        private string DecodeCommon1Byte(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            return val.ToString();
        }
        private string DecodeReqSync(string str)
        {
            if (str == "01")
                return "是";
            else
                return "否";
        }

        private string DecodeCommonShrink10Keep1(string high, string low)
        {
            double result = Function.Shrink10Keep1ByStr(low, high);
            return result.ToString("f1");
        }
  
        private string DecodeReady(string arr)
        {
            if (arr.ToUpper() == "AA")
            {
                return "准备就绪";
            }
            else if (arr == "00")
                return "未准备就绪";
            else
                return "无效";
        }

    }
}
