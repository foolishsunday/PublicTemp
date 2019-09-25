using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP4001 : ConsistCommon
    {
        private string CSD = "CSD";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_CSD csd = new Access_CSD();
                csd.GetCSD(db);
                if (csd.IsNullData())
                {
                    result.AppendNoMsg(CSD);
                    report = result.ExportTestReport();
                    return report;
                }

                Measure measure = new Measure(csd.Data,CSD);
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
