using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN2003to04 : ConsistCommon
    {
        private string CML = "CML";
        private string CEM = "CEM";
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
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToLastWithinSec(cml.Data, cml.Data, 5000);
                mt.AppendText("自首次发送CML报文起", "内，充电机按周期发送该报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(cml.Data, CML);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                //Access_CEM cem = new Access_CEM();
                //cem.GetCEM_SPN3923_01(db);
                //if (cem.IsNullData())
                //{
                //    return report = result.ExportNullReport("SPN3923=01的CEM");
                //}
                //mt.MeasureFirstMsgToFirstMsg(cml.Data, cem.Data, 5000);
                //mt.AppendText("自首次发送CML报文起超过", "，充电机发送SPN3923=01的CEM报文");
                //result.AppendTestResult(mt.ExportTestResult());

                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);
                if (cemTotal.IsNullData())
                {
                    return report = result.ExportNullReport(CEM);
                }

                mt.MeasureFirstToFirstWithoutSec(cml.Data, cemTotal.Data, 5000);
                mt.AppendText("自首次发送CML报文起超过", "，充电机发送CEM报文");
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
