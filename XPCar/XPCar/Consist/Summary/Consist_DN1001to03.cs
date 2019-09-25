using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.Summary
{
    public class Consist_DN1001to03 : ConsistCommon
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
                crm.GetCRM_SPN2560_00(db);
                if (crm.IsNullData())
                {
                    result.AppendNoMsg(CRM);
                    report = result.ExportTestReport();
                    return report;
                }

                Access_CRM crmTotal = new Access_CRM();
                crmTotal.GetCRM(db);

                Measure measure = new Measure(crm.Data, CRM);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                Access_CEM cem = new Access_CEM();
                cem.GetCEM_SPN3921_01(db);
                if (cem.IsNullData())
                {
                    result.AppendNoMsg("SPN3921=01的CEM");
                    report = result.ExportTestReport();
                    return report;
                }

                MeasureTimeout mt = new MeasureTimeout();
                long span = mt.MeasureFirstMsgToFirstMsg(crm.Data, cem.Data, 5000);
                mt.AppendText("自首次发送CRM报文起超过", "，充电机发送SPN3921=01的CEM报文");
                result.AppendTestResult(mt.ExportTestResult());

                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);

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
