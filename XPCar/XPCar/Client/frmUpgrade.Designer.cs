namespace XPCar.Client
{
    partial class frmUpgrade
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
            this.tlpUpgrade = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbBin = new System.Windows.Forms.RichTextBox();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenBin = new System.Windows.Forms.Button();
            this.tbUpgradePath = new System.Windows.Forms.TextBox();
            this.tbBinLen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUpgradeState = new System.Windows.Forms.TextBox();
            this.tlpUpgrade.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpUpgrade
            // 
            this.tlpUpgrade.ColumnCount = 3;
            this.tlpUpgrade.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpUpgrade.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpUpgrade.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpUpgrade.Controls.Add(this.groupBox1, 1, 1);
            this.tlpUpgrade.Location = new System.Drawing.Point(14, 6);
            this.tlpUpgrade.Name = "tlpUpgrade";
            this.tlpUpgrade.RowCount = 2;
            this.tlpUpgrade.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpUpgrade.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.tlpUpgrade.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpUpgrade.Size = new System.Drawing.Size(763, 424);
            this.tlpUpgrade.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rtbBin);
            this.groupBox1.Controls.Add(this.btnUpgrade);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnOpenBin);
            this.groupBox1.Controls.Add(this.tbUpgradePath);
            this.groupBox1.Controls.Add(this.tbBinLen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbUpgradeState);
            this.groupBox1.Location = new System.Drawing.Point(41, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 400);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(8, 356);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 38);
            this.panel1.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(87, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(457, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "系统升级期间，请勿点击任何非本界面按钮，否则会造成升级失败！";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "文件路径";
            // 
            // rtbBin
            // 
            this.rtbBin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbBin.Location = new System.Drawing.Point(74, 116);
            this.rtbBin.Name = "rtbBin";
            this.rtbBin.Size = new System.Drawing.Size(493, 234);
            this.rtbBin.TabIndex = 16;
            this.rtbBin.Text = "";
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpgrade.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpgrade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpgrade.Location = new System.Drawing.Point(579, 116);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(87, 26);
            this.btnUpgrade.TabIndex = 15;
            this.btnUpgrade.Text = "系统升级";
            this.btnUpgrade.UseVisualStyleBackColor = true;
            this.btnUpgrade.Click += new System.EventHandler(this.BtnUpgrade_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "文件长度";
            // 
            // btnOpenBin
            // 
            this.btnOpenBin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenBin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenBin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenBin.Location = new System.Drawing.Point(579, 78);
            this.btnOpenBin.Name = "btnOpenBin";
            this.btnOpenBin.Size = new System.Drawing.Size(87, 26);
            this.btnOpenBin.TabIndex = 14;
            this.btnOpenBin.Text = "文件选择";
            this.btnOpenBin.UseVisualStyleBackColor = true;
            this.btnOpenBin.Click += new System.EventHandler(this.BtnOpenBin_Click);
            // 
            // tbUpgradePath
            // 
            this.tbUpgradePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUpgradePath.Location = new System.Drawing.Point(74, 82);
            this.tbUpgradePath.Name = "tbUpgradePath";
            this.tbUpgradePath.Size = new System.Drawing.Size(493, 21);
            this.tbUpgradePath.TabIndex = 0;
            // 
            // tbBinLen
            // 
            this.tbBinLen.Location = new System.Drawing.Point(74, 48);
            this.tbBinLen.Name = "tbBinLen";
            this.tbBinLen.ReadOnly = true;
            this.tbBinLen.Size = new System.Drawing.Size(73, 21);
            this.tbBinLen.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "烧写状态";
            // 
            // tbUpgradeState
            // 
            this.tbUpgradeState.Location = new System.Drawing.Point(74, 14);
            this.tbUpgradeState.Name = "tbUpgradeState";
            this.tbUpgradeState.ReadOnly = true;
            this.tbUpgradeState.Size = new System.Drawing.Size(73, 21);
            this.tbUpgradeState.TabIndex = 1;
            // 
            // frmUpgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.tlpUpgrade);
            this.Name = "frmUpgrade";
            this.Size = new System.Drawing.Size(790, 435);
            this.tlpUpgrade.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpUpgrade;
        private System.Windows.Forms.TextBox tbUpgradePath;
        private System.Windows.Forms.Button btnOpenBin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBinLen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUpgradeState;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbBin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
    }
}
