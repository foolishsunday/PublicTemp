using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class BaseInfo
    {
        public string ChargeV { get; set; }
        public string ChargeI { get; set; }
        public string CC1Volt { get; set; }
        public string CC2Volt { get; set; }
        public string AssistVolt { get; set; }
        public string AmbientTemp { get; set; }
        public string DC_P_Temp { get; set; }
        public string DC_M_Temp { get; set; }
        public string ChargeState { get; set; }
    }
}
