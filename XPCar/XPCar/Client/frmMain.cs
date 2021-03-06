﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using XPCar.Common;
using XPCar.Prj;
using XPCar.Prj.Controller;
using log4net;
using System.IO.Ports;

using XPCar.Client;
using System.IO;
using System.Threading;
using XPCar.Database;
using XPCar.Prj.Model;
using Aplus.Prj.Model;
using XPCar.Sys.IO.DocFile;
using System.Data;
using XPCar.Client.ACTest;
using XPCar.Client.SysUpgrade;
using XPCar.Client.Wave;
using XPCar.Client.Statistics;
using XPCar.Client.Consist;
using XPCar.Client.BMS;

namespace XPCar
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private MainController _MainController;
        private frmMsgCan _frmMsgCan;
        private frmConsist _frmConsist;
        private frmBaseInfo _frmBaseInfo;
        private frmInterop _frmInterop;
        private frmUpgradeWin _frmUpgradeWin;
        private frmCanBtn _frmCanBtn;
        private frmConsistBtn _frmConsistBtn;
        private frmLogin _frmLogin;
        private frmWave _frmWave;
        private frmSoftwareVersion _frmSoftwareVersion;
        private frmStatistics _frmStatistics;
        private frmConsistConfig _frmConsistStd;
        private frmBMS _frmBMS;
#if ST_9980BP
        private frmAC _frmAC;
#endif
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().Name + "()" + ": System Start!");
            Prj.Prj.Init();

            this.Init(Prj.Prj.MainController);

            InitMenu();
            InitComView();
            InitCanMsg();
            InitBaseData();
            InitChargeState();
            InitAlarm();
            InitSendTimer();
            InitBottom();
            InitButton();
#if ST_9980A_DC
            Init9980A();
#elif ST_990_DC
            Init990();
#else
            InitWave();
            InitStatistics();
#endif

#if ST_9980BP
            InitAC();
            InitFrmSize();
#else
            InitDC();
#endif

            //InitSkin();
            this.tbcMain.Dock = DockStyle.Fill;
            this.splContainCan.Dock = DockStyle.Fill;
            this.splContainMain.Dock = DockStyle.Fill;
            Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().Name + "()"+ ": Initial Success!");

        }
#region 初始化
        private void Init(MainController controller)
        {
            if (controller == null) throw new NullReferenceException("参数为空：controller");
            _MainController = controller;

            _MainController.CommIOStatusUpdated += this.HandleCommIOStatusUpdated;
            _MainController.CommIOButtonUpdated += this.HandleCommIOButtonUpdated;

            _MainController.WarningLight.ComStateImage += this.HandleCommStateImageUpdated;
      
            _MainController.Init();

#if ST_9980AP_DC
            this.Text = KeyConst.WinLabel.ST9980AP + KeyConst.Punctuation.Space + _MainController.Config.Title;
#elif ST_9980A_DC
            this.Text = KeyConst.WinLabel.ST9980A + KeyConst.Punctuation.Space + _MainController.Config.Title;
#elif ST_9980BP
            this.Text = KeyConst.WinLabel.ST9980BP + KeyConst.Punctuation.Space + _MainController.Config.Title;
#elif ST_990_DC
            this.Text = KeyConst.WinLabel.ST990 + KeyConst.Punctuation.Space + _MainController.Config.Title;
#endif
            Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().Name + "()" + ": Version = " + this.Text);
            Prj.Prj.RepositoryManager.Reset();
        }
        private void InitFrmSize()
        {
            //this.Width = 1090;
            //this.Height = 600;
        }
        private void InitSkin()
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + _MainController.Config.SkinPath;
            skinEng.SkinFile = path;
        }
        private void InitMenu()
        {
            tsmiDev.Visible = _MainController.Config.DeveloperItem;
        }
        private void InitComView()
        {
            tscbPort.Text = _MainController.Config.ComPort;
            tscbBaud.Text = _MainController.Config.ComBaudrate.ToString();
        }
        private void InitCanMsg()
        {
            _frmMsgCan = new frmMsgCan();
            _frmMsgCan.Dock = DockStyle.Fill;
            Prj.Prj.CanMsgController.UpdateCalcState += this.HandleUpdateCalcState;

            tbpCan.Controls.Add(_frmMsgCan);
            //this.splContainCan.Panel1.Controls.Add(_frmMsgCan);
           

        }
        private void InitBaseData()
        {
            _frmBaseInfo = new frmBaseInfo();

            _frmBaseInfo.Init();

            _frmBaseInfo.Dock = DockStyle.Fill;
            this.splContainMain.Panel1.Controls.Add(_frmBaseInfo);

        }
        private void InitChargeState()
        {
            Prj.Prj.RcvdProtocolManager.UpdateBaseInfo += this.HandleUpdateChargeState;
        }
        private void InitBottom()
        {
            tsslbCSV.Visible = false;
        }
        private void InitAlarm()
        {
            Prj.Prj.GeneralController.UpdateAlarm += this.HandleUpdateAlarm;
        }
        private void InitSendTimer()
        {
#if ST_9980BP
            Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.ACGet);
