using System;
using XPCar.Common;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.Summary
{
    public class Consist_DP1003 : ConsistCommon
    {
        //private string BRM = "BRM";
        private string CRM = "CRM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_CRM crm = new Access_CRM();
                crm.GetCRM_SPN2560_AA(db);
                if (crm.IsNullData())
                {
                    result.AppendNoMsg("SPN2560=AA的CRM");
                    report = result.ExportTestReport();
                    return report;
                }

                Access_CRM crmTotal = new Access_CRM();
                crmTotal.GetCRM(db);

                Measure measure = new Measure(crmTotal.Data, CRM);
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
