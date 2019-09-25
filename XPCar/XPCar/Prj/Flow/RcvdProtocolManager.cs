using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using XPCar.Common;
using XPCar.Prj.Data;
using XPCar.Prj.Model;
using XPCar.Protocol;
using XPCar.Protocol.Decode;
using XPCar.Protocol.Encode;
using XPCar.Sys.Comm;
using XPCar.Sys.IO.Port;
using XPCar.Task;
using static XPCar.Task.TaskCommon;

namespace XPCar.Prj.Flow
{
    //public delegate void DecodeUpdateCanHandler(List<DecodePackageModel> lists);
    public delegate void UpdateBaseInfoHandler(BaseInfo info);
    public class RcvdProtocolManager
    {
        //public event DecodeUpdateCanHandler DecodeUpdateCan;
        public event UpdateBaseInfoHandler UpdateBaseInfo;
        protected SerialPortIO _PortIO; 
        //private readonly static object _locker = new object ();
        private Thread _ThreadRead;
        private Thread _ThreadDecode;
        private EventWaitHandle _EventWaitRead;
        private EventWaitHandle _EventWaitDecode;
        private DataCollection _RawCollect;
        private DataCollection _WaitDecodeBuf;
        private DataCollection _OnlineDecodeBuf;
      

        private static Queue<RawData> _TaskQueue;
        public RcvdProtocolManager()
        {
            _EventWaitRead = new AutoResetEvent(false);
            _ThreadRead = new Thread(FunctionWorkRead);

            _EventWaitDecode = new AutoResetEvent(false);
            _ThreadDecode = new Thread(FunctionWorkDecode);

            _TaskQueue = new Queue<RawData>();
            _RawCollect = new DataCollection();
            _WaitDecodeBuf = new DataCollection();
            _OnlineDecodeBuf = new DataCollection();

        }

        public void Init(SerialPortIO portIO)
        {
            this._PortIO = portIO;
            this._ThreadRead.Start();
            this._ThreadDecode.Start();
            this._PortIO.CommDataReceived += this.HandleDataReceived;

        }
    
        public void FunctionWorkRead()
        {
            try
            {
                while (true)
                {
                    RawData work = new RawData();
                    if (_TaskQueue.Count > 0)
                    {
                        work = _TaskQueue.Dequeue();
                        if (work.TaskName == TaskName.Stop)
                        {
                            return; //任务为空则停止
                        }
                    }
                    if (work.TaskName == TaskName.ReadPort)
                    {
                        DoReadTask();//_RawCollect -> _WaitDecodeBuf
                        _EventWaitDecode.Set();
                    }
                    _EventWaitRead.WaitOne();
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        public void FunctionWorkDecode()
        {
            try
            {
                while (true)
                {
                    if (_WaitDecodeBuf.GetList().Count > 0)
                    {
                        DoDecodeTask();
                    }
                    _EventWaitDecode.WaitOne();
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        /// <summary>
        /// 读取数据任务压入任务队列，唤醒读取数据进程
        /// </summary>
        /// <param name="rawData"></param>
        public void EnqueueTask(RawData rawData)
        {

            _TaskQueue.Enqueue(rawData);
            _EventWaitRead.Set();
        }
        public void Dispose()
        {
            RawData package = new RawData();
            package.TaskName = TaskName.Stop;

            EnqueueTask(package);
            _ThreadRead.Abort();
            _ThreadRead.Join();         //等待工作线程完成
            _EventWaitRead.Close();

            _ThreadDecode.Abort();
            _ThreadDecode.Join();
            _EventWaitDecode.Close();
        }


        /// <summary>
        /// _RawCollect -> _WaitDecodeBuf
        /// </summary>
        private void DoReadTask()
        {
            try
            {
                lock (_RawCollect)
                {
                    lock (_WaitDecodeBuf)
                    {
                        _WaitDecodeBuf.AddList(_RawCollect.GetList());

                    }
                    _RawCollect.Clear();
                }

            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            
        }

        /// <summary>
        /// _WaitDecodeBuf -> _OnlineDecodeBuf 并解码
        /// </summary>
        private void DoDecodeTask()
        {
            List<EachFrameModel> lists = null;
            lock (_WaitDecodeBuf)
            {
                _OnlineDecodeBuf.AddList(_WaitDecodeBuf.GetList());
                _WaitDecodeBuf.Clear();        
            }
            lists = _OnlineDecodeBuf.VerifyAndPackage();
            DecodeManager decode = new DecodeManager();
            decode.CreateDecodeMachine(lists);

        }
        /// <summary>
        /// 串口数据 -> _RawCollect
        /// </summary>
        /// <param name="index"></param>
        /// <param name="buf"></param>
        /// <param name="len"></param>
        private void HandleDataReceived(int index, byte[] buf, int len)
        {
            try
            {
                byte[] readOut = new byte[len];
                Array.Copy(buf, readOut, len);
                lock (_RawCollect)
                {
                    _RawCollect.AddBuf(readOut);
                    //_RawCollect.AddBuf(buf);
                }
                RawData package = new RawData(TaskName.ReadPort, null);
                EnqueueTask(package);
                
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

        }
        public void DoUpdateBaseInfo(BaseInfo info)
        {
            UpdateBaseInfo(info);
        }
    }
}
