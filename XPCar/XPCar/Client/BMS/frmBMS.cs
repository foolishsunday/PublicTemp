using System;

using System.Windows.Forms;
using XPCar.Common;

namespace XPCar.Client.BMS
{
    public partial class frmBMS : UserControl
    {
        private frmHandshake _frmHandshake;
        private frmChargePara _frmChargePara;
        private frmCharging _frmCharging;
        private frmChargeStop _frmChargeStop;
        public frmBMS()
        {
            InitializeComponent();
        }
        public void EnterBMSPage()
        {
            tbcBMS_SelectedIndexChanged(null, null);
        }

        private void tbcBMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcBMS.SelectedTab.Name == "tbpHandshake")
            {
                if (_frmHandshake == null)
                {
                    _frmHandshake = new frmHandshake();
                    _frmHandshake.Dock = DockStyle.Fill;
                    tbpHandshake.Controls.Add(_frmHandshake);
                }
                Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.Handshake);
            }
            else if (tbcBMS.SelectedTab.Name == "tbpChargePara")
            {
                if (_frmChargePara == null)
                {
                    _frmChargePara = new frmChargePara();
                    _frmChargePara.Dock = DockStyle.Fill;
                    tbpChargePara.Controls.Add(_frmChargePara);
                }
                Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.ChargeParaGet);

            }
            else if (tbcBMS.SelectedTab.Name == "tbpCharging")
            {
                if (_frmCharging == null)
                {
                    _frmCharging = new frmCharging();
                    _frmCharging.Dock = DockStyle.Fill;
                    tbpCharging.Controls.Add(_frmCharging);
                }
                Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.ChargingGet);
            }
            else if (tbcBMS.SelectedTab.Name == "tbpChargeStop")
            {
                if (_frmChargeStop == null)
                {
                    _frmChargeStop = new frmChargeStop();
                    _frmChargeStop.Dock = DockStyle.Fill;
                    tbpChargeStop.Controls.Add(_frmChargeStop);
                }
                Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.ChargeStop);
            }
        }
    }
}
