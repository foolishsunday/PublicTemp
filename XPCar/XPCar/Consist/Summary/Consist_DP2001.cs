using System;
using XPCar.Common;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.Summary
{
    public class Consist_DP2001 : ConsistCommon
    {
        //private string BCP = "BCP";
        private string CML = "CML";
        //private string CTS = "CTS";
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
                    return report = result.ExportNullReport(CML);
                }
                Measure measure = new Measure(cml.Data, CML);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                //Access_CTS cts = new Access_CTS();
                //cts.GetCTS(db);
                //if (cts.IsNullData())
                //{
                //    return report = result.ExportNullReport(CTS);
                //}
                //measure = new Measure(cts.Data, CTS);
                //measure.MeasureCommon(consistId);
                //result.AppendTestResult(measure.ExportTestResult());

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

