using System;
using System.Windows.Forms;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Client.ACTest
{
    public partial class frmACResult : Form
    {
        private int _ObjectNo;
        public frmACResult()
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
                TestAC item = db.QueryTestACItem(objNo);
                DisplayItem(item);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void DisplayItem(TestAC item)
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
                if (db.UpdateTestAC(_ObjectNo, cmbTestResult.Text))
                {
                    lblCommitOk.Visible = true;
                    Prj.Prj.GeneralController.RefreshUpdateACResult();
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
    }
}
