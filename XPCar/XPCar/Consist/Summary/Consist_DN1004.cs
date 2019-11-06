using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.Summary
{
    public class Consist_DN1004 : ConsistCommon
    {
        private string CRM = "CRM";
        private string CEM = "CEM";
        private string BRM = "BRM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                //Access_BRM brm = new Access_BRM();
                //brm.GetMutiReady(db);
                //if (brm.IsNullData())
                //{
                //    return report = result.ExportNullReport(BRM);
                //}


                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);
                if (cemTotal.IsNullData())
                {
                    return report = result.ExportNullReport(CEM);
                }


                Access_CRM crmSection = new Access_CRM();
                //crmSection.GetBeforeMsg(db, cemTotal.Data);
                crmSection.GetCRM_SPN2560_AA(db);
                if (crmSection.IsNullData())
                {
                    return report = result.ExportNullReport(CRM);
                }

                Access_BRM brm = new Access_BRM();
                brm.GetAfterMsg(db, crmSection.Data);
                if (brm.IsNullData())
                {
                    return report = result.ExportNullReport(BRM);
                }

                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToLastWithinSec(crmSection.Data, brm.Data, 5000);
                mt.AppendText("自首次发送CRM报文起", "内，充电机使用传输协议功能接收BRM报文");
                result.AppendTestResult(mt.ExportTestResult());

                mt.MeasureFirstToLastWithinSec(crmSection.Data, crmSection.Data, 5000);
                mt.AppendText("自首次发送CRM报文起", "内，充电机按周期发送该报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(crmSection.Data, CRM);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());


                mt.MeasureFirstToFirstWithoutSec(crmSection.Data, cemTotal.Data, 5000);
                mt.AppendText("自首次发送CRM报文起超过", "，充电机发送CEM报文");
                result.AppendTestResult(mt.ExportTestResult());

                measure = new Measure(cemTotal.Data, CEM);
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
