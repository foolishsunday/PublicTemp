using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Timers
{
    public class ThreadTimer
    {
        private System.Threading.Timer _Timer;
        private int _Interval;
        public int Cnt { get; set; }
        public ThreadTimer(System.Threading.TimerCallback callBack)
        {
            _Timer = new System.Threading.Timer(callBack);

            _Interval = System.Threading.Timeout.Infinite;

            Stop();
        }

        public int Interval
        {
            get { return _Interval; }
            set { _Interval = value; }
        }

        public void Start()
        {
            _Timer.Change(_Interval, _Interval);
        }

        public void Stop()
        {
            _Timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            Cnt = 0;
        }

    }
}
