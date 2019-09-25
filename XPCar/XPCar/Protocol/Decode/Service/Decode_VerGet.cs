using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Prj.Model;
namespace XPCar.Protocol.Decode.Service
{
    public class Decode_VerGet : DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            try
            {
                List<byte> buf = package.Buffer;

                List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.VER_GET);
                string[] arr = Function.SplitMsgData(content);

                //下位机软件版本号
                int i = 0;
                string version = DecodeVersion(arr[i++], arr[i++], arr[i++]);
                string year = DecodeYear(arr[i++], arr[i++]);
                string month = DecodeCommonHex(arr[i++]);
                string day = DecodeCommonHex(arr[i++]);
                string flowNo = DecodeCommonHex(arr[i++]);

                string verTotal = "V" + version + " " + year + month + day;

                Prj.Prj.GeneralController.RefreshUpdateVersion(verTotal, flowNo);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private string DecodeVersion(string s1, string s2, string s3)
        {
            string left = BaseConvert.HexStr2Int32(s1).ToString();
            string middle = BaseConvert.HexStr2Int32(s2).ToString();
            string right = BaseConvert.HexStr2Int32(s3).ToString();

            return left + "." + middle + right;
        }
        private string DecodeYear(string high, string low)
        {
            return BaseConvert.HexStr2Int32(high + low).ToString();
        }
        private string DecodeCommonHex(string text)
        {
            return BaseConvert.HexStr2Int32(text).ToString().PadLeft(2,'0');
        }
        
    }
}
