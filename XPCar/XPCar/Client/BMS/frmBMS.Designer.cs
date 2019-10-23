namespace XPCar.Client.BMS
{
    partial class frmBMS
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
            this.tbcBMS = new System.Windows.Forms.TabControl();
            this.tbpHandshake = new System.Windows.Forms.TabPage();
            this.tbpChargePara = new System.Windows.Forms.TabPage();
            this.tbpCharging = new System.Windows.Forms.TabPage();
            this.tbpChargeStop = new System.Windows.Forms.TabPage();
            this.tbcBMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcBMS
            // 
            this.tbcBMS.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbcBMS.Controls.Add(this.tbpHandshake);
            this.tbcBMS.Controls.Add(this.tbpChargePara);
            this.tbcBMS.Controls.Add(this.tbpCharging);
            this.tbcBMS.Controls.Add(this.tbpChargeStop);
            this.tbcBMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcBMS.ItemSize = new System.Drawing.Size(140, 21);
            this.tbcBMS.Location = new System.Drawing.Point(0, 0);
            this.tbcBMS.Multiline = true;
            this.tbcBMS.Name = "tbcBMS";
            this.tbcBMS.SelectedIndex = 0;
            this.tbcBMS.Size = new System.Drawing.Size(1060, 512);
            this.tbcBMS.TabIndex = 1;
            this.tbcBMS.SelectedIndexChanged += new System.EventHandler(this.tbcBMS_SelectedIndexChanged);
            // 
            // tbpHandshake
            // 
            this.tbpHandshake.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbpHandshake.Location = new System.Drawing.Point(4, 25);
            this.tbpHandshake.Name = "tbpHandshake";
            this.tbpHandshake.Padding = new System.Windows.Forms.Padding(3);
            this.tbpHandshake.Size = new System.Drawing.Size(1052, 483);
            this.tbpHandshake.TabIndex = 0;
            this.tbpHandshake.Text = "充电及充电握手阶段";
            // 
            // tbpChargePara
            // 
            this.tbpChargePara.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbpChargePara.Location = new System.Drawing.Point(4, 25);
            this.tbpChargePara.Name = "tbpChargePara";
            this.tbpChargePara.Padding = new System.Windows.Forms.Padding(3);
            this.tbpChargePara.Size = new System.Drawing.Size(1052, 483);
            this.tbpChargePara.TabIndex = 1;
            this.tbpChargePara.Text = "充电参数配置阶段";
            // 
            // tbpCharging
            // 
            this.tbpCharging.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbpCharging.Location = new System.Drawing.Point(4, 25);
            this.tbpCharging.Name = "tbpCharging";
            this.tbpCharging.Size = new System.Drawing.Size(1052, 483);
            this.tbpCharging.TabIndex = 2;
            this.tbpCharging.Text = "充电阶段";
            // 
            // tbpChargeStop
            // 
            this.tbpChargeStop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbpChargeStop.Location = new System.Drawing.Point(4, 25);
            this.tbpChargeStop.Name = "tbpChargeStop";
            this.tbpChargeStop.Size = new System.Drawing.Size(1052, 483);
            this.tbpChargeStop.TabIndex = 3;
            this.tbpChargeStop.Text = "充电结束阶段";
            // 
            // frmBMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbcBMS);
            this.Name = "frmBMS";
            this.Size = new System.Drawing.Size(1060, 512);
            this.tbcBMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcBMS;
        private System.Windows.Forms.TabPage tbpHandshake;
        private System.Windows.Forms.TabPage tbpChargePara;
        private System.Windows.Forms.TabPage tbpCharging;
        private System.Windows.Forms.TabPage tbpChargeStop;
    }
}
