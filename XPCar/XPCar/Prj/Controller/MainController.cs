using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Component;
using XPCar.Prj;
using XPCar.Prj.Data;
using XPCar.Sys.Comm;
using XPCar.Sys.IO.Port;

namespace XPCar.Prj.Controller
{
    public delegate void CommIOStatusUpdated(string status);
    public delegate void CommIOButtonUpdated(string text);
    public delegate void CommIOPicUpdated(Image pic);
    public class MainController
    {
        public event CommIOStatusUpdated CommIOStatusUpdated;
        public event CommIOButtonUpdated CommIOButtonUpdated;
        //public event MsgDataFormHandle MsgDataForm;


        private PrjConfig _Config;
        public WarningLight WarningLight;
        private MainStatus _MainStatus;
        public MainController(string configFilePath)
        {
            if (configFilePath == null) throw new NullReferenceException("参数为空：configFilePath");
            _Config = new PrjConfig(configFilePath);
            _Config.Load();

            WarningLight = new WarningLight();

            _MainStatus = new MainStatus();


            Prj.PortIO.CommConnected += this.HandlePortConnected;
            Prj.PortIO.CommDisconnected += this.HandlePortDisconnected;

            //_WarningLight.ComStateImage += this.HandleComStateImage;

        }
        ~MainController()
        {
            Prj.PortIO.CommConnected -= this.HandlePortConnected;
            Prj.PortIO.CommDisconnected -= this.HandlePortDisconnected;
        }
        public void Init()
        {
            WarningLight.FlashRed(1000);
        }
        private void HandlePortConnected(CommIOState state)
        {
            if (CommIOStatusUpdated != null)
            {
                CommIOStatusUpdated(state.StatusString);
                CommIOButtonUpdated("关闭设备");
                WarningLight.OnGreen();
                //CommIOPicUpdated(XPCar.Properties.Resources.Ball_green);
            }
               
        }
        private void HandlePortDisconnected(CommIOState state)
        {
            if (CommIOStatusUpdated != null)
            {
                CommIOStatusUpdated(state.StatusString);
                CommIOButtonUpdated("打开设备");
                WarningLight.FlashRed(1000);
                //CommIOPicUpdated(false);
                //CommIOPicUpdated(XPCar.Properties.Resources.Ball_red);
            }
        }
        //private void HandleComStateImage(Image img)
        //{
            
        //}
        public bool IsConnected()
        {
            if (Prj.PortIO.GetPortState().Sp.IsOpen)
                return true;
            else
                return false;
        }
        public void ConnPort()
        {
            try
            {
                Prj.PortIO.Disconnect();
                Prj.PortIO.SetPortParam(_Config.ComPort,_Config.ComBaudrate);
                Prj.PortIO.Connect();
                //CommIOState state = Prj.PortIO.GetPortState();
                //if (state != null && state.IsConnected)
                //    HandlePortConnected(state);

            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

        }
        public void DisconnPort()
        {
            try
            {
                Prj.PortIO.Disconnect();
                //CommIOState state = Prj.PortIO.GetPortState();
                //if (state != null && state.IsConnected == false)
                //    HandlePortDisconnected(state);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        public PrjConfig Config
        {
            get { return _Config; }
        }
        public void SaveConfig()
        {
            _Config.Save();
        }
        public bool IsCatchOpen()
        {
            return _MainStatus.OpenCatch;
        }
        public void OpenCatch()
        {
            _MainStatus.OpenCatch = true;
        }
        public void CloseCatch()
        {
            _MainStatus.OpenCatch = false;
        }
        public bool IsSysStart()
        {
            return _MainStatus.SysStartStop;
        }
        public void SysStart()
        {
            _MainStatus.SysStartStop = true;
        }
        public void SysStop()
        {
            _MainStatus.SysStartStop = false;
        }
    }
}
