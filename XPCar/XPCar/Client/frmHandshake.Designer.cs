namespace XPCar.Client
{
    partial class frmHandshake
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
            this.lblValue_Version = new System.Windows.Forms.Label();
            this.lblMaxVoltText_BHM = new System.Windows.Forms.Label();
            this.tlpHandshake = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblValue_Area = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblValue_EQNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblValue_Recognized = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbMaxV_BHM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbBHMPeriod = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoPrivate = new System.Windows.Forms.RadioButton();
            this.rdoBorrow = new System.Windows.Forms.RadioButton();
            this.pnlBatType = new System.Windows.Forms.Panel();
            this.rdoMoH = new System.Windows.Forms.RadioButton();
            this.rdoBatLeadAcid = new System.Windows.Forms.RadioButton();
            this.rdoPFeLi = new System.Windows.Forms.RadioButton();
            this.rdoMnLi = new System.Windows.Forms.RadioButton();
            this.rdoGoLi = new System.Windows.Forms.RadioButton();
            this.rdoTernary = new System.Windows.Forms.RadioButton();
            this.rdoCompound = new System.Windows.Forms.RadioButton();
            this.rdoTiLi = new System.Windows.Forms.RadioButton();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.tbVin = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbChargeCnt = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbProduceDay = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbProduceMonth = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbProduceYear = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbBatNum = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbBatTotalV = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbBatCapacity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbVerHigh = new System.Windows.Forms.TextBox();
            this.tbVerLow = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBRMPeriod = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSendHandshake = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tlpHandshake.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlBatType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblValue_Version
            // 
            this.lblValue_Version.AutoSize = true;
            this.lblValue_Version.Location = new System.Drawing.Point(156, 23);
            this.lblValue_Version.Name = "lblValue_Version";
            this.lblValue_Version.Size = new System.Drawing.Size(35, 12);
            this.lblValue_Version.TabIndex = 3;
            this.lblValue_Version.Text = "blank";
            // 
            // lblMaxVoltText_BHM
            // 
            this.lblMaxVoltText_BHM.AutoSize = true;
            this.lblMaxVoltText_BHM.Location = new System.Drawing.Point(15, 23);
            this.lblMaxVoltText_BHM.Name = "lblMaxVoltText_BHM";
            this.lblMaxVoltText_BHM.Size = new System.Drawing.Size(131, 12);
            this.lblMaxVoltText_BHM.TabIndex = 2;
            this.lblMaxVoltText_BHM.Text = "充电机通信协议版本号:";
            // 
            // tlpHandshake
            // 
            this.tlpHandshake.ColumnCount = 3;
            this.tlpHandshake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpHandshake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tlpHandshake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpHandshake.Controls.Add(this.tabControl1, 1, 0);
            this.tlpHandshake.Controls.Add(this.tabControl2, 1, 1);
            this.tlpHandshake.Controls.Add(this.btnSendHandshake, 1, 2);
            this.tlpHandshake.Location = new System.Drawing.Point(13, 3);
            this.tlpHandshake.Name = "tlpHandshake";
            this.tlpHandshake.RowCount = 3;
            this.tlpHandshake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tlpHandshake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tlpHandshake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlpHandshake.Size = new System.Drawing.Size(1022, 500);
            this.tlpHandshake.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(64, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(893, 135);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage1.Controls.Add(this.lblValue_Version);
            this.tabPage1.Controls.Add(this.lblMaxVoltText_BHM);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 161);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "充电机握手报文(CHM)";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage2.Controls.Add(this.lblValue_Area);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.lblValue_EQNum);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lblValue_Recognized);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 109);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "充电机辨识报文(CRM)";
            // 
            // lblValue_Area
            // 
            this.lblValue_Area.AutoSize = true;
            this.lblValue_Area.Location = new System.Drawing.Point(156, 85);
            this.lblValue_Area.Name = "lblValue_Area";
            this.lblValue_Area.Size = new System.Drawing.Size(35, 12);
            this.lblValue_Area.TabIndex = 9;
            this.lblValue_Area.Text = "blank";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "充电机/充电站所在编码:";
            // 
            // lblValue_EQNum
            // 
            this.lblValue_EQNum.AutoSize = true;
            this.lblValue_EQNum.Location = new System.Drawing.Point(156, 52);
            this.lblValue_EQNum.Name = "lblValue_EQNum";
            this.lblValue_EQNum.Size = new System.Drawing.Size(35, 12);
            this.lblValue_EQNum.TabIndex = 7;
            this.lblValue_EQNum.Text = "blank";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "充电机编号:";
            // 
            // lblValue_Recognized
            // 
            this.lblValue_Recognized.AutoSize = true;
            this.lblValue_Recognized.Location = new System.Drawing.Point(156, 19);
            this.lblValue_Recognized.Name = "lblValue_Recognized";
            this.lblValue_Recognized.Size = new System.Drawing.Size(35, 12);
            this.lblValue_Recognized.TabIndex = 5;
            this.lblValue_Recognized.Text = "blank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "辨识结果:";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(64, 146);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(893, 243);
            this.tabControl2.TabIndex = 15;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage4.Controls.Add(this.tbMaxV_BHM);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.tbBHMPeriod);
            this.tabPage4.Controls.Add(this.label44);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(885, 238);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "BMS握手报文(BHM)";
            // 
            // tbMaxV_BHM
            // 
            this.tbMaxV_BHM.Location = new System.Drawing.Point(158, 13);
            this.tbMaxV_BHM.Name = "tbMaxV_BHM";
            this.tbMaxV_BHM.Size = new System.Drawing.Size(77, 21);
            this.tbMaxV_BHM.TabIndex = 24;
            this.tbMaxV_BHM.Text = "500.0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "最高允许总电压(V):";
            // 
            // tbBHMPeriod
            // 
            this.tbBHMPeriod.Location = new System.Drawing.Point(158, 45);
            this.tbBHMPeriod.Name = "tbBHMPeriod";
            this.tbBHMPeriod.Size = new System.Drawing.Size(77, 21);
            this.tbBHMPeriod.TabIndex = 22;
            this.tbBHMPeriod.Text = "250";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(15, 48);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(83, 12);
            this.label44.TabIndex = 10;
            this.label44.Text = "报文周期(ms):";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.pnlBatType);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.tbVin);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.tbChargeCnt);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.tbProduceDay);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.tbProduceMonth);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.tbProduceYear);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.tbBatNum);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.tbVendor);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.tbBatTotalV);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.tbBatCapacity);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.tbVerHigh);
            this.tabPage3.Controls.Add(this.tbVerLow);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.tbBRMPeriod);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(885, 217);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "BMS和车辆辨识报文(BRM)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoPrivate);
            this.panel2.Controls.Add(this.rdoBorrow);
            this.panel2.Location = new System.Drawing.Point(635, 178);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 32);
            this.panel2.TabIndex = 61;
            // 
            // rdoPrivate
            // 
            this.rdoPrivate.AutoSize = true;
            this.rdoPrivate.Checked = true;
            this.rdoPrivate.Location = new System.Drawing.Point(6, 6);
            this.rdoPrivate.Name = "rdoPrivate";
            this.rdoPrivate.Size = new System.Drawing.Size(59, 16);
            this.rdoPrivate.TabIndex = 59;
            this.rdoPrivate.TabStop = true;
            this.rdoPrivate.Text = "车自有";
            this.rdoPrivate.UseVisualStyleBackColor = true;
            // 
            // rdoBorrow
            // 
            this.rdoBorrow.AutoSize = true;
            this.rdoBorrow.Location = new System.Drawing.Point(88, 6);
            this.rdoBorrow.Name = "rdoBorrow";
            this.rdoBorrow.Size = new System.Drawing.Size(47, 16);
            this.rdoBorrow.TabIndex = 60;
            this.rdoBorrow.TabStop = true;
            this.rdoBorrow.Text = "租赁";
            this.rdoBorrow.UseVisualStyleBackColor = true;
            // 
            // pnlBatType
            // 
            this.pnlBatType.Controls.Add(this.rdoMoH);
            this.pnlBatType.Controls.Add(this.rdoBatLeadAcid);
            this.pnlBatType.Controls.Add(this.rdoPFeLi);
            this.pnlBatType.Controls.Add(this.rdoMnLi);
            this.pnlBatType.Controls.Add(this.rdoGoLi);
            this.pnlBatType.Controls.Add(this.rdoTernary);
            this.pnlBatType.Controls.Add(this.rdoCompound);
            this.pnlBatType.Controls.Add(this.rdoTiLi);
            this.pnlBatType.Controls.Add(this.rdoOther);
            this.pnlBatType.Location = new System.Drawing.Point(80, 50);
            this.pnlBatType.Name = "pnlBatType";
            this.pnlBatType.Size = new System.Drawing.Size(777, 55);
            this.pnlBatType.TabIndex = 10;
            // 
            // rdoMoH
            // 
            this.rdoMoH.AutoSize = true;
            this.rdoMoH.Location = new System.Drawing.Point(103, 3);
            this.rdoMoH.Name = "rdoMoH";
            this.rdoMoH.Size = new System.Drawing.Size(71, 16);
            this.rdoMoH.TabIndex = 32;
            this.rdoMoH.Text = "镍氢电池";
            this.rdoMoH.UseVisualStyleBackColor = true;
            // 
            // rdoBatLeadAcid
            // 
            this.rdoBatLeadAcid.AutoSize = true;
            this.rdoBatLeadAcid.Location = new System.Drawing.Point(8, 3);
            this.rdoBatLeadAcid.Name = "rdoBatLeadAcid";
            this.rdoBatLeadAcid.Size = new System.Drawing.Size(71, 16);
            this.rdoBatLeadAcid.TabIndex = 31;
            this.rdoBatLeadAcid.Text = "铅酸电池";
            this.rdoBatLeadAcid.UseVisualStyleBackColor = true;
            // 
            // rdoPFeLi
            // 
            this.rdoPFeLi.AutoSize = true;
            this.rdoPFeLi.Checked = true;
            this.rdoPFeLi.Location = new System.Drawing.Point(198, 3);
            this.rdoPFeLi.Name = "rdoPFeLi";
            this.rdoPFeLi.Size = new System.Drawing.Size(95, 16);
            this.rdoPFeLi.TabIndex = 33;
            this.rdoPFeLi.TabStop = true;
            this.rdoPFeLi.Text = "磷酸铁锂电池";
            this.rdoPFeLi.UseVisualStyleBackColor = true;
            // 
            // rdoMnLi
            // 
            this.rdoMnLi.AutoSize = true;
            this.rdoMnLi.Location = new System.Drawing.Point(317, 3);
            this.rdoMnLi.Name = "rdoMnLi";
            this.rdoMnLi.Size = new System.Drawing.Size(83, 16);
            this.rdoMnLi.TabIndex = 34;
            this.rdoMnLi.Text = "锰酸锂电池";
            this.rdoMnLi.UseVisualStyleBackColor = true;
            // 
            // rdoGoLi
            // 
            this.rdoGoLi.AutoSize = true;
            this.rdoGoLi.Location = new System.Drawing.Point(424, 3);
            this.rdoGoLi.Name = "rdoGoLi";
            this.rdoGoLi.Size = new System.Drawing.Size(83, 16);
            this.rdoGoLi.TabIndex = 35;
            this.rdoGoLi.Text = "钴酸锂电池";
            this.rdoGoLi.UseVisualStyleBackColor = true;
            // 
            // rdoTernary
            // 
            this.rdoTernary.AutoSize = true;
            this.rdoTernary.Location = new System.Drawing.Point(531, 3);
            this.rdoTernary.Name = "rdoTernary";
            this.rdoTernary.Size = new System.Drawing.Size(95, 16);
            this.rdoTernary.TabIndex = 36;
            this.rdoTernary.Text = "三元材料电池";
            this.rdoTernary.UseVisualStyleBackColor = true;
            // 
            // rdoCompound
            // 
            this.rdoCompound.AutoSize = true;
            this.rdoCompound.Location = new System.Drawing.Point(650, 3);
            this.rdoCompound.Name = "rdoCompound";
            this.rdoCompound.Size = new System.Drawing.Size(119, 16);
            this.rdoCompound.TabIndex = 37;
            this.rdoCompound.Text = "聚合物锂离子电池";
            this.rdoCompound.UseVisualStyleBackColor = true;
            // 
            // rdoTiLi
            // 
            this.rdoTiLi.AutoSize = true;
            this.rdoTiLi.Location = new System.Drawing.Point(8, 34);
            this.rdoTiLi.Name = "rdoTiLi";
            this.rdoTiLi.Size = new System.Drawing.Size(83, 16);
            this.rdoTiLi.TabIndex = 38;
            this.rdoTiLi.Text = "钛酸锂电池";
            this.rdoTiLi.UseVisualStyleBackColor = true;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Location = new System.Drawing.Point(103, 34);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(71, 16);
            this.rdoOther.TabIndex = 37;
            this.rdoOther.Text = "其他电池";
            this.rdoOther.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(546, 186);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 12);
            this.label23.TabIndex = 58;
            this.label23.Text = "电池产权标识:";
            // 
            // tbVin
            // 
            this.tbVin.Location = new System.Drawing.Point(315, 178);
            this.tbVin.Name = "tbVin";
            this.tbVin.Size = new System.Drawing.Size(191, 21);
            this.tbVin.TabIndex = 57;
            this.tbVin.Text = "SAITER00000000001";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(216, 181);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 12);
            this.label22.TabIndex = 56;
            this.label22.Text = "车辆识别码(VIN):";
            // 
            // tbChargeCnt
            // 
            this.tbChargeCnt.Location = new System.Drawing.Point(114, 178);
            this.tbChargeCnt.Name = "tbChargeCnt";
            this.tbChargeCnt.Size = new System.Drawing.Size(77, 21);
            this.tbChargeCnt.TabIndex = 55;
            this.tbChargeCnt.Text = "2";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 181);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 12);
            this.label21.TabIndex = 54;
            this.label21.Text = "电池组充电次数:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(633, 145);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 12);
            this.label20.TabIndex = 53;
            this.label20.Text = "日";
            // 
            // tbProduceDay
            // 
            this.tbProduceDay.Location = new System.Drawing.Point(550, 142);
            this.tbProduceDay.Name = "tbProduceDay";
            this.tbProduceDay.Size = new System.Drawing.Size(77, 21);
            this.tbProduceDay.TabIndex = 52;
            this.tbProduceDay.Text = "31";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(512, 145);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 51;
            this.label19.Text = "月";
            // 
            // tbProduceMonth
            // 
            this.tbProduceMonth.Location = new System.Drawing.Point(429, 142);
            this.tbProduceMonth.Name = "tbProduceMonth";
            this.tbProduceMonth.Size = new System.Drawing.Size(77, 21);
            this.tbProduceMonth.TabIndex = 50;
            this.tbProduceMonth.Text = "5";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(398, 145);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 49;
            this.label18.Text = "年";
            // 
            // tbProduceYear
            // 
            this.tbProduceYear.Location = new System.Drawing.Point(315, 142);
            this.tbProduceYear.Name = "tbProduceYear";
            this.tbProduceYear.Size = new System.Drawing.Size(77, 21);
            this.tbProduceYear.TabIndex = 48;
            this.tbProduceYear.Text = "2018";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(218, 145);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 12);
            this.label17.TabIndex = 47;
            this.label17.Text = "电池生产日期:";
            // 
            // tbBatNum
            // 
            this.tbBatNum.Location = new System.Drawing.Point(114, 142);
            this.tbBatNum.Name = "tbBatNum";
            this.tbBatNum.Size = new System.Drawing.Size(77, 21);
            this.tbBatNum.TabIndex = 46;
            this.tbBatNum.Text = "1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 12);
            this.label16.TabIndex = 45;
            this.label16.Text = "电池组序号:";
            // 
            // tbVendor
            // 
            this.tbVendor.Location = new System.Drawing.Point(753, 109);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.Size = new System.Drawing.Size(77, 21);
            this.tbVendor.TabIndex = 44;
            this.tbVendor.Text = "BYD";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(688, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 43;
            this.label15.Text = "电池厂商:";
            // 
            // tbBatTotalV
            // 
            this.tbBatTotalV.Location = new System.Drawing.Point(564, 109);
            this.tbBatTotalV.Name = "tbBatTotalV";
            this.tbBatTotalV.Size = new System.Drawing.Size(77, 21);
            this.tbBatTotalV.TabIndex = 42;
            this.tbBatTotalV.Text = "410.0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(361, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(197, 12);
            this.label14.TabIndex = 41;
            this.label14.Text = "整车动力畜电池系统额定总电压(V):";
            // 
            // tbBatCapacity
            // 
            this.tbBatCapacity.Location = new System.Drawing.Point(212, 109);
            this.tbBatCapacity.Name = "tbBatCapacity";
            this.tbBatCapacity.Size = new System.Drawing.Size(77, 21);
            this.tbBatCapacity.TabIndex = 40;
            this.tbBatCapacity.Text = "100.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(191, 12);
            this.label10.TabIndex = 39;
            this.label10.Text = "整车动力畜电池系统额定容量(Ah):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "电池类型:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "充电机通信协议版本号:";
            // 
            // tbVerHigh
            // 
            this.tbVerHigh.Location = new System.Drawing.Point(168, 17);
            this.tbVerHigh.MaxLength = 2;
            this.tbVerHigh.Name = "tbVerHigh";
            this.tbVerHigh.Size = new System.Drawing.Size(43, 21);
            this.tbVerHigh.TabIndex = 26;
            this.tbVerHigh.Text = "1";
            // 
            // tbVerLow
            // 
            this.tbVerLow.Location = new System.Drawing.Point(232, 17);
            this.tbVerLow.MaxLength = 2;
            this.tbVerLow.Name = "tbVerLow";
            this.tbVerLow.Size = new System.Drawing.Size(43, 21);
            this.tbVerLow.TabIndex = 29;
            this.tbVerLow.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "V";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = ".";
            // 
            // tbBRMPeriod
            // 
            this.tbBRMPeriod.Location = new System.Drawing.Point(521, 17);
            this.tbBRMPeriod.Name = "tbBRMPeriod";
            this.tbBRMPeriod.Size = new System.Drawing.Size(77, 21);
            this.tbBRMPeriod.TabIndex = 21;
            this.tbBRMPeriod.Text = "250";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(419, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "报文周期(ms):";
            // 
            // btnSendHandshake
            // 
            this.btnSendHandshake.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSendHandshake.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSendHandshake.Location = new System.Drawing.Point(64, 399);
            this.btnSendHandshake.Name = "btnSendHandshake";
            this.btnSendHandshake.Size = new System.Drawing.Size(87, 26);
            this.btnSendHandshake.TabIndex = 13;
            this.btnSendHandshake.Text = "设置";
            this.btnSendHandshake.UseVisualStyleBackColor = true;
            this.btnSendHandshake.Click += new System.EventHandler(this.BtnSendHandshake_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "blank";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "blank";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(156, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "blank";
            // 
            // frmHandshake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.tlpHandshake);
            this.Name = "frmHandshake";
            this.Size = new System.Drawing.Size(1050, 512);
            this.tlpHandshake.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBatType.ResumeLayout(false);
            this.pnlBatType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblMaxVoltText_BHM;
        private System.Windows.Forms.Label lblValue_Version;
        private System.Windows.Forms.TableLayoutPanel tlpHandshake;
        private System.Windows.Forms.Button btnSendHandshake;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbBRMPeriod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox tbBHMPeriod;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValue_Area;
        private System.Windows.Forms.Label lblValue_EQNum;
        private System.Windows.Forms.Label lblValue_Recognized;
        private System.Windows.Forms.TextBox tbMaxV_BHM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbChargeCnt;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbProduceDay;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbProduceMonth;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbProduceYear;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbBatNum;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbVendor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbBatTotalV;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbBatCapacity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdoTiLi;
        private System.Windows.Forms.RadioButton rdoCompound;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.RadioButton rdoTernary;
        private System.Windows.Forms.RadioButton rdoGoLi;
        private System.Windows.Forms.RadioButton rdoMnLi;
        private System.Windows.Forms.RadioButton rdoPFeLi;
        private System.Windows.Forms.RadioButton rdoMoH;
        private System.Windows.Forms.RadioButton rdoBatLeadAcid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbVerHigh;
        private System.Windows.Forms.TextBox tbVerLow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdoBorrow;
        private System.Windows.Forms.RadioButton rdoPrivate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbVin;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel pnlBatType;
        private System.Windows.Forms.Panel panel2;
    }
}