#else
            Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.BaseInfo);
#endif
            Prj.Prj.TimerManager.Start();
        }
#if ST_9980BP
        private void InitAC()
        {
            _frmAC = new frmAC();
            _frmAC.SingleOrDualForm(1);
            //_frmSingle = new frmSingle();
            this.pnlMain.Controls.Remove(splContainMain);
            this.pnlMain.Controls.Add(_frmAC);
            tsslbCSV.Visible = false;
            tsslCalc.Visible = false;
            tsmiBoard.Visible = false;
            tsmiStdSetting.Enabled = false;
            tsmiStdSetting.Visible = false;
            //tsmiHome.Visible = false;
            //tsmiTestItem.Visible = true;

        }
#endif
        private void InitDC()
        {
            tsmiTestItem.Visible = false;
        }
        private void InitButton()
        {
            _frmCanBtn = new frmCanBtn();
            _frmConsist = new frmConsist();
            _frmConsist.Dock = DockStyle.Fill;
            tbpConsist.Controls.Add(_frmConsist);
            _frmConsistBtn = new frmConsistBtn(_frmConsist, _frmCanBtn);
            _frmCanBtn.ClearCanMsg += _frmMsgCan.ClearCanMsg;
            _frmConsist.PressStartBtn += this.HandlePressStartBtn;
            LoadButton(0);
        }
        private void InitWave()
        {
            _frmWave = new frmWave(ClientRectangle.Width, ClientRectangle.Height);
            _frmWave.Dock = DockStyle.Fill;
            tbpWaveForm.Controls.Add(_frmWave);
            _frmCanBtn.ClearCanMsg += _frmWave.HandleClear;
        }
        private void InitStatistics()
        {
            _frmStatistics = new frmStatistics();
            _frmStatistics.Dock = DockStyle.Fill;
            tbpStatistics.Controls.Add(_frmStatistics);
        }
        private void Init9980A()
        {
            this.tbpInterop.Parent = null;
            this.tbpWaveForm.Parent = null;
            this.tbpStatistics.Parent = null;
        }
        private void Init990()
        {
            this.tbpInterop.Parent = null;
            this.tbpWaveForm.Parent = null;
            this.tbpStatistics.Parent = null;
            this.tbpConsist.Parent = null;
            this.tsmiStdSetting.Visible = false;
        }
        #endregion 初始化


        #region 条形Paint
        private void PnlSplit_Paint(object sender, PaintEventArgs e)
        {
            PanelPaint(sender, e);
        }

        private void MsMenu_Paint(object sender, PaintEventArgs e)
        {
            //Color TColor = Color.SteelBlue;
            //Color FColor = Color.White;
            //Graphics g = e.Graphics;
            //Brush brush;
            //brush = new LinearGradientBrush(this.msMenu.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);
            //g.FillRectangle(brush, msMenu.ClientRectangle);
        }
        private void PanelPaint(object sender, PaintEventArgs e)
        {
            Panel obj = (Panel)sender;
            Graphics g = e.Graphics;
            Color FColor = Color.White;
            Color TColor =  SystemColors.ActiveCaption;//SystemColors.GradientActiveCaption;
            Brush brush;

            if (obj.Name == pnlSplit.Name)
            {
                brush = new LinearGradientBrush(pnlSplit.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);
                g.FillRectangle(brush, pnlSplit.ClientRectangle);
            }
        }
#endregion 条形Paint

