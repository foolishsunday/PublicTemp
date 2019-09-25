using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPCar.Prj.Model;
using System.Threading;
using XPCar.Common;

namespace XPCar.Client
{
    public partial class frmChargeStop : UserControl
    {
        public frmChargeStop()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.tlpChargeStop.Dock = DockStyle.Fill;
            Prj.Prj.GeneralController.UpdateChargeStop += this.HandleUpdateChargeStop;
        }
        private void HandleUpdateChargeStop(GetChargeStop data)
        {
            Action async = delegate ()
            {
                lblChargeTime.Text = data.ChargeTime;
                lblEnergy.Text = data.Energy;
                lblEqNum.Text = data.EqNum;
            };
            this.BeginInvoke(async);
        }
        private void BtnSetChargeStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsInputMatchOk() == false)
                {
                    ShowMessageBox(KeyConst.MdiText_Common.Illegal);
                    return;
                }

                SettingChargeStop data = new SettingChargeStop();
                data.PauseSoc = tbSoc.Text;
                data.MinSingleV = tbMinV.Text;
                data.MinTemp = tbMinTemp.Text;
                data.MaxSingleV = tbMaxV.Text;
                data.MaxTemp = tbMaxTemp.Text;
                data.BSDPeriod = tbBSDPeriod.Text;

                Prj.Prj.SendProtocolManager.SendChargeStopSet(data);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void ShowMessageBox(string text)
        {
            ThreadPool.QueueUserWorkItem(a =>
            {
                MessageBox.Show(text);
            }, null);
        }
        private bool IsInputMatchOk()
        {
            bool isMatch = true;
            isMatch &= MatchCheck.IsInt(tbSoc.Text);
            isMatch &= MatchCheck.IsDouble(tbMinV.Text);
            isMatch &= MatchCheck.IsDouble(tbMaxV.Text);
            isMatch &= MatchCheck.IsInt(tbMinTemp.Text);
            isMatch &= MatchCheck.IsInt(tbMaxTemp.Text);
            isMatch &= MatchCheck.IsInt(tbBSDPeriod.Text);

            return isMatch;

        }
    }
}
