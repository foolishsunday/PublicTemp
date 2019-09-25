using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class SettingChargePara
    {
        //BCP
        public string MaxSingleV { get; set; }
        public string MaxTemp { get; set; }
        public string Energy { get; set; }
        public string BCPPeriod { get; set; }
        public string CurBatVolt { get; set; }
        public string BROPeriod { get; set; }
        public string MaxChargeI { get; set; }
        public string MaxChargeV { get; set; }
        public string SOC { get; set; }

        //BRO
        public string ReadyState { get; set; }
        public string CROPeriod { get; set; }
    }
}
