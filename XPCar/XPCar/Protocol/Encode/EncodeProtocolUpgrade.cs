using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolUpgrade : EncodeProtocol
    {
        public EncodeProtocolUpgrade(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolUpgrade()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.UPGRADE);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];

            byte[] content = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdContent.UPGRADE);
            this.Content.AddRange(content);
        }
    }
}
