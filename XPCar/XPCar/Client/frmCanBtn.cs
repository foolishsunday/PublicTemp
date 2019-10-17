using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPCar.Common;
using System.IO;
using System.Threading;

namespace XPCar.Client
{
    public delegate void ClearCanMsgHandle();
    public partial class frmCanBtn : UserControl
    {
        public event ClearCanMsgHandle ClearCanMsg;
        public frmCanBtn()
        {
            InitializeComponent();
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
        private void BtnCanCatch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Prj.Prj.MainController.IsCatchOpen())
                {
                    Prj.Prj.MainController.CloseCatch();
                    Prj.Prj.SendProtocolManager.SendCanClose();
                    btnCanCatch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
                }
                else
                {
                    Prj.Prj.MainController.OpenCatch();
                    Prj.Prj.SendProtocolManager.SendTimeSyncSet();
                    Thread.Sleep(100);
                    Prj.Prj.SendProtocolManager.SendCanOpen();
                    btnCanCatch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        public void PressClearButton()
        {
            BtnClearCan_Click(null, null);
        }
        private void BtnClearCan_Click(object sender, EventArgs e)
        {
            try
            {
                Action async = delegate ()
                {
                    Prj.Prj.CSVManager.Reset();
                    Prj.Prj.CanMsgController.Reset();
                    Prj.Prj.RepositoryManager.Reset();
                    Prj.Prj.ValueManager.Reset(); //add for 时间增量
                    Prj.Prj.StatisticsController.Reset();
                    //tsslbCSV.Text = " 实时保存 : 未保存";
                    //_frmMsgCan.ClearCanMsg();
                    if (ClearCanMsg != null)
                        ClearCanMsg();
                    btnSaveCSV.ForeColor = SystemColors.ControlText;

                };
                this.BeginInvoke(async);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private void BtnSaveCSV_Click(object sender, EventArgs e)
        {
            try
            {
                Action async = delegate ()
                {
                    SaveFileDialog sfd = new SaveFileDialog();  //选择路径
                    sfd.Filter = "csv文件(*.csv)|*.csv|所有文件(*.*)|*.*";
                    sfd.OverwritePrompt = false;
                    DialogResult rs = sfd.ShowDialog();

                    if (rs != DialogResult.OK)
                    {
                        return;
                    }
                    string path = sfd.FileName;

                    if (!File.Exists(path))
                    {
                        if (Prj.Prj.CSVManager.Create(path))
                        {
                            this.btnSaveCSV.ForeColor = SystemColors.Highlight;
                        }
                        Prj.Prj.CSVManager.CSVPath = path;
                        Prj.Prj.CSVManager.StartSave();
                        //this.tsslbCSV.Text = " 实时保存 : 已保存";
                        //this.ssBottom.Refresh();
                        ShowMessageBox("文件已实时保存！");
                    }
                    else
                    {
                        ShowAlarm("文件已存在！请选择正确的保存路径！");
                    }

                    this.btnSaveCSV.Refresh();

                };
                this.BeginInvoke(async);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private void BtnCanPause_Click(object sender, EventArgs e)
        {
            try
            {
                Action async = delegate ()
                {
                    if (!Prj.Prj.CanMsgController.IsPause())
                    {
                        Prj.Prj.CanMsgController.SetCanPause(true);
                        this.btnCanPause.Text = "继续";
                    }
                    else
                    {
                        Prj.Prj.CanMsgController.SetCanPause(false);
                        this.btnCanPause.Text = "暂停显示";
                    }
                };
                this.BeginInvoke(async);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string fold = Path.GetDirectoryName(Prj.Prj.CSVManager.CSVPath);
                if (Directory.Exists(fold))
                    System.Diagnostics.Process.Start("explorer.exe", fold);
                else
                {
                    ShowAlarm("文件夹不存在：" + fold);
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private void cbTranslate_CheckedChanged(object sender, EventArgs e)
        {
            Prj.Prj.ValueManager.EnableTranslate = cbTranslate.Checked;
        }
    }
}
