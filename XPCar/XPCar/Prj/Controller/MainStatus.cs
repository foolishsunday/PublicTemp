using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Controller
{
    public class MainStatus
    {
        public bool OpenCatch { get; set; }
        public bool SysStartStop { get; set; }
        public MainStatus()
        {
            OpenCatch = false;
            SysStartStop = false;
        }
    }
}
