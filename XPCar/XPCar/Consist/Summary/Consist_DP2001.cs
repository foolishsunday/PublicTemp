using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.Summary
{
    public class Consist_DP2001 : ConsistCommon
    {
        private string BCP = "BCP";
        private string CML = "CML";
        //private string CRM = "CRM";
        //private string CTS = "CTS";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BCP bcp = new Access_BCP();
                bcp.GetMutiEnd(db);
                if (bcp.IsNullData())
                {
                    return report = result.ExportNullReport(BCP);
                }
                result.AppendResultCorrectText("充电机使用传输协议功能接收BCP报文");

                Access_CRM crm = new Access_CRM();
                crm.GetCRM_SPN2560_AA(db);
                if (crm.IsNullData())
                {
                    return report = result.ExportNullReport("SPN2560=AA的CRM");
                }
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureAStopWhileRcvB(crm.Data, bcp.Data);
                mt.AppendStopResult("充电机", "未", "停止发送SPN2560=AA的CRM");
                result.AppendTestResult(mt.ExportTestResult());

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

