using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP2003 : ConsistCommon
    {
        private string CRO = "CRO";
        //private string BRO = "BRO";
        private string CML = "CML";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BRO bro = new Access_BRO();
                bro.GetBRO_SPN2829_AA(db);
                if (bro.IsNullData())
                {
                    return report = result.ExportNullReport("SPN2829=AA的BRO");
                }
                Access_CML cml = new Access_CML();
                cml.GetCML(db);
                if (cml.IsNullData())
                {
                    return report = result.ExportNullReport(CML);
                }
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureAStopWhileRcvB(cml.Data, bro.Data);
                mt.AppendStopResult("充电机接收到SPN2829=AA的BRO报文后，", "未", "停止发送CML报文");
                result.AppendTestResult(mt.ExportTestResult());

                Access_CRO croTotal = new Access_CRO();
                croTotal.GetCRO(db);
                if (croTotal.IsNullData())
                {
                    return report = result.ExportNullReport(CRO);
                }

                Measure measure = new Measure(croTotal.Data, CRO);
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
