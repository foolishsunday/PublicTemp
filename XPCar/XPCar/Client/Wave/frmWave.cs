using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPCar.Prj.Model;
using XPCar.Common;
using ZedGraph;
using XPCar.WaveData;

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

            Prj.Prj.WaveController.DrawWave += this.HandleDrawWave;
            Prj.Prj.WaveController.DrawLineTitle();

        }
        private void HandleDrawWave(PointPairList[] points, PointPairList[] lines)
        {
            Action async = delegate ()
            {
                for (int i = 0; i < KeyConst.WavePara.CurveCnt; i++)
                {
                    _DrawGraphics.DrawWaveList(points, lines);
                    zgcMsgGraph.Refresh();
                }
            };
            this.BeginInvoke(async);
        }
        public void HandleClear()
        {
            Action async = delegate ()
            {
                _DrawGraphics.Clear();
                Prj.Prj.WaveController.DrawLineTitle();
                zgcMsgGraph.Refresh();
            };
            this.BeginInvoke(async);
        }
    }
}
