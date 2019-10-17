namespace XPCar.Client
{
    partial class frmConsist
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
            this.splContainConsist = new System.Windows.Forms.SplitContainer();
            this.dgvConsist = new System.Windows.Forms.DataGridView();
            this.pnlSplit = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splContainConsist)).BeginInit();
            this.splContainConsist.Panel1.SuspendLayout();
            this.splContainConsist.Panel2.SuspendLayout();
            this.splContainConsist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsist)).BeginInit();
            this.SuspendLayout();
            // 
            // splContainConsist
            // 
            this.splContainConsist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splContainConsist.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splContainConsist.Location = new System.Drawing.Point(0, 0);
            this.splContainConsist.Name = "splContainConsist";
            this.splContainConsist.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splContainConsist.Panel1
            // 
            this.splContainConsist.Panel1.Controls.Add(this.dgvConsist);
            // 
            // splContainConsist.Panel2
            // 
            this.splContainConsist.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splContainConsist.Panel2.Controls.Add(this.pnlSplit);
            this.splContainConsist.Panel2Collapsed = true;
            this.splContainConsist.Size = new System.Drawing.Size(979, 471);
            this.splContainConsist.SplitterDistance = 400;
            this.splContainConsist.TabIndex = 0;
            // 
            // dgvConsist
            // 
            this.dgvConsist.AllowUserToAddRows = false;
            this.dgvConsist.AllowUserToDeleteRows = false;
            this.dgvConsist.AllowUserToResizeRows = false;
            this.dgvConsist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConsist.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvConsist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsist.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsist.GridColor = System.Drawing.Color.White;
            this.dgvConsist.Location = new System.Drawing.Point(0, 0);
            this.dgvConsist.Name = "dgvConsist";
            this.dgvConsist.ReadOnly = true;
            this.dgvConsist.RowHeadersVisible = false;
            this.dgvConsist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsist.Size = new System.Drawing.Size(979, 471);
            this.dgvConsist.TabIndex = 0;
            this.dgvConsist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvConsist_CellClick);
            this.dgvConsist.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvConsist_CellDoubleClick);
            // 
            // pnlSplit
            // 
            this.pnlSplit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSplit.Location = new System.Drawing.Point(0, 0);
            this.pnlSplit.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSplit.Name = "pnlSplit";
            this.pnlSplit.Size = new System.Drawing.Size(979, 10);
            this.pnlSplit.TabIndex = 5;
            this.pnlSplit.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlSplit_Paint);
            // 
            // frmConsist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.splContainConsist);
            this.Name = "frmConsist";
            this.Size = new System.Drawing.Size(979, 471);
            this.splContainConsist.Panel1.ResumeLayout(false);
            this.splContainConsist.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splContainConsist)).EndInit();
            this.splContainConsist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splContainConsist;
        private System.Windows.Forms.DataGridView dgvConsist;
        private System.Windows.Forms.Panel pnlSplit;
    }
}
