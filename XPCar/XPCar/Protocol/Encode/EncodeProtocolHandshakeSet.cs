using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolHandshakeSet : EncodeProtocol
    {
        public EncodeProtocolHandshakeSet(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolHandshakeSet()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.HANDSHAKE_SET);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];
        }
        private bool EncodeVersion(string high, string ml)
        {
            try
            {
                high = high.PadLeft(2, '0');
                //low = low.PadRight(4, '0');
                int lowInt = Convert.ToInt32(ml);

                string middle = ml.Substring(0, 1);
                middle = middle.PadLeft(2, '0');

                string low = ml.Substring(1, 1);
                low = low.PadLeft(2, '0');

                byte[] result = ProtocolHelper.ConvertCharToBytes(high + middle + low);
                this.Content.AddRange(result);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }

        public bool AddContent(SettingHandshake data)
        {
            try
            {
                bool result;
                //X1-X2 最高允许电压
                result = EncodeCommonStrMultiply10(data.MaxV);

                //X3-X4 BHM周期
                result &= EncodeCommon2HexStr(data.BHMPeriod);

                //X5-X7 协议版本号
                result &= EncodeVersion(data.VerH, data.VerL);

                //X8 电池类型
                result &= EncodeCommon1HexStr(data.BatType);

                //X9-X10 整车电池额定容量
                result &= EncodeCommonStrMultiply10(data.BatCapacity);

                //X11-X12 电池额定电压
                result &= EncodeCommonStrMultiply10(data.BatTotalV);

                //X13-X16 电池生产厂商
                result &= EncodeVendor(data.Vendor);

                //X17-X20 电池组序号
                result &= EncodeBatNum(data.BatNum);

                //X21-X23 电池生产日期
                result &= EncodeProduceYear(data.ProduceYear);
                result &= EncodeInt2Hex(data.ProduceMonth);
                result &= EncodeInt2Hex(data.ProduceDay);

                //X24-X26 充电次数
                result &= EncodeChargeCnt(data.ChargeCnt);

                //X27 产权标识
                result &= EncodeCommon1HexStr(data.Property);

                //X28 预留
                this.Content.AddRange(new byte[] { 0, 0 });

                //X29-X45 车辆识别码
                result &= EncodeVin(data.Vin);

                //X46-X53 预留
                this.Content.AddRange(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

                //X54-X55 BRM报文周期
                result &= EncodeCommon2HexStr(data.BRMPeriod);

                return result;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeVendor(string text)
        {
            try
            {
                if (text.Length > 4)
                    return false;
                text = text.PadRight(4, ' ');
                string str = "";
                byte[] vendor = ProtocolHelper.ConvertCharToBytesUseFormat(text);//"BYD" -> 0x42 0x59 0x44
                for (int i = 0; i < vendor.Length; i++)
                {
                    str += BaseConvert.Byte2HexStr(vendor[i]);      //0x42 0x59 0x44 -> "425944"
                }
                byte[] content = ProtocolHelper.ConvertCharToBytesUseFormat(str);//"425944" -> 0x34 0x32 ...

                this.Content.AddRange(content);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeBatNum(string text)
        {
            try
            {
                text = text.PadLeft(8, '0');
                string s1 = text.Substring(0, 2);
                string s2 = text.Substring(2, 2);
                string s3 = text.Substring(4, 2);
                string s4 = text.Substring(6, 2);

                byte[] result = ProtocolHelper.ConvertCharToBytesUseFormat(s1);
                this.Content.AddRange(result);

                result = ProtocolHelper.ConvertCharToBytesUseFormat(s2);
                this.Content.AddRange(result);

                result = ProtocolHelper.ConvertCharToBytesUseFormat(s3);
                this.Content.AddRange(result);

                result = ProtocolHelper.ConvertCharToBytesUseFormat(s4);
                this.Content.AddRange(result);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeProduceYear(string text)
        {
            try
            {
                int year = Convert.ToInt32(text.Trim()); //"2018" -> 2018
                year -= 1985; //33
                string str = Convert.ToString(year, 16).PadLeft(2, '0'); //33 -> 0x21 -> 二进制
                byte[] result = ProtocolHelper.ConvertCharToBytes(str);
                this.Content.AddRange(result);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeInt2Hex(string text)
        {
            try
            {
                int val = Convert.ToInt32(text.Trim());
                string str = Convert.ToString(val, 16).PadLeft(2, '0');
                byte[] result = ProtocolHelper.ConvertCharToBytes(str);
                this.Content.AddRange(result);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeChargeCnt(string text)
        {
            try
            {
                int val = Convert.ToInt32(text.Trim());
                string str = Convert.ToString(val, 16).PadLeft(6, '0');
                byte[] result = ProtocolHelper.ConvertCharToBytes(str);
                this.Content.AddRange(result);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeVin(string text)
        {
            try
            {
                string str = text.PadRight(17, ' ');
                string content = BaseConvert.Str2Hex2AsciiStr(str);
                byte[] result = ProtocolHelper.ConvertCharToBytes(content);
                this.Content.AddRange(result);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
    }
}
