using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Sys.IO.DocFile
{
    public class CSVManager
    {
        private CSVHelper _CSVHelper;
        private Thread _CSVThread;
        public string CSVPath { get; set; }
        public string CSVFolder { get; set; }
        //private int _Index;
        private List<CanMsg> _Lists;
        private static readonly object _Locker = new object();
        //private EventWaitHandle _Wakeup;
        public CSVManager()
        {
            _CSVHelper = new CSVHelper();
            _CSVThread = new Thread(WriteTask);
            //_Wakeup = new AutoResetEvent(false);
            _Lists = new List<CanMsg>();
            //_Index = 0;
            CSVPath = string.Empty;
        }
        public void Init() { }
        public void Reset()
        {
            //this._Index = 0;

            CSVPath = string.Empty;
            _Lists.Clear();
        }
        public bool Create(string path)
        {
            try
            {
                if (_CSVHelper.CreateFile(path) == true)
                {
                    string head = "帧序号,收发标志,帧时间,时间增量,帧ID,DLC,数据,BMS报文翻译";//add for 时间增量
                    _CSVHelper.WriteLine(path, head);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        //public bool Append
        public void StartSave()
        {
            try
            {
                if(!_CSVThread.IsAlive)
                    _CSVThread.Start();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
   
        }
        public void StopSave()
        {
            try
            {
                _CSVThread.Abort();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
    
        }
        public void WriteTask()
        {
            while (true)
            {
                if (!string.IsNullOrEmpty(CSVPath))
                {
                    lock (_Locker)
                    {
                        List<string> lists = new List<string>();
                        if (_Lists != null && _Lists.Count > 0)
                        {
                            for (int i = 0; i < _Lists.Count; i++)
                            {
                                string line = _Lists[i].ObjectNo + ","
                                            + _Lists[i].Direction + ","
                                            + _Lists[i].CreateTimestamp + ","
                                            + _Lists[i].TimeIncrement + ","
                                            + _Lists[i].Id + ","
                                            + _Lists[i].Dlc + ","
                                            + _Lists[i].MsgData + ","
                                            + _Lists[i].MsgText;
                                lists.Add(line);
                            }
                            _Lists.Clear();
                            _CSVHelper.AppendLine(this.CSVPath, lists);
                        }

                    }
                }
                Thread.Sleep(50);
            }

        }
        public void AddModel(CanMsg msg)
        {
            lock (_Locker)
            {
                _Lists.Add(msg);
            }
        }
    }
}
