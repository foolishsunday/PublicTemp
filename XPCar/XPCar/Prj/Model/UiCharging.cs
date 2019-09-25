using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class UiCharging
    {
        //BCL
        public string ReqV { get; set; }
        public string ReqI { get; set; }
        public string ChargeMode { get; set; }

        public string BCLPeriod { get; set; }

        //BCS
        public string ChargeV { get; set; }
        public string ChargeI { get; set; }
        public string MaxSingleV { get; set; }
        public string MaxSingleVNum { get; set; }
        public string SOC { get; set; }
        public string RemainTime { get; set; }
  
        public string BCSPeriod { get; set; }

        //BSM
        public string SingleVNumBSM { get; set; }
        public string MaxTemp { get; set; }
        public string MaxTempNum { get; set; }
        public string MinTemp { get; set; }
        public string MinTempNum { get; set; }
        public string SingleVState { get; set; }
        public string SOCState { get; set; }
        public string ChargeIState { get; set; }
        public string TempState { get; set; }
        public string InsulateState { get; set; }
        public string BatConnState { get; set; }
        public string ChargePermitState { get; set; }     
        public string BSMPeriod { get; set; }

        //BST
        //--BMS终止充电原因：
        public string TargetSOC { get; set; }
        public string TargetSettingV { get; set; }
        public string TargetSingleV { get; set; }
        public string BmsPause { get; set; }

        //--BMS终止充电故障原因
        public string InsulateTrouble { get; set; }
        public string OutputConnTrouble { get; set; }
        public string BmsConnTrouble { get; set; }
        public string ChargeConnTrouble { get; set; }
        public string BatTempTrouble { get; set; }
        public string RelayTrouble { get; set; }
        public string Detection2Trouble { get; set; }
        public string OtherTrouble { get; set; }

        //--BMS终止充电错误原因
        public string OverI { get; set; }
        public string VoltTrouble { get; set; }
        public string BSTPeriod { get; set; }
    }
}
