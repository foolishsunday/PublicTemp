using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using ToggleButton;
using System.Windows.Forms;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Controller;
using System.Threading;
using XPCar.Prj.Model;
using System.IO;
using XPCar.Sys.IO.DocFile;

namespace XPCar.Client
{
    public partial class frmInterop : UserControl
    {
        private InteropController _InteropController;
        private BitHelper _BitHelper;
        private frmInteropResult _frmInteropResult;
        //private int _MaxObjectNo;
        private bool _IsInput;  //光标在panel上
        public frmInterop()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            try
            {
                AddCheckBox();
                DbService db = new DbService();
                this.dgvInterop.DataSource = db.QueryTestInterop();

                _InteropController = new InteropController();
                DisableSortMode();
                _BitHelper = new BitHelper(32);
                Prj.Prj.GeneralController.UpdateInteropCtrl += this.HandleUpdateInteropCtrl;
                Prj.Prj.GeneralController.UpdateDCItem += this.HandleUpdateDCItem;

            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            
        }

        #region dgvInterop
        private void AddCheckBox()
        {
            try
            {
                DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
                newColumn.HeaderText = "";
                this.dgvInterop.Columns.Insert(0, newColumn);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void FrmInterop_Paint(object sender, PaintEventArgs e)
        {
            Action async = delegate ()
            {
                HandleUpdateDCItem();
            };
            this.BeginInvoke(async);
        }
        private void DisableSortMode()
        {
            try
            {
                for (int i = 0; i < this.dgvInterop.Columns.Count; i++)
                {
                    this.dgvInterop.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void SetBackColor(int objNo, Color color)
        {
            try
            {
                if (objNo < 0 || objNo > dgvInterop.Rows.Count) return;

                for (int i = 0; i < dgvInterop.Rows.Count; i++)
                {
                    if (dgvInterop.Rows[i].Cells[1].Value.ToString() == objNo.ToString())
                    {
                        this.dgvInterop.Rows[i].DefaultCellStyle.BackColor = color;
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void BtnDCTest_Click(object sender, EventArgs e)
        {
            try
            {
                Action async = delegate ()
                {
                    SetBackColor(_InteropController.SelectedObjNo, Color.SteelBlue);
                };
                this.BeginInvoke(async);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void HandleUpdateDCItem()
        {
            try
            {
                DbService db = new DbService();
                List<TestInterop> list = db.QueryTestInteropAll();
                if (list != null && list.Count > 0)
                {
                    foreach (TestInterop ele in list)
                    {
                        //SetBackColor(ele.ObjectNo, Color.Red);
                        if (ele.TestResult == "合格")
                            SetBackColor(ele.ObjectNo, Color.Green);
                        else if (ele.TestResult == "不合格")
                            SetBackColor(ele.ObjectNo, Color.Red);
                        else
                            SetBackColor(ele.ObjectNo, Color.Silver);

                    }
                    //_MaxObjectNo = list.Count;
                }

            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

        }
        private void BtnDCViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_frmInteropResult != null)
                {
                    _frmInteropResult.Close();
                    _frmInteropResult.Dispose();
                }
                _frmInteropResult = new frmInteropResult();
                _frmInteropResult.Show();
                _frmInteropResult.Init(_InteropController.SelectedObjNo);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void DgvInterop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvInterop.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ck = dgvInterop.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                    if (i != e.RowIndex)
                        ck.Value = false;
                    else
                    {
                        string selectedObjNo = dgvInterop.Rows[i].Cells[1].Value.ToString();
                        if (selectedObjNo == _InteropController.SelectedObjNo.ToString())
                        {
                            ck.Value = false;
                            _InteropController.SelectedObjNo = -1;
                        }
                        else
                        {
                            ck.Value = true;
                            _InteropController.SelectedObjNo = Convert.ToInt32(selectedObjNo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        #endregion dgvInterop

        #region 设置控制导引测试 
        private void OnlyOneAllowedOpen(TableLayoutPanel tlp, object sender)
        {
            try
            {
                SlideButton slb = (SlideButton)sender;
                if (slb.Checked == false)   //实现效果：已开启的按钮，再点一次还是开启
                {
                    slb.Checked = true;
                    return;
                }
                foreach (Control pnl in tlp.Controls)
                {
                    if (pnl is Panel)
                    {
                        foreach (Control c in pnl.Controls)
                        {
                            if (c is SlideButton)
                            {
                                if (((SlideButton)c).Name == slb.Name)
                                {
                                }
                                else
                                {
                                    ((SlideButton)c).Checked = false;
                                }
                            }
                        }
                    }
                }
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
        private void CommonSend()
        {
            try
            {
                int rValue = 0;
                double batV = 0;
                if (int.TryParse(tbRValue.Text, out rValue) == false)
                {
                    ShowMessageBox(KeyConst.MdiText_Common.Illegal);
                    return;
                }
                if (double.TryParse(tbBatVolt.Text, out batV) == false)
                {
                    ShowMessageBox(KeyConst.MdiText_Common.Illegal);
                    return;
                }
                else
                {
                    if (rValue > 65535 || rValue < 0)
                    {
                        ShowMessageBox("设置失败！R4阻值设置已超出允许范围！");
                        return;
                    }
                    if (batV > 65535 || batV < 0)
                    {
                        ShowMessageBox("设置失败！电池电压值设置已超出允许范围！");
                        return;
                    }
                }

                TraversePanel(tlpDCP);
                TraversePanel(tlpDCM);
                TraversePanel(tlpCtrl);

                SettingDC data = new SettingDC();
                data.RValue = rValue;
                data.BatVolt = batV;
                data.IoState = _BitHelper.GetValueResult();
                Prj.Prj.SendProtocolManager.SendInteropDcSet(data);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void TraversePanel(TableLayoutPanel tlp)
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
                                int index = GetIoStateBitInedex(slb.Name);
                                _BitHelper.SetBitValue(index, slb.Checked);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void DcpButtonSetting(object sender)
        {
            OnlyOneAllowedOpen(tlpDCP, sender);
            CommonSend();
        }
        private void DcmButtonSetting(object sender)
        {
            OnlyOneAllowedOpen(tlpDCM, sender);   
            CommonSend();
        }
        private void CtrlButtonSetting(object sender)
        {
            CommonSend();
        }
        private int GetIoStateBitInedex(string name)
        {
            //SlideButton slb = (SlideButton)sender;
            //string name = slb.Name;
            switch (name)
            {
                case "slbDCPtoGroud":
                    return 0;
                case "slbDCP229":
                    return 1;
                case "slbDCP248":
                    return 2;
                case "slbDCP297":
                    return 3;
                case "slbDCP33":
                    return 4;
                case "slbDCP75":
                    return 5;
                case "slbDCP100":
                    return 6;
                case "slbDCP300":
                    return 7;
                case "slbDCMtoGround":
                    return 8;
                case "slbDCM229":
                    return 9;
                case "slbDCM248":
                    return 10;
                case "slbDCM297":
                    return 11;
                case "slbDCM33":
                    return 12;
                case "slbDCM75":
                    return 13;
                case "slbDCM100":
                    return 14;
                case "slbDCM300":
                    return 15;
                case "slbReverseConn":
                    return 16;
                case "slbCtrlPE":
                    return 17;
                case "slbCtrlDCP":
                    return 18;
                case "slbCtrlDCM":
                    return 19;
                case "slbCtrlSP":
                    return 20;
                case "slbCtrlSM":
                    return 21;
                case "slbCtrlCC1":
                    return 22;
                case "slbCtrlCC2":
                    return 23;
                case "slbCtrlAP":
                    return 24;
                case "slbCtrlAM":
                    return 25;
                case "slbOverVoltCtrl":
                    return 26;
            }
            return 0;
        }
        private void SetPanelState(string state, TableLayoutPanel tlp)
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
                                int index = GetIoStateBitInedex(c.Name);
                                ((SlideButton)c).Checked = GetStateByIndex(index, state);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void HandleUpdateInteropCtrl(SettingDC data)
        {
            try
            {
                string state = data.BinaryState;

                Action async = delegate ()
                {
                    if (tbRValue.Focused || tbBatVolt.Focused || _IsInput)
                    {
                        if (tbRValue.BackColor != SystemColors.Window)
                        {
                            tbRValue.BackColor = SystemColors.Window;
                            tbBatVolt.BackColor = SystemColors.Window;
                        }
                    }
                    else
                    {
                        tbRValue.Text = data.RValue.ToString();
                        tbBatVolt.Text = data.BatVolt.ToString("f1");
                        if (tbRValue.BackColor != SystemColors.ControlLight)
                        {
                            tbRValue.BackColor = SystemColors.ControlLight;
                            tbBatVolt.BackColor = SystemColors.ControlLight;
                        }
                    }
                    SetPanelState(state, tlpDCP);
                    SetPanelState(state, tlpDCM);
                    SetPanelState(state, tlpCtrl);
                };
                this.BeginInvoke(async);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private bool GetStateByIndex(int index, string state)
        {
            if (state.Substring(index, 1) == "0")
                return false;
            else
                return true;
        }
        #endregion 设置控制导引测试 
        #region 设置按钮
        private void BtnSetRValue_Click(object sender, EventArgs e)
        {
            CommonSend();
        }
        #endregion 设置按钮
        #region panel DC+
        private void SlbDCPtoGroud_Click(object sender, EventArgs e)
        {
            DcpButtonSetting(sender);
        }
        private void SlbDCP229_Click(object sender, EventArgs e)
        {
            DcpButtonSetting(sender);
        }      

        private void SlbDCP248_Click(object sender, EventArgs e)
        {
            DcpButtonSetting(sender);
        }

        private void SlbDCP297_Click(object sender, EventArgs e)
        {
            DcpButtonSetting(sender);
        }

        private void SlbDCP33_Click(object sender, EventArgs e)
        {
            DcpButtonSetting(sender);
        }

        private void SlbDCP75_Click(object sender, EventArgs e)
        {
            DcpButtonSetting(sender);
        }

        private void SlbDCP100_Click(object sender, EventArgs e)
        {
            DcpButtonSetting(sender);
        }

        private void SlbDCP300_Click(object sender, EventArgs e)
        {
            DcpButtonSetting(sender);
        }
        #endregion panel DC+
        #region panel DC- 
        private void SlbDCMtoGround_Click(object sender, EventArgs e)
        {
            DcmButtonSetting(sender);
        }

        private void SlbDCM229_Click(object sender, EventArgs e)
        {
            DcmButtonSetting(sender);
        }

        private void SlbDCM248_Click(object sender, EventArgs e)
        {
            DcmButtonSetting(sender);
        }

        private void SlbDCM297_Click(object sender, EventArgs e)
        {
            DcmButtonSetting(sender);
        }

        private void SlbDCM33_Click(object sender, EventArgs e)
        {
            DcmButtonSetting(sender);
        }

        private void SlbDCM75_Click(object sender, EventArgs e)
        {
            DcmButtonSetting(sender);
        }

        private void SlbDCM100_Click(object sender, EventArgs e)
        {
            DcmButtonSetting(sender);
        }

        private void SlbDCM300_Click(object sender, EventArgs e)
        {
            DcmButtonSetting(sender);
        }
        #endregion panel DC- 
        #region panel Ctrl
        private void SlbCtrlPE_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }

        private void SlbCtrlDCP_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }

        private void SlbCtrlDCM_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }

        private void SlbCtrlSP_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }

        private void SlbCtrlSM_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }

        private void SlbCtrlCC1_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }

        private void SlbCtrlCC2_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }

        private void SlbCtrlAP_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }

        private void SlbCtrlAM_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }

        private void SlbReverseConn_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }
        private void SlbOverVoltCtrl_Click(object sender, EventArgs e)
        {
            CtrlButtonSetting(sender);
        }
        #endregion panel Ctrl

        private void BtnDCExport_Click(object sender, EventArgs e)
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
            catch(Exception ex)
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
                List<TestInterop> report = db.QueryModel<TestInterop>();

                string dotPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @".\Config\InteropTemp.dot";
                //WordManager word = new WordManager(path, dotPath);
                AsposeWordManager word = new AsposeWordManager(path, dotPath);
                word.SaveInterop(report);
                ShowMessageBox("输出报告成功！");
            }
            catch(Exception ex)
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
        private void BtnDCReset_Click(object sender, EventArgs e)
        {
            try
            {
                DbService db = new DbService();
                db.DeleteTestInteropResult();
                //for (int i = 1; i <= _MaxObjectNo; i++)
                //{
                //    db.UpdateTestInterop(i, "");
                //}
                HandleUpdateDCItem();
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private void BtnSetRValue_MouseEnter(object sender, EventArgs e)
        {
            _IsInput = true;
        }

        private void BtnSetRValue_MouseLeave(object sender, EventArgs e)
        {
            _IsInput = false;
        }

        private void BtnSetBatVolt_Click(object sender, EventArgs e)
        {
            CommonSend();
        }

        private void BtnSetBatVolt_MouseEnter(object sender, EventArgs e)
        {
            _IsInput = true;
        }

        private void BtnSetBatVolt_MouseLeave(object sender, EventArgs e)
        {
            _IsInput = false;
        }
    }
}
