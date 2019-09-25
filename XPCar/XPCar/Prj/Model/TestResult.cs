using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;

namespace XPCar.Prj.Model
{
    public class TestResult
    {
        //public long MinInterval { get; set; }
        //public long MaxInterval { get; set; }
        //public int Length { get; set; }
        //public string Format { get; set; }
        //public string MinIntervalResult { get; set; }
        //public string MaxIntervalResult { get; set; }
        //public string LengthResult { get; set; }
        //public string FormatResult { get; set; }
        public string TestText { get; set; }
        public bool IsSummaryOk { get; set; }
        public TestResult(bool bInitSummary)
        {
            IsSummaryOk = bInitSummary;
            TestText = string.Empty;
        }
        public TestItemsReport NullMsgReport(string msgName, TestItemsReport report)
        {
            report.TestText1 += "未接收到" + msgName + "报文" + KeyConst.Punctuation.Space;
            report.TestResult1 = KeyConst.Consist.Result.Unqualified;
            report.TestSummary = KeyConst.Consist.Result.Unqualified;
            return report;
        }
        public void AppendTestResult(TestResult now)
        {
            TestText += now.TestText;
            IsSummaryOk &= now.IsSummaryOk;
        }
        public void AppendText(string text)
        {
            TestText += text + KeyConst.Punctuation.Space;
        }
        public void AppendNoMsg(string msgName)
        {
            TestText += "未接收到" + msgName + "报文" + KeyConst.Punctuation.Space;
            IsSummaryOk &= false;
        }
        public void AppendText(string text, bool bResult)
        {
            TestText += text + KeyConst.Punctuation.Space;
            IsSummaryOk &= bResult;
        }
        public TestItemsReport ExportTestReport()
        {
            TestItemsReport report = new TestItemsReport();
            report.TestText1 = TestText;
            if (IsSummaryOk)
            {
                report.TestResult1 = KeyConst.Consist.Result.Qualified;
                report.TestSummary = KeyConst.Consist.Result.Qualified;

            }
            else
            {
                report.TestResult1 = KeyConst.Consist.Result.Unqualified;
                report.TestSummary = KeyConst.Consist.Result.Unqualified;
            }
            return report;
        }
    }
}
