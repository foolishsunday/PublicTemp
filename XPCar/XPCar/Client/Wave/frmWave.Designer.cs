namespace XPCar.Client.Wave
{
    partial class frmWave
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
            this.components = new System.ComponentModel.Container();
            this.zgcMsgGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zgcMsgGraph
            // 
            this.zgcMsgGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcMsgGraph.Location = new System.Drawing.Point(0, 0);
            this.zgcMsgGraph.Name = "zgcMsgGraph";
            this.zgcMsgGraph.ScrollGrace = 0D;
            this.zgcMsgGraph.ScrollMaxX = 0D;
            this.zgcMsgGraph.ScrollMaxY = 0D;
            this.zgcMsgGraph.ScrollMaxY2 = 0D;
            this.zgcMsgGraph.ScrollMinX = 0D;
            this.zgcMsgGraph.ScrollMinY = 0D;
            this.zgcMsgGraph.ScrollMinY2 = 0D;
            this.zgcMsgGraph.Size = new System.Drawing.Size(1050, 512);
            this.zgcMsgGraph.TabIndex = 0;
            // 
            // frmWave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.zgcMsgGraph);
            this.Name = "frmWave";
            this.Size = new System.Drawing.Size(1050, 512);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zgcMsgGraph;
    }
}
