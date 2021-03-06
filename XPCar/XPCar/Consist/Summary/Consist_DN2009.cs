﻿using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DN2009 : ConsistCommon
    {
        private string BRO = "BRO";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_CRO cro = new Access_CRO();
                cro.GetCRO_SPN2830_00(db);
                if (cro.IsNullData())
                {
                    return report = result.ExportNullReport("SPN2830=00的CRO");
                }


                Access_BRO bro = new Access_BRO();
                bro.GetAfter_SPN2829_00(db, cro.Data);
                //bro.GetBRO_SPN2829_00(db);
                if (bro.IsNullData())
                {
                    return report = result.ExportNullReport(BRO);
                }
                Access_Any any = new Access_Any();
                //any.GetCXX_Msg(db);
                any.GetCxxExceptCEM(db);
                if (any.IsNullData())
                {
                    return report = result.ExportNullReport("充电机");
                }
                MeasureTimeout mt = new MeasureTimeout();
                //mt.MeasureFirstToLastWithinSec(bro.Data, any.Data, 1000);
                mt.MeasureFirstToLastLess(bro.Data, any.Data, 1000);
                mt.AppendText("自首次接收到SPN2829=00的BRO报文起", "内，充电机停止了通讯");
                result.AppendTestResult(mt.ExportTestResult());

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
