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
        private bool _ResultTimeout;
        private string _ResultText;
        public MeasureTimeout()
        {
            _ResultTimeout = true;
        }
        public string ResultText(string consistId)
        {
            return _ResultText;
        }
        public bool IsResultOk()
        {
            return _ResultTimeout;
        }

        public long MeasureFirstMsgWithoutSec(string earlier, List<ConsistMsg> laterList, long ms)
        {
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= ms && span <= TimeoutOffset(ms))
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;

        }
        public long MeasureFirstMsgToFirstMsgWithoutSec(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[0].CreateTimestamp;
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= ms && span <= TimeoutOffset(ms))
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;

        }
        public long MeasureFirstMsgWithinSec(string earlier, List<ConsistMsg> laterList, long ms)
        {
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= ms && span <= TimeoutOffset(ms))
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;

        }
        public long MeasureStopLastMsgToFirstMsg(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[earlierList.Count - 1].CreateTimestamp;
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= ms)
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = "";
            return span;
        }
        public long MeasureFirstMsgToFirstMsg(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[0].CreateTimestamp;
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= ms && span <= TimeoutOffset(ms))
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;

        }
        public long MeasureFirstMsgToFirstMsgWithinSec(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[0].CreateTimestamp;
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span <= TimeoutOffset(ms))
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;

        }
        public long MeasureFirstMsgToLastMsgWithinSec(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[0].CreateTimestamp;
            string later = laterList[laterList.Count - 1].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span <= TimeoutOffset(ms))
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;

        }
        public long MeasureFirstMsgToLastMsg(List<ConsistMsg> earlierList, List<ConsistMsg> laterList)
        {
            string earlier = earlierList[earlierList.Count - 1].CreateTimestamp;
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= 0)
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;
        }
        public long MeasureLastMsgToFirstMsgWithinSec(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[earlierList.Count - 1].CreateTimestamp;
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= 0 && span <= TimeoutOffset(ms))
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;
        }
        public long MeasureFirstMsgToLastMsgWithoutSec(List<ConsistMsg> earlierList, List<ConsistMsg> laterList, long ms)
        {
            string earlier = earlierList[earlierList.Count - 1].CreateTimestamp;
            string later = laterList[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= ms && span <= TimeoutOffset(ms))
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;
        }
        public long MeasureOneStartToEndWithoutSec(List<ConsistMsg> list, long ms)
        {
            string later = list[list.Count - 1].CreateTimestamp;
            string earlier = list[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= ms && span <= TimeoutOffset(ms))
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;
        }
        //public long MeasureOneStartToEndWithinSec(List<ConsistMsg> list, long ms)
        //{
        //    string later = list[list.Count - 1].CreateTimestamp;
        //    string earlier = list[0].CreateTimestamp;
        //    long span = Function.CalcIntervalByTwoPara(later, earlier);
        //    if (span <= ms)
        //        _ResultTimeout = true;
        //    else
        //        _ResultTimeout = false;
        //    _ResultText = span.ToString() + "ms";
        //    return span;
        //}
        public long MeasureSpecialBST(List<ConsistMsg> bsts)
        {
            string earlier = bsts[0].CreateTimestamp;
            string later = bsts[bsts.Count - 1].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= 50 && span < 100)
                _ResultTimeout = true;
            else
                _ResultTimeout = false;
            _ResultText = span.ToString() + "ms";
            return span;
        }
        public long TimeoutOffset(long timeout)
        {
            long std = 0;
            if (timeout == 1000)
                std = 1200;
            else if (timeout == 5000)
                std = 5500;
            else if (timeout >= 10000)
                std = timeout + 3000;
            return std;
        }

        public void AppendText(string text1, string text2)
        {
            string text = text1 + ResultText(null) + text2 + KeyConst.Punctuation.Space;
            _ResultText = text;
            if (_ResultTimeout)
                text += KeyConst.Consist.Result.Qualified + KeyConst.Punctuation.Space;
            else
                text += KeyConst.Consist.Result.Unqualified + KeyConst.Punctuation.Space;
            _ResultText = text;
        }
        public void AppendText(string text)
        {
            _ResultText = text;
            if (_ResultTimeout)
                text += KeyConst.Consist.Result.Qualified + KeyConst.Punctuation.Space;
            else
                text += KeyConst.Consist.Result.Unqualified + KeyConst.Punctuation.Space;
            _ResultText = text;
        }
        public TestResult ExportTestResult()
        {
            TestResult tr = new TestResult(true);
            tr.IsSummaryOk = _ResultTimeout;
            tr.TestText += _ResultText;
            return tr;
        }
    }
}
