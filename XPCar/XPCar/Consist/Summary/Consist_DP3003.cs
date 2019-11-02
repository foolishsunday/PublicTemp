using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP3003 : ConsistCommon
    {
        private string CST = "CST";
        //private string BSM = "BSM";
        private string CCS = "CCS";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BSM bsm = new Access_BSM();
                bsm.GetBSM_SPN_DP3003(db);
                if (bsm.IsNullData())
                {
                    return report = result.ExportNullReport("SPN3090=01或SPN3090=10或SPN3091=01或SPN3091=10或" +
                        "SPN3092=01或SPN3093=01或SPN3094=01或SPN3095=01的BSM");
                }
                Access_CCS ccs = new Access_CCS();
                ccs.GetCCS(db);
                if (ccs.IsNullData())
                {
                    return report = result.ExportNullReport(CCS);
                }
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureAStopWhileRcvB(ccs.Data, bsm.Data);
                mt.AppendStopResult("充电机接收到异常BSM报文后，", "未", "停止发送CCS报文");
                result.AppendTestResult(mt.ExportTestResult());


                Access_CST cst = new Access_CST();
                cst.GetCST(db);
                if (cst.IsNullData())
                {
                    return report = result.ExportNullReport(CST);
                }
                Measure measure = new Measure(cst.Data, CST);
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
