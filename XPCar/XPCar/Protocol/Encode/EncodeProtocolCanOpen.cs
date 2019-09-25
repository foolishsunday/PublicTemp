using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolCanOpen : EncodeProtocol
    {
        public EncodeProtocolCanOpen(EncodeProtocol encodeProtocol):base(encodeProtocol)
        {

        }
        public EncodeProtocolCanOpen()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.CMD_CAN);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];

            byte[] content = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdContent.OPEN_CAN);
            this.Content.AddRange(content);
        }
        //public int BuildProtocol
    }
}
