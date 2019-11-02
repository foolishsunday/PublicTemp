﻿using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP3002 : ConsistCommon
    {
        //private string BMV = "BMV";
        //private string BMT = "BMT";
        //private string BSP = "BSP";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BMV bmv = new Access_BMV();
                bmv.GetMutiEnd(db);
                Access_BMT bmt = new Access_BMT();
                bmt.GetMutiEnd(db);
                Access_BSP bsp = new Access_BSP();
                bsp.GetMutiEnd(db);

                if (bmv.IsNullData())
                {
                    result.AppendResultIncorrectText("充电机未使用传输功能接收BMV报文");
                }
                else
                    result.AppendResultCorrectText("充电机使用传输功能接收BMV报文");

                if (bmt.IsNullData())
                {
                    result.AppendResultIncorrectText("充电机未使用传输功能接收BMT报文");
                }
                else
                    result.AppendResultCorrectText("充电机使用传输功能接收BMT报文");

                if (bsp.IsNullData())
                {
                    result.AppendResultCorrectText("充电机未使用传输功能接收BSP报文");
                }
                else
                    result.AppendResultCorrectText("充电机使用传输功能接收BSP报文");

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
