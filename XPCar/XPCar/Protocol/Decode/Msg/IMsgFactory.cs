using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Protocol.Decode.Msg
{
    public interface IMsgFactory
    {
        MsgCommon CreateMsgDecodeMachine(string msgid);
    }
}
