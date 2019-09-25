using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolVerGet : EncodeProtocol
    {
        public EncodeProtocolVerGet(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolVerGet()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.REQUEST_BYTE);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.VER_GET);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];

            byte[] content = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdContent.VER_GET);
            this.Content.AddRange(content);
        }
    }
}
