using System.Windows.Forms;

namespace XPCar.Client
{
    public partial class frmConsistDetail : Form
    {
    
        public frmConsistDetail()
        {
            InitializeComponent();

        }
        public void SetValue(string itemid, string condition, string step, string expected)
        {
            rtbConsistId.Text = itemid;
            rtbCondition.Text = condition;
            rtbStep.Text = step;
            rtbExpected.Text = expected;

            //lblConsistId.Text = itemid;
            //lblCondition.Text = condition;
            //lblStep.Text = step;
            //lblExpected.Text = expected;

        }
    }

}
