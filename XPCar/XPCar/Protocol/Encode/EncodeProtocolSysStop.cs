﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolSysStop : EncodeProtocol
    {
        public EncodeProtocolSysStop(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolSysStop()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.SYS_START_STOP);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];

            byte[] content = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdContent.SYS_STOP);
            this.Content.AddRange(content);
        }
    }
}