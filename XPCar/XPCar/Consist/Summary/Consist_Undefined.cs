using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.Summary
{
    public class Consist_Undefined : ConsistCommon
    {
        public override TestItemsReport GenerateReport(DbService db, string msgName)
        {
            try
            {
                TestItemsReport report = new TestItemsReport();
                report.TestSummary = KeyConst.Consist.Result.Unqualified;
                report.ItemId = string.Empty;
                return report;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return null;
            }

        }
    }
}
