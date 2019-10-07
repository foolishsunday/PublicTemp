using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPCar.Wave;
using XPCar.Prj.Model;
using XPCar.Common;
using ZedGraph;

namespace XPCar.Client.Wave
{
    public partial class frmWave : UserControl
    {
        public frmWave(int width, int height)
        {
            InitializeComponent();
            Init(width, height);
        }
        private DrawGraphics _DrawGraphics;
        //GraphPoint gp = new GraphPoint();
        private void Init(int width, int height)
        {
            _DrawGraphics = new DrawGraphics(zgcMsgGraph, width, height);
            //Prj.Prj.WaveController.Init(_DrawGraphics);
            Prj.Prj.WaveController.DrawWave += this.HandleDrawWave;
            //gp.SetPointPair(200, "CHM");
            //gp.SetPointPair(5600, "CHM");
            //gp.SetPointPair(8800, "CHM");
            //gp.SetPointPair(12, "BHM");
            //gp.SetPointPair(300, "BHM");
            //gp.SetPointPair(2315, "BHM");
            //_DrawGraphics.AddPoint(gp);
        }
        private void HandleDrawWave(PointPairList[] data)
        {
            Action async = delegate ()
            {
                for (int i = 0; i < KeyConst.WavePara.CurveCnt; i++)
                {
                    _DrawGraphics.DrawPointPairList(data);
                    zgcMsgGraph.Refresh();
                }
            };
            this.BeginInvoke(async);
        }
    }
}
