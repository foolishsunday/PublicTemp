using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Prj.Model;

namespace XPCar.Consist
{
    public class Measure
    {
        private List<ConsistMsg> _ConsistData;
        private string _MsgName;
        private TestResult _Report;
        public TestResult Report
        {
            get { return _Report; }
            set { _Report = value; }
        }
        public Measure(List<ConsistMsg> lists, string msgName)
        {
            _Report = new TestResult(true);
            _ConsistData = lists;
            _MsgName = msgName;
        }

        //TODO:判断Consist数据基本信息
        public void MeasureCommon(string consistId)
        {
            //格式
            IMeasureResult im = new MeasureFormat(_ConsistData, _MsgName);
            _Report.TestText += im.ResultText(consistId);
            _Report.IsSummaryOk &= im.IsResultOk();

            //周期
            im = new MeasureInterval(_ConsistData, _MsgName);
            _Report.TestText += im.ResultText(consistId);
            _Report.IsSummaryOk &= im.IsResultOk();

            //长度
            im = new MeasureLength(_ConsistData, _MsgName);
            _Report.TestText += im.ResultText(consistId);
            _Report.IsSummaryOk &= im.IsResultOk();
        }

     
        public string GetSummaryText()
        {
            if (_Report.IsSummaryOk)
                return KeyConst.Consist.Result.Qualified;
            else
                return KeyConst.Consist.Result.Unqualified;
        }
        //public TestItemsReport ExportReport(TestResult result)
        //{
        //    TestItemsReport report = new TestItemsReport();
        //    report.TestText1 = result.TestText + _Report.TestText;
        //    if (result.IsSummaryOk & _Report.IsSummaryOk)
        //    {
        //        report.TestResult1 = KeyConst.Consist.Result.Qualified;
        //        report.TestSummary = KeyConst.Consist.Result.Qualified;
        //    }
        //    else
        //    {
        //        report.TestResult1 = KeyConst.Consist.Result.Unqualified;
        //        report.TestSummary = KeyConst.Consist.Result.Unqualified;
        //    }
        //    return report;
        //}
        //public void SetSummary(bool result)
        //{
        //    _Report.IsSummaryOk &= result;
        //}
        //public bool GetSummary()
        //{
        //    return _Report.IsSummaryOk;
        //}
        public TestResult ExportTestResult()
        {
            return _Report;
        }

    }
}
