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
                Access_BRO bro = new Access_BRO();
                bro.GetBRO_SPN2829_00(db);
                if (bro.IsNullData())
                {
                    result.AppendNoMsg(BRO);
                    report = result.ExportTestReport();
                    return report;
                }
                Access_Any any = new Access_Any();
                any.GetCXX_Msg(db);
                if (any.IsNullData())
                {
                    result.AppendText("自首次接收到SPN2829=00的BRO报文起0s内，充电机停止了通讯", true);
                }
                else
                {
                    MeasureTimeout mt = new MeasureTimeout();
                    mt.MeasureFirstMsgToLastMsgWithinSec(bro.Data, any.Data, 1000);
                    mt.AppendText("自首次接收到SPN2829=00的BRO报文起，", "内，充电机停止了通讯");
                    result.AppendTestResult(mt.ExportTestResult());
                }
                //Measure measure = new Measure(cem.Data, CEM);
                //measure.MeasureCommon(consistId);
                //result.AppendTestResult(measure.ExportTestResult());

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