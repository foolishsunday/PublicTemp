using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;

namespace XPCar.Protocol
{
    public static class ProtocolHelper
    {
      
        public static byte[] CalCheckSum(List<byte> lists, ref byte check1, ref byte check2)
        {

            int sum = 0;
            foreach (byte b in lists)
            {
                sum += b;
            }
            string temp = Convert.ToString(sum, 2);
            temp = temp.Replace('1', '-').Replace('0', '1').Replace('-', '0');//按位取反

            int plus = Convert.ToInt32(temp, 2) + 1;
            plus = plus & 0xff;
            int low = plus & 0x0f;
            int high = (plus & 0xf0) >> 4;

            string sLow = Convert.ToString(low, 16).ToUpper();  //0x0d -> "0x0D"
            string sHigh = Convert.ToString(high, 16).ToUpper();

            byte[] ascii1 = Encoding.ASCII.GetBytes(sHigh);     //"0x0D" -> 0x44
            byte[] ascii2 = Encoding.ASCII.GetBytes(sLow);

            check1 = ascii1[0];
            check2 = ascii2[0];
            return new byte[] { ascii1[0], ascii2[0] };
        }

        public static bool CheckSum(List<byte> lists)
        {
            int len = lists.Count;
            if (len <= 2)
                return false;


            byte code1 = lists[len - 2];
            byte code2 = lists[len - 1];
            List<byte> buf = new List<byte>();
            buf = BaseConvert.CutLists2Lists(lists, 0, len - 2);
            byte standard1 = 0;
            byte standard2 = 0;
            CalCheckSum(buf, ref standard1, ref standard2);
            if (standard1 == code1 && standard2 == code2) return true;

            return false;
        }

        //全部先转化为大写，再转为Ascii码
        public static byte[] ConvertCharToBytes(string text)
        {
            byte[] result = System.Text.Encoding.Default.GetBytes(text.ToUpper());
            return result;
        }

        //包含字母小写
        //"1fA0" -> 0x31 0x66 0x41 0x30
        public static byte[] ConvertCharToBytesUseFormat(string text)
        {
            byte[] result = System.Text.Encoding.Default.GetBytes(text);
            return result;
        }
        ////拼接2个数组
        //public static int AddValueToBuf(ref byte[] buf, byte[] content)
        //{
        //    buf = buf.Concat(content).ToArray();    
        //    return content.Length;
        //}

    }
}
