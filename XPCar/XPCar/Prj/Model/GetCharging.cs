using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class GetCharging
    {
        //CCS
        public string OutputV { get; set; }
        public string OutputI { get; set; }
        public string ChargeTime { get; set; }
        public string PermitState { get; set; }
        public string CCSPeriod { get; set; }

        //CST
        public string ConditionPause { get; set; }
        public string ManPause { get; set; }
        public string TroublePause { get; set; }
        public string BMSPause { get; set; }
        public string HighTempTrouble { get; set; }
        public string ConnTrouble { get; set; }
        public string InnerTrouble { get; set; }
        public string TransferTrouble { get; set; }
        public string EmergencyStopTrouble { get; set; }
        public string OtherTrouble { get; set; }
        public string MismatchI { get; set; }
        public string UnusualV { get; set; }
        public string CSTPeriod { get; set; }
    }
}
