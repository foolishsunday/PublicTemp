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
                Access_BCL bcl = new Access_BCL();
                bcl.GetBCL(db);
                if (bcl.IsNullData())
                {
                    result.AppendNoMsg(BCL);
                    report = result.ExportTestReport();
                    return report;
                }

                Access_CCS ccs = new Access_CCS();
                ccs.GetCCS(db);
                if (ccs.IsNullData())
                {
                    result.AppendNoMsg(CCS);
                    report = result.ExportTestReport();
                    return report;
                }

                Measure measure = new Measure(ccs.Data, CCS);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                Access_CEM cem = new Access_CEM();
                cem.GetCEM_SPN3925_01(db);
                if (cem.IsNullData())
                {
                    result.AppendNoMsg("SPN3925=01的CEM");
                    report = result.ExportTestReport();
                    return report;
                }

                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstMsgToFirstMsg(bcl.Data, cem.Data, 1000);
                mt.AppendText("自首次发送BCL报文起超过", "，充电机发送SPN3925=01的CEM报文");
                result.AppendTestResult(mt.ExportTestResult());

                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);

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
