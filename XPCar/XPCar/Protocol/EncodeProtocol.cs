using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;

namespace XPCar.Protocol
{
    public static class ConstProtocol
    {
        public const byte HEAD_FLAG = 0x7E;

        public const byte ADDR1_HIGH = 0x30;
        public const byte ADDR1_LOW = 0x30;
        public const byte ADDR2_HIGH = 0x46;
        public const byte ADDR2_LOW = 0x46;

        public const byte END_FLAG = 0x0D;

    }
    public class EncodeProtocol
    {
        public List<byte> Protocol = new List<byte>();
        public List<byte> Content = new List<byte>();

        //protected int _State = 0;
        //protected int _Pos = 0;
        //protected int _StartPos = 0;

        public byte HeadFlag = ConstProtocol.HEAD_FLAG;
        public byte Addr1High = ConstProtocol.ADDR1_HIGH;
        public byte Addr1Low = ConstProtocol.ADDR1_LOW;
        public byte Addr2High = ConstProtocol.ADDR2_HIGH;
        public byte Addr2Low = ConstProtocol.ADDR2_LOW;

        public byte CmdTypeHigh = 0;
        public byte CmdTypeLow = 0;
        public byte CmdHigh = 0;
        public byte CmdLow = 0;

        public byte EndFlag = ConstProtocol.END_FLAG;

        public byte CheckCode1 = 0;
        public byte CheckCode2 = 0;

        public int ContentLen = 0;
        //public int ContentStart = 0;
        //public string Cmd;
        public EncodeProtocol()
        { }

        public EncodeProtocol(EncodeProtocol encodeProtocol)
        {
            this.CmdTypeHigh = encodeProtocol.CmdTypeHigh;
            this.CmdTypeLow = encodeProtocol.CmdTypeLow;
            this.CmdHigh = encodeProtocol.CmdHigh;
            this.CmdLow = encodeProtocol.CmdLow;
            this.ContentLen = encodeProtocol.ContentLen;
            //this.ContentStart = encodeProtocol.ContentStart;
        }
        public bool EncodeCommonIntUse2Byte(int num)
        {
            string str = BaseConvert.Int32ToHexStr(num);
            string result = str.PadLeft(4, '0');

            byte[] content = ProtocolHelper.ConvertCharToBytes(result);
            this.Content.AddRange(content);
            return true;
        }
        public bool EncodeCommon1Int(int num)
        {
            string result = BaseConvert.Int32ToHexStr(num);
            result = result.PadLeft(2, '0');

            byte[] content = ProtocolHelper.ConvertCharToBytes(result);
            this.Content.AddRange(content);
            return true;
        }
        public bool EncodeCommon2HexStr(string text)
        {
            try
            {
                int num = Convert.ToInt32(text);
                string str = BaseConvert.Int32ToHexStr(num);
                string result = str.PadLeft(4, '0');

                byte[] content = ProtocolHelper.ConvertCharToBytes(result);
                this.Content.AddRange(content);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        public bool EncodeCommonStrMultiply10(string text)
        {
            try
            {
                int num = (int)(Convert.ToDouble(text) * 10);
                string str = BaseConvert.Int32ToHexStr(num);
                string result = str.PadLeft(4, '0');

                byte[] content = ProtocolHelper.ConvertCharToBytes(result);
                this.Content.AddRange(content);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        public bool EncodeCommonStrMultiply100(string text)
        {
            try
            {
                int num = (int)(Convert.ToDouble(text) * 100);
                string str = BaseConvert.Int32ToHexStr(num);
                string result = str.PadLeft(4, '0');

                //string result = str.Substring(2, 2) + str.Substring(0, 2);

                byte[] content = ProtocolHelper.ConvertCharToBytes(result);
                this.Content.AddRange(content);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        public bool EncodeCommon1HexStr(string hex)
        {
            try
            {
                if (hex.Length != 2) return false;
                byte[] content = ProtocolHelper.ConvertCharToBytes(hex);
                this.Content.AddRange(content);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        public virtual byte[] Encode()
        {  
            try
            {
                Protocol.Clear();

                Protocol.Add(this.HeadFlag);
                Protocol.Add(this.Addr1High);
                Protocol.Add(this.Addr1Low);
                Protocol.Add(this.Addr2High);
                Protocol.Add(this.Addr2Low);
                Protocol.Add(this.CmdTypeHigh);
                Protocol.Add(this.CmdTypeLow);
                Protocol.Add(this.CmdHigh);
                Protocol.Add(this.CmdLow);

                Protocol.AddRange(this.Content);
                Protocol.Add(this.EndFlag);
                byte[] checkCode = ProtocolHelper.CalCheckSum(Protocol,ref this.CheckCode1,ref this.CheckCode2);
                Protocol.Add(this.CheckCode1);
                Protocol.Add(this.CheckCode2);

                byte[] lists = Protocol.ToArray();
                return lists;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return null;
            }

        }
    }
}
