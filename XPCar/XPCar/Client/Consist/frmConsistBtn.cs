using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XPCar.Client
{
    public partial class frmConsistBtn : UserControl
    {
        private frmConsist _frmConsist;
        private frmCanBtn _frmCanBtn;
        public frmConsistBtn(frmConsist consist, frmCanBtn canBtn)
        {
            InitializeComponent();
            _frmConsist = consist;
            _frmCanBtn = canBtn;

        }

        private void BtnConsistTest_Click(object sender, EventArgs e)
        {
            _frmCanBtn.PressClearButton();
            _frmConsist.PressConsistTest();
        }

        private void BtnConsistReset_Click(object sender, EventArgs e)
        {
            _frmConsist.PressReset();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            _frmConsist.PressExport();
        }

        private void BtnViewReport_Click(object sender, EventArgs e)
        {
            _frmConsist.PressView();
        }
    }
}