#region 按钮

        private void TsmiConn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_MainController.IsConnected())
                {
                    _MainController.DisconnPort();
                }
                else
                {
                    _MainController.Config.ComPort = tscbPort.Text;
                    int baud = 0;
                    if (int.TryParse(tscbBaud.Text.Trim(), out baud))
                    {
                        _MainController.Config.ComBaudrate = baud;
                        _MainController.SaveConfig();

                        _MainController.ConnPort();
                    }
                    if (_MainController.IsConnected() == false)
                    {
                        MessageBox.Show("打开设备失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void TscbPort_Click(object sender, EventArgs e)
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                Array.Sort(ports);
                tscbPort.Items.Clear();
                tscbPort.Items.AddRange(ports);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void LoadButton(int index)
        {
            Action async = delegate ()
            {
                pnlPageButton.Controls.Clear();
                if (index == 0)
                {

                    pnlPageButton.Controls.Add(_frmCanBtn);
                }
                else if (index == 1)
                {
                    pnlPageButton.Controls.Add(_frmConsistBtn);
                }
                else
                {
                }
                this.pnlPageButton.Refresh();
            };
            this.BeginInvoke(async);
        }
        private void BtnSysStart_Click(object sender, EventArgs e)
        {
            try
            {
                Prj.Prj.SendProtocolManager.SetDisalbeTimingSend(true);
                Thread.Sleep(10);
                if (!Prj.Prj.MainController.IsSysStart())
                {
                    Prj.Prj.MainController.SysStart();
                    Prj.Prj.SendProtocolManager.SendSysStart();
                    Action async = delegate ()
                    {
                        this.btnSysStart.Text = "Stop";
                        this.btnSysStart.Refresh();

                    };
                    this.BeginInvoke(async);
    
                }
                else
                {
                    Prj.Prj.MainController.SysStop();
                    Prj.Prj.SendProtocolManager.SendSysStop();
                    Action async = delegate ()
                    {
                        this.btnSysStart.Text = "Start";
                        this.btnSysStart.Refresh();

                    };
                    this.BeginInvoke(async);
                }
                Thread.Sleep(10);
                Prj.Prj.SendProtocolManager.SetDisalbeTimingSend(false);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        private void TsmiShow_Click(object sender, EventArgs e)
        {
            Action async = delegate ()
            {
                splContainCan.Panel2Collapsed = !splContainCan.Panel2Collapsed;
                this.Refresh();
            };
            this.BeginInvoke(async);
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


#endregion 按钮

#region 响应事件
        private void HandlePressStartBtn(int itemIndex)
        {
            if (itemIndex == -1)
                return;
            if (this.btnSysStart.Text == "Start")
            {
                BtnSysStart_Click(null, null);
            }
            else
            {
                Prj.Prj.MainController.SysStart();
                Prj.Prj.SendProtocolManager.SendSysStart();
            }
        }
        private void HandleCommStateImageUpdated(Image img)
        {
            Action async = delegate ()
            {
                this.tsddbConn.Image = img;
                this.ssBottom.Refresh();
            };
            this.BeginInvoke(async);
        }
        private void HandleCommIOStatusUpdated(string status)
        {
            Action async = delegate ()
            {
                this.tsslConnect.Text = status;

            };
            this.BeginInvoke(async);
        }

        private void HandleCommIOButtonUpdated(string text)
        {
            Action async = delegate ()
            {
                this.tsmiConn.Text = text;

            };
            this.BeginInvoke(async);
        }
        private void HandleUpdateCalcState(string text)
        {
            Action async = delegate ()
            {
                this.tsslCalc.Text = text;
            };
            this.BeginInvoke(async);
        }
        private void HandleUpdateChargeState(BaseInfo info)
        {
            Action async = delegate ()
            {
                this.lblChargeState.Text = info.ChargeState;
                this.grpbState.Refresh();
            };
            this.BeginInvoke(async);
        }
        private void HandleUpdateAlarm(string text)
        {
            Action async = delegate ()
            {
                if (text == "正常")
                    this.lblAlarm.ForeColor = SystemColors.ControlText;
                else
                    this.lblAlarm.ForeColor = Color.OrangeRed;
                this.lblAlarm.Text = text;
                this.grpbAlarm.Refresh();
            };
            this.BeginInvoke(async);
        }
        private void HandleClearCanMsg()
        {
            Action async = delegate ()
            {
                _frmMsgCan.ClearCanMsg();
            };
            this.BeginInvoke(async);
        }
#endregion 响应事件

#region 窗体事件
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Prj.Prj.Dispose();
            Prj.Prj.RcvdProtocolManager.Dispose();
            Prj.Prj.RepositoryManager.Dispose();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _MainController.WarningLight.Off();
            _MainController.WarningLight.ComStateImage -= this.HandleCommStateImageUpdated;
            Prj.Prj.CSVManager.StopSave();
            //Prj.Prj.WaveController.StopTask();
        }


        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            WinRefresh();
        }
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                Action async = delegate ()
                {
                    this.Refresh();
                };
                this.BeginInvoke(async);
            }
        }
        private void WinRefresh()
        {
            if (this.IsHandleCreated)
            {
                Action async = delegate ()
                {
                    this.Refresh();
                };
                this.BeginInvoke(async);
            }
        }
        private void TbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_frmSoftwareVersion!=null)
            {
                _frmSoftwareVersion.Close();
            }
            if (tbcMain.SelectedTab.Name == "tbpCan")
            {
                Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.BaseInfo);
                WinRefresh();
            }
            else if (tbcMain.SelectedTab.Name == "tbpConsist")
            {
                if (_frmConsist == null)
                {
                    _frmConsist = new frmConsist();
                    _frmConsist.Dock = DockStyle.Fill;
                    tbpConsist.Controls.Add(_frmConsist);
                }
                Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.BaseInfo);
            }
            else if (tbcMain.SelectedTab.Name == "tbpBMS")
            {
                if (_frmBMS == null)
                {
                    _frmBMS = new frmBMS();
                    _frmBMS.Dock = DockStyle.Fill;
                    tbpBMS.Controls.Add(_frmBMS);
                }
                _frmBMS.EnterBMSPage();
            }
            else if (tbcMain.SelectedTab.Name == "tbpInterop")
            {
                if (_frmInterop == null)
                {
                    _frmInterop = new frmInterop();
                    _frmInterop.Dock = DockStyle.Fill;
                    tbpInterop.Controls.Add(_frmInterop);
                }
                Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.DCGet);
            }
            else if (tbcMain.SelectedTab.Name == "tbpWaveForm")
            {
                Prj.Prj.TimerManager.SetFormIndex(KeyConst.TimeToSend.Page.BaseInfo);
            }
            else if (tbcMain.SelectedTab.Name == "tbpStatistics")
            {

            }
            LoadButton(tbcMain.SelectedIndex);
        }

        private void TsmiSingle_Click(object sender, EventArgs e)
        {
#if ST_9980BP
            _frmAC.SingleOrDualForm(1);
#endif
        }

        private void TsmiDual_Click(object sender, EventArgs e)
        {
#if ST_9980BP
            _frmAC.SingleOrDualForm(2);
#endif
        }

        private void TsmiSysUpgrade_Click(object sender, EventArgs e)
        {
            if (_frmUpgradeWin != null)
            {
                _frmUpgradeWin.Close();
                _frmUpgradeWin.Dispose();
            }
            _frmUpgradeWin = new frmUpgradeWin();
            _frmUpgradeWin.Dock = DockStyle.Fill;
            _frmUpgradeWin.Show();
        }
        //for AC Test end
        private void TsmiOpenSendCmd_Click(object sender, EventArgs e)
        {
            Prj.Prj.TimerManager.Start();
        }

        private void TsmiCloseSendCmd_Click(object sender, EventArgs e)
        {
            Prj.Prj.TimerManager.Stop();
        }

        private void TsmiRegister_Click(object sender, EventArgs e)
        {
            _frmLogin = null;
            if (_frmLogin == null)
            {

                Encrypt.Encryption en = new Encrypt.Encryption();//不能省略，否则出错
                int ret = Encrypt.TimeClass.InitReg();
                string warning = Function.ReturnRegisterWarning(ret);
                
                _frmLogin = new frmLogin(warning);
                _frmLogin.Show();
            }
        }

        private void TsmiLowerDeviceVer_Click(object sender, EventArgs e)
        {
            if (_frmSoftwareVersion != null)
            {
                _frmSoftwareVersion.Close();
                _frmSoftwareVersion.Dispose();
            }
            _frmSoftwareVersion = new frmSoftwareVersion();
            _frmSoftwareVersion.Dock = DockStyle.Fill;
            _frmSoftwareVersion.Show();
        }

        private void tsmiStdSetting_Click(object sender, EventArgs e)
        {
            if (_frmConsistStd != null)
            {
                _frmConsistStd.Close();
                _frmConsistStd.Dispose();
            }
            _frmConsistStd = new frmConsistConfig();
            _frmConsistStd.Show();
        }
        #endregion 窗体事件
    }
}
