using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Sys.Comm
{
    public abstract class CommIOState
    {
        //public int Index;
        //public int State;
        public byte[] ReceiveDataBuf;
        public int ReceiveDataLen;
        //public int BufSize;

        public string Name;
        //public byte[] ReceiveDataBuf;
        //public int ReceiveDataLen;
        public abstract bool IsConnected { get; }
        //public abstract string ButtonText { get; }
        public abstract string StatusString { get; }
    }
}
