namespace XPCar.Client
{
    partial class frmMsgCan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMsgCan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsgCan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMsgCan
            // 
            this.dgvMsgCan.AllowUserToAddRows = false;
            this.dgvMsgCan.AllowUserToDeleteRows = false;
            this.dgvMsgCan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMsgCan.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvMsgCan.ColumnHeadersHeight = 26;
            this.dgvMsgCan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMsgCan.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMsgCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMsgCan.GridColor = System.Drawing.SystemColors.Control;
            this.dgvMsgCan.Location = new System.Drawing.Point(0, 0);
            this.dgvMsgCan.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.dgvMsgCan.Name = "dgvMsgCan";
            this.dgvMsgCan.RowHeadersVisible = false;
            this.dgvMsgCan.RowTemplate.Height = 23;
            this.dgvMsgCan.RowTemplate.ReadOnly = true;
            this.dgvMsgCan.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMsgCan.Size = new System.Drawing.Size(979, 345);
            this.dgvMsgCan.TabIndex = 1;
            // 
            // frmMsgCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.dgvMsgCan);
            this.Name = "frmMsgCan";
            this.Size = new System.Drawing.Size(979, 345);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsgCan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMsgCan;
    }
}
