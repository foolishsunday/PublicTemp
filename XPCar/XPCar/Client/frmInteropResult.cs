using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Client
{
    public partial class frmInteropResult : Form
    {
        private int _ObjectNo;
        public frmInteropResult()
        {
            InitializeComponent();
        }
        public void Init(int objNo)
        {
            try
            {
                lblCommitOk.Visible = false;
                _ObjectNo = objNo;
                DbService db = new DbService();
                TestInterop item = db.QueryTestInteropItem(objNo);
                DisplayItem(item);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void DisplayItem(TestInterop item)
        {
            Action async = delegate ()
            {
                this.rtbTestName.Text = item.OpName;
                this.rtbTestNumber.Text = item.TestNumber;
                this.rtbTestPurpose.Text = item.TestPurpose;
                this.rtbTestStep.Text = item.TestStep;
                this.rtbTestJudge.Text = item.TestJudge;
                this.cmbTestResult.Text = item.TestResult;
            };
            this.BeginInvoke(async);
        }

        private void BtnTestCommit_Click(object sender, EventArgs e)
        {
            try
            {
                DbService db = new DbService();
                if (db.UpdateTestInterop(_ObjectNo, cmbTestResult.Text))
                {
                    lblCommitOk.Visible = true;
                    Prj.Prj.GeneralController.RefreshDCItem();
                }
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
    }
}
