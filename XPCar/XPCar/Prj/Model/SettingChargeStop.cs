using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class SettingChargeStop
    {
        public string PauseSoc { get; set; }
        public string MinSingleV { get; set; }
        public string MinTemp { get; set; }
        public string MaxSingleV { get; set; }
        public string MaxTemp { get; set; }
        public string BSDPeriod { get; set; }
    }
}
