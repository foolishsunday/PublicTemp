namespace XPCar.Client
{
    partial class frmSoftwareVersion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pnlVerText = new System.Windows.Forms.Panel();
            this.lblLowerDeviceVer = new System.Windows.Forms.Label();
            this.lblFlowNo = new System.Windows.Forms.Label();
            this.pnlFlowNoText = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlVerText.SuspendLayout();
            this.pnlFlowNoText.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(585, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前下位机软件版本为：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlVerText
            // 
            this.pnlVerText.Controls.Add(this.label1);
            this.pnlVerText.Location = new System.Drawing.Point(13, 60);
            this.pnlVerText.Name = "pnlVerText";
            this.pnlVerText.Size = new System.Drawing.Size(585, 37);
            this.pnlVerText.TabIndex = 1;
            // 
            // lblLowerDeviceVer
            // 
            this.lblLowerDeviceVer.Location = new System.Drawing.Point(13, 90);
            this.lblLowerDeviceVer.Name = "lblLowerDeviceVer";
            this.lblLowerDeviceVer.Size = new System.Drawing.Size(585, 29);
            this.lblLowerDeviceVer.TabIndex = 2;
            this.lblLowerDeviceVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFlowNo
            // 
            this.lblFlowNo.Location = new System.Drawing.Point(15, 186);
            this.lblFlowNo.Name = "lblFlowNo";
            this.lblFlowNo.Size = new System.Drawing.Size(585, 29);
            this.lblFlowNo.TabIndex = 4;
            this.lblFlowNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFlowNoText
            // 
            this.pnlFlowNoText.Controls.Add(this.label3);
            this.pnlFlowNoText.Location = new System.Drawing.Point(15, 156);
            this.pnlFlowNoText.Name = "pnlFlowNoText";
            this.pnlFlowNoText.Size = new System.Drawing.Size(585, 37);
            this.pnlFlowNoText.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(585, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "版本流水号为：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSoftwareVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(610, 298);
            this.Controls.Add(this.lblFlowNo);
            this.Controls.Add(this.pnlFlowNoText);
            this.Controls.Add(this.lblLowerDeviceVer);
            this.Controls.Add(this.pnlVerText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSoftwareVersion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下位机软件版本";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSoftwareVersion_FormClosing);
            this.pnlVerText.ResumeLayout(false);
            this.pnlFlowNoText.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlVerText;
        private System.Windows.Forms.Label lblLowerDeviceVer;
        private System.Windows.Forms.Label lblFlowNo;
        private System.Windows.Forms.Panel pnlFlowNoText;
        private System.Windows.Forms.Label label3;
    }
}