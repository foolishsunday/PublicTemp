using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static XPCar.Common.KeyConst;

namespace XPCar.Client
{
    public partial class frmSoftwareVersion : Form
    {
        //private TimeToSend.Page _PrePage;
        public frmSoftwareVersion()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            Prj.Prj.GeneralController.UpdateVersion += this.HandleUpdateVersion;
            //_PrePage = Prj.Prj.TimerManager.GetPage(); //恢复之前的发送
            Prj.Prj.TimerManager.SetFormIndex(TimeToSend.Page.VersionGet);   
        }
        private void HandleUpdateVersion(string ver, string flowNo)
        {
            Action async = delegate ()
            {
                lblLowerDeviceVer.Text = ver;
                lblFlowNo.Text = flowNo;
            };
            this.BeginInvoke(async);
        }

        private void DisposeResource()
        {
            //Prj.Prj.TimerManager.SetFormIndex(_PrePage);    //恢复之前的发送
            Prj.Prj.GeneralController.UpdateVersion -= this.HandleUpdateVersion;
        }

        private void FrmSoftwareVersion_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeResource();
        }
    }
}
