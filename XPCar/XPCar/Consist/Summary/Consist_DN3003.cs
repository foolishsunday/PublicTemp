using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN3003 : ConsistCommon
    {
        private string CRO = "CRO";
        private string CEM = "CEM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_CRO cro = new Access_CRO();
                cro.GetCRO_SPN2830_AA(db);
                if (cro.IsNullData())
                {
                    result.AppendNoMsg("SPN2830=AA的CRO");
                    report = result.ExportTestReport();
                    return report;
                }

                Access_CRO croTotal = new Access_CRO();
                croTotal.GetCRO(db);

                Measure measure = new Measure(croTotal.Data, CRO);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                Access_CEM cem = new Access_CEM();
                cem.GetCEM_SPN3924_01(db);
                if (cem.IsNullData())
                {
                    result.AppendNoMsg("SPN3924=01的CEM");
                    report = result.ExportTestReport();
                    return report;
                }

                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstMsgToFirstMsg(cro.Data, cem.Data, 5000);
                mt.AppendText("自首次发送SPN2830=AA的CRO报文起超过", "，充电机发送SPN3924=01的CEM报文");
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
