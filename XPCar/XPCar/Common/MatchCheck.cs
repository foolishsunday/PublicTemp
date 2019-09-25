using System.Text.RegularExpressions;

namespace XPCar.Common
{
    public class MatchCheck
    {
        public static bool IsInt(string str)
        {
            //匹配数字（0~9）
            //$表示字符串结尾
            int num = 0;
            return int.TryParse(str, out num);
        }

        public static bool IsDouble(string str)
        {
            double num = 0;
            return double.TryParse(str, out num);
        }
        public static bool IsNumAndChar(string input)
        {
            string pattern = @"^[A-Za-z0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        } 
    }
}
