using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using XPCar.Common;
using XPCar.Prj.Model;
using XPCar.Wave;
using ZedGraph;

namespace XPCar.Prj.Controller
{
    public delegate void DrawWaveHandle(PointPairList[] data);
    public class WaveController
    {
        private GraphPoint _GraphPoint;
        private Thread _Thread;
        private static readonly object _Locker = new object();
        public event DrawWaveHandle DrawWave;
        private EventWaitHandle _EventDraw;
        public WaveController()
        {
            _GraphPoint = new GraphPoint();
            _Thread = new Thread(WaveTask);
            _Thread.Start();
            _EventDraw = new AutoResetEvent(false);
        }
        public void AddModel(CanMsgRich model)
        {
            try
            {
                string msgName = model.ConsistMsg.MsgName;
                double span = model.SpanTime;
                lock (_Locker)
                {
                    _GraphPoint.SetPointPair(span, msgName);
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void WaveTask()
        {
            while (true)
            {
                lock (_Locker)
                {
                    if (DrawWave != null)
                    {
                        PointPairList[] lists = _GraphPoint.GetPoints();
                        DrawWave(lists);
                        _GraphPoint.ClearAllPoint();
                    }
                }
                _EventDraw.WaitOne();
                //Thread.Sleep(1000);
            }
        }
        public void WackupDraw()
        {
            _EventDraw.Set();
        }
        public void StopTask()
        {
            try
            {
                _Thread.Abort();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

        }
    }
}
