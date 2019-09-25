using System;
using XPCar.Common;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.Summary
{
    public class Consist_DP1002 : ConsistCommon
    {
        private string CHM = "CHM";
        private string CRM = "CRM";
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
                    result.AppendNoMsg(CHM);
                    report = result.ExportTestReport();
                    return report;
                }
                Measure measure = new Measure(chm.Data, CHM);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                Access_CRM crm = new Access_CRM();
                crm.GetCRM(db);
                if (crm.IsNullData())
                {
                    result.AppendNoMsg(CRM);
                    report = result.ExportTestReport();
                    return report;
                }
                measure = new Measure(crm.Data, CRM);
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
