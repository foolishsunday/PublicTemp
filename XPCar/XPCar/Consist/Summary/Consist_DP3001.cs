using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP3001 : ConsistCommon
    {
        private string BCS = "BCS";
        private string CCS = "CCS";
        //private string CRO = "CRO";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BCS bcs = new Access_BCS();
                bcs.GetMutiEnd(db);
                if (bcs.IsNullData())
                {
                    return report = result.ExportNullReport(BCS);
                }
                result.AppendResultCorrectText("充电机使用传输协议功能接收完成BCS报文");

                Access_CRO cro = new Access_CRO();
                cro.GetCRO_SPN2830_AA(db);
                if (cro.IsNullData())
                {
                    return report = result.ExportNullReport("SPN2830=AA的CRO");
                }
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureAStopWhileRcvB(cro.Data, bcs.Data);
                mt.AppendStopResult("充电机接收到BCS报文后，", "未", "停止发送SPN2830=AA的CRO报文");
                result.AppendTestResult(mt.ExportTestResult());


                Access_CCS ccs = new Access_CCS();
                ccs.GetCCS(db);
                if (ccs.IsNullData())
                {
                    return report = result.ExportNullReport(CCS);
                }
                Measure measure = new Measure(ccs.Data, CCS);
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
