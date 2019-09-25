using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPCar.Prj.Model;
using XPCar.Common;
using System.Threading;

namespace XPCar.Client
{
    public partial class frmChargePara : UserControl
    {
        public frmChargePara()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.tlpChargePara.Dock = DockStyle.Fill;
            Prj.Prj.GeneralController.UpdateChargePara += this.HandleUpdateChargePara;
        }
        private void ShowMessageBox(string text)
        {
            ThreadPool.QueueUserWorkItem(a =>
            {
                MessageBox.Show(text);
            }, null);
        }
        private void HandleUpdateChargePara(GetChargePara data)
        {
            Action async = delegate ()
            {
                lblDate.Text = data.DateYear + "年" + data.DateMonth + "月" + data.DateDay + "日"
                            + data.DateHour + "时" + data.DateMinute + "分" + data.DateSecond + "秒";
                lblReqSync.Text = data.ReqSync;
                lblMaxV.Text = data.MaxOutputV;
                lblMinV.Text = data.MinOutputV;
                lblMaxI.Text = data.MaxOutputI;
                lblMinI.Text = data.MinOutputI;
                lblReadyState.Text = data.ReadyState;
            };
            this.BeginInvoke(async);
        }
        private bool IsInputMatchOk()
        {
            bool isMatch = true;
            isMatch &= MatchCheck.IsInt(tbMaxSingleV.Text);
            isMatch &= MatchCheck.IsInt(tbMaxTemp.Text);
            isMatch &= MatchCheck.IsInt(tbEnergy.Text);
            isMatch &= MatchCheck.IsInt(tbCurBatV.Text);
            isMatch &= MatchCheck.IsInt(tbMaxChargeI.Text);
            isMatch &= MatchCheck.IsInt(tbMaxChargeV.Text);
            isMatch &= MatchCheck.IsInt(tbSoc.Text);
            isMatch &= MatchCheck.IsInt(tbBCPPeriod.Text);
            isMatch &= MatchCheck.IsDouble(tbBROPeriod.Text);

            return isMatch;

        }

        private void BtnSetChargePara_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsInputMatchOk() == false)
                {
                    ShowMessageBox(KeyConst.MdiText_Common.Illegal);
                    return;
                }

                SettingChargePara data = new SettingChargePara();
                data.MaxSingleV = tbMaxSingleV.Text;
                data.MaxTemp = tbMaxTemp.Text;
                data.Energy = tbEnergy.Text;
                data.CurBatVolt = tbCurBatV.Text;
                data.MaxChargeI = tbMaxChargeI.Text;
                data.MaxChargeV = tbMaxChargeV.Text;
                data.SOC = tbSoc.Text;
                data.BCPPeriod = tbBCPPeriod.Text;
                data.ReadyState = GetReadyState();
                data.BROPeriod = tbBROPeriod.Text;

                Prj.Prj.SendProtocolManager.SendChargeParaSet(data);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private string GetReadyState()
        {
            if (rdoReady.Checked == true)
                return "AA";
            else return "00";
        }
    }
}
