using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP3004 : ConsistCommon
    {
        private string CCS = "CCS";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BSM bsm = new Access_BSM();
                bsm.GetBSM_SPN_DP3004(db);
                if (bsm.IsNullData())
                {
                    return report = result.ExportNullReport("SPN3092=10或SPN3093=10或SPN3094=10或SPN3095=10的BSM");
                }

                Access_CCS ccs01 = new Access_CCS();
                ccs01.Get_SPN3929_01_AfterMsg(db, bsm.Data);
                if (ccs01.IsNullData())
                {
                    result.AppendResultIncorrectText("充电机未保持上一状态,对不可信状态数据包不做处理,按BMS需求输出");
                }
                else
                    result.AppendResultCorrectText("充电机保持上一状态,对不可信状态数据包不做处理,按BMS需求输出");

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
