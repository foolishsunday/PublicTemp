using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Controller
{
    public delegate void UpdateUpgradeStateHandle(string state); 
    public class UpgradeController
    {
        public event UpdateUpgradeStateHandle UpdateUpgradeState;
        public string BinPath { get; set; }
        private int _UpgradeState;

        public UpgradeController()
        {
            _UpgradeState = 0;
        }
        public void SetUpgradeState(string stateHex)
        {
            string text;
            if (stateHex == "55")
                text = "准备就绪";
            else if(stateHex=="AA")
                text = "升级成功";
            else if (stateHex == "FF")
                text = "升级失败";
            else
                text = "无效";
            if (UpdateUpgradeState != null)
                UpdateUpgradeState(text);
        }
        public void SetReqUpgradeState()
        {
            _UpgradeState = 1;
        }
        public bool IsRequestUpgrade()
        {
            return _UpgradeState == 1 ? true : false;
        }
        public void Reset()
        {
            _UpgradeState = 0;
        }
    }
}
