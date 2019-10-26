using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCar.Common;
using XPCar.Prj.Controller;
using XPCar.Prj.Data;
using XPCar.Sys.IO;
using log4net;
using XPCar.Sys.IO.Port;
using XPCar.Task;
using XPCar.Protocol.Encode;
using XPCar.Prj.Flow;
using XPCar.Protocol.Decode;
using XPCar.Timers;
using XPCar.Sys.IO.DocFile;
using XPCar.Protocol;
using System.Reflection;

namespace XPCar.Prj
{
    public static class Prj
    {
#if ST_9980AP_DC
        public static string ConfigFilePath = "Aplus.exe.config";
#elif ST_9980A_DC
        public static string ConfigFilePath = "ST-9980A.exe.config";
#elif ST_9980AP_AC
        public static string ConfigFilePath = "ST-9980AP.exe.config";
#endif
        public static SerialPortIO PortIO;
        public static MainController MainController;
        public static RcvdProtocolManager RcvdProtocolManager;
        public static SendProtocolManager SendProtocolManager;
        public static CanMsgController CanMsgController;
        public static MutiPackage MutiPackage;//多包报文
        public static CSVManager CSVManager;
        public static RepositoryManager RepositoryManager;
        public static ConsistController ConsistController;
        public static GeneralController GeneralController;
        public static UpgradeController UpgradeController;
        public static TimerManager TimerManager;
        public static ValueManager ValueManager;//add for 时间增量

        public static WaveController WaveController;
        public static StatisticsController StatisticsController;
        public static void Init()
        {
            try
            {
                ConfigFilePath = Assembly.GetExecutingAssembly().GetName().Name + ".exe.config";
                PortIO = new SerialPortIO();
                PortIO.Init();

                TimerManager = new TimerManager();

                MainController = new MainController(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + ConfigFilePath);

                RcvdProtocolManager = new RcvdProtocolManager();
                RcvdProtocolManager.Init(PortIO);

                SendProtocolManager = new SendProtocolManager();
                SendProtocolManager.Init(PortIO);

                CanMsgController = new CanMsgController();
                CanMsgController.Init();

                ConsistController = new ConsistController();
                //DecodeManager = new DecodeManager();
                //DecodeManager.UpdateMutiPackage += MutiPackage.HandleUpdateMutiPackage;
                MutiPackage = new MutiPackage();

                CSVManager = new CSVManager();
                CSVManager.Init();

                RepositoryManager = new RepositoryManager();

                GeneralController = new GeneralController();

                //TimerManager.Start();
                UpgradeController = new UpgradeController();

                ValueManager = new ValueManager();//add for 时间增量

                WaveController = new WaveController();

                StatisticsController = new StatisticsController();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod() + "()", ex);
            }

        }
        public static void Dispose()
        {
            //DecodeFactory.UpdateMutiPackage -= MutiPackage.HandleUpdateMutiPackage;
        }
    }
}
