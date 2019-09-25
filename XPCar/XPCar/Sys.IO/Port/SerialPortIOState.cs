using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using XPCar.Sys.Comm;

namespace XPCar.Sys.IO.Port
{
    public class SerialPortIOState : CommIOState
    {
        public SerialPort Sp;

        public SerialPortIOState(SerialPort sp)
        {
            //this.State = 0;

            this.ReceiveDataBuf = new byte[2048];
            this.ReceiveDataLen = 0;
            //this.BufSize = bufSize;
            this.Sp = sp;
        }
        ~SerialPortIOState()
        {
            if (Sp != null)
            {
                if (Sp.IsOpen)
                    Sp.Close();
                Sp.Dispose();
            }
        }
        public override bool IsConnected
        {
            get
            {
                if (Sp == null) return false;
                if (Sp.IsOpen)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public override string StatusString
        {
            get
            {
                if (Sp == null) return "No device";
                if (Sp.IsOpen)
                {
                    return this.Name.ToString() + Common.KeyConst.Punctuation.Space + Sp.BaudRate.ToString() +
                        Common.KeyConst.Punctuation.Space + "Connected";
                }
                else
                {
                    return this.Name.ToString() + Common.KeyConst.Punctuation.Space + "Disconnected";
                }
            }
        }
    }
}
