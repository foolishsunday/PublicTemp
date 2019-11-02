using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.Summary
{
    public class Consist_DP1003 : ConsistCommon
    {
        private string BRM = "BRM";
        private string CRM = "CRM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BRM brm = new Access_BRM();
                brm.GetBRM(db);
                if (brm.IsNullData())
                {
                    return report = result.ExportNullReport(BRM);
                }
                result.AppendResultCorrectText("充电机使用传输协议功能接收完成BRM报文");

                Access_CRM crm = new Access_CRM();
                crm.GetCRM_SPN2560_00(db);
                if (crm.IsNullData())
                {
                    return report = result.ExportNullReport("SPN2560=00的CRM");
                }

                MeasureTimeout mt = new MeasureTimeout();
                long span = mt.MeasureAStopWhileRcvB(crm.Data, brm.Data);
                mt.AppendStopResult("充电机", "未", "停止发送SPN2560=00的CRM报文");
                result.AppendTestResult(mt.ExportTestResult());

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
