using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Prj.Model;
namespace XPCar.Protocol.Decode.Service
{
    public class Decode_DCGet : DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            try
            {
                List<byte> buf = package.Buffer;
                List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.DC_GET);
                string[] arr = Function.SplitMsgData(content);
                int i = 0;

                SettingDC data = new SettingDC();
                data.RValue = DecodeRValue(arr[i++], arr[i++]);
                data.BatVolt = DecodeBatVolt(arr[i++], arr[i++]);
                data.BinaryState = DecodeState(arr[i++], arr[i++], arr[i++], arr[i++]);
                Prj.Prj.GeneralController.RefreshInteropCtrl(data);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private int DecodeRValue(string high, string low)
        {
            int val = BaseConvert.HexStr2Int32(high + low);
            return val;
        }
        private double DecodeBatVolt(string high, string low)
        {
            double num = Function.Shrink10Keep1ByStr(low, high);
            return num;
        }
        private string DecodeState(string str1, string str2, string str3, string str4)
        {
            int num1 = Convert.ToInt32(str1, 16);
            int num2 = Convert.ToInt32(str2, 16);
            int num3 = Convert.ToInt32(str3, 16);
            int num4 = Convert.ToInt32(str4, 16);

            string bin = Convert.ToString(num1, 2).PadLeft(8, '0')
                        + Convert.ToString(num2, 2).PadLeft(8, '0')
                        + Convert.ToString(num3, 2).PadLeft(8, '0')
                        + Convert.ToString(num4, 2).PadLeft(8, '0');
            return bin;
        }
    }
}
