using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using XPCar.Common;

namespace XPCar.Client.Consist
{
    public partial class frmConsistConfig : Form
    {
        public frmConsistConfig()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            tbStd1s.Text = Prj.Prj.MainController.Config.StandardSet.Std1s.ToString();
            tbStd5s.Text = Prj.Prj.MainController.Config.StandardSet.Std5s.ToString();
            tbStd10s.Text = Prj.Prj.MainController.Config.StandardSet.Std10s.ToString();
            tbStd10ms.Text = Prj.Prj.MainController.Config.StandardSet.Std10ms.ToString();
            tbStd50ms.Text = Prj.Prj.MainController.Config.StandardSet.Std50ms.ToString();
            lblConfirmOk.Visible = false;

        }
        private void btnConfirmSetting_Click(object sender, EventArgs e)
        {
            bool isLegal = MatchCheck.IsInt(tbStd1s.Text);
            isLegal &= MatchCheck.IsInt(tbStd5s.Text);
            isLegal &= MatchCheck.IsInt(tbStd10s.Text);
            isLegal &= MatchCheck.IsInt(tbStd10ms.Text);
            isLegal &= MatchCheck.IsInt(tbStd50ms.Text);
            if (isLegal)
            {
                Prj.Prj.MainController.Config.StandardSet.Std1s = Convert.ToInt32(tbStd1s.Text);
                Prj.Prj.MainController.Config.StandardSet.Std5s = Convert.ToInt32(tbStd5s.Text);
                Prj.Prj.MainController.Config.StandardSet.Std10s = Convert.ToInt32(tbStd10s.Text);
                Prj.Prj.MainController.Config.StandardSet.Std10ms = Convert.ToInt32(tbStd10ms.Text);
                Prj.Prj.MainController.Config.StandardSet.Std50ms = Convert.ToInt32(tbStd50ms.Text);
                Prj.Prj.MainController.Config.SaveConsistStd();
                Action async = delegate ()
                {
                    lblConfirmOk.Visible = true;
                };
                this.BeginInvoke(async);
            }
            else
            {
                ThreadPool.QueueUserWorkItem(a =>
                {
                    MessageBox.Show("输入的数值不合法！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }, null);
            }
        }
    }
}
