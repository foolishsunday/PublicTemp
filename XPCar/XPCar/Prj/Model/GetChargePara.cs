using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class GetChargePara
    {
        //CTS
        public string DateYear { get; set; }
        public string DateMonth { get; set; }
        public string DateDay { get; set; }
        public string DateHour { get; set; }
        public string DateMinute { get; set; }
        public string DateSecond { get; set; }
        public string ReqSync { get; set; }

        //CML
        public string MaxOutputV { get; set; }
        public string MinOutputV { get; set; }
        public string MaxOutputI { get; set; }
        public string MinOutputI { get; set; }
        public string CMLPeriod { get; set; }

        //CRO
        public string ReadyState { get; set; }

    }
}