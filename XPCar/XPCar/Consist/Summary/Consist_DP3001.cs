using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP3001 : ConsistCommon
    {
        //private string BCS = "BCS";
        private string CCS = "CCS";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {

                Access_CCS ccs = new Access_CCS();
                ccs.GetCCS(db);
                if (ccs.IsNullData())
                {
                    return report = result.ExportNullReport(CCS);
                }
                Measure measure = new Measure(ccs.Data, CCS);
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
