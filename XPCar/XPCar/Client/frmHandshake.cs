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
    public partial class frmHandshake : UserControl
    {
        public frmHandshake()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.tlpHandshake.Dock = DockStyle.Fill;
            //numericUpDown1.Controls[0].Visible = false;

            Prj.Prj.GeneralController.UpdateHandShake += this.HandleUpdateHandshake;
        }
        private void HandleUpdateHandshake(GetHandShake data)
        {
            Action async = delegate ()
            {
                lblValue_Version.Text = data.Version;
                lblValue_Recognized.Text = data.RecognizedResult;
                lblValue_EQNum.Text = data.EQNum;
                lblValue_Area.Text = data.Area;

            };
            this.BeginInvoke(async);
        }

        private void BtnSendHandshake_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsInputMatchOk() == false)
                {
                    ShowMessageBox(KeyConst.MdiText_Common.Illegal);
                    return;
                }
                SettingHandshake data = new SettingHandshake();
                data.BHMPeriod = tbBHMPeriod.Text;
                data.MaxV = tbMaxV_BHM.Text;

                data.VerH = tbVerHigh.Text;
                data.VerL = tbVerLow.Text;
                data.BatType = GetBatType();
                data.BatCapacity = tbBatCapacity.Text;
                data.BatTotalV = tbBatTotalV.Text;
                data.Vendor = tbVendor.Text;
                data.BatNum = tbBatNum.Text;
                data.ProduceYear = tbProduceYear.Text;
                data.ProduceMonth = tbProduceMonth.Text;
                data.ProduceDay = tbProduceDay.Text;
                data.ChargeCnt = tbChargeCnt.Text;
                data.Vin = tbVin.Text;
                data.Property = rdoPrivate.Checked == true ? "01" : "00";
                data.BRMPeriod = tbBRMPeriod.Text;

                Prj.Prj.SendProtocolManager.SendHandshakeSet(data);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private string GetBatType()
        {
            foreach (Control c in pnlBatType.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rdo = (RadioButton)c;
                    if (rdo.Checked)
                    {
                        return GetBatTypeHex(rdo.Text);
                    }
                }
            }
            return "00";
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
            isMatch &= MatchCheck.IsDouble(tbMaxV_BHM.Text);
            isMatch &= MatchCheck.IsInt(tbBHMPeriod.Text);
            isMatch &= MatchCheck.IsInt(tbVerHigh.Text);
            isMatch &= MatchCheck.IsInt(tbVerLow.Text);
            isMatch &= MatchCheck.IsInt(tbBRMPeriod.Text);
            isMatch &= MatchCheck.IsDouble(tbBatCapacity.Text);
            isMatch &= MatchCheck.IsDouble(tbBatTotalV.Text);
            isMatch &= MatchCheck.IsNumAndChar(tbVendor.Text);
            isMatch &= MatchCheck.IsInt(tbBatNum.Text);
            isMatch &= MatchCheck.IsInt(tbProduceYear.Text);
            isMatch &= MatchCheck.IsInt(tbProduceMonth.Text);
            isMatch &= MatchCheck.IsInt(tbProduceDay.Text);
            isMatch &= MatchCheck.IsInt(tbChargeCnt.Text);
            isMatch &= MatchCheck.IsNumAndChar(tbVin.Text);

            return isMatch;

        }
        public static string GetBatTypeHex(string sType)
        {
            string bat = string.Empty;
            switch (sType)
            {
                case "铅酸电池":
                    bat = KeyConst.BatteryType.H01;
                    break;
                case "镍氢电池":
                    bat = KeyConst.BatteryType.H02;
                    break;
                case "磷酸铁锂电池":
                    bat = KeyConst.BatteryType.H03;
                    break;
                case "锰酸锂电池":
                    bat = KeyConst.BatteryType.H04;
                    break;
                case "钴酸锂电池":
                    bat = KeyConst.BatteryType.H05;
                    break;
                case "三元材料电池":
                    bat = KeyConst.BatteryType.H06;
                    break;
                case "聚合物锂离子电池":
                    bat = KeyConst.BatteryType.H07;
                    break;
                case "钛酸锂电池":
                    bat = KeyConst.BatteryType.H08;
                    break;
                case "其他电池":
                    bat = KeyConst.BatteryType.HFF;
                    break;
                default:
                    bat = "Undefined";
                    break;
            }
            return bat;
        }
    }
}
