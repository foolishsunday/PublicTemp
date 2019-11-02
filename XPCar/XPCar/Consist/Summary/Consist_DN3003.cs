using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN3003 : ConsistCommon
    {
        private string CRO = "CRO";
        private string CEM = "CEM";
        //private string BCS = "BCS";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BCS bcs = new Access_BCS();
                bcs.GetBCS(db);
                if (bcs.IsNullData())
                {                   
                    result.AppendResultIncorrectText("充电机没有使用传输协议功能接收BCS报文");
                }
                else
                {
                    result.AppendResultCorrectText("充电机使用传输协议功能完成接收完成BCS报文");
                }

                Access_CEM cemTotal = new Access_CEM();
                cemTotal.GetCEM(db);
                if (cemTotal.IsNullData())
                {
                    return report = result.ExportNullReport(CEM);
                }

                Access_CRO croTotal = new Access_CRO();
                //croTotal.GetBeforeMsg(db, cemTotal.Data);
                croTotal.GetCRO_SPN2830_AA(db);
                if (croTotal.IsNullData())
                {
                    return report = result.ExportNullReport(CRO);
                }

                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToLastWithinSec(croTotal.Data, croTotal.Data, 5000);
                mt.AppendText("自首次发送CRO报文起", "内，充电机按周期发送该报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(croTotal.Data, CRO);
                measure.MeasureCommon(consistId);
                result.AppendTestResult(measure.ExportTestResult());

                mt.MeasureFirstToFirstWithoutSec(croTotal.Data, cemTotal.Data, 5000);
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
