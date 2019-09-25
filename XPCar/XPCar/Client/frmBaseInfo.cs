using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using XPCar.Prj.Model;
using XPCar.Timers;

namespace XPCar.Client
{
    public partial class frmBaseInfo : UserControl
    {
        public frmBaseInfo()
        {
            InitializeComponent();
        }
        public void Init()
        {
            Prj.Prj.RcvdProtocolManager.UpdateBaseInfo += this.HandleBaseInfo;
                
        }
        private void HandleBaseInfo(BaseInfo info)
        {
            Action async = delegate ()
            {
                this.lblChargV.Text = info.ChargeV;
                this.lblChargeI.Text = info.ChargeI;
                this.lblCC1.Text = info.CC1Volt;
                this.lblCC2.Text = info.CC2Volt;
                this.lblAmbientTemp.Text = info.AmbientTemp;
                this.lblAssist.Text = info.AssistVolt;
                this.lblDCP.Text = info.DC_P_Temp;
                this.lblDCM.Text = info.DC_M_Temp;
                this.Refresh();
            };
            this.BeginInvoke(async);
        }

        private void Tlaypnl_Paint(object sender, PaintEventArgs e)
        {
            //Color FColor = Color.Silver;
            //Color TColor = Color.SteelBlue;//SystemColors.InactiveCaption;
            //Graphics g = e.Graphics;
            //Brush brush;
            //brush = new LinearGradientBrush(this.tlaypnl.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);
            //g.FillRectangle(brush, this.tlaypnl.ClientRectangle);
        }
    }
}
