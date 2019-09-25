using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Service
{
    public class Decode_ACInteropGet: DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            try
            {
                List<byte> buf = package.Buffer;
                List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.AC_INTEROP_GET);
                string[] arr = Function.SplitMsgData(content);
                int i = 0;
                GetACInterop data = new GetACInterop();
                data.BinaryStateX1X2 = DecodeState(arr[i++], arr[i++]);
                data.BinaryStateX3X4 = DecodeState(arr[i++], arr[i++]);

                Prj.Prj.GeneralController.RefreshUpdateACInterop(data);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private string DecodeState(string str1, string str2)
        {
            int num1 = Convert.ToInt32(str1, 16);
            int num2 = Convert.ToInt32(str2, 16);

            string bin = Convert.ToString(num1, 2).PadLeft(8, '0') + Convert.ToString(num2, 2).PadLeft(8, '0');
            return bin;
        }
    }
}
