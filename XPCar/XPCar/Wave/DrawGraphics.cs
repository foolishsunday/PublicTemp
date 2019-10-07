using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;
using ZedGraph;

namespace XPCar.Wave
{
    public class DrawGraphics
    {
        private ZedGraphControl graph;
        private GraphPane pane;
        private LineItem[] lines;
        public DrawGraphics(ZedGraphControl g, int clientWidth, int clientHeight)//public DrawGraphics(ZedGraphControl g)//
        {
            this.graph = g;
            this.graph.Size = new Size(clientWidth - 20, clientHeight - 20);
            lines = new LineItem[KeyConst.WavePara.CurveCnt];
            Init();
        }
        public void Init()
        {
            graph.Location = new Point(10, 10);

            pane = graph.GraphPane;

            pane.YAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(HandleYScaleFormat);
            pane.XAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(HandleXScaleFormat);

            pane.Title.Text = "报文控制时序图";
            pane.XAxis.Title.Text = "时间(ms)";


            pane.Title.FontSpec.FontColor = Color.Blue;
            pane.Title.FontSpec.Size = 20f;

            pane.XAxis.Title.FontSpec.FontColor = Color.Blue;
            pane.XAxis.Title.FontSpec.Size = 12f;
            pane.XAxis.Title.IsOmitMag = false;
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.FontSpec.Size = 8f;


   

            pane.YAxis.Title.Text = "报文类型";
            pane.YAxis.Title.FontSpec.FontColor = Color.Blue;
            pane.YAxis.Title.FontSpec.Size = 12f;

            pane.YAxis.Scale.IsUseTenPower = false;//Y轴不以10的幂显示
            pane.YAxis.Scale.MinorStep = 1;
            pane.YAxis.Scale.MajorStep = 1;

            pane.YAxis.Scale.Max = 25;
            pane.YAxis.Scale.FontSpec.Size = 8f;

            //pane.YAxis.MinorGrid.IsVisible = true;
            ////网格线
            //pane.XAxis.MinorGrid.IsVisible = false;

            //是否允许纵向缩放
            graph.IsEnableVZoom = false;

            graph.IsEnableZoom = false;

            //鼠标经过图表上的点时是否显示该点所对应的值 默认为false 
            //graph.IsShowPointValues = true;

            //对坐标轴框架添加背景倾斜填充(其实就是坐标轴的背景图)
            // Add a background gradient fill to the axis frame
            pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 210), 135F);


        }
        public void DrawPointPairList(PointPairList[] lists)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SymbolType square = SymbolType.Square;
            PointPairList xy = new PointPairList();
            for (int i = 0; i < KeyConst.WavePara.CurveCnt; i++)
            {
                xy = lists[i];
                LineItem lineItem;
                if (xy != null && xy.Count() > 0)
                {
                    //string lineName = Function.MapMsgIndex(xy[0].Y);
                    lineItem = pane.AddCurve("", xy, Color.Transparent, square);
                    lineItem.Symbol.Size = 5.0F;
                    lineItem.Symbol.Fill = new Fill(Function.MapMsgColor(xy[0].Y));
                }
                graph.AxisChange();
            }
            sw.Stop();
            long times = sw.ElapsedMilliseconds;
        }

        public void DrawPoint(GraphPoint pnt)
        {
            SymbolType square = SymbolType.Square;
            PointPairList xy = new PointPairList();
            
            for (int i = 0; i < KeyConst.WavePara.CurveCnt; i++)
            {
                xy = pnt.GetPointPairPerGroup(i);
                LineItem lineItem;
                if (xy != null && xy.Count() > 0)
                {
                    //string lineName = Function.MapMsgIndex(xy[0].Y);

                    lineItem = pane.AddCurve("", xy, Color.Transparent, square);
                    lineItem.Symbol.Size = 5.0F;
                    lineItem.Symbol.Fill = new Fill(Function.MapMsgColor(xy[0].Y));
                }
                graph.AxisChange();
            }

            //pane.XAxis.Type = AxisType.Date;
            //pane.XAxis.Scale.Format = "HH:mm:ss.fff"; //显示到毫秒
            //pane.XAxis.Scale.TextLabels = xAxis;

            //画到zedGraphControl1控件中
            //graph.AxisChange();
        }
        public string HandleYScaleFormat(GraphPane pane, Axis axis, double val, int index)
        {
            return Function.MapMsgIndex(val);
        }
        public string HandleXScaleFormat(GraphPane pane, Axis axis, double val, int index)
        {
            return Function.MapDatetime(val);
        }
    }
}
