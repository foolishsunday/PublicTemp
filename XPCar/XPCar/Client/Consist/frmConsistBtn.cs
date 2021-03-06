﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

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
            Thread.Sleep(20);
            _frmConsist.PressConsistTest();
        }

        private void BtnConsistReset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("重置将会清空所有测试记录，确认重置?", "重置", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                _frmConsist.PressReset();
            }

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
