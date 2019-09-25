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

                Access_CEM cem = new Access_CEM();
                cem.GetCEM_SPN3922_01(db);
                if (cem.IsNullData())
                {
                    result.AppendNoMsg(CEM);
                    report = result.ExportTestReport();
                    return report;
                }

                MeasureTimeout mt = new MeasureTimeout();
                long span = mt.MeasureFirstMsgToFirstMsg(crm.Data, cem.Data, 5000);
                mt.AppendText("自首次发送SPN2560=AA的CRM报文起超过", "，充电机发送SPN3922=01的CEM报文");
                result.AppendTestResult(mt.ExportTestResult());

                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);

                measure = new Measure(cem.Data, CEM);
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
