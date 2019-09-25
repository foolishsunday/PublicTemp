using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class SettingHandshake
    {
        //BHM
        public string MaxV { get; set; }
        public string BHMPeriod { get; set; }

        //BRM
        public string VerH { get; set; }
        public string VerL { get; set; }
        public string BRMPeriod { get; set; }
        public string BatType { get; set; }
        public string BatCapacity { get; set; }
        public string BatTotalV { get; set; }
        public string Vendor { get; set; }
        public string BatNum { get; set; }
        public string ProduceYear { get; set; }
        public string ProduceMonth { get; set; }
        public string ProduceDay { get; set; }
        public string ChargeCnt { get; set; }
        public string Vin { get; set; }
        public string Property { get; set; }
    }
}
