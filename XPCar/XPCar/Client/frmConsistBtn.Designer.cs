namespace XPCar.Client
{
    partial class frmConsistBtn
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
            this.grpbConsistBtn = new System.Windows.Forms.GroupBox();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnConsistTest = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnConsistReset = new System.Windows.Forms.Button();
            this.grpbConsistBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbConsistBtn
            // 
            this.grpbConsistBtn.Controls.Add(this.btnViewReport);
            this.grpbConsistBtn.Controls.Add(this.btnConsistTest);
            this.grpbConsistBtn.Controls.Add(this.btnExport);
            this.grpbConsistBtn.Controls.Add(this.btnConsistReset);
            this.grpbConsistBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbConsistBtn.Location = new System.Drawing.Point(0, 0);
            this.grpbConsistBtn.Margin = new System.Windows.Forms.Padding(0);
            this.grpbConsistBtn.Name = "grpbConsistBtn";
            this.grpbConsistBtn.Padding = new System.Windows.Forms.Padding(0);
            this.grpbConsistBtn.Size = new System.Drawing.Size(482, 46);
            this.grpbConsistBtn.TabIndex = 17;
            this.grpbConsistBtn.TabStop = false;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(285, 11);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(87, 29);
            this.btnViewReport.TabIndex = 7;
            this.btnViewReport.Text = "查看结果";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.BtnViewReport_Click);
            // 
            // btnConsistTest
            // 
            this.btnConsistTest.Location = new System.Drawing.Point(6, 11);
            this.btnConsistTest.Name = "btnConsistTest";
            this.btnConsistTest.Size = new System.Drawing.Size(87, 29);
            this.btnConsistTest.TabIndex = 4;
            this.btnConsistTest.Text = "测试";
            this.btnConsistTest.UseVisualStyleBackColor = true;
            this.btnConsistTest.Click += new System.EventHandler(this.BtnConsistTest_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(192, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(87, 29);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "输出报告";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnConsistReset
            // 
            this.btnConsistReset.Location = new System.Drawing.Point(99, 11);
            this.btnConsistReset.Name = "btnConsistReset";
            this.btnConsistReset.Size = new System.Drawing.Size(87, 29);
            this.btnConsistReset.TabIndex = 6;
            this.btnConsistReset.Text = "重置";
            this.btnConsistReset.UseVisualStyleBackColor = true;
            this.btnConsistReset.Click += new System.EventHandler(this.BtnConsistReset_Click);
            // 
            // frmConsistBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.grpbConsistBtn);
            this.Name = "frmConsistBtn";
            this.Size = new System.Drawing.Size(482, 46);
            this.grpbConsistBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbConsistBtn;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnConsistTest;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnConsistReset;
    }
}
