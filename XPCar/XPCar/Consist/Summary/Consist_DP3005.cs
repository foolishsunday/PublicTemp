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
        //private string BSM = "BSM";
        //private string CCS = "CCS";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                MeasureTimeout mt = new MeasureTimeout();

                Access_BSM bsm00 = new Access_BSM();
                //bsm00.GetBSM_SPN3096_00(db);
                bsm00.GetBSM_SPN3096_00(db);
                if (bsm00.IsNullData())
                {
                    return report = result.ExportNullReport("SPN3096=00的BSM");
                }

                //
                Access_CCS ccs00 = new Access_CCS();
                ccs00.Get_SPN3929_00_AfterMsg(db, bsm00.Data);
                if (ccs00.IsNullData())
                {
                    return report = result.ExportNullReport("SPN3929=00的CCS");
                }

                bool isPuase = IsPauseOuputI(bsm00.Data, ccs00.Data);
                if (isPuase)
                {
                    result.AppendResultCorrectText("充电机暂停输出电流");
                }
                else
                    result.AppendResultIncorrectText("充电机未暂停输出电流");

                Access_CCS ccs01 = new Access_CCS();
                ccs01.Get_SPN3929_01_AfterMsg(db, ccs00.Data);
                if (ccs01.IsNullData())
                {
                    return report = result.ExportNullReport("SPN3929=01的CCS");
                }

                mt.MeasureFirstToFirstWithinSec(ccs00.Data, ccs01.Data, 600000);
                mt.AppendText("等待时间", "内，充电机恢复充电");
                result.AppendTestResult(mt.ExportTestResult());

                //
                Access_CST cst = new Access_CST();
                cst.GetCST(db);
                if (cst.IsNullData())
                {
                    return report = result.ExportNullReport(CST);
                }

                Access_BSM bsm01 = new Access_BSM();
                bsm01.GetBSM_SPN3096_01(db);
                if (bsm01.IsNullData())
                {
                    return report = result.ExportNullReport("SPN3096=01的BSM");
                }

                Access_BSM bsm00Special = new Access_BSM();
                bsm00Special.GetBSM_AfterLastMsg(db, bsm01.Data);    //获取：时间大于最后一条SPN3906=01的BSM，且SPN3906=00的BSM
                if (bsm00Special.IsNullData())
                {
                    return report = result.ExportNullReport("第二次SPN3096=00的BSM");
                }


                mt.MeasureFirstToFirstSpecial(bsm00Special.Data, cst.Data, 600000);
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
        private bool IsPauseOuputI(List<ConsistMsg> bsm00, List<ConsistMsg> ccs00)
        {
            MeasureTimeout mt = new MeasureTimeout();
            string earlier = bsm00[0].CreateTimestamp;
            string later = ccs00[0].CreateTimestamp;
            long span = Function.CalcIntervalByTwoPara(later, earlier);
            if (span >= 0)
                return true;
            else
                return false;
        }
    }
}
