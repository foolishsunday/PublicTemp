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
    public partial class frmCharging : UserControl
    {
        private string H00 = "00";
        private string H01 = "01";
        private string H10 = "10";
        public frmCharging()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.tlpChargePara.Dock = DockStyle.Fill;
            Prj.Prj.GeneralController.UpdateCharging += this.HandleUpdateCharging;
        }
        private void HandleUpdateCharging(GetCharging data)
        {
            Action async = delegate ()
            {
                lblOutputV.Text = data.OutputV;
                lblOutputI.Text = data.OutputI;
                lblChargeTime.Text = data.ChargeTime;
                lblChargePermit.Text = data.PermitState;

                lblConditionPause.Text = data.ConditionPause;
                lblManPause.Text = data.ManPause;
                lblTroublePause.Text = data.TroublePause;
                lblBmsPause.Text = data.BMSPause;

                lblHighTimeTrouble.Text = data.HighTempTrouble;
                lblConnTrouble.Text = data.ConnTrouble;
                lblInnerTrouble.Text = data.InnerTrouble;
                lblTransferTrouble.Text = data.TransferTrouble;
                lblEmergencyStop.Text = data.EmergencyStopTrouble;
                lblOtherTrouble.Text = data.OtherTrouble;

                lblMismatchI.Text = data.MismatchI;
                lblUnusualV.Text = data.UnusualV;

            };
            this.BeginInvoke(async);
        }

        private void BtnSetCharging_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsInputMatchOk() == false)
                {
                    ShowMessageBox(KeyConst.MdiText_Common.Illegal);
                    return;
                }

                SettingCharging data = new SettingCharging();

                data.ReqV = tbReqV.Text;
                data.ReqI = tbReqI.Text;
                data.ChargeMode = rdoChargI.Checked == true ? "02" : "01";
                data.BCLPeriod = tbBCLPeriod.Text;

                data.MeasureV = tbMeasureV.Text;
                data.MeasureI = tbMeasureI.Text;
                data.CurSOC = tbSoc.Text;
                data.RemainTime = tbRemainTime.Text;
                data.MaxSingleBatV = tbMaxSingleBatV.Text;
                data.MaxSingleBatGrpNum = tbMaxSingleBatGrpNum.Text;
                data.BCSPeriod = tbBCSPeriod.Text;

                data.MaxSingleBatVNum = tbMaxSingleBatVNum.Text;
                data.MaxBatTemp = tbMaxBatTemp.Text;
                data.MaxTempDetectionNum = tbMaxTempDetectionNum.Text;
                data.MinBatTemp = tbMinBatTemp.Text;
                data.MinTempDetectionNum = tbMinTempDetectionNum.Text;
                data.BSMPeriod = tbBSMPeriod.Text;

                data.BitStateSingleV = GetPanelState(pnlSingleOverV);
                data.BitStateSOC = GetPanelState(pnlSocHighLow);
                data.BitStateOverI = GetPanelState(pnlBatOverI);
                data.BitStateOverTemp = GetPanelState(pnlOverTemp);
                data.BitStateInsulate = GetPanelState(pnlInsulateState);
                data.BitStateConnState = GetPanelState(pnlConnState);
                data.BitStateChargePermit = GetPanelState(pnlChargePermit);

                //BST 中止原因
                data.AchievedSOC = GetPanelState(pnlAchievedSoc);
                data.AchievedTotalV = GetPanelState(pnlAchievedTotalV);
                data.AchievedSingleV = GetPanelState(pnlAchievedSingleV);
                data.BmsPause = GetPanelState(pnlBmsPause);

                //故障原因
                data.InsulateTrouble = GetPanelState(pnlInsulateTrouble);
                data.OutputConnTrouble = GetPanelState(pnlOutputConnTrouble);
                data.BmsConnTempTrouble = GetPanelState(pnlBmsConnTempTrouble);
                data.ChargeConnTrouble = GetPanelState(pnlChargeConnTrouble);
                data.BatOverTempTrouble = GetPanelState(pnlBatOverTempTrouble);
                data.Detection2Trouble = GetPanelState(pnlDetection2Trouble);
                data.RelayTrouble = GetPanelState(pnlRelayTrouble);
                data.OtherTrouble = GetPanelState(pnlOtherTrouble);

                data.OverIError = GetPanelState(pnlOverIError);
                data.UnusualVError = GetPanelState(pnlUnusualVError);
                data.BSTPeriod = tbBSTPeriod.Text;

                //错误原因 

                Prj.Prj.SendProtocolManager.SendChargingSet(data);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private string GetPanelState(Panel pnl)
        {
            foreach (Control c in pnl.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton btn = ((RadioButton)c);
                    if (btn.Checked == true)
                    {
                        if (btn.Text == "正常" || btn.Text == "未达到" || btn.Text == "禁止")
                            return H00;
                        else if (btn.Text == "不可信" || btn.Text == "过低")
                            return H10;
                        else
                            return H01;
                    }
                }
            }
            return H10;
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
            isMatch &= MatchCheck.IsDouble(tbReqV.Text);
            isMatch &= MatchCheck.IsDouble(tbReqI.Text);
            isMatch &= MatchCheck.IsInt(tbRemainTime.Text);
            isMatch &= MatchCheck.IsInt(tbBCLPeriod.Text);

            isMatch &= MatchCheck.IsDouble(tbMeasureV.Text);
            isMatch &= MatchCheck.IsDouble(tbMeasureI.Text);
            isMatch &= MatchCheck.IsInt(tbSoc.Text);
            isMatch &= MatchCheck.IsInt(tbRemainTime.Text);
            isMatch &= MatchCheck.IsDouble(tbMaxSingleBatV.Text);
            isMatch &= MatchCheck.IsInt(tbMaxSingleBatGrpNum.Text);
            isMatch &= MatchCheck.IsInt(tbBCSPeriod.Text);

            isMatch &= MatchCheck.IsInt(tbMaxSingleBatVNum.Text);
            isMatch &= MatchCheck.IsInt(tbMaxBatTemp.Text);
            isMatch &= MatchCheck.IsInt(tbMaxTempDetectionNum.Text);
            isMatch &= MatchCheck.IsInt(tbMinBatTemp.Text);
            isMatch &= MatchCheck.IsInt(tbMinTempDetectionNum.Text);
            isMatch &= MatchCheck.IsInt(tbBSMPeriod.Text);

            isMatch &= MatchCheck.IsInt(tbBSTPeriod.Text);

            return isMatch;

        }

        private void BtnSetChargingBST_Click(object sender, EventArgs e)
        {
            BtnSetCharging_Click(sender, e);
        }

        private void BtnSetChargingBSM_Click(object sender, EventArgs e)
        {
            BtnSetCharging_Click(sender, e);
        }

        private void BtnSetChargingBCS_Click(object sender, EventArgs e)
        {
            BtnSetCharging_Click(sender, e);
        }

        private void BtnSetChargingBCL_Click(object sender, EventArgs e)
        {
            BtnSetCharging_Click(sender, e);
        }
    }
}
