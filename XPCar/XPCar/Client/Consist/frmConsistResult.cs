using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Client
{
    public partial class frmConsistResult : Form
    {
        private string _ItemId;
        public frmConsistResult(string itemid)
        {
            InitializeComponent();
            _ItemId = itemid;
            Init();
        }
        private void Init()
        {
            try
            {
                DbService db = new DbService();
                TestItemsReport report = db.QueryReport(_ItemId);

                UpdateItemReport(report);

            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void UpdateItemReport(TestItemsReport report)
        {
            this.lblItemId.Text = _ItemId;
            this.lblConsistResult_CreateTime.Text = report.CreateTimestamp;
            this.rtbConsistText1.Text = report.TestText1;
            //this.rtbConsistText2.Text = report.TestText2;
            //this.rtbConsistText3.Text = report.TestText3;
            //this.rtbConsistText4.Text = report.TestText4;

            this.rtbConsistResult1.Text = report.TestResult1;
            //this.rtbConsistResult2.Text = report.TestResult2;
            //this.rtbConsistResult3.Text = report.TestResult3;
            //this.rtbConsistResult4.Text = report.TestResult4;

            this.rtbSummary.Text = report.TestSummary;
        }

        private void frmConsistResult_Load(object sender, EventArgs e)
        {

        }
    }
}
