namespace XPCar.Client
{
    partial class frmChargeStop
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
            this.tlpChargeStop = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbBSDPeriod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMaxTemp = new System.Windows.Forms.TextBox();
            this.tbMinTemp = new System.Windows.Forms.TextBox();
            this.tbMaxV = new System.Windows.Forms.TextBox();
            this.tbMinV = new System.Windows.Forms.TextBox();
            this.tbSoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetChargeStop = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.lblEqNum = new System.Windows.Forms.Label();
            this.lblChargeTime = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tlpChargeStop.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpChargeStop
            // 
            this.tlpChargeStop.ColumnCount = 3;
            this.tlpChargeStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpChargeStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tlpChargeStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpChargeStop.Controls.Add(this.tabControl1, 1, 1);
            this.tlpChargeStop.Controls.Add(this.btnSetChargeStop, 1, 2);
            this.tlpChargeStop.Controls.Add(this.tabControl2, 1, 0);
            this.tlpChargeStop.Location = new System.Drawing.Point(14, 6);
            this.tlpChargeStop.Name = "tlpChargeStop";
            this.tlpChargeStop.RowCount = 3;
            this.tlpChargeStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpChargeStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.tlpChargeStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tlpChargeStop.Size = new System.Drawing.Size(1022, 500);
            this.tlpChargeStop.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(64, 153);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(893, 220);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage1.Controls.Add(this.tbBSDPeriod);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbMaxTemp);
            this.tabPage1.Controls.Add(this.tbMinTemp);
            this.tabPage1.Controls.Add(this.tbMaxV);
            this.tabPage1.Controls.Add(this.tbMinV);
            this.tabPage1.Controls.Add(this.tbSoc);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 194);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BMS统计数据报文(BSD)";
            // 
            // tbBSDPeriod
            // 
            this.tbBSDPeriod.Location = new System.Drawing.Point(210, 162);
            this.tbBSDPeriod.Name = "tbBSDPeriod";
            this.tbBSDPeriod.Size = new System.Drawing.Size(92, 21);
            this.tbBSDPeriod.TabIndex = 32;
            this.tbBSDPeriod.Text = "250";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "报文周期(ms):";
            // 
            // tbMaxTemp
            // 
            this.tbMaxTemp.Location = new System.Drawing.Point(210, 133);
            this.tbMaxTemp.Name = "tbMaxTemp";
            this.tbMaxTemp.Size = new System.Drawing.Size(92, 21);
            this.tbMaxTemp.TabIndex = 30;
            this.tbMaxTemp.Text = "55";
            // 
            // tbMinTemp
            // 
            this.tbMinTemp.Location = new System.Drawing.Point(210, 102);
            this.tbMinTemp.Name = "tbMinTemp";
            this.tbMinTemp.Size = new System.Drawing.Size(92, 21);
            this.tbMinTemp.TabIndex = 29;
            this.tbMinTemp.Text = "40";
            // 
            // tbMaxV
            // 
            this.tbMaxV.Location = new System.Drawing.Point(210, 71);
            this.tbMaxV.Name = "tbMaxV";
            this.tbMaxV.Size = new System.Drawing.Size(92, 21);
            this.tbMaxV.TabIndex = 28;
            this.tbMaxV.Text = "5.00";
            // 
            // tbMinV
            // 
            this.tbMinV.Location = new System.Drawing.Point(210, 40);
            this.tbMinV.Name = "tbMinV";
            this.tbMinV.Size = new System.Drawing.Size(92, 21);
            this.tbMinV.TabIndex = 27;
            this.tbMinV.Text = "4.00";
            // 
            // tbSoc
            // 
            this.tbSoc.Location = new System.Drawing.Point(210, 9);
            this.tbSoc.Name = "tbSoc";
            this.tbSoc.Size = new System.Drawing.Size(92, 21);
            this.tbSoc.TabIndex = 26;
            this.tbSoc.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "中止荷电状态SOC(0~100%):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "动力蓄电池单体最低电压(0~24V):";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(203, 12);
            this.label15.TabIndex = 25;
            this.label15.Text = "动力蓄电池最高温度(-50℃~+200℃):";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(185, 12);
            this.label14.TabIndex = 5;
            this.label14.Text = "动力蓄电池单体最高电压(0~24V):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "动力蓄电池最低温度(-50℃~+200℃):";
            // 
            // btnSetChargeStop
            // 
            this.btnSetChargeStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetChargeStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSetChargeStop.Location = new System.Drawing.Point(64, 379);
            this.btnSetChargeStop.Name = "btnSetChargeStop";
            this.btnSetChargeStop.Size = new System.Drawing.Size(87, 26);
            this.btnSetChargeStop.TabIndex = 13;
            this.btnSetChargeStop.Text = "设置";
            this.btnSetChargeStop.UseVisualStyleBackColor = true;
            this.btnSetChargeStop.Click += new System.EventHandler(this.BtnSetChargeStop_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(64, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(893, 140);
            this.tabControl2.TabIndex = 15;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage3.Controls.Add(this.lblEnergy);
            this.tabPage3.Controls.Add(this.lblEqNum);
            this.tabPage3.Controls.Add(this.lblChargeTime);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(885, 114);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "充电统计数据报文(CSD)";
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.Location = new System.Drawing.Point(125, 78);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(35, 12);
            this.lblEnergy.TabIndex = 22;
            this.lblEnergy.Text = "blank";
            // 
            // lblEqNum
            // 
            this.lblEqNum.AutoSize = true;
            this.lblEqNum.Location = new System.Drawing.Point(125, 49);
            this.lblEqNum.Name = "lblEqNum";
            this.lblEqNum.Size = new System.Drawing.Size(35, 12);
            this.lblEqNum.TabIndex = 21;
            this.lblEqNum.Text = "blank";
            // 
            // lblChargeTime
            // 
            this.lblChargeTime.AutoSize = true;
            this.lblChargeTime.Location = new System.Drawing.Point(125, 20);
            this.lblChargeTime.Name = "lblChargeTime";
            this.lblChargeTime.Size = new System.Drawing.Size(35, 12);
            this.lblChargeTime.TabIndex = 20;
            this.lblChargeTime.Text = "blank";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "累计充电时间(min):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "充电机编号:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "输出能量(kW·h):";
            // 
            // frmChargeStop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.tlpChargeStop);
            this.Name = "frmChargeStop";
            this.Size = new System.Drawing.Size(1050, 512);
            this.tlpChargeStop.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpChargeStop;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSetChargeStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.Label lblEqNum;
        private System.Windows.Forms.Label lblChargeTime;
        private System.Windows.Forms.TextBox tbMaxTemp;
        private System.Windows.Forms.TextBox tbMinTemp;
        private System.Windows.Forms.TextBox tbMaxV;
        private System.Windows.Forms.TextBox tbMinV;
        private System.Windows.Forms.TextBox tbSoc;
        private System.Windows.Forms.TextBox tbBSDPeriod;
        private System.Windows.Forms.Label label4;
    }
}
