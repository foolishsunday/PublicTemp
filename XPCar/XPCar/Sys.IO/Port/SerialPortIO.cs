using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Sys.Comm;

namespace XPCar.Sys.IO.Port
{
    public class SerialPortIO : CommIO
    {
        public override event CommConnectedHandler CommConnected;
        public override event CommDisconnectedHandler CommDisconnected;
        public override event CommDataReceivedHandler CommDataReceived;
        private SerialPortIOState state;
        private SerialPort port;
        public void Init()
        {
            port = new SerialPort();
            state = new SerialPortIOState(port);
            state.Sp.DataReceived += this.HandleDataReceived;

        }
        public override int SendData(byte[] buf, int len)
        {
            try
            {
                if (state == null) return 0;

                if (state.Sp == null) return 0;
                if (state.Sp.IsOpen)
                {
                    if (state.Sp.BytesToWrite == 0)
                    {
                        state.Sp.Write(buf, 0, len);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);

            }
            return 0;
        }
        public void SetPortParam(string portName, int baud)
        {
            if (state == null || state.Sp == null)
                return;
            state.Sp.StopBits = StopBits.One;
            state.Sp.DataBits = 8;
            state.Sp.Parity = Parity.None;
            state.Sp.PortName = portName;
            state.Sp.BaudRate = baud;
            state.Sp.ReadBufferSize = 40960;
            state.Name = portName;
        }
        public bool Connect()
        {
            try
            {
                if (state == null || state.Sp == null)
                    return false;
                state.Sp.Open();
                System.Threading.Thread.Sleep(20);
     
                if (CommConnected != null)
                    CommConnected(state);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return true;
        }
        public bool Disconnect()
        {
            try
            {
                if (state == null || state.Sp == null || state.Name == null)
                    return false;
                state.Sp.Close();
                System.Threading.Thread.Sleep(20);
                if (CommDisconnected != null)
                {
                    CommDisconnected(state);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return true;
        }

        public SerialPortIOState GetPortState()
        {
            return state;
        }

        private void HandleDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //SerialPort sp = (SerialPort)sender;
            if (state == null)
                return;
            int bytesCanRead = state.Sp.BytesToRead;
            if (bytesCanRead <= 0)
                return;

            try
            {
                state.ReceiveDataLen = state.Sp.Read(state.ReceiveDataBuf, 0, bytesCanRead);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            try
            {
                if (state.ReceiveDataLen == 0)
                    return;
                if (CommDataReceived != null)
                {
                    CommDataReceived(0, state.ReceiveDataBuf, state.ReceiveDataLen);
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }


        }

    }
}
