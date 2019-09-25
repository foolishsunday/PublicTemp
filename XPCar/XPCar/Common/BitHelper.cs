using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Common
{
    public class BitHelper
    {
        private string _BitValue;
        private int _BitLen;
        public BitHelper(int setCnt)
        {
            _BitValue = "";
            for (int i = 0; i < setCnt; i++)
            {
                _BitValue += "0";
            }
            _BitLen = setCnt;
        }
        public void SetBitValue(int selectedBit, bool isTrue)
        {
            string middle = "0";
            if (isTrue)
                middle = "1";
            string left = _BitValue.Substring(0, selectedBit);
            string right = _BitValue.Substring(selectedBit + 1, _BitLen - 1 - selectedBit);
            _BitValue = left + middle + right;
        }

        //批量置0
        public void SetBulkFalse(int startP, int len)
        {
            string middle = "";
            for (int i = 0; i < len; i++)
            {
                middle+= "0";
            }
            string left = _BitValue.Substring(0, startP);
            string right = _BitValue.Substring(startP + len, _BitLen - len - startP);
            _BitValue = left + middle + right;
        }

        /// <summary>
        /// 把二进制字符串转化为hex字符串
        /// </summary>
        /// <returns></returns>
        public string GetValueResult()
        {
            string hex = Convert.ToInt32(_BitValue, 2).ToString("X2");
            hex = hex.PadLeft(_BitLen / 4, '0');
            return hex;
        }

    }
}
