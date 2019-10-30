using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN2010: ConsistCommon
    {
        //private string BCP = "BCP";
        private string CRO = "CRO";
        private string CEM = "CEM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_CEM cem = new Access_CEM();
                cem.GetCEM(db);
                if (cem.IsNullData())
                {
                    return report = result.ExportNullReport(CEM);
                }

                Access_CRO cro = new Access_CRO();
                cro.GetBeforeMsgSPN2830_AA(db, cem.Data);
                if (cro.IsNullData())
                {
                    return report = result.ExportNullReport(CRO);
                }
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToLastWithinSec(cro.Data, cro.Data, 1000);
                mt.AppendText("自首次发送CRO报文起", "内，充电机按周期发送该报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(cro.Data, CRO);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                /****************************************************/


                mt.MeasureFirstToFirstWithoutSec(cro.Data, cem.Data, 1000);
                mt.AppendText("自首次发送CRO报文起超过", "，充电机发送CEM报文");
                result.AppendTestResult(mt.ExportTestResult());

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
