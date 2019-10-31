using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using XPCar.Sys.IO;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Prj.Data
{
    public class PrjConfig
    {
        private ConfigIO _Config;
        public string ComPort { get; set; }
        public int ComBaudrate { get; set; }
        public string SkinPath { get; set; }
        public int KeepRowCount { get; set; }
        public bool DeveloperItem { get; set; }
        public string Title { get; set; }
        //public StandardSet StandardSet { get; set; }
        public PrjConfig(string configFilePath)
        {
            if (configFilePath == null) throw new NullReferenceException("参数为空：configFilePath");

            _Config = new ConfigIO(configFilePath);
            //StandardSet = new StandardSet();


        }
        public void Load()
        {
            try
            {
                //System.Configuration.ConfigXmlDocument.
                this.ComPort = ConfigurationManager.AppSettings["ComPort"];//ConfigurationManager.AppSettings["ComPort"];// _Config.GetValue("appSettings", "ComPort"); 
                this.ComBaudrate = Convert.ToInt32(ConfigurationManager.AppSettings["ComBaudrate"]);//Convert.ToInt32(_Config.GetValue("appSettings", "ComBaudrate"));
                this.SkinPath = ConfigurationManager.AppSettings["SkinPath"];//_Config.GetValue("appSettings", "SkinPath");
                this.KeepRowCount = Convert.ToInt32(ConfigurationManager.AppSettings["KeepRowCount"]);
                this.DeveloperItem = Convert.ToBoolean(ConfigurationManager.AppSettings["DeveloperItem"]);
                this.Title = ConfigurationManager.AppSettings["Title"];
                //this.StandardSet.Std1s = Convert.ToInt32(ConfigurationManager.AppSettings["Std1s"]);
                //this.StandardSet.Std5s = Convert.ToInt32(ConfigurationManager.AppSettings["Std5s"]);
                //this.StandardSet.Std10s = Convert.ToInt32(ConfigurationManager.AppSettings["Std10s"]);
                //this.StandardSet.Std10ms = Convert.ToInt32(ConfigurationManager.AppSettings["Std10ms"]);
                //this.StandardSet.Std50ms = Convert.ToInt32(ConfigurationManager.AppSettings["Std50ms"]);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        public void Save()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection app = config.AppSettings;
                ConnectionStringsSection conn = config.ConnectionStrings;

                app.Settings["ComPort"].Value = this.ComPort;
                app.Settings["ComBaudrate"].Value = this.ComBaudrate.ToString();
                config.Save();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        public void SaveConsistStd()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection app = config.AppSettings;
                ConnectionStringsSection conn = config.ConnectionStrings;

                //app.Settings["Std1s"].Value = this.StandardSet.Std1s.ToString();
                //app.Settings["Std5s"].Value = this.StandardSet.Std5s.ToString();
                //app.Settings["Std10s"].Value = this.StandardSet.Std10s.ToString();
                //app.Settings["Std10ms"].Value = this.StandardSet.Std10ms.ToString();
                //app.Settings["Std50ms"].Value = this.StandardSet.Std50ms.ToString();
                config.Save();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
    }
}
