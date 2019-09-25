using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using static XPCar.Common.KeyConst;

namespace XPCar.Timers
{
    public delegate void SendGetCmdHandle(TimeToSend.Page formIndex);
    public class TimerManager
    {
        private ThreadTimer _Timer100ms;
        private TimeToSend.Page _FormIndex;
        //private bool _IsBaseCmd;
        public event SendGetCmdHandle SendGetCmd;
        private int _CmdJob;
        public TimerManager()
        {
            _Timer100ms = new ThreadTimer(this.Timer100ms_Tick);
            _Timer100ms.Interval = 100;
            _FormIndex = 0;
            _CmdJob = 0;
        }
        public void Stop()
        {
            _Timer100ms.Stop();
        }
        public void Start()
        {
            _Timer100ms.Start();
        }
        private void Timer100ms_Tick(object state)
        {
            //_IsBaseCmd = !_IsBaseCmd;
            _CmdJob++;
            if (_CmdJob > 2)
                _CmdJob = 0;
#if AC_TEST
            SendGetCmd(_FormIndex);
#else
            if (_CmdJob == 0)//交替发送
            {
                SendGetCmd(TimeToSend.Page.BaseInfo);
            }
            else if (_CmdJob == 1)
            {
                SendGetCmd(TimeToSend.Page.Alarm);
            }
            else
            {
                SendGetCmd(_FormIndex);
            }
            //if (_IsBaseCmd)//交替发送
            //{
            //    SendGetCmd(TimeToSend.Page.BaseInfo);
            //}
            //else
            //{
            //    SendGetCmd(_FormIndex);
            //}
#endif
        }
        public void SetFormIndex(TimeToSend.Page index)
        {
            _FormIndex = index;
        }
        public TimeToSend.Page GetPage()
        {
            return _FormIndex;
        }
    }
}
