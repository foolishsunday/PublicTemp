namespace XPCar
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpCan = new System.Windows.Forms.TabPage();
            this.tbpConsist = new System.Windows.Forms.TabPage();
            this.tbpInterop = new System.Windows.Forms.TabPage();
            this.tbpHandshake = new System.Windows.Forms.TabPage();
            this.tbpChargePara = new System.Windows.Forms.TabPage();
            this.tbpCharging = new System.Windows.Forms.TabPage();
            this.tbpChargeStop = new System.Windows.Forms.TabPage();
            this.tbpWaveForm = new System.Windows.Forms.TabPage();
            this.tbpStatistics = new System.Windows.Forms.TabPage();
            this.splContainCan = new System.Windows.Forms.SplitContainer();
            this.grpbSysStartBtn = new System.Windows.Forms.GroupBox();
            this.btnSysStart = new System.Windows.Forms.Button();
            this.grpbAlarm = new System.Windows.Forms.GroupBox();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.lblAlarmTypeText = new System.Windows.Forms.Label();
            this.grpbState = new System.Windows.Forms.GroupBox();
            this.lblChargeState = new System.Windows.Forms.Label();
            this.lblChargeStateText = new System.Windows.Forms.Label();
            this.pnlSplit = new System.Windows.Forms.Panel();
            this.pnlPageButton = new System.Windows.Forms.Panel();
            this.splContainMain = new System.Windows.Forms.SplitContainer();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.tsddbConn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsslConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSpace = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbCSV = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCalc = new System.Windows.Forms.ToolStripStatusLabel();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiTestItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDual = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSys = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSysUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLowerDeviceVer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDev = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenSendCmd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseSendCmd = new System.Windows.Forms.ToolStripMenuItem();
            this.端口配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPortSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbPort = new System.Windows.Forms.ToolStripComboBox();
            this.tsmiBaud = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbBaud = new System.Windows.Forms.ToolStripComboBox();
            this.tsmiConn = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.skinEng = new Sunisoft.IrisSkin.SkinEngine();
            this.tbcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splContainCan)).BeginInit();
            this.splContainCan.Panel1.SuspendLayout();
            this.splContainCan.Panel2.SuspendLayout();
            this.splContainCan.SuspendLayout();
            this.grpbSysStartBtn.SuspendLayout();
            this.grpbAlarm.SuspendLayout();
            this.grpbState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splContainMain)).BeginInit();
            this.splContainMain.Panel2.SuspendLayout();
            this.splContainMain.SuspendLayout();
            this.ssBottom.SuspendLayout();
            this.msMenu.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbcMain.Controls.Add(this.tbpCan);
            this.tbcMain.Controls.Add(this.tbpConsist);
            this.tbcMain.Controls.Add(this.tbpInterop);
            this.tbcMain.Controls.Add(this.tbpHandshake);
            this.tbcMain.Controls.Add(this.tbpChargePara);
            this.tbcMain.Controls.Add(this.tbpCharging);
            this.tbcMain.Controls.Add(this.tbpChargeStop);
            this.tbcMain.Controls.Add(this.tbpWaveForm);
            this.tbcMain.Controls.Add(this.tbpStatistics);
            this.tbcMain.ItemSize = new System.Drawing.Size(120, 22);
            this.tbcMain.Location = new System.Drawing.Point(17, 5);
            this.tbcMain.Margin = new System.Windows.Forms.Padding(0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1036, 422);
            this.tbcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcMain.TabIndex = 2;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.TbcMain_SelectedIndexChanged);
            // 
            // tbpCan
            // 
            this.tbpCan.BackColor = System.Drawing.Color.Transparent;
            this.tbpCan.Location = new System.Drawing.Point(4, 26);
            this.tbpCan.Margin = new System.Windows.Forms.Padding(0);
            this.tbpCan.Name = "tbpCan";
            this.tbpCan.Size = new System.Drawing.Size(1028, 392);
            this.tbpCan.TabIndex = 0;
            this.tbpCan.Text = "实时报文";
            // 
            // tbpConsist
            // 
            this.tbpConsist.BackColor = System.Drawing.Color.LightGray;
            this.tbpConsist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpConsist.Location = new System.Drawing.Point(4, 26);
            this.tbpConsist.Name = "tbpConsist";
            this.tbpConsist.Size = new System.Drawing.Size(1028, 392);
            this.tbpConsist.TabIndex = 1;
            this.tbpConsist.Text = "协议一致性";
            // 
            // tbpInterop
            // 
            this.tbpInterop.Location = new System.Drawing.Point(4, 26);
            this.tbpInterop.Name = "tbpInterop";
            this.tbpInterop.Size = new System.Drawing.Size(1028, 392);
            this.tbpInterop.TabIndex = 7;
            this.tbpInterop.Text = "互操作性";
            this.tbpInterop.UseVisualStyleBackColor = true;
            // 
            // tbpHandshake
            // 
            this.tbpHandshake.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbpHandshake.Location = new System.Drawing.Point(4, 26);
            this.tbpHandshake.Name = "tbpHandshake";
            this.tbpHandshake.Size = new System.Drawing.Size(1028, 392);
            this.tbpHandshake.TabIndex = 2;
            this.tbpHandshake.Text = "上电及充电握手阶段";
            this.tbpHandshake.UseVisualStyleBackColor = true;
            // 
            // tbpChargePara
            // 
            this.tbpChargePara.Location = new System.Drawing.Point(4, 26);
            this.tbpChargePara.Name = "tbpChargePara";
            this.tbpChargePara.Size = new System.Drawing.Size(1028, 392);
            this.tbpChargePara.TabIndex = 3;
            this.tbpChargePara.Text = "充电参数配置阶段";
            this.tbpChargePara.UseVisualStyleBackColor = true;
            // 
            // tbpCharging
            // 
            this.tbpCharging.Location = new System.Drawing.Point(4, 26);
            this.tbpCharging.Name = "tbpCharging";
            this.tbpCharging.Size = new System.Drawing.Size(1028, 392);
            this.tbpCharging.TabIndex = 4;
            this.tbpCharging.Text = "充电阶段";
            this.tbpCharging.UseVisualStyleBackColor = true;
            // 
            // tbpChargeStop
            // 
            this.tbpChargeStop.Location = new System.Drawing.Point(4, 26);
            this.tbpChargeStop.Name = "tbpChargeStop";
            this.tbpChargeStop.Size = new System.Drawing.Size(1028, 392);
            this.tbpChargeStop.TabIndex = 5;
            this.tbpChargeStop.Text = "充电结束阶段";
            this.tbpChargeStop.UseVisualStyleBackColor = true;
            // 
            // tbpWaveForm
            // 
            this.tbpWaveForm.Location = new System.Drawing.Point(4, 26);
            this.tbpWaveForm.Name = "tbpWaveForm";
            this.tbpWaveForm.Size = new System.Drawing.Size(1028, 392);
            this.tbpWaveForm.TabIndex = 8;
            this.tbpWaveForm.Text = "控制时序图";
            this.tbpWaveForm.UseVisualStyleBackColor = true;
            // 
            // tbpStatistics
            // 
            this.tbpStatistics.Location = new System.Drawing.Point(4, 26);
            this.tbpStatistics.Name = "tbpStatistics";
            this.tbpStatistics.Size = new System.Drawing.Size(1028, 392);
            this.tbpStatistics.TabIndex = 9;
            this.tbpStatistics.Text = "统计";
            this.tbpStatistics.UseVisualStyleBackColor = true;
            // 
            // splContainCan
            // 
            this.splContainCan.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splContainCan.Location = new System.Drawing.Point(6, 11);
            this.splContainCan.Margin = new System.Windows.Forms.Padding(0);
            this.splContainCan.Name = "splContainCan";
            this.splContainCan.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splContainCan.Panel1
            // 
            this.splContainCan.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splContainCan.Panel1.Controls.Add(this.tbcMain);
            // 
            // splContainCan.Panel2
            // 
            this.splContainCan.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splContainCan.Panel2.Controls.Add(this.grpbSysStartBtn);
            this.splContainCan.Panel2.Controls.Add(this.grpbAlarm);
            this.splContainCan.Panel2.Controls.Add(this.grpbState);
            this.splContainCan.Panel2.Controls.Add(this.pnlSplit);
            this.splContainCan.Panel2.Controls.Add(this.pnlPageButton);
            this.splContainCan.Panel2.Margin = new System.Windows.Forms.Padding(1);
            this.splContainCan.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.splContainCan.Size = new System.Drawing.Size(1072, 518);
            this.splContainCan.SplitterDistance = 450;
            this.splContainCan.TabIndex = 0;
            // 
            // grpbSysStartBtn
            // 
            this.grpbSysStartBtn.Controls.Add(this.btnSysStart);
            this.grpbSysStartBtn.Location = new System.Drawing.Point(5, 15);
            this.grpbSysStartBtn.Name = "grpbSysStartBtn";
            this.grpbSysStartBtn.Size = new System.Drawing.Size(102, 46);
            this.grpbSysStartBtn.TabIndex = 16;
            this.grpbSysStartBtn.TabStop = false;
            // 
            // btnSysStart
            // 
            this.btnSysStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSysStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSysStart.Location = new System.Drawing.Point(6, 11);
            this.btnSysStart.Name = "btnSysStart";
            this.btnSysStart.Size = new System.Drawing.Size(87, 29);
            this.btnSysStart.TabIndex = 6;
            this.btnSysStart.Text = "Start";
            this.btnSysStart.UseVisualStyleBackColor = true;
            this.btnSysStart.Click += new System.EventHandler(this.BtnSysStart_Click);
            // 
            // grpbAlarm
            // 
            this.grpbAlarm.Controls.Add(this.lblAlarm);
            this.grpbAlarm.Controls.Add(this.lblAlarmTypeText);
            this.grpbAlarm.Location = new System.Drawing.Point(352, 15);
            this.grpbAlarm.Name = "grpbAlarm";
            this.grpbAlarm.Size = new System.Drawing.Size(233, 44);
            this.grpbAlarm.TabIndex = 11;
            this.grpbAlarm.TabStop = false;
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.Location = new System.Drawing.Point(65, 21);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(29, 12);
            this.lblAlarm.TabIndex = 1;
            this.lblAlarm.Text = "正常";
            // 
            // lblAlarmTypeText
            // 
            this.lblAlarmTypeText.AutoSize = true;
            this.lblAlarmTypeText.Location = new System.Drawing.Point(6, 21);
            this.lblAlarmTypeText.Name = "lblAlarmTypeText";
            this.lblAlarmTypeText.Size = new System.Drawing.Size(65, 12);
            this.lblAlarmTypeText.TabIndex = 0;
            this.lblAlarmTypeText.Text = "告警类型：";
            // 
            // grpbState
            // 
            this.grpbState.Controls.Add(this.lblChargeState);
            this.grpbState.Controls.Add(this.lblChargeStateText);
            this.grpbState.Location = new System.Drawing.Point(113, 15);
            this.grpbState.Name = "grpbState";
            this.grpbState.Size = new System.Drawing.Size(233, 44);
            this.grpbState.TabIndex = 10;
            this.grpbState.TabStop = false;
            // 
            // lblChargeState
            // 
            this.lblChargeState.AutoSize = true;
            this.lblChargeState.Location = new System.Drawing.Point(66, 21);
            this.lblChargeState.Name = "lblChargeState";
            this.lblChargeState.Size = new System.Drawing.Size(35, 12);
            this.lblChargeState.TabIndex = 1;
            this.lblChargeState.Text = "blank";
            // 
            // lblChargeStateText
            // 
            this.lblChargeStateText.AutoSize = true;
            this.lblChargeStateText.Location = new System.Drawing.Point(6, 21);
            this.lblChargeStateText.Name = "lblChargeStateText";
            this.lblChargeStateText.Size = new System.Drawing.Size(65, 12);
            this.lblChargeStateText.TabIndex = 0;
            this.lblChargeStateText.Text = "充电状态：";
            // 
            // pnlSplit
            // 
            this.pnlSplit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSplit.Location = new System.Drawing.Point(1, 1);
            this.pnlSplit.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSplit.Name = "pnlSplit";
            this.pnlSplit.Size = new System.Drawing.Size(1070, 10);
            this.pnlSplit.TabIndex = 4;
            this.pnlSplit.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlSplit_Paint);
            // 
            // pnlPageButton
            // 
            this.pnlPageButton.Location = new System.Drawing.Point(591, 15);
            this.pnlPageButton.Name = "pnlPageButton";
            this.pnlPageButton.Size = new System.Drawing.Size(482, 46);
            this.pnlPageButton.TabIndex = 17;
            // 
            // splContainMain
            // 
            this.splContainMain.BackColor = System.Drawing.Color.Transparent;
            this.splContainMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splContainMain.Location = new System.Drawing.Point(3, 6);
            this.splContainMain.Name = "splContainMain";
            this.splContainMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splContainMain.Panel1MinSize = 41;
            // 
            // splContainMain.Panel2
            // 
            this.splContainMain.Panel2.Controls.Add(this.splContainCan);
            this.splContainMain.Size = new System.Drawing.Size(1084, 593);
            this.splContainMain.SplitterDistance = 41;
            this.splContainMain.TabIndex = 3;
            // 
            // ssBottom
            // 
            this.ssBottom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbConn,
            this.tsslConnect,
            this.tsslSpace,
            this.tsslbCSV,
            this.toolStripStatusLabel1,
            this.tsslCalc});
            this.ssBottom.Location = new System.Drawing.Point(0, 605);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(1090, 22);
            this.ssBottom.TabIndex = 4;
            this.ssBottom.Text = "statusStrip1";
            // 
            // tsddbConn
            // 
            this.tsddbConn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbConn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbConn.Name = "tsddbConn";
            this.tsddbConn.Size = new System.Drawing.Size(13, 20);
            this.tsddbConn.Text = "toolStripDropDownButton1";
            // 
            // tsslConnect
            // 
            this.tsslConnect.Name = "tsslConnect";
            this.tsslConnect.Size = new System.Drawing.Size(162, 17);
            this.tsslConnect.Text = "Disconnected                   ";
            // 
            // tsslSpace
            // 
            this.tsslSpace.Name = "tsslSpace";
            this.tsslSpace.Size = new System.Drawing.Size(24, 17);
            this.tsslSpace.Text = "    ";
            // 
            // tsslbCSV
            // 
            this.tsslbCSV.ForeColor = System.Drawing.Color.Black;
            this.tsslbCSV.Name = "tsslbCSV";
            this.tsslbCSV.Size = new System.Drawing.Size(107, 17);
            this.tsslbCSV.Text = " 实时保存 : 未保存";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(24, 17);
            this.toolStripStatusLabel1.Text = "    ";
            // 
            // tsslCalc
            // 
            this.tsslCalc.Name = "tsslCalc";
            this.tsslCalc.Size = new System.Drawing.Size(56, 17);
            this.tsslCalc.Text = "数据状态";
            // 
            // msMenu
            // 
            this.msMenu.BackColor = System.Drawing.SystemColors.Control;
            this.msMenu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTestItem,
            this.tsmiBoard,
            this.tsmiSys,
            this.tsmiDev,
            this.端口配置ToolStripMenuItem,
            this.tsmiConn});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Margin = new System.Windows.Forms.Padding(3);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1090, 24);
            this.msMenu.TabIndex = 1;
            this.msMenu.Text = "标题菜单";
            this.msMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.MsMenu_Paint);
            // 
            // tsmiTestItem
            // 
            this.tsmiTestItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSingle,
            this.tsmiDual});
            this.tsmiTestItem.Name = "tsmiTestItem";
            this.tsmiTestItem.Size = new System.Drawing.Size(65, 20);
            this.tsmiTestItem.Text = "测试项目";
            // 
            // tsmiSingle
            // 
            this.tsmiSingle.Name = "tsmiSingle";
            this.tsmiSingle.Size = new System.Drawing.Size(94, 22);
            this.tsmiSingle.Text = "单枪";
            this.tsmiSingle.Click += new System.EventHandler(this.TsmiSingle_Click);
            // 
            // tsmiDual
            // 
            this.tsmiDual.Name = "tsmiDual";
            this.tsmiDual.Size = new System.Drawing.Size(94, 22);
            this.tsmiDual.Text = "双枪";
            this.tsmiDual.Click += new System.EventHandler(this.TsmiDual_Click);
            // 
            // tsmiBoard
            // 
            this.tsmiBoard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShow});
            this.tsmiBoard.Name = "tsmiBoard";
            this.tsmiBoard.Size = new System.Drawing.Size(41, 20);
            this.tsmiBoard.Text = "视图";
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(124, 22);
            this.tsmiShow.Text = "隐藏/显示";
            this.tsmiShow.Click += new System.EventHandler(this.TsmiShow_Click);
            // 
            // tsmiSys
            // 
            this.tsmiSys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSysUpgrade,
            this.tsmiRegister,
            this.tsmiLowerDeviceVer});
            this.tsmiSys.Name = "tsmiSys";
            this.tsmiSys.Size = new System.Drawing.Size(41, 20);
            this.tsmiSys.Text = "系统";
            // 
            // tsmiSysUpgrade
            // 
            this.tsmiSysUpgrade.Name = "tsmiSysUpgrade";
            this.tsmiSysUpgrade.Size = new System.Drawing.Size(154, 22);
            this.tsmiSysUpgrade.Text = "系统升级";
            this.tsmiSysUpgrade.Click += new System.EventHandler(this.TsmiSysUpgrade_Click);
            // 
            // tsmiRegister
            // 
            this.tsmiRegister.Name = "tsmiRegister";
            this.tsmiRegister.Size = new System.Drawing.Size(154, 22);
            this.tsmiRegister.Text = "注册";
            this.tsmiRegister.Click += new System.EventHandler(this.TsmiRegister_Click);
            // 
            // tsmiLowerDeviceVer
            // 
            this.tsmiLowerDeviceVer.Name = "tsmiLowerDeviceVer";
            this.tsmiLowerDeviceVer.Size = new System.Drawing.Size(154, 22);
            this.tsmiLowerDeviceVer.Text = "下位机软件版本";
            this.tsmiLowerDeviceVer.Click += new System.EventHandler(this.TsmiLowerDeviceVer_Click);
            // 
            // tsmiDev
            // 
            this.tsmiDev.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenSendCmd,
            this.tsmiCloseSendCmd});
            this.tsmiDev.Name = "tsmiDev";
            this.tsmiDev.Size = new System.Drawing.Size(77, 20);
            this.tsmiDev.Text = "开发者选项";
            // 
            // tsmiOpenSendCmd
            // 
            this.tsmiOpenSendCmd.Name = "tsmiOpenSendCmd";
            this.tsmiOpenSendCmd.Size = new System.Drawing.Size(142, 22);
            this.tsmiOpenSendCmd.Text = "开启发送命令";
            this.tsmiOpenSendCmd.Click += new System.EventHandler(this.TsmiOpenSendCmd_Click);
            // 
            // tsmiCloseSendCmd
            // 
            this.tsmiCloseSendCmd.Name = "tsmiCloseSendCmd";
            this.tsmiCloseSendCmd.Size = new System.Drawing.Size(142, 22);
            this.tsmiCloseSendCmd.Text = "关闭发送命令";
            this.tsmiCloseSendCmd.Click += new System.EventHandler(this.TsmiCloseSendCmd_Click);
            // 
            // 端口配置ToolStripMenuItem
            // 
            this.端口配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPortSetting,
            this.tsmiBaud});
            this.端口配置ToolStripMenuItem.Name = "端口配置ToolStripMenuItem";
            this.端口配置ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.端口配置ToolStripMenuItem.Text = "端口配置";
            // 
            // tsmiPortSetting
            // 
            this.tsmiPortSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbPort});
            this.tsmiPortSetting.Name = "tsmiPortSetting";
            this.tsmiPortSetting.Size = new System.Drawing.Size(106, 22);
            this.tsmiPortSetting.Text = "端口号";
            // 
            // tscbPort
            // 
            this.tscbPort.Name = "tscbPort";
            this.tscbPort.Size = new System.Drawing.Size(121, 25);
            this.tscbPort.Click += new System.EventHandler(this.TscbPort_Click);
            // 
            // tsmiBaud
            // 
            this.tsmiBaud.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbBaud});
            this.tsmiBaud.Name = "tsmiBaud";
            this.tsmiBaud.Size = new System.Drawing.Size(106, 22);
            this.tsmiBaud.Text = "波特率";
            // 
            // tscbBaud
            // 
            this.tscbBaud.Name = "tscbBaud";
            this.tscbBaud.Size = new System.Drawing.Size(121, 25);
            // 
            // tsmiConn
            // 
            this.tsmiConn.Name = "tsmiConn";
            this.tsmiConn.Size = new System.Drawing.Size(65, 20);
            this.tsmiConn.Text = "打开设备";
            this.tsmiConn.Click += new System.EventHandler(this.TsmiConn_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splContainMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1090, 581);
            this.pnlMain.TabIndex = 4;
            // 
            // skinEng
            // 
            this.skinEng.@__DrawButtonFocusRectangle = true;
            this.skinEng.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEng.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEng.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEng.SerialNumber = "";
            this.skinEng.SkinFile = null;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1090, 627);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.msMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "充电桩测试系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.tbcMain.ResumeLayout(false);
            this.splContainCan.Panel1.ResumeLayout(false);
            this.splContainCan.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splContainCan)).EndInit();
            this.splContainCan.ResumeLayout(false);
            this.grpbSysStartBtn.ResumeLayout(false);
            this.grpbAlarm.ResumeLayout(false);
            this.grpbAlarm.PerformLayout();
            this.grpbState.ResumeLayout(false);
            this.grpbState.PerformLayout();
            this.splContainMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splContainMain)).EndInit();
            this.splContainMain.ResumeLayout(false);
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpCan;
        private System.Windows.Forms.SplitContainer splContainCan;
        private System.Windows.Forms.Panel pnlSplit;
        private System.Windows.Forms.TabPage tbpConsist;
        private System.Windows.Forms.Button btnSysStart;

        private System.Windows.Forms.SplitContainer splContainMain;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.ToolStripDropDownButton tsddbConn;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnect;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiBoard;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.ToolStripStatusLabel tsslbCSV;
        private System.Windows.Forms.ToolStripStatusLabel tsslSpace;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslCalc;
        private System.Windows.Forms.TabPage tbpHandshake;
        private System.Windows.Forms.TabPage tbpChargePara;
        private System.Windows.Forms.TabPage tbpCharging;
        private System.Windows.Forms.TabPage tbpChargeStop;
        private System.Windows.Forms.TabPage tbpInterop;
        private System.Windows.Forms.ToolStripMenuItem 端口配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPortSetting;
        private System.Windows.Forms.ToolStripComboBox tscbPort;
        private System.Windows.Forms.ToolStripMenuItem tsmiBaud;
        private System.Windows.Forms.ToolStripMenuItem tsmiConn;
        private System.Windows.Forms.ToolStripComboBox tscbBaud;
        private System.Windows.Forms.GroupBox grpbState;
        private System.Windows.Forms.Label lblChargeState;
        private System.Windows.Forms.Label lblChargeStateText;
        private System.Windows.Forms.GroupBox grpbAlarm;
        private System.Windows.Forms.Label lblAlarm;
        private System.Windows.Forms.Label lblAlarmTypeText;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiTestItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSingle;
        private System.Windows.Forms.ToolStripMenuItem tsmiDual;
        private System.Windows.Forms.ToolStripMenuItem tsmiSys;
        private System.Windows.Forms.ToolStripMenuItem tsmiSysUpgrade;
        private System.Windows.Forms.ToolStripMenuItem tsmiDev;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenSendCmd;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseSendCmd;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegister;
        private System.Windows.Forms.Panel pnlPageButton;
        private System.Windows.Forms.GroupBox grpbSysStartBtn;
        private System.Windows.Forms.TabPage tbpWaveForm;
        private System.Windows.Forms.ToolStripMenuItem tsmiLowerDeviceVer;
        private System.Windows.Forms.TabPage tbpStatistics;
        private Sunisoft.IrisSkin.SkinEngine skinEng;
    }
}

