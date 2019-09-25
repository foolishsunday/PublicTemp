using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Sys.Comm
{
    public delegate void CommConnectedHandler(CommIOState state);
    public delegate void CommDisconnectedHandler(CommIOState state);
    public delegate void CommDataReceivedHandler(int index, byte[] buf, int len);
}
