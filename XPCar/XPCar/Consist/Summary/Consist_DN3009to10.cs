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
                    result.AppendNoMsg(CST);
                    report = result.ExportTestReport();
                    return report;
                }

                Measure measure = new Measure(cst.Data, CST);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                Access_CEM cem = new Access_CEM();
                cem.GetCEM_SPN3926_01(db);
                if (cem.IsNullData())
                {
                    result.AppendNoMsg("SPN3926=01的CEM");
                    report = result.ExportTestReport();
                    return report;
                }

                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstMsgToFirstMsg(cst.Data, cem.Data, 5000);
                mt.AppendText("自首次发送BCS报文起超过", "，充电机发送SPN3926=01的CEM报文");
                result.AppendTestResult(mt.ExportTestResult());

                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);

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
