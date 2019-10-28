using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN3001 : ConsistCommon
    {
        private string CRO = "CRO";
        private string CEM = "CEM";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                //Access_CRO cro = new Access_CRO();
                //cro.GetCRO_SPN2830_AA(db);
                //if (cro.IsNullData())
                //{
                //    return report = result.ExportNullReport("SPN2830=AA的CRO");
                //}

                //Access_CRO croTotal = new Access_CRO();
                //croTotal.GetCRO(db);

                //Measure measure = new Measure(croTotal.Data, CRO);
                //measure.MeasureCommon(consistId);
                //result.AppendTestResult(measure.ExportTestResult());

                Access_CRO cro = new Access_CRO();
                cro.GetCRO(db);
                if (cro.IsNullData())
                {
                    return report = result.ExportNullReport(CRO);
                }

                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToLastWithinSec(cro.Data, cro.Data, 5000);
                mt.AppendText("自首次发送CRO报文起", "内，充电机按周期发送该报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(cro.Data, CRO);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                /*************************************************/
                //Access_CEM cem = new Access_CEM();
                //cem.GetCEM_SPN3924_01(db);
                //if (cem.IsNullData())
                //{
                //    return report = result.ExportNullReport("SPN3924=01的CEM");
                //}


                //mt.MeasureFirstToFirstWithinSec(cro.Data, cem.Data, 5000);
                //mt.AppendText("自首次发送SPN2830=AA的CRO报文起超过", "，充电机发送SPN3924=01的CEM报文");
                //result.AppendTestResult(mt.ExportTestResult());

                //Access_CEM cemTotal = new Access_CEM();
                //cemTotal.GetCEM(db);

                //measure = new Measure(cemTotal.Data, CEM);
                //measure.MeasureCommon(consistId);
                //result.AppendTestResult(measure.ExportTestResult());

                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);

                mt.MeasureFirstToFirstWithoutSec(cro.Data, cemTotal.Data, 5000);
                mt.AppendText("自首次发送CRO报文起超过", "，充电机发送CEM报文");
                result.AppendTestResult(mt.ExportTestResult());

                measure = new Measure(cemTotal.Data, CEM);
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
