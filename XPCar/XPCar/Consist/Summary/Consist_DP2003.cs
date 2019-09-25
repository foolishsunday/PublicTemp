using System;
using XPCar.Common;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP2003 : ConsistCommon
    {
        private string CRO = "CRO";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_CRO cro = new Access_CRO();
                cro.GetCRO_SPN2830_00(db);
                if (cro.IsNullData())
                {
                    result.AppendNoMsg("SPN2830=00的CRO");
                    report = result.ExportTestReport();
                    return report;
                }
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
