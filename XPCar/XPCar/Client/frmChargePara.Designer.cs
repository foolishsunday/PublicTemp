namespace XPCar.Client
{
    partial class frmChargePara
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpChargePara = new System.Windows.Forms.TableLayoutPanel();
            this.btnSetChargePara = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblReqSync = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblMinI = new System.Windows.Forms.Label();
            this.lblMaxI = new System.Windows.Forms.Label();
            this.lblMinV = new System.Windows.Forms.Label();
            this.lblMaxV = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbpCRO = new System.Windows.Forms.TabPage();
            this.lblReadyState = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbBCPPeriod = new System.Windows.Forms.TextBox();
            this.tbMaxChargeV = new System.Windows.Forms.TextBox();
            this.tbSoc = new System.Windows.Forms.TextBox();
            this.lblText_SOC = new System.Windows.Forms.Label();
            this.tbMaxChargeI = new System.Windows.Forms.TextBox();
            this.tbCurBatV = new System.Windows.Forms.TextBox();
            this.tbEnergy = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMaxTemp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaxSingleV = new System.Windows.Forms.TextBox();
            this.lblText_Version_BRM = new System.Windows.Forms.Label();
            this.lblText_TotalV_BRM = new System.Windows.Forms.Label();
            this.lblText_Capacity_BRM = new System.Windows.Forms.Label();
            this.lblText_BatType_BRM = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbBROPeriod = new System.Windows.Forms.TextBox();
            this.rdoNotready = new System.Windows.Forms.RadioButton();
            this.rdoReady = new System.Windows.Forms.RadioButton();
            this.lblText_BROPeriod = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tlpChargePara.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tbpCRO.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpChargePara
            // 
            this.tlpChargePara.ColumnCount = 3;
            this.tlpChargePara.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpChargePara.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tlpChargePara.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpChargePara.Controls.Add(this.btnSetChargePara, 1, 2);
            this.tlpChargePara.Controls.Add(this.tabControl2, 1, 0);
            this.tlpChargePara.Controls.Add(this.tabControl1, 1, 1);
            this.tlpChargePara.Location = new System.Drawing.Point(16, 7);
            this.tlpChargePara.Name = "tlpChargePara";
            this.tlpChargePara.RowCount = 3;
            this.tlpChargePara.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpChargePara.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tlpChargePara.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tlpChargePara.Size = new System.Drawing.Size(1022, 500);
            this.tlpChargePara.TabIndex = 2;
            // 
            // btnSetChargePara
            // 
            this.btnSetChargePara.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetChargePara.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSetChargePara.Location = new System.Drawing.Point(64, 317);
            this.btnSetChargePara.Name = "btnSetChargePara";
            this.btnSetChargePara.Size = new System.Drawing.Size(87, 26);
            this.btnSetChargePara.TabIndex = 13;
            this.btnSetChargePara.Text = "设置";
            this.btnSetChargePara.UseVisualStyleBackColor = true;
            this.btnSetChargePara.Click += new System.EventHandler(this.BtnSetChargePara_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tbpCRO);
            this.tabControl2.Location = new System.Drawing.Point(64, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(893, 124);
            this.tabControl2.TabIndex = 15;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage3.Controls.Add(this.lblDate);
            this.tabPage3.Controls.Add(this.lblReqSync);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(885, 98);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "充电机发送时间同步信息报文(CTS)";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(144, 24);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 12);
            this.lblDate.TabIndex = 31;
            this.lblDate.Text = "blank";
            // 
            // lblReqSync
            // 
            this.lblReqSync.AutoSize = true;
            this.lblReqSync.Location = new System.Drawing.Point(144, 51);
            this.lblReqSync.Name = "lblReqSync";
            this.lblReqSync.Size = new System.Drawing.Size(35, 12);
            this.lblReqSync.TabIndex = 30;
            this.lblReqSync.Text = "blank";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 12);
            this.label20.TabIndex = 29;
            this.label20.Text = "是否需要对时:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "年/月/日/时/分/秒:";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage4.Controls.Add(this.lblMinI);
            this.tabPage4.Controls.Add(this.lblMaxI);
            this.tabPage4.Controls.Add(this.lblMinV);
            this.tabPage4.Controls.Add(this.lblMaxV);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(885, 98);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "充电机最大输出能力报文(CML)";
            // 
            // lblMinI
            // 
            this.lblMinI.AutoSize = true;
            this.lblMinI.Location = new System.Drawing.Point(394, 51);
            this.lblMinI.Name = "lblMinI";
            this.lblMinI.Size = new System.Drawing.Size(35, 12);
            this.lblMinI.TabIndex = 35;
            this.lblMinI.Text = "blank";
            // 
            // lblMaxI
            // 
            this.lblMaxI.AutoSize = true;
            this.lblMaxI.Location = new System.Drawing.Point(137, 51);
            this.lblMaxI.Name = "lblMaxI";
            this.lblMaxI.Size = new System.Drawing.Size(35, 12);
            this.lblMaxI.TabIndex = 34;
            this.lblMaxI.Text = "blank";
            // 
            // lblMinV
            // 
            this.lblMinV.AutoSize = true;
            this.lblMinV.Location = new System.Drawing.Point(394, 18);
            this.lblMinV.Name = "lblMinV";
            this.lblMinV.Size = new System.Drawing.Size(35, 12);
            this.lblMinV.TabIndex = 32;
            this.lblMinV.Text = "blank";
            // 
            // lblMaxV
            // 
            this.lblMaxV.AutoSize = true;
            this.lblMaxV.Location = new System.Drawing.Point(137, 18);
            this.lblMaxV.Name = "lblMaxV";
            this.lblMaxV.Size = new System.Drawing.Size(35, 12);
            this.lblMaxV.TabIndex = 31;
            this.lblMaxV.Text = "blank";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "充电机最高输出电压:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "充电机最大输出电流:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "充电机最低输出电压:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "充电机最小输出电流:";
            // 
            // tbpCRO
            // 
            this.tbpCRO.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbpCRO.Controls.Add(this.lblReadyState);
            this.tbpCRO.Controls.Add(this.label18);
            this.tbpCRO.Location = new System.Drawing.Point(4, 22);
            this.tbpCRO.Name = "tbpCRO";
            this.tbpCRO.Size = new System.Drawing.Size(885, 98);
            this.tbpCRO.TabIndex = 2;
            this.tbpCRO.Text = "充电机输出准备就绪报文(CRO)";
            // 
            // lblReadyState
            // 
            this.lblReadyState.AutoSize = true;
            this.lblReadyState.Location = new System.Drawing.Point(138, 25);
            this.lblReadyState.Name = "lblReadyState";
            this.lblReadyState.Size = new System.Drawing.Size(35, 12);
            this.lblReadyState.TabIndex = 33;
            this.lblReadyState.Text = "blank";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 12);
            this.label18.TabIndex = 18;
            this.label18.Text = "充电机充电准备就绪:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(64, 133);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(893, 178);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage1.Controls.Add(this.tbBCPPeriod);
            this.tabPage1.Controls.Add(this.tbMaxChargeV);
            this.tabPage1.Controls.Add(this.tbSoc);
            this.tabPage1.Controls.Add(this.lblText_SOC);
            this.tabPage1.Controls.Add(this.tbMaxChargeI);
            this.tabPage1.Controls.Add(this.tbCurBatV);
            this.tabPage1.Controls.Add(this.tbEnergy);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbMaxTemp);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbMaxSingleV);
            this.tabPage1.Controls.Add(this.lblText_Version_BRM);
            this.tabPage1.Controls.Add(this.lblText_TotalV_BRM);
            this.tabPage1.Controls.Add(this.lblText_Capacity_BRM);
            this.tabPage1.Controls.Add(this.lblText_BatType_BRM);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 152);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "动力蓄电池充电参数报文(BCP)";
            // 
            // tbBCPPeriod
            // 
            this.tbBCPPeriod.Location = new System.Drawing.Point(674, 112);
            this.tbBCPPeriod.Name = "tbBCPPeriod";
            this.tbBCPPeriod.Size = new System.Drawing.Size(92, 21);
            this.tbBCPPeriod.TabIndex = 25;
            this.tbBCPPeriod.Text = "500";
            // 
            // tbMaxChargeV
            // 
            this.tbMaxChargeV.Location = new System.Drawing.Point(674, 78);
            this.tbMaxChargeV.Name = "tbMaxChargeV";
            this.tbMaxChargeV.Size = new System.Drawing.Size(92, 21);
            this.tbMaxChargeV.TabIndex = 24;
            this.tbMaxChargeV.Text = "500";
            // 
            // tbSoc
            // 
            this.tbSoc.Location = new System.Drawing.Point(284, 112);
            this.tbSoc.Name = "tbSoc";
            this.tbSoc.Size = new System.Drawing.Size(92, 21);
            this.tbSoc.TabIndex = 23;
            this.tbSoc.Text = "80";
            // 
            // lblText_SOC
            // 
            this.lblText_SOC.AutoSize = true;
            this.lblText_SOC.Location = new System.Drawing.Point(11, 115);
            this.lblText_SOC.Name = "lblText_SOC";
            this.lblText_SOC.Size = new System.Drawing.Size(191, 12);
            this.lblText_SOC.TabIndex = 13;
            this.lblText_SOC.Text = "整车动力蓄电池荷电状态(0~100%):";
            // 
            // tbMaxChargeI
            // 
            this.tbMaxChargeI.Location = new System.Drawing.Point(284, 78);
            this.tbMaxChargeI.Name = "tbMaxChargeI";
            this.tbMaxChargeI.Size = new System.Drawing.Size(92, 21);
            this.tbMaxChargeI.TabIndex = 22;
            this.tbMaxChargeI.Text = "200";
            // 
            // tbCurBatV
            // 
            this.tbCurBatV.Location = new System.Drawing.Point(674, 44);
            this.tbCurBatV.Name = "tbCurBatV";
            this.tbCurBatV.Size = new System.Drawing.Size(92, 21);
            this.tbCurBatV.TabIndex = 21;
            this.tbCurBatV.Text = "390";
            // 
            // tbEnergy
            // 
            this.tbEnergy.Location = new System.Drawing.Point(284, 44);
            this.tbEnergy.Name = "tbEnergy";
            this.tbEnergy.Size = new System.Drawing.Size(92, 21);
            this.tbEnergy.TabIndex = 20;
            this.tbEnergy.Text = "200";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(468, 115);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 12);
            this.label19.TabIndex = 18;
            this.label19.Text = "报文周期(ms):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "最高允许充电总电压(V):";
            // 
            // tbMaxTemp
            // 
            this.tbMaxTemp.Location = new System.Drawing.Point(674, 10);
            this.tbMaxTemp.Name = "tbMaxTemp";
            this.tbMaxTemp.Size = new System.Drawing.Size(92, 21);
            this.tbMaxTemp.TabIndex = 19;
            this.tbMaxTemp.Text = "60";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "最高允许充电电流(A):";
            // 
            // tbMaxSingleV
            // 
            this.tbMaxSingleV.Location = new System.Drawing.Point(284, 10);
            this.tbMaxSingleV.Name = "tbMaxSingleV";
            this.tbMaxSingleV.Size = new System.Drawing.Size(92, 21);
            this.tbMaxSingleV.TabIndex = 18;
            this.tbMaxSingleV.Text = "5";
            // 
            // lblText_Version_BRM
            // 
            this.lblText_Version_BRM.AutoSize = true;
            this.lblText_Version_BRM.Location = new System.Drawing.Point(11, 13);
            this.lblText_Version_BRM.Name = "lblText_Version_BRM";
            this.lblText_Version_BRM.Size = new System.Drawing.Size(251, 12);
            this.lblText_Version_BRM.TabIndex = 0;
            this.lblText_Version_BRM.Text = "单体动力蓄电池最高允许充电电压(0-24.00V):";
            // 
            // lblText_TotalV_BRM
            // 
            this.lblText_TotalV_BRM.AutoSize = true;
            this.lblText_TotalV_BRM.Location = new System.Drawing.Point(468, 47);
            this.lblText_TotalV_BRM.Name = "lblText_TotalV_BRM";
            this.lblText_TotalV_BRM.Size = new System.Drawing.Size(185, 12);
            this.lblText_TotalV_BRM.TabIndex = 7;
            this.lblText_TotalV_BRM.Text = "整车动力蓄电池当前电池电压(V):";
            // 
            // lblText_Capacity_BRM
            // 
            this.lblText_Capacity_BRM.AutoSize = true;
            this.lblText_Capacity_BRM.Location = new System.Drawing.Point(468, 13);
            this.lblText_Capacity_BRM.Name = "lblText_Capacity_BRM";
            this.lblText_Capacity_BRM.Size = new System.Drawing.Size(167, 12);
            this.lblText_Capacity_BRM.TabIndex = 5;
            this.lblText_Capacity_BRM.Text = "最高允许温度(-50℃~+200℃):";
            // 
            // lblText_BatType_BRM
            // 
            this.lblText_BatType_BRM.AutoSize = true;
            this.lblText_BatType_BRM.Location = new System.Drawing.Point(11, 47);
            this.lblText_BatType_BRM.Name = "lblText_BatType_BRM";
            this.lblText_BatType_BRM.Size = new System.Drawing.Size(203, 12);
            this.lblText_BatType_BRM.TabIndex = 3;
            this.lblText_BatType_BRM.Text = "动力蓄电池标称总能量(0-1000.0KW):";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage2.Controls.Add(this.tbBROPeriod);
            this.tabPage2.Controls.Add(this.rdoNotready);
            this.tabPage2.Controls.Add(this.rdoReady);
            this.tabPage2.Controls.Add(this.lblText_BROPeriod);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 152);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BMS充电准备就绪报文(BRO)";
            // 
            // tbBROPeriod
            // 
            this.tbBROPeriod.Location = new System.Drawing.Point(133, 43);
            this.tbBROPeriod.Name = "tbBROPeriod";
            this.tbBROPeriod.Size = new System.Drawing.Size(92, 21);
            this.tbBROPeriod.TabIndex = 24;
            this.tbBROPeriod.Text = "250";
            // 
            // rdoNotready
            // 
            this.rdoNotready.AutoSize = true;
            this.rdoNotready.Location = new System.Drawing.Point(220, 17);
            this.rdoNotready.Name = "rdoNotready";
            this.rdoNotready.Size = new System.Drawing.Size(83, 16);
            this.rdoNotready.TabIndex = 16;
            this.rdoNotready.Text = "未准备就绪";
            this.rdoNotready.UseVisualStyleBackColor = true;
            // 
            // rdoReady
            // 
            this.rdoReady.AutoSize = true;
            this.rdoReady.Checked = true;
            this.rdoReady.Location = new System.Drawing.Point(133, 17);
            this.rdoReady.Name = "rdoReady";
            this.rdoReady.Size = new System.Drawing.Size(71, 16);
            this.rdoReady.TabIndex = 15;
            this.rdoReady.TabStop = true;
            this.rdoReady.Text = "准备就绪";
            this.rdoReady.UseVisualStyleBackColor = true;
            // 
            // lblText_BROPeriod
            // 
            this.lblText_BROPeriod.AutoSize = true;
            this.lblText_BROPeriod.Location = new System.Drawing.Point(11, 46);
            this.lblText_BROPeriod.Name = "lblText_BROPeriod";
            this.lblText_BROPeriod.Size = new System.Drawing.Size(83, 12);
            this.lblText_BROPeriod.TabIndex = 13;
            this.lblText_BROPeriod.Text = "报文周期(ms):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "BMS充电就绪状态:";
            // 
            // frmChargePara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.tlpChargePara);
            this.Name = "frmChargePara";
            this.Size = new System.Drawing.Size(1050, 512);
            this.tlpChargePara.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tbpCRO.ResumeLayout(false);
            this.tbpCRO.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpChargePara;
        private System.Windows.Forms.Label lblText_SOC;
        private System.Windows.Forms.Label lblText_Version_BRM;
        private System.Windows.Forms.Label lblText_BatType_BRM;
        private System.Windows.Forms.Label lblText_TotalV_BRM;
        private System.Windows.Forms.Label lblText_Capacity_BRM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSetChargePara;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tbpCRO;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblText_BROPeriod;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblReqSync;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblMinI;
        private System.Windows.Forms.Label lblMaxI;
        private System.Windows.Forms.Label lblMinV;
        private System.Windows.Forms.Label lblMaxV;
        private System.Windows.Forms.Label lblReadyState;
        private System.Windows.Forms.TextBox tbBCPPeriod;
        private System.Windows.Forms.TextBox tbMaxChargeV;
        private System.Windows.Forms.TextBox tbSoc;
        private System.Windows.Forms.TextBox tbMaxChargeI;
        private System.Windows.Forms.TextBox tbCurBatV;
        private System.Windows.Forms.TextBox tbEnergy;
        private System.Windows.Forms.TextBox tbMaxTemp;
        private System.Windows.Forms.TextBox tbMaxSingleV;
        private System.Windows.Forms.TextBox tbBROPeriod;
        private System.Windows.Forms.RadioButton rdoNotready;
        private System.Windows.Forms.RadioButton rdoReady;
    }
}
