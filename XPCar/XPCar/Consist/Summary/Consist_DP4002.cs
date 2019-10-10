using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.Summary
{
    public class Consist_DP4002 : ConsistCommon
    {
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                result.AppendText("充电机无法响应充电,需重新插拔充电连接装置后才能继续充电", true);

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
