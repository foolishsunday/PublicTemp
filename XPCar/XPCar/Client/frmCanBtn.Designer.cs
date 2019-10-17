namespace XPCar.Client
{
    partial class frmCanBtn
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
            this.grpbCanBtn = new System.Windows.Forms.GroupBox();
            this.btnSaveCSV = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnClearCan = new System.Windows.Forms.Button();
            this.btnCanCatch = new System.Windows.Forms.Button();
            this.btnCanPause = new System.Windows.Forms.Button();
            this.cbTranslate = new System.Windows.Forms.CheckBox();
            this.grpbCanBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbCanBtn
            // 
            this.grpbCanBtn.Controls.Add(this.cbTranslate);
            this.grpbCanBtn.Controls.Add(this.btnSaveCSV);
            this.grpbCanBtn.Controls.Add(this.btnOpenFolder);
            this.grpbCanBtn.Controls.Add(this.btnClearCan);
            this.grpbCanBtn.Controls.Add(this.btnCanCatch);
            this.grpbCanBtn.Controls.Add(this.btnCanPause);
            this.grpbCanBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbCanBtn.Location = new System.Drawing.Point(0, 0);
            this.grpbCanBtn.Margin = new System.Windows.Forms.Padding(0);
            this.grpbCanBtn.Name = "grpbCanBtn";
            this.grpbCanBtn.Padding = new System.Windows.Forms.Padding(0);
            this.grpbCanBtn.Size = new System.Drawing.Size(530, 46);
            this.grpbCanBtn.TabIndex = 16;
            this.grpbCanBtn.TabStop = false;
            // 
            // btnSaveCSV
            // 
            this.btnSaveCSV.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveCSV.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveCSV.Location = new System.Drawing.Point(378, 11);
            this.btnSaveCSV.Name = "btnSaveCSV";
            this.btnSaveCSV.Size = new System.Drawing.Size(87, 29);
            this.btnSaveCSV.TabIndex = 10;
            this.btnSaveCSV.Text = "实时保存";
            this.btnSaveCSV.UseVisualStyleBackColor = true;
            this.btnSaveCSV.Click += new System.EventHandler(this.BtnSaveCSV_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenFolder.Location = new System.Drawing.Point(285, 11);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(87, 29);
            this.btnOpenFolder.TabIndex = 12;
            this.btnOpenFolder.Text = "打开文件夹";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // btnClearCan
            // 
            this.btnClearCan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearCan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearCan.Location = new System.Drawing.Point(99, 11);
            this.btnClearCan.Name = "btnClearCan";
            this.btnClearCan.Size = new System.Drawing.Size(87, 29);
            this.btnClearCan.TabIndex = 9;
            this.btnClearCan.Text = "清空";
            this.btnClearCan.UseVisualStyleBackColor = true;
            this.btnClearCan.Click += new System.EventHandler(this.BtnClearCan_Click);
            // 
            // btnCanCatch
            // 
            this.btnCanCatch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCanCatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCanCatch.Location = new System.Drawing.Point(6, 11);
            this.btnCanCatch.Name = "btnCanCatch";
            this.btnCanCatch.Size = new System.Drawing.Size(87, 29);
            this.btnCanCatch.TabIndex = 5;
            this.btnCanCatch.Text = "Can报文捕捉";
            this.btnCanCatch.UseVisualStyleBackColor = true;
            this.btnCanCatch.Click += new System.EventHandler(this.BtnCanCatch_Click);
            // 
            // btnCanPause
            // 
            this.btnCanPause.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCanPause.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCanPause.Location = new System.Drawing.Point(192, 11);
            this.btnCanPause.Name = "btnCanPause";
            this.btnCanPause.Size = new System.Drawing.Size(87, 29);
            this.btnCanPause.TabIndex = 11;
            this.btnCanPause.Text = "暂停显示";
            this.btnCanPause.UseVisualStyleBackColor = true;
            this.btnCanPause.Click += new System.EventHandler(this.BtnCanPause_Click);
            // 
            // cbTranslate
            // 
            this.cbTranslate.AutoSize = true;
            this.cbTranslate.Location = new System.Drawing.Point(479, 18);
            this.cbTranslate.Name = "cbTranslate";
            this.cbTranslate.Size = new System.Drawing.Size(48, 16);
            this.cbTranslate.TabIndex = 13;
            this.cbTranslate.Text = "翻译";
            this.cbTranslate.UseVisualStyleBackColor = true;
            this.cbTranslate.CheckedChanged += new System.EventHandler(this.cbTranslate_CheckedChanged);
            // 
            // frmCanBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.grpbCanBtn);
            this.Name = "frmCanBtn";
            this.Size = new System.Drawing.Size(530, 46);
            this.grpbCanBtn.ResumeLayout(false);
            this.grpbCanBtn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbCanBtn;
        private System.Windows.Forms.Button btnSaveCSV;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnClearCan;
        private System.Windows.Forms.Button btnCanCatch;
        private System.Windows.Forms.Button btnCanPause;
        private System.Windows.Forms.CheckBox cbTranslate;
    }
}
