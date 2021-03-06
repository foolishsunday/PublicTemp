﻿using System;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;


namespace XPCar.Consist.Summary
{
    public class Consist_DP3006 : ConsistCommon
    {
        private string CST = "CST";
        private string BST = "BST";
        private string CCS = "CCS";
        public override TestItemsReport GenerateReport(DbService db, string consistId)
        {
            TestItemsReport report = new TestItemsReport();
            TestResult result = new TestResult(true);
            try
            {
                Access_BST bst = new Access_BST();
                bst.GetBST(db);
                if (bst.IsNullData())
                {
                    return report = result.ExportNullReport(BST);
                }

                Access_CCS ccs = new Access_CCS();
                ccs.GetCCS(db);
                if (ccs.IsNullData())
                {
                    return report = result.ExportNullReport(CCS);
                }

                MeasureTimeout mt = new MeasureTimeout();
                mt.MeasureAStopWhileRcvB(ccs.Data, bst.Data);
                mt.AppendStopResult("充电机接收到BST报文后，", "未", "停止发送CCS报文");
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
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return report;
        }
    }
}
