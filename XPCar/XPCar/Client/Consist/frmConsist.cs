using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPCar.Database;
using System.Collections;
using XPCar.Prj.Controller;
using System.Threading;
using System.IO;
using XPCar.Prj.Model;
using XPCar.Sys.IO.DocFile;
using XPCar.Common;
using XPCar.Prj.Flow;
using System.Drawing.Drawing2D;

namespace XPCar.Client
{
    public delegate void PressStartBtnHandle(int itemIndex);
    public partial class frmConsist : UserControl
    {
        private frmConsistDetail _frmConsistDetail;
        //private Hashtable _ConsistMap;
        private ConsistController _ConsistController;
        private frmConsistResult _frmConsistResult;
        public event PressStartBtnHandle PressStartBtn;
        private delegate void MyWinDelegate();
        private enum ThreadState
        {
            Run,
            Idle
        }
        private ThreadState _State;
        public frmConsist()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            try
            {
                _ConsistController = Prj.Prj.ConsistController;
                _State = ThreadState.Idle;


                AddCheckBox();

                DbService db = new DbService();
                this.dgvConsist.DataSource = db.QueryConsistItemsAll();

                _ConsistController.SetConsistMap(db);
                Prj.Prj.RepositoryManager.UpdateConsistResult += this.HandleUpdateConsistResult;
                Prj.Prj.GeneralController.FinishConsist += this.HandleFinishConsist;

                DisableSortMode();
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
                for (int i = 0; i < this.dgvConsist.Columns.Count; i++)
                {
                    this.dgvConsist.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch(Exception ex)
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
                dgvConsist.Columns.Insert(0, newColumn);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void DgvConsist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvConsist.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ck = dgvConsist.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                    if (i != e.RowIndex)
                        ck.Value = false;
                    else
                    {
                        if (e.RowIndex == _ConsistController.ItemIndex)
                        {
                            ck.Value = false;
                            _ConsistController.ItemIndex = -1;
                        }
                        else
                        {
                            ck.Value = true;
                            _ConsistController.ClickMsgName = dgvConsist.Rows[i].Cells[1].Value.ToString();
                            _ConsistController.ItemIndex = _ConsistController.GetItemBitsNum(_ConsistController.ClickMsgName);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private void DgvConsist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int selected = e.RowIndex;
                if (selected < 0) return;
                string itemid = dgvConsist.Rows[selected].Cells[1].Value.ToString();
                string condition = dgvConsist.Rows[selected].Cells[2].Value.ToString();
                string step = dgvConsist.Rows[selected].Cells[3].Value.ToString();
                string expected = dgvConsist.Rows[selected].Cells[4].Value.ToString();
                if (_frmConsistDetail != null)
                {
                    _frmConsistDetail.Close();
                    _frmConsistDetail.Dispose();
                }

                _frmConsistDetail = new frmConsistDetail();
                _frmConsistDetail.Show();
                _frmConsistDetail.SetValue(itemid, condition, step, expected);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        public void PressConsistTest()
        {
            BtnConsistTest_Click(null, null);
        }
        public void PressExport()
        {
            BtnExport_Click(null, null);
        }
        public void PressView()
        {
            ViewReport();
        }
        public delegate void ThreadFunDelegate();

        public void PressReset()
        {
            BtnConsistReset_Click(null, null);
        }
        private void BtnConsistTest_Click(object sender, EventArgs e)
        {
            try
            {
                Prj.Prj.SendProtocolManager.SetDisalbeTimingSend(true);
                Thread.Sleep(10);
                Prj.Prj.SendProtocolManager.SendConsistStart(_ConsistController.ItemIndex);
                Thread.Sleep(10);

                _ConsistController.ConsistStarted = true;
                if (_ConsistController.IsSelectedNone())
                {
                    _ConsistController.SelectedMsgName = "";
                }
                else
                {
                    _ConsistController.SelectedMsgName = _ConsistController.ClickMsgName;
                }

                if (PressStartBtn != null)
                    PressStartBtn(_ConsistController.ItemIndex);

                if (!IsNormalTest())
                {
                    for (int i = 0; i < dgvConsist.Rows.Count; i++)
                    {
                        if (dgvConsist.Rows[i].Cells[1].Value.ToString() == _ConsistController.ClickMsgName)
                        {
                            this.dgvConsist.Rows[i].DefaultCellStyle.BackColor = Color.SteelBlue;
                            Prj.Prj.RepositoryManager.WakeupCommit(2);
                            Prj.Prj.RepositoryManager.SetConsistTimeMode(_ConsistController.SelectedMsgName);
                            Prj.Prj.SendProtocolManager.SetDisalbeTimingSend(false);
                            return;
                        }
                    }
                }
                Prj.Prj.SendProtocolManager.SetDisalbeTimingSend(false);
            }
            catch (Exception ex)
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
        private void ShowAlarm(string text)
        {
            ThreadPool.QueueUserWorkItem(a =>
            {
                MessageBox.Show(text, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }, null);
        }
        private void BtnExport_Click(object sender, EventArgs e)
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
                        if (_State == ThreadState.Idle)
                        {
                            _State = ThreadState.Run;

                            ThreadPool.QueueUserWorkItem(new WaitCallback(ExportReport), path);
                            //ShowMessageBox("保存路径成功！请等待报告输出完成！");
                        }
                        else
                        {
                            ShowMessageBox("正在输出报告...");

                        }
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
                List<TestItemsReport> report = db.QueryModel<TestItemsReport>();

                string dotPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @".\Config\template.dot";
                //WordManager word = new WordManager(path, dotPath);
                AsposeWordManager word = new AsposeWordManager(path, dotPath);
                word.Save(report);

                _State = ThreadState.Idle;
                ShowMessageBox("输出报告成功！");
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                ShowAlarm("输出报告失败！请联系管理员处理！");
            }
        }
        //查看勾选项的结果
        private void ViewReport()
        {
            if (_frmConsistResult != null)
            {
                _frmConsistResult.Close();
                _frmConsistResult.Dispose();
            }
            if (string.IsNullOrEmpty(_ConsistController.ClickMsgName)) return;

            _frmConsistResult = new frmConsistResult(_ConsistController.ClickMsgName.Replace(".", ""));
            _frmConsistResult.Show();
        }
        //查看确认测试项的结果
        private void ViewSelectedReport()
        {
            if (_frmConsistResult != null)
            {
                _frmConsistResult.Close();
                _frmConsistResult.Dispose();
            }
            if (string.IsNullOrEmpty(_ConsistController.SelectedMsgName)) return;

            _frmConsistResult = new frmConsistResult(_ConsistController.SelectedMsgName.Replace(".", ""));
            _frmConsistResult.Show();
        }
        private void HandleUpdateConsistResult(string msgName, Function.ConsistResult result)
        {
            try
            {
                for (int i = 0; i < dgvConsist.Rows.Count; i++)
                {
                    string msgFullName = dgvConsist.Rows[i].Cells[1].Value.ToString();
                    if (msgFullName.Replace(".", "") == msgName)
                    {
                        if (result == Function.ConsistResult.OK)
                        {
                            this.dgvConsist.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        }
                        else if (result == Function.ConsistResult.NG)
                            this.dgvConsist.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        else
                        {
                            this.dgvConsist.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private void BtnConsistReset_Click(object sender, EventArgs e)
        {
            try
            {
                Prj.Prj.ConsistController.ConsistStarted = false;
                for (int i = 0; i < dgvConsist.Rows.Count; i++)
                {
                    //Color defalut = this.dgvConsist.Rows[i].DefaultCellStyle.BackColor;
                    this.dgvConsist.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                    Prj.Prj.RepositoryManager.ResetConsistResult();
                }
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            
        }

        private void PnlSplit_Paint(object sender, PaintEventArgs e)
        {
            PanelPaint(sender, e);
        }
        private void PanelPaint(object sender, PaintEventArgs e)
        {
            Panel obj = (Panel)sender;
            Graphics g = e.Graphics;
            Color FColor = Color.White;
            Color TColor = SystemColors.ActiveCaption; //SystemColors.GradientActiveCaption;
            Brush brush;

            if (obj.Name == pnlSplit.Name)
            {
                brush = new LinearGradientBrush(pnlSplit.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);
                g.FillRectangle(brush, pnlSplit.ClientRectangle);
            }
        }
        private void HandleFinishConsist()//一致性测试完，主动弹出结果
        {
      
            if (_ConsistController.ConsistStarted)
            {
                if (IsNormalTest())   //从一致性测试，恢复为正常测试，无须显示一致性测试结果
                    return;
                MyWinDelegate del = new MyWinDelegate(ViewSelectedReport);
                this.BeginInvoke(del);
                //ViewReport();
            }
        }
        private bool IsNormalTest()
        {
            if (string.IsNullOrEmpty(_ConsistController.SelectedMsgName))
                return true;
            else
                return false;
        }
    }
}
