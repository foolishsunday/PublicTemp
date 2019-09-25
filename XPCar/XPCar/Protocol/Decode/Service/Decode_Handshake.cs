using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Service
{
    public class Decode_Handshake : DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            try
            {
                List<byte> buf = package.Buffer;
                List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.HANDSHAKE_GET);
                string[] arr = Function.SplitMsgData(content);
                int i = 0;

                GetHandShake data = new GetHandShake();
                data.Version = DecodeVersion(arr[i++], arr[i++], arr[i++]);
                data.RecognizedResult = DecodeRecognizedResult(arr[i++]);
                data.EQNum = DecodeEqNum(arr[i++], arr[i++], arr[i++], arr[i++]);
                data.Area = DecodeArea(arr[i++], arr[i++], arr[i++]);

                Prj.Prj.GeneralController.RefreshHandshake(data);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private int DecodePeriod(string high, string low)
        {
            int result = BaseConvert.HexStr2Int32(high + low);
            return result;
        }
        private string DecodeVersion(string verH, string verL_FF00, string verL_00FF)
        {
            int high = Convert.ToInt32(verH, 16);

            string verL = verL_FF00.TrimStart('0') + verL_00FF.TrimStart('0');
            int low = Convert.ToInt32(verL, 16);

            string ver = "V" + high.ToString() + "." + low.ToString();
            return ver;
        }
        private string DecodeRecognizedResult(string arr)
        {
            if (arr.ToUpper() == "AA")
                return "辨识成功";
            else
                return "未辨识";
        }
        private string DecodeEqNum(string s1, string s2, string s3, string s4)
        {
            //uint val = Convert.ToUInt32(s4 + s3 + s2 + s1, 16) + 1;
            string text = s1 + s2 + s3 + s4;
            uint eqnum = Convert.ToUInt32(text, 16);
            return eqnum.ToString();
        }
        private string DecodeArea(string s1, string s2, string s3)
        {
            string area = BaseConvert.HexString2AsciiString(s1)
                + BaseConvert.HexString2AsciiString(s2)
                + BaseConvert.HexString2AsciiString(s3);

            area = Function.RandomCodeReplaceBySpace(area);
            return area;
        }
    }
}
