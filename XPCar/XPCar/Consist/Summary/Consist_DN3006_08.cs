using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN3006_08 : ConsistCommon
    {
        private string BCL = "BCL";
        private string CCS = "CCS";
        private string CEM = "CEM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                //CEM
                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);
                if (cemTotal.IsNullData())
                {
                    return report = result.ExportNullReport(CEM);
                }

                //CCS
                Access_BCL bcl = new Access_BCL();
                bcl.GetBeforeMsg(db, cemTotal.Data);
                if (bcl.IsNullData())
                {
                    return report = result.ExportNullReport(BCL);
                }

                Access_CCS ccs = new Access_CCS();
                ccs.GetBeforeMsg(db, cemTotal.Data);
                if (ccs.IsNullData())
                {
                    return report = result.ExportNullReport(CCS);
                }

                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureLastToLastWithinSec(bcl.Data, ccs.Data, 1000);
                mt.AppendText("自上一次接收到BCL报文起", "内，充电机按周期发送CCS报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(ccs.Data, CCS);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                mt.MeasureLastToFirstWithoutSec(bcl.Data, cemTotal.Data, 1000);
                mt.AppendText("自上一次接收到BCL报文起超过", "，充电机发送CEM报文");
                result.AppendTestResult(mt.ExportTestResult());

                measure = new Measure(cemTotal.Data, CEM);
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
