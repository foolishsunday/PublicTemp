using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN3009to10 : ConsistCommon
    {
        private string CST = "CST";
        private string CEM = "CEM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_CST cst = new Access_CST();
                cst.GetCST(db);
                if (cst.IsNullData())
                {
                    return report = result.ExportNullReport(CST);
                }

                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToLastWithinSec(cst.Data, cst.Data, 5000);
                mt.AppendText("自首次发送CST报文起", "内，充电机按周期发送该报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(cst.Data, CST);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                //CEM
                Access_CEM cem = new Access_CEM();
                cem.GetCEM(db);
                if (cem.IsNullData())
                {
                    return report = result.ExportNullReport(CEM);
                }

                mt.MeasureFirstToFirstWithoutSec(cst.Data, cem.Data, 5000);
                mt.AppendText("自首次发送CST报文起超过", "，充电机发送CEM报文");
                result.AppendTestResult(mt.ExportTestResult());

                measure = new Measure(cem.Data, CEM);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                report = result.ExportTestReport();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return report;
        }
    }
}
