using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Sys.Comm
{
    public abstract class CommIO
    {
        public abstract event CommConnectedHandler CommConnected;
        public abstract event CommDisconnectedHandler CommDisconnected;
        public abstract event CommDataReceivedHandler CommDataReceived;
        public abstract int SendData(byte[] buf, int len);
    }
}
