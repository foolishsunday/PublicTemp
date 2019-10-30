namespace XPCar.Client
{
    partial class frmLogin
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
            this.tbMachineCode = new System.Windows.Forms.TextBox();
            this.tbRegCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnResgister = new System.Windows.Forms.Button();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.lblRegState = new System.Windows.Forms.Label();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMachineCode
            // 
            this.tbMachineCode.Location = new System.Drawing.Point(79, 176);
            this.tbMachineCode.Name = "tbMachineCode";
            this.tbMachineCode.Size = new System.Drawing.Size(539, 21);
            this.tbMachineCode.TabIndex = 1;
            // 
            // tbRegCode
            // 
            this.tbRegCode.Location = new System.Drawing.Point(79, 220);
            this.tbRegCode.Name = "tbRegCode";
            this.tbRegCode.Size = new System.Drawing.Size(539, 21);
            this.tbRegCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "电脑特征";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "注册码";
            // 
            // btnResgister
            // 
            this.btnResgister.BackColor = System.Drawing.Color.Transparent;
            this.btnResgister.BackgroundImage = global::XPCar.Properties.Resources.Button;
            this.btnResgister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResgister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResgister.Location = new System.Drawing.Point(518, 264);
            this.btnResgister.Name = "btnResgister";
            this.btnResgister.Size = new System.Drawing.Size(100, 40);
            this.btnResgister.TabIndex = 6;
            this.btnResgister.Text = "注册";
            this.btnResgister.UseVisualStyleBackColor = false;
            this.btnResgister.Click += new System.EventHandler(this.BtnResgister_Click);
            // 
            // pcbLogo
            // 
            this.pcbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pcbLogo.Image = global::XPCar.Properties.Resources.Logo_White;
            this.pcbLogo.Location = new System.Drawing.Point(1, -1);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(100, 100);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbLogo.TabIndex = 7;
            this.pcbLogo.TabStop = false;
            // 
            // lblRegState
            // 
            this.lblRegState.AutoSize = true;
            this.lblRegState.BackColor = System.Drawing.Color.Transparent;
            this.lblRegState.Location = new System.Drawing.Point(77, 269);
            this.lblRegState.Name = "lblRegState";
            this.lblRegState.Size = new System.Drawing.Size(53, 12);
            this.lblRegState.TabIndex = 9;
            this.lblRegState.Text = "注册状态";
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginTitle.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblLoginTitle.Location = new System.Drawing.Point(1, 70);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(630, 29);
            this.lblLoginTitle.TabIndex = 11;
            this.lblLoginTitle.Text = "充电桩测试系统";
            this.lblLoginTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::XPCar.Properties.Resources.Background_Science;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(636, 324);
            this.Controls.Add(this.lblLoginTitle);
            this.Controls.Add(this.lblRegState);
            this.Controls.Add(this.pcbLogo);
            this.Controls.Add(this.btnResgister);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRegCode);
            this.Controls.Add(this.tbMachineCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMachineCode;
        private System.Windows.Forms.TextBox tbRegCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnResgister;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.Label lblRegState;
        private System.Windows.Forms.Label lblLoginTitle;
    }
}