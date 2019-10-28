using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN2001to02 : ConsistCommon
    {
        private string CRM = "CRM";
        private string CEM = "CEM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                //Access_CRM crm = new Access_CRM();
                //crm.GetCRM_SPN2560_AA(db);

                //if (crm.IsNullData())
                //{
                //    return report = result.ExportNullReport("SPN2560=AA的CRM");
                //}

                //Access_CRM crmTotal = new Access_CRM();
                //crmTotal.GetCRM(db);

                //Measure measure = new Measure(crmTotal.Data, CRM);
                //measure.MeasureCommon(consistId);
                //result.AppendTestResult(measure.ExportTestResult());

                //Access_CEM cem = new Access_CEM();
                //cem.GetCEM_SPN3922_01(db);
                //if (cem.IsNullData())
                //{
                //    return report = result.ExportNullReport("SPN3922=01的CEM");
                //}
                //MeasureTimeout mt = new MeasureTimeout();
                //mt.MeasureFirstMsgToFirstMsg(crm.Data, cem.Data, 5000);
                //mt.AppendText("自首次发送SPN2560=AA的CRM报文起超过", "，充电机发送SPN3922=01的CEM报文");
                //result.AppendTestResult(mt.ExportTestResult());

                //Access_CEM cemTotal = new Access_CEM();
                //cemTotal.GetCEM(db);

                //measure = new Measure(cemTotal.Data, CEM);
                //measure.MeasureCommon(consistId);
                //result.AppendTestResult(measure.ExportTestResult());

                //CRM
                Access_CRM crmTotal = new Access_CRM();
                crmTotal.GetCRM(db);
                if (crmTotal.IsNullData())
                {
                    return report = result.ExportNullReport(CRM);
                }
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToLastWithinSec(crmTotal.Data, crmTotal.Data, 5000);
                mt.AppendText("自首次发送CRM报文起", "内，充电机按周期发送该报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(crmTotal.Data, CRM);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                //CEM
                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);
                if (cemTotal.IsNullData())
                {
                    return report = result.ExportNullReport(CEM);
                }
                mt.MeasureFirstToFirstWithoutSec(crmTotal.Data, cemTotal.Data, 5000);
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
