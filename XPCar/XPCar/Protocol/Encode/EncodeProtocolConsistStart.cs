using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolConsistStart : EncodeProtocol
    {
        public EncodeProtocolConsistStart(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolConsistStart(int bitNum)
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.CONSIST_START);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];

            byte[] content;
            content = ProtocolHelper.ConvertCharToBytes(EncodeContent(bitNum));
            this.Content.AddRange(content);
        }
        private string EncodeContent(int bitNum)
        {
            byte[] arrs = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            string text = string.Empty;

            if (bitNum < 0)
            {
                for (int i = 0; i < arrs.Length; i++)
                {
                    text += Convert.ToString(arrs[i], 16).PadLeft(2, '0');
                }
                return text;
            }

            int arrIndex = bitNum / 8;
            int bitIndex = bitNum % 8;

            arrs[arrIndex] = SetBitTrueByIndex(bitIndex);

            for (int i = 0; i < arrs.Length; i++)
            {
                text += Convert.ToString(arrs[i], 16).PadLeft(2, '0');
            }
            return text;
        }
        private byte SetBitTrueByIndex(int index)
        {
            var bits = new BitArray(8);//此处不能用bit64，因为与实际字节的高4位低四位互反了
            bits.SetAll(false);
            bits.Set(7 - index, true);//bits.Set(6,true) -> 0100 0000
            byte[] byte1 = new byte[1];
            bits.CopyTo(byte1, 0);
            return byte1[0];
        }
    }
}
