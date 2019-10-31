using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP3005 : ConsistCommon
    {
        private string CST = "CST";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BSM bsm00 = new Access_BSM();
                bsm00.GetBSM_SPN3096_00(db);
                if (bsm00.IsNullData())
                {
                    return report = result.ExportNullReport("SPN3096=00的BSM");
                }               

                Access_CST cst = new Access_CST();
                cst.GetCST(db);
                if (cst.IsNullData())
                {
                    return report = result.ExportNullReport(CST);
                }
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToFirstWithoutSec(bsm00.Data, cst.Data, 600000);
                mt.AppendText("等待时间超过", "，充电机发送CST报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(cst.Data, CST);
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
