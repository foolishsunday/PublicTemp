using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPCar.Common;
using XPCar.Prj.Model;
using XPCar.Database;
using XPCar.Prj.Controller;
using ToggleButton;
using System.IO;
using System.Threading;
using XPCar.Sys.IO.DocFile;

namespace XPCar.Client.ACTest
{
    public partial class frmAC : UserControl
    {
        private ACController _ACController;
        private frmACResult _frmACResult;
        public frmAC()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            try
            {
                //Initial controller
                _ACController = new ACController();

                //Initial Form
                this.Dock = DockStyle.Fill;

                //Initial event
                Prj.Prj.GeneralController.UpdateAC += this.HandleUpdateAC;
                Prj.Prj.GeneralController.UpdateACResult += this.UpdateACResult;
                Prj.Prj.GeneralController.UpdateACInterop += this.HandleUpdateACInterop;

                //Initial datagridview
                AddCheckBox();
                UpdateACResult();
                DisableSortMode();
                SetColumnsWidth();
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

        }
        private void SetColumnsWidth()
        {
            dgvAC.Columns[0].Width = 30;
            dgvAC.Columns[1].Width = 40;
            dgvAC.Columns[2].Width = 180;
            dgvAC.Columns[3].Width = 85;
        }
        private void SetBackColor(int objNo, Color color)
        {
            try
            {
                if (objNo < 0 || objNo > dgvAC.Rows.Count) return;

                for (int i = 0; i < dgvAC.Rows.Count; i++)
                {
                    if (dgvAC.Rows[i].Cells[1].Value.ToString() == objNo.ToString())
                    {
                        this.dgvAC.Rows[i].DefaultCellStyle.BackColor = color;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void UpdateACResult()
        {
            try
            {
                DbService db = new DbService();
                DataTable dt = db.QueryTestACAll();
                dgvAC.DataSource = dt;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string testResult = dt.Rows[i][2].ToString();
                        int objectNo = Convert.ToInt32(dt.Rows[i][0].ToString());
                        if (testResult == "合格")
                            SetBackColor(objectNo, Color.Green);
                        else if (testResult == "不合格")
                            SetBackColor(objectNo, Color.Red);
                        else
                            SetBackColor(objectNo, Color.Silver);

                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void DisableSortMode()
        {
            try
            {
                for (int i = 0; i < this.dgvAC.Columns.Count; i++)
                {
                    this.dgvAC.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void AddCheckBox()
        {
            try
            {
                DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
                newColumn.HeaderText = "";
                dgvAC.Columns.Insert(0, newColumn);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void HandleUpdateAC(GetAC data)
        {
            Action async = delegate ()
            {
                this.lblSingle_ChargeV.Text = this.lblA_ChargeV.Text = data.A_ChargeV;
                this.lblSingle_ChargeI.Text = this.lblA_ChargeI.Text = data.A_ChargeI;
                this.lblSingle_ChargeQuantity.Text = this.lblA_ChargeQuantity.Text = data.A_ChargeQuantity;
                this.lblSingle_ChargePower.Text = this.lblA_ChargePower.Text = data.A_ChargePower;
                this.lblSingle_DutyCycle.Text = this.lblA_DutyCycle.Text = data.A_DutyCycle;
                this.lblSingle_CPVolt.Text = this.lblA_CPVolt.Text = data.A_CPVolt;
                this.lblSingle_Frequency.Text = this.lblA_Frequency.Text = data.A_Frequency;
                this.lblSingle_CCRes.Text = this.lblA_CCRes.Text = data.A_CCRes;
                this.lblSingle_GunTemp.Text = this.lblA_GunTemp.Text = data.A_GunTemp;
                this.lblSingle_RatedI.Text = this.lblA_RatedI.Text = data.A_RatedI;
                this.lblSingle_PermitI.Text = this.lblA_PermitI.Text = data.A_PermitI;
                this.lblSingle_ConnState.Text = this.lblA_ConnState.Text = data.A_ConnState;
                this.lblSingle_SysState.Text = this.lblA_SysState.Text = data.A_SysState;


                this.lblB_ChargeV.Text = data.B_ChargeV;
                this.lblB_ChargeI.Text = data.B_ChargeI;
                this.lblB_ChargeQuantity.Text = data.B_ChargeQuantity;
                this.lblB_ChargePower.Text = data.B_ChargePower;
                this.lblB_DutyCycle.Text = data.B_DutyCycle;
                this.lblB_CPVolt.Text = data.B_CPVolt;
                this.lblB_Frequency.Text = data.B_Frequency;
                this.lblB_CCRes.Text = data.B_CCRes;
                this.lblB_GunTemp.Text = data.B_GunTemp;
                this.lblB_RatedI.Text = data.B_RatedI;
                this.lblB_PermitI.Text = data.B_PermitI;
                this.lblB_ConnState.Text = data.B_ConnState;
                this.lblB_SysState.Text = data.B_SysState;

            };
            this.BeginInvoke(async);
        }
        private void HandleUpdateACInterop(GetACInterop data)
        {
            Action async = delegate ()
            {
                SetPanelState(data.BinaryStateX1X2,tlpAGun);
                SetPanelState(data.BinaryStateX3X4, tlpBGun);
            };
            this.BeginInvoke(async);
        }
        private int GetBitIndex(string name)
        {
            switch (name)
            {
                case "slbA_S":
                    return 0;
                case "slbA_FanCtrl":
                    return 1;
                case "slbA_CCDisconnCtrl":
                    return 2;
                case "slbA_CPDisconnCtrl":
                    return 3;
                case "slbA_CPGroundCtrl":
                    return 4;
                case "slbA_PEDisconnCtrl":
                    return 5;
                case "slbA_CCResCtrl":
                    return 6;
                case "slbA_TimingCharge":
                    return 7;

                case "slbB_S":
                    return 16;
                case "slbB_FanCtrl":
                    return 17;
                case "slbB_CCDisconnCtrl":
                    return 18;
                case "slbB_CPDisconnCtrl":
                    return 19;
                case "slbB_CPGroundCtrl":
                    return 20;
                case "slbB_PEDisconnCtrl":
                    return 21;
                case "slbB_CCResCtrl":
                    return 22;
                case "slbB_TimingCharge":
                    return 23;
                default:
                    return 0;
            }
        }
        private bool GetStateByIndex(int index, string state)
        {
            if (state.Substring(index, 1) == "0")
                return false;
            else
                return true;
        }
        private void SetPanelState(string binState, TableLayoutPanel tlp)
        {
            try
            {
                foreach (Control pnl in tlp.Controls)
                {
                    if (pnl is Panel)
                    {
                        foreach (Control c in pnl.Controls)
                        {
                            if (c is SlideButton)
                            {
                                int index = GetBitIndex(c.Name);
                                ((SlideButton)c).Checked = GetStateByIndex(index, binState);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void DgvAC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvAC.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ck = dgvAC.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                    if (i != e.RowIndex)
                        ck.Value = false;
                    else
                    {
                        if (e.RowIndex == _ACController.ItemIndex)
                        {
                            ck.Value = false;
                            _ACController.ItemIndex = -1;
                        }
                        else
                        {
                            ck.Value = true;
                            _ACController.ClickMsgName = dgvAC.Rows[i].Cells[1].Value.ToString();
                            _ACController.ItemIndex = i;
                            //_ACController.ItemIndex = _ACController.GetItemBitsNum(_ConsistController.ClickMsgName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        public void SingleOrDualForm(int gunCnt)
        {
            if (gunCnt == 1)
            {
                tbpChargeGet_Single.Parent = tbcACAll;
                tbpChargeGet_Dual.Parent = null;
            }
            else
            {
                tbpChargeGet_Single.Parent = null;
                tbpChargeGet_Dual.Parent = tbcACAll;
            }
            tbpInterop.Parent = null;
            tbpInterop.Parent = tbcACAll;
        }

        private void ClickSendCmd(object sender)
        {
            try
            {
                BitHelper bits = new BitHelper(32);
                bits = GetCtrlStateByPanel(tlpAGun, bits);
                bits = GetCtrlStateByPanel(tlpBGun, bits);

                SettingACInterop data = new SettingACInterop();
                data.HexState = bits.GetValueResult();

                Prj.Prj.SendProtocolManager.SendACSet(data);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private BitHelper GetCtrlStateByPanel(TableLayoutPanel tlp, BitHelper bits)
        {
            try
            {
                foreach (Control pnl in tlp.Controls)
                {
                    if (pnl is Panel)
                    {
                        foreach (Control c in pnl.Controls)
                        {
                            if (c is SlideButton)
                            {
                                SlideButton slb = (SlideButton)c;
                                int index = GetBitIndex(slb.Name);
                                bool check = CheckIfFlip(slb.Name, slb.Checked);//协议上有6个bit是反的
                                bits.SetBitValue(index, check);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return bits;
        }
        private bool CheckIfFlip(string name, bool check)
        {
            if (name == "slbA_CCDisconnCtrl"
                || name == "slbA_CPDisconnCtrl"
                || name == "slbA_PEDisconnCtrl"
                || name == "slbB_CCDisconnCtrl"
                || name == "slbB_CPDisconnCtrl"
                || name == "slbB_PEDisconnCtrl")
            {
                return !check;//bit翻转
            }
            else
                return check;
        }
        private void BtnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_frmACResult != null)
                {
                    _frmACResult.Close();
                    _frmACResult.Dispose();
                }
                _frmACResult = new frmACResult();
                _frmACResult.Show();
                _frmACResult.Init(_ACController.ItemIndex + 1);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                DbService db = new DbService();
                db.DeleteTestACResult();
                UpdateACResult();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        #region 按键
        private void SlbA_S_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbA_FanCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbA_CCDisconnCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbA_CPDisconnCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }
        private void SlbA_CPGroundCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbA_PEDisconnCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbA_CCResCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbA_TimingCharge_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbB_S_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbB_FanCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbB_CCDisconnCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbB_CPDisconnCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbB_CPGroundCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbB_PEDisconnCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbB_CCResCtrl_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }

        private void SlbB_TimingCharge_Click(object sender, EventArgs e)
        {
            ClickSendCmd(sender);
        }
        #endregion 按键
        private void TbcACAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcACAll.SelectedIndex == 0 || tbcACAll.SelectedIndex == 1)
            {
                Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.ACGet);
            }
            else if (tbcACAll.SelectedIndex == 2)
            {
                Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.ACInterop);
            }
            else { }
        }

        private void BtnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                Action async = delegate ()
                {
                    SaveFileDialog sfd = new SaveFileDialog();  //选择路径
                    sfd.Filter = "Word Files(*.doc)|*.doc";
                    sfd.OverwritePrompt = false;
                    DialogResult rs = sfd.ShowDialog();

                    if (rs != DialogResult.OK)
                    {
                        return;
                    }
                    string path = sfd.FileName;

                    if (!File.Exists(path))
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(ExportReport), path);
                    }
                    else
                    {
                        ShowAlarm("报告已存在！请选择正确的保存路径！");
                    }
                };
                this.BeginInvoke(async);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private void ExportReport(object state)
        {
            try
            {
                string path = (string)state;
                DbService db = new DbService();
                List<TestAC> report = db.QueryModel<TestAC>();

                string dotPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @".\Config\ACTemplate.dot";
                WordManager word = new WordManager(path, dotPath);
                word.SaveTestAC(report);
                ShowMessageBox("输出报告成功！");
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                ShowAlarm("输出报告失败！请联系管理员处理！");
            }
        }
        private void ShowAlarm(string text)
        {
            ThreadPool.QueueUserWorkItem(a =>
            {
                MessageBox.Show(text, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }, null);
        }
        private void ShowMessageBox(string text)
        {
            ThreadPool.QueueUserWorkItem(a =>
            {
                MessageBox.Show(text);
            }, null);
        }

       
    }
}
