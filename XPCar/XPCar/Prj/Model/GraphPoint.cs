using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using ZedGraph;

namespace XPCar.Prj.Model
{
    public class GraphPoint
    {
        private PointPairList[] _TotalPoint { get; set; }
        private PointPairList[] _LinePoint { get; set; }
        public GraphPoint()
        {
            _TotalPoint = new PointPairList[KeyConst.WavePara.CurveCnt];
            _LinePoint = new PointPairList[KeyConst.WavePara.LineCnt];
        }
       
        public void SetPointPair(double xdata, string ydata)
        {
            int index = Function.MapMsgName(ydata) - 1;
            if (index > KeyConst.WavePara.CurveCnt || index < 0)
            {
                return;
            }
            PointPair pair = new PointPair(xdata, index + 1);
            if (_TotalPoint[index] == null)
                _TotalPoint[index] = new PointPairList();
            _TotalPoint[index].Add(pair);

        }
        public void SetLinePair(double xdata, double ydata, int lineName)
        {
            if (_LinePoint[lineName] == null)
                _LinePoint[lineName] = new PointPairList();
            PointPair pair = new PointPair(xdata, ydata);
            _LinePoint[lineName].Add(pair);
        }
        public PointPairList GetPointPairPerGroup(int index)
        {
            return _TotalPoint[index];
        }
        public PointPairList[] GetPoints()
        {
            PointPairList[] pnts = new PointPairList[KeyConst.WavePara.CurveCnt];
            for (int i = 0; i < _TotalPoint.Length; i++)
            {
                if (_TotalPoint[i] != null && _TotalPoint[i].Count() > 0)
                {
                    pnts[i] = new PointPairList();
                    for (int j = 0; j < _TotalPoint[i].Count(); j++)
                    {
                        pnts[i].Add(_TotalPoint[i][j].X, _TotalPoint[i][j].Y);
                    }
                }
            }
            return pnts;
        }
        public PointPairList[] GetLines()
        {
            PointPairList[] pnts = new PointPairList[KeyConst.WavePara.LineCnt];
            for (int i = 0; i < _LinePoint.Length; i++)
            {
                if (_LinePoint[i] != null && _LinePoint[i].Count() > 0)
                {
                    pnts[i] = new PointPairList();
                    for (int j = 0; j < _LinePoint[i].Count(); j++)
                    {
                        pnts[i].Add(_LinePoint[i][j].X, _LinePoint[i][j].Y);
                    }
                }
            }
            return pnts;
        }
        public void ClearAllPoint()
        {
            for (int i = 0; i < _TotalPoint.Length; i++)
            {
                if (_TotalPoint[i] != null && _TotalPoint[i].Count() > 0)
                {
                    _TotalPoint[i].Clear();
                }
            }
            for(int i=0;i<_LinePoint.Length;i++)
            {

                if (_LinePoint[i] != null && _LinePoint[i].Count() > 0)
                {
                    _LinePoint[i].Clear();
                }
            }
        }
    }
}
