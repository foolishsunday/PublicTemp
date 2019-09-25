using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN2006 : ConsistCommon
    {
        //private string BCP = "BCP";
        private string CML = "CML";
        private string CEM = "CEM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_CML cml = new Access_CML();
                cml.GetCML(db);
                if (cml.IsNullData())
                {
                    result.AppendNoMsg(CML);
                    report = result.ExportTestReport();
                    return report;
                }
                Measure measure = new Measure(cml.Data, CML);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                Access_CEM cem = new Access_CEM();
                cem.GetCEM_SPN3923_01(db);
                if (cem.IsNullData())
                {
                    result.AppendNoMsg(CEM);
                    report = result.ExportTestReport();
                    return report;
                }
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstMsgToFirstMsg(cml.Data, cem.Data, 5000);
                mt.AppendText("自首次发送CML报文起超过", "，充电机发送SPN3923=01的CEM报文");
                result.AppendTestResult(mt.ExportTestResult());

                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);

                measure = new Measure(cemTotal.Data, CEM);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                report = result.ExportTestReport();

                return report;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return report;
        }
    }
}
