using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;
using ZedGraph;

namespace XPCar.WaveData
{
    public class DrawGraphics
    {
        private ZedGraphControl graph;
        private GraphPane pane;
        private bool[] IsThereTitle = new bool[KeyConst.WavePara.LineCnt];
        //private LineItem[] lines;
        public DrawGraphics(ZedGraphControl g, int clientWidth, int clientHeight)//public DrawGraphics(ZedGraphControl g)//
        {
            this.graph = g;
            this.graph.Size = new Size(clientWidth - 20, clientHeight - 20);
            //lines = new LineItem[KeyConst.WavePara.CurveCnt];
            Init();
            InitIsThereTitle();
        }
        public void Init()
        {
            graph.Location = new Point(10, 10);

            pane = graph.GraphPane;


            pane.Y2Axis.IsVisible = true;
            pane.Y2Axis.MajorTic.IsOpposite = true;

            pane.XAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(HandleXScaleFormat);
            pane.YAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(HandleYScaleFormat);
            pane.Y2Axis.ScaleFormatEvent += new Axis.ScaleFormatHandler(HandleY2ScaleFormat);


            pane.Title.Text = "";
            pane.XAxis.Title.Text = "时间(ms)";


            pane.Title.FontSpec.FontColor = Color.Blue;
            pane.Title.FontSpec.Size = 20f;

            pane.XAxis.Title.FontSpec.FontColor = Color.Blue;
            pane.XAxis.Title.FontSpec.Size = 12f;
            pane.XAxis.Title.IsOmitMag = false;//是否显示指数幂
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.FontSpec.Size = 8f;

            pane.XAxis.Scale.IsUseTenPower = false;//X轴不以10的幂显示

            pane.YAxis.Title.Text = "报文类型";
            pane.YAxis.Title.FontSpec.FontColor = Color.Blue;
            pane.YAxis.Title.FontSpec.Size = 12f;

            pane.YAxis.Scale.IsUseTenPower = false;//Y轴不以10的幂显示
            pane.YAxis.Scale.MinorStep = 1;
            pane.YAxis.Scale.MajorStep = 1;

            pane.YAxis.Scale.Max = 25;
            pane.YAxis.Scale.FontSpec.Size = 8f;
            pane.YAxis.MajorGrid.IsVisible = true;//参考线


            pane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            pane.Y2Axis.Title.FontSpec.Size = 12f;
            pane.Y2Axis.Title.IsOmitMag = false;//是否显示指数幂
            pane.Y2Axis.Scale.Min = 0;
            pane.Y2Axis.Scale.Max = 25;
            pane.Y2Axis.Title.Text = "刻度值";
            pane.Y2Axis.Scale.IsUseTenPower = false;//Y轴不以10的幂显示
            pane.Y2Axis.Scale.MinorStep = 1;
            pane.Y2Axis.Scale.MajorStep = 1;
            pane.Y2Axis.Scale.FontSpec.Size = 8f;

            pane.YAxis.Scale.IsPreventLabelOverlap = true;//坐标值显示是否允许重叠，如果False的话，控件会根据坐标值长度自动消除部分坐标值的显示状态
            pane.Y2Axis.Scale.IsPreventLabelOverlap = true;
            //pane.YAxis.MinorGrid.IsVisible = true;
            ////网格线
            //pane.XAxis.MinorGrid.IsVisible = false;

            //是否允许纵向缩放
            graph.IsEnableVZoom = false;
            graph.PanModifierKeys = System.Windows.Forms.Keys.Shift;
            //graph.IsEnableZoom = false;

            //鼠标经过图表上的点时是否显示该点所对应的值 默认为false 
            //graph.IsShowPointValues = true;

            //对坐标轴框架添加背景倾斜填充(其实就是坐标轴的背景图)
            // Add a background gradient fill to the axis frame
            pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 210), 135F);

        }
        private void InitIsThereTitle()
        {
            for (int i = 0; i < IsThereTitle.Length; i++)
            {
                IsThereTitle[i] = false;
            }
        }
        public void DrawLineList(PointPairList[] lines)
        {
            try
            {
                PointPairList line = new PointPairList();
                SymbolType circle = SymbolType.Circle;

                for (int i = 0; i < KeyConst.WavePara.LineCnt; i++)
                {
                    line = lines[i];
                    LineItem lineItem;
                    string lineTitle = string.Empty;
                    Color lineColor = Color.Transparent;
                    if (line != null && line.Count() > 0)
                    {
                        lineColor = GetLineColor(i);
                        if (line[0].X == 0 && !IsThereTitle[i])//第一条数据，添加title
                        {
                            lineTitle = GetLineTitle(i);
                            IsThereTitle[i] = true;
                        }
        
                        lineItem = pane.AddCurve(lineTitle, line, lineColor, circle);
                        lineItem.Label.FontSpec = new FontSpec();
                        lineItem.Label.FontSpec.Size = 10F;
                        lineItem.Line.Width = 1.5F; ;
                        lineItem.Symbol.Size = 0.5F;
                        lineItem.Symbol.Fill = new Fill(lineColor);

                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        public void DrawPointList(PointPairList[] lists)
        {
            try
            {
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
                        lineItem.Symbol.Size = 7.0F;
                        lineItem.Symbol.Fill = new Fill(Function.MapMsgColor(xy[0].Y));
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        public void DrawWaveList(PointPairList[] points, PointPairList[] lines)
        {
            DrawLineList(lines);
            DrawPointList(points);
            try
            {
                graph.AxisChange();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private string GetLineTitle(int lineIndex)
        {
            switch (lineIndex)
            {
                case 0: return KeyConst.HeaderText.CURVE_CHARGE_V;
                case 1: return KeyConst.HeaderText.CURVE_CHARGE_I;
                case 2: return KeyConst.HeaderText.CURVE_CC1;
                case 3: return KeyConst.HeaderText.CURVE_CC2;
                case 4: return KeyConst.HeaderText.CURVE_ASSIST;
                default: return "";
            }
        }
        private Color GetLineColor(int lineIndex)
        {
            switch (lineIndex)
            {
                case 0: return Color.Tomato;
                case 1: return Color.Aqua;
                case 2: return Color.MediumVioletRed;
                case 3: return Color.LawnGreen;
                case 4: return Color.DarkBlue;
                default: return Color.Transparent;
            }
        }

        public string HandleYScaleFormat(GraphPane pane, Axis axis, double val, int index)
        {
            return Function.MapMsgIndex(val);
        }
        public string HandleXScaleFormat(GraphPane pane, Axis axis, double val, int index)
        {
            return Function.MapDatetime(val);
        }
        public string HandleY2ScaleFormat(GraphPane pane, Axis axis, double val, int index)
        {
            return Function.MapY2Name(val);
        }
        public void Clear()
        {
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();
            ResetTitle();
        }
        private void ResetTitle()
        {
            InitIsThereTitle();
        }
    }
}
