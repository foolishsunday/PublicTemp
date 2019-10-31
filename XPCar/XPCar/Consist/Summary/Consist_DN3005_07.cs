using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN3005_07 : ConsistCommon
    {
        private string CCS = "CCS";
        private string BCS = "BCS";
        private string CEM = "CEM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);

                if (cemTotal.IsNullData())
                {
                    return report = result.ExportNullReport(CEM);
                }

                Access_BCS bcs = new Access_BCS();
                //bcs.GetBeforeMsg(db, cemTotal.Data);
                bcs.GetBCS(db);
                if (bcs.IsNullData())
                {
                    return report = result.ExportNullReport(BCS);
                }

                Access_CCS ccs = new Access_CCS();
                //ccs.GetBeforeMsg(db, cemTotal.Data);
                ccs.GetCCS(db);
                if (ccs.IsNullData())
                {
                    return report = result.ExportNullReport(CCS);
                }

                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToLastWithinSec(bcs.Data, ccs.Data, 5000);
                mt.AppendText("自上一次接收到BCS报文起", "内，充电机按周期发送CCS报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(ccs.Data, CCS);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                mt.MeasureLastToFirstWithoutSec(bcs.Data, cemTotal.Data, 5000);
                mt.AppendText("自上一次接收到BCS报文起超过", "，充电机发送CEM报文");
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
