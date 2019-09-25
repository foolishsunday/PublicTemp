using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class TestItemsReport
    {
        public TestItemsReport()
        {
            ObjectNo = 0;
            ItemId = "";
            ResultInView = "";
            Remarks = "";
            TestText1 = "";
            TestResult1 = "";
            TestText2 = "";
            TestResult2 = "";
            TestText3 = "";
            TestResult3 = "";
            TestText4 = "";
            TestResult4 = "";
            TestSummary = "";
            CreateTimestamp = "";
        }
        public int ObjectNo { get; set; }
        public string ItemId { get; set; }
        public string ResultInView { get; set; }
        public string Remarks { get; set; }
        public string TestText1 { get; set; }
        public string TestResult1 { get; set; }
        public string TestText2 { get; set; }
        public string TestResult2 { get; set; }
        public string TestText3 { get; set; }
        public string TestResult3 { get; set; }
        public string TestText4 { get; set; }
        public string TestResult4 { get; set; }
        public string TestSummary { get; set; }
        public string CreateTimestamp { get; set; }

    }
}
