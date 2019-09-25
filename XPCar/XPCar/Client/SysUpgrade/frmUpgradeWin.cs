using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XPCar.Client.SysUpgrade
{
    public partial class frmUpgradeWin : Form
    {
        private frmUpgrade _frmUpgrade;
        public frmUpgradeWin()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            if (_frmUpgrade == null)
            {
                _frmUpgrade = new frmUpgrade();
                _frmUpgrade.Dock = DockStyle.Fill;
                Prj.Prj.UpgradeController.UpdateUpgradeState += _frmUpgrade.HandleUpdateUpgradeState;
                this.Controls.Add(_frmUpgrade);
            }
        }

        private void FrmUpgradeWin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FrmUpgradeWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Prj.Prj.UpgradeController.UpdateUpgradeState -= _frmUpgrade.HandleUpdateUpgradeState;
            _frmUpgrade.DisposeResource();
        }
    }
}
