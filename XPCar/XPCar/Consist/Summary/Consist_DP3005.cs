using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP3005 : ConsistCommon
    {
        private string CST = "CST";
        private string BSM = "BSM";
        private string CCS = "CCS";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BSM bsm00 = new Access_BSM();
                //bsm00.GetBSM_SPN3096_00(db);
                bsm00.GetBSM_NoCharging(db);
                if (bsm00.IsNullData())
                {
                    return report = result.ExportNullReport(BSM);
                }

                Access_BSM bsm01 = new Access_BSM();
                bsm01.GetBSM_PermitCharging(db);
                if (bsm01.IsNullData())
                {
                    return report = result.ExportNullReport(BSM);
                }

                Access_CCS ccs = new Access_CCS();
                ccs.GetCCS(db);
                if (ccs.IsNullData())
                {
                    return report = result.ExportNullReport(CCS);
                    //result.AppendResultIncorrectText("充电机接收到异常BSM报文后，未暂停输出电流");
                }

                bool isPuase = IsSPN3929Equal00BetweenBSM(ccs.Data, bsm00.Data, bsm01.Data);
                if (isPuase)
                {
                    result.AppendResultCorrectText("充电机暂停输出电流");
                }
                else
                    result.AppendResultIncorrectText("充电机未暂停输出电流");

                Access_CST cst = new Access_CST();
                cst.GetCST(db);
                if (cst.IsNullData())
                {
                    return report = result.ExportNullReport(CST);
                }
                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureFirstToFirstWithoutSec(bsm00.Data, cst.Data, 600000);
                mt.AppendText("等待时间超过", "，充电机发送CST报文");
                result.AppendTestResult(mt.ExportTestResult());

                Measure measure = new Measure(cst.Data, CST);
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
        private bool IsSPN3929Equal00BetweenBSM(List<ConsistMsg> ccs, List<ConsistMsg> bsm00, List<ConsistMsg> bsm01)
        {
            int start = bsm00[0].ObjectNo;
            int end = bsm01[0].ObjectNo;
            if (start <= end)
            {
                for (int i = 0; i < ccs.Count; i++)
                {
                    if (ccs[i].ObjectNo >= start && ccs[i].ObjectNo <= end)
                    {
                        if (ccs[i].SPN3929 != "00")
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
                return false;
        }
    }
}
