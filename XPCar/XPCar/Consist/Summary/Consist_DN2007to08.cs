using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN2007to08 : ConsistCommon
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
                //BRO
                Access_BRO bro = new Access_BRO();
                bro.GetBRO_SPN2829_AA(db);
                if (bro.IsNullData())
                {
                    return report = result.ExportNullReport("SPN2829=AA的BRO");
                }
                //CEM
                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);
                if (cemTotal.IsNullData())
                {
                    return report = result.ExportNullReport(CEM);
                }

                //CRO
                Access_CRO cro = new Access_CRO();
                cro.GetBeforeMsg(db, cemTotal.Data);
                if (cro.IsNullData())
                {
                    return report = result.ExportNullReport(CRO);
                }
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToLastWithinSec(bro.Data, cro.Data, 5000);
                mt.AppendText("自上一次接收到SPN2829=AA的BRO报文起", "内，充电机按周期发送CRO报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(cro.Data, CRO);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());


                mt.MeasureFirstToFirstWithoutSec(bro.Data, cemTotal.Data, 5000);
                mt.AppendText("自上一次接收到SPN2829=AA的BRO报文起超过", "，充电机按发送CEM报文");
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
