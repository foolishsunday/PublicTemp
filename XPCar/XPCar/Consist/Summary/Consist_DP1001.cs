using System;
using XPCar.Common;
using XPCar.Consist;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.Summary
{
    public class Consist_DP1001 : ConsistCommon
    {
        private string CHM = "CHM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_CHM chm = new Access_CHM();
                chm.GetCHM(db);
                if (chm.IsNullData())
                {
                    return report = result.ExportNullReport(CHM);
                }
                Measure measure = new Measure(chm.Data,CHM);
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
