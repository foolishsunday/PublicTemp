using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Consist.Calc
{
    public class MeasureTimeout: IMeasureResult
    {
        private bool _IsQualified;
        private string _ResultText;
        public MeasureTimeout()
        {
            _IsQualified = true;
        }
        public string ResultText(string consistId)
        {
            return _ResultText;
        }
        public bool IsResultOk()
        {
            return _IsQualified;
        }
     
        public long MeasureFirstToFirstWithoutSec(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[0].CreateTimestamp;
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= ms)
                _IsQualified = true;
            else
                _IsQualified = false;
            _ResultText = span.ToString() + "ms";
            return span;
        }
        public long MeasureFirstToLastWithinSec(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[0].CreateTimestamp;
            string later = laterList[laterList.Count - 1].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= 0 && span <= TimeoutOffset(ms))
                _IsQualified = true;
            else
                _IsQualified = false;
            _ResultText = span.ToString() + "ms";
            return span;
        }
        public long MeasureLastToLastWithinSec(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[earlierList.Count - 1].CreateTimestamp;
            string later = laterList[laterList.Count - 1].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= 0 && span <= TimeoutOffset(ms))
                _IsQualified = true;
            else
                _IsQualified = false;
            _ResultText = span.ToString() + "ms";
            return span;
        }
        public long MeasureLastToFirstWithoutSec(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[earlierList.Count - 1].CreateTimestamp;
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= ms)
                _IsQualified = true;
            else
                _IsQualified = false;
            _ResultText = span.ToString() + "ms";
            return span;
        }
        public long TimeoutOffset(long timeout)
        {
            long std = 0;
            double offset1s = Convert.ToDouble(Prj.Prj.MainController.Config.StandardSet.Std1s) / 1000F;
            double offset5s = Convert.ToDouble(Prj.Prj.MainController.Config.StandardSet.Std5s) / 1000F;
            double offset10s = Convert.ToDouble(Prj.Prj.MainController.Config.StandardSet.Std10s) / 1000F;
            if (timeout == 1000)
                std = (long)(timeout * (1 + offset1s));
            else if (timeout == 5000)
                std = (long)(timeout * (1 + offset5s));
            else if (timeout >= 10000)
                std = (long)(timeout * (1 + offset10s));
            return std;
        }

        public void AppendText(string text1, string text2)
        {
            string text = text1 + ResultText(null) + text2 + KeyConst.Punctuation.Space;
            _ResultText = text;
            if (_IsQualified)
                text += KeyConst.Consist.Result.Qualified + KeyConst.Punctuation.Space;
            else
                text += KeyConst.Consist.Result.Unqualified + KeyConst.Punctuation.Space;
            _ResultText = text;
        }

        public TestResult ExportTestResult()
        {
            TestResult tr = new TestResult(true);
            tr.IsSummaryOk = _IsQualified;
            tr.TestText += _ResultText + Environment.NewLine;
            return tr;
        }
    }
}
