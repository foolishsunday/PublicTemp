using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using XPCar.Common;
using XPCar.Prj.Model;
using XPCar.Protocol;
using XPCar.Protocol.Encode;
using XPCar.Sys.IO.Port;
using XPCar.Task;
using static XPCar.Common.KeyConst;
using static XPCar.Task.TaskCommon;

namespace XPCar.Prj.Flow
{
    public class SendProtocolManager
    {
        protected SerialPortIO _PortIO;
        private bool _DisableTimingSend;//禁止发送常态查询命令，用于按钮按下时
        public void Init(SerialPortIO portIO)
        {
            this._PortIO = portIO;

        }
        #region 系统及报文Cmd
        public void SendAlarmGet()
        {
            EncodeProtocolAlarmGet protocol = new EncodeProtocolAlarmGet();
            SendData(protocol);
        }
        public void SendBaseData()
        {
            EncodeProtocolBaseInfo protocol = new EncodeProtocolBaseInfo();
            SendData(protocol);
        }
        public void SendCanOpen()
        {
            EncodeProtocolCanOpen protocol = new EncodeProtocolCanOpen();
            SendData(protocol);
            //Thread.Sleep(10);
        }
        public void SendCanClose()
        {
            EncodeProtocolCanClose protocol = new EncodeProtocolCanClose();
            SendData(protocol);
            //Thread.Sleep(10);
        }
        public void SendSysStart()
        {
            EncodeProtocolSysStart protocol = new EncodeProtocolSysStart();
            SendData(protocol);
            //Thread.Sleep(10);
        }
        public void SendSysStop()
        {
            EncodeProtocolSysStop protocol = new EncodeProtocolSysStop();
            SendData(protocol);
            //Thread.Sleep(10);
        }
        public void SendConsistStart(int bitNum)
        {
            EncodeProtocolConsistStart protocol = new EncodeProtocolConsistStart(bitNum);
            SendData(protocol);
        }
        #endregion 系统及报文Cmd
        #region 读取GET Cmd
        public void SendHandshakeGet()
        {
            EncodeProtocolHandshakeGet protocol = new EncodeProtocolHandshakeGet();
            SendData(protocol);
        }
        public void SendChargeParaGet()
        {
            EncodeProtocolChargeParaGet protocol = new EncodeProtocolChargeParaGet();
            SendData(protocol);
        }
        public void SendChargingGet()
        {
            EncodeProtocolChargingGet protocol = new EncodeProtocolChargingGet();
            SendData(protocol);
        }
        public void SendChargeStopGet()
        {
            EncodeProtocolChargeStopGet protocol = new EncodeProtocolChargeStopGet();
            SendData(protocol);
        }
        public void SendDCGet()
        {
            EncodeProtocolDCGet protocol = new EncodeProtocolDCGet();
            SendData(protocol);
        }
        public void SendACGet()
        {
            EncodeProtocolACGet protocol = new EncodeProtocolACGet();
            SendData(protocol);
        }
        public void SendVerGet()
        {
            EncodeProtocolVerGet protocol = new EncodeProtocolVerGet();
            SendData(protocol);
        }
        #endregion 读取GET Cmd
        #region 写CMD
        public void SendHandshakeSet(SettingHandshake data)
        {
            EncodeProtocolHandshakeSet protocol = new EncodeProtocolHandshakeSet();
            protocol.AddContent(data);
            SendData(protocol);
        }
        public void SendChargeParaSet(SettingChargePara data)
        {
            EncodeProtocolChargeParaSet protocol = new EncodeProtocolChargeParaSet();
            protocol.AddContent(data);
            SendData(protocol);
        }
        public void SendChargingSet(SettingCharging data)
        {
            EncodeProtocolChargingSet protocol = new EncodeProtocolChargingSet();
            protocol.AddContent(data);
            SendData(protocol);
        }
        public void SendChargeStopSet(SettingChargeStop data)
        {
            EncodeProtocolChargeStopSet protocol = new EncodeProtocolChargeStopSet();
            protocol.AddContent(data);
            SendData(protocol);
        }
        public void SendUpdgradeRequest()
        {
            EncodeProtocolUpgrade protocol = new EncodeProtocolUpgrade();
            SendData(protocol);
        }
        public void SendUpdgradeFile(byte[] content)
        {
            try
            {
                RawData package = new RawData();

                package.TaskName = TaskName.WritePort;
                package.Buffer = content;
                DoWriteTask(package);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        public void SendInteropDcSet(SettingDC data)
        {
            EncodeProtocolDCSet protocol = new EncodeProtocolDCSet();
            protocol.AddContent(data);
            SendData(protocol);
        }
        public void SendACSet(SettingACInterop data)
        {
            EncodeProtocolACSet protocol = new EncodeProtocolACSet();
            protocol.AddContent(data);
            SendData(protocol);
        }
        public void SendTimeSyncSet()//add for 实时时间
        {
            EncodeProtocolTimeSyncSet protocol = new EncodeProtocolTimeSyncSet();
            protocol.AddContent();
            SendData(protocol);
        }
        #endregion 写CMD

        private void SendData(EncodeProtocol protocol)
        {
            try
            {
                RawData package = new RawData();

                package.TaskName = TaskName.WritePort;
                package.Buffer = protocol.Encode();

                DoWriteTask(package);
                //EnqueueTask(package);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void DoWriteTask(RawData package)
        {
            try
            {
                _PortIO.SendData(package.Buffer, package.Buffer.Length);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

        }
        public void HandleSendGetCmd(TimeToSend.Page state)
        {
            if (_DisableTimingSend)//有按钮按下，暂时不发送
                return;
            switch (state)
            {
                case TimeToSend.Page.BaseInfo:
                    SendBaseData();
                    break;
                case TimeToSend.Page.Alarm:
                    SendAlarmGet();
                    break;
                case TimeToSend.Page.Handshake:
                    SendHandshakeGet();
                    break;
                case TimeToSend.Page.ChargeParaGet:
                    SendChargeParaGet();
                    break;
                case TimeToSend.Page.ChargingGet:
                    SendChargingGet();
                    break;
                case TimeToSend.Page.ChargeStop:
                    SendChargeStopGet();
                    break;
                case TimeToSend.Page.DCGet:
                    SendDCGet();
                    break;
                case TimeToSend.Page.ACGet:
                    SendACGet();
                    break;
                case TimeToSend.Page.ACInterop://无须发送
                    break;
                case TimeToSend.Page.VersionGet:
                    SendVerGet();
                    break;
                default:
                    break;
            }
        }
        public void SetDisalbeTimingSend(bool disable)
        {
            _DisableTimingSend = disable;
        }
    }
}
