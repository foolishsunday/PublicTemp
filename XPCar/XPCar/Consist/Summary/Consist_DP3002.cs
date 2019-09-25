using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP3002 : ConsistCommon
    {
        private string BMV = "BMV";
        private string BMT = "BMT";
        private string BSP = "BSP";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BMV bmv = new Access_BMV();
                bmv.GetBMV(db);
                Access_BMT bmt = new Access_BMT();
                bmt.GetBMT(db);
                Access_BSP bsp = new Access_BSP();
                bsp.GetBSP(db);

                if (bmv.IsNullData())
                {
                    result.AppendNoMsg(BMV);
                    report = result.ExportTestReport();
                    return report;
                }
                Measure measure = new Measure(bmv.Data, BMV);

                if (bmt.IsNullData())
                {
                    result.AppendNoMsg(BMT);
                    report = result.ExportTestReport();
                    return report;
                }

                if (bsp.IsNullData())
                {
                    result.AppendNoMsg(BSP);
                    report = result.ExportTestReport();
                    return report;
                }
                result.AppendText("充电机使用传输功能接收BMV报文、BMT报文、BSP报文", true);
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
