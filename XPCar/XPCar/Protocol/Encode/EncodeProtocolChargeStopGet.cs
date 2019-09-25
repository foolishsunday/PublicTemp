using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolChargeStopGet : EncodeProtocol
    {
        public EncodeProtocolChargeStopGet(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolChargeStopGet()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.REQUEST_BYTE);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.CHARGE_STOP_GET);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];

            byte[] content = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdContent.CHARGE_STOP);
            this.Content.AddRange(content);
        }
    }
}
