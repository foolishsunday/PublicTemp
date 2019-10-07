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
        public GraphPoint()
        {
            _TotalPoint = new PointPairList[KeyConst.WavePara.CurveCnt];
        }
        public void SetPointPairList(List<double> xdata, List<string> ydata)
        {
            for (int i = 0; i < xdata.Count(); i++)
            {

                string msgName = ydata[i];
                int index = Function.MapMsgName(msgName) - 1;
                if (index > KeyConst.WavePara.CurveCnt || index < 0)
                {
                    continue;
                }
                PointPair pair = new PointPair(xdata[i], index + 1);
                if (_TotalPoint[index] == null)
                    _TotalPoint[index] = new PointPairList();
                _TotalPoint[index].Add(pair);
            }
            PointPair pp = new PointPair();
        }
        public PointPairList[] ClonePointPairList()
        {
            PointPairList[] lists = new PointPairList[KeyConst.WavePara.CurveCnt];
            lists = (PointPairList[])_TotalPoint.Clone();
            return lists;
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
        public void ClearAllPoint()
        {
            for (int i = 0; i < _TotalPoint.Length; i++)
            {
                if (_TotalPoint[i] != null && _TotalPoint[i].Count() > 0)
                {
                    _TotalPoint[i].Clear();
                }
            }
        }
    }
}
