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
    public delegate void DrawWaveHandle(PointPairList[] points, PointPairList[] lines);
    public class WaveController
    {
        private GraphPoint _GraphPoint;
        //private Thread _Thread;
        private static readonly object _Locker = new object();
        public event DrawWaveHandle DrawWave;
        //private EventWaitHandle _EventDraw;
        public BaseInfo WaveBaseInfo { get; set; }
        public WaveController()
        {
            _GraphPoint = new GraphPoint();
            //_Thread = new Thread(WaveTask);
            //_Thread.Start();
            //_EventDraw = new AutoResetEvent(false);
            WaveBaseInfo = new BaseInfo();
        }

        //时序图曲线值，按倍数缩放
        public void SetWaveBaseInfo(BaseInfo data)
        {
            try
            {
                WaveBaseInfo.WaveChargeV = Convert.ToDouble(data.ChargeV) / 50F + 3F;
                WaveBaseInfo.WaveChargeI = Convert.ToDouble(data.ChargeI) / 15F + 3F;
                WaveBaseInfo.WaveCC1Volt = Convert.ToDouble(data.CC1Volt) / 1.5F + 3F;
                WaveBaseInfo.WaveCC2Volt = Convert.ToDouble(data.CC2Volt) / 1.5F + 3F;
                WaveBaseInfo.WaveAssistVolt = Convert.ToDouble(data.AssistVolt) / 1.5F + 3F;
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
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
                    _GraphPoint.SetLinePair(span, WaveBaseInfo.WaveChargeV, 0);
                    _GraphPoint.SetLinePair(span, WaveBaseInfo.WaveChargeI, 1);
                    _GraphPoint.SetLinePair(span, WaveBaseInfo.WaveCC1Volt, 2);
                    _GraphPoint.SetLinePair(span, WaveBaseInfo.WaveCC2Volt, 3);
                    _GraphPoint.SetLinePair(span, WaveBaseInfo.WaveAssistVolt, 4);
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        public void DrawLineTitle()
        {
            try
            {
                _GraphPoint.SetLinePair(0, 0, 0);
                _GraphPoint.SetLinePair(0, 0, 1);
                _GraphPoint.SetLinePair(0, 0, 2);
                _GraphPoint.SetLinePair(0, 0, 3);
                _GraphPoint.SetLinePair(0, 0, 4);
                WackupDraw();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        //private void WaveTask()
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            lock (_Locker)
        //            {
        //                if (DrawWave != null)
        //                {
        //                    PointPairList[] lists = _GraphPoint.GetPoints();
        //                    PointPairList[] lines = _GraphPoint.GetLines();
        //                    DrawWave(lists, lines);
        //                    _GraphPoint.ClearAllPoint();
        //                }
        //            }
        //            _EventDraw.WaitOne();
        //            //Thread.Sleep(1000);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }
        //}
        private void DrawWaveTask(object state)
        {
            lock (_Locker)
            {
                if (DrawWave != null)
                {
                    PointPairList[] lists = _GraphPoint.GetPoints();
                    PointPairList[] lines = _GraphPoint.GetLines();
                    DrawWave(lists, lines);
                    _GraphPoint.ClearAllPoint();
                }
            }
        }
        public void WackupDraw()
        {
            //_EventDraw.Set();
            ThreadPool.QueueUserWorkItem(new WaitCallback(DrawWaveTask));
        }
        //public void StopTask()
        //{
        //    try
        //    {
        //        _Thread.Abort();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }

        //}
    }
}
