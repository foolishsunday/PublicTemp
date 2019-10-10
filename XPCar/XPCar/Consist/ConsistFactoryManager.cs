using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Consist.Summary;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist
{
    public class ConsistFactoryManager : IConsistFactory
    {
        public Function.ConsistResult CreateConsistMachine(string msgName)//msgName = BP1001等
        {
            TestItemsReport report;
            DbService db = new DbService();
            report = CreateMachineByMsgName(msgName).GenerateReport(db, msgName);
            report.ItemId = msgName;
            report.CreateTimestamp = DateTime.Now.ToString(KeyConst.TextFormat.Date);
            if (db.Update(report))
            {
                if (report.TestSummary == KeyConst.Consist.Result.Qualified)
                    return Function.ConsistResult.OK;
                else
                    return Function.ConsistResult.NG;
            }
            return Function.ConsistResult.ERROR;
        }
        private ConsistCommon CreateMachineByMsgName(string msgName)
        {
            switch (msgName.ToUpper())
            {
                case KeyConst.Consist.ItemId.DP1001:
                    return new Consist_DP1001();
                case KeyConst.Consist.ItemId.DP1002:
                    return new Consist_DP1002();
                case KeyConst.Consist.ItemId.DP1003:
                    return new Consist_DP1003();
                case KeyConst.Consist.ItemId.DN1001:
                case KeyConst.Consist.ItemId.DN1002:
                case KeyConst.Consist.ItemId.DN1003:
                    return new Consist_DN1001to03();
                case KeyConst.Consist.ItemId.DN1004:
                    return new Consist_DN1004();
                case KeyConst.Consist.ItemId.DP2001:
                    return new Consist_DP2001();
                case KeyConst.Consist.ItemId.DP2002:
                    return new Consist_DP2002();
                case KeyConst.Consist.ItemId.DP2003:
                    return new Consist_DP2003();
                case KeyConst.Consist.ItemId.DN2001:
                case KeyConst.Consist.ItemId.DN2002:
                    return new Consist_DN2001to02();
                case KeyConst.Consist.ItemId.DN2003:
                case KeyConst.Consist.ItemId.DN2004:
                    return new Consist_DN2003to04();
                case KeyConst.Consist.ItemId.DN2005:
                    return new Consist_DN2005();
                case KeyConst.Consist.ItemId.DN2006:
                    return new Consist_DN2006();
                case KeyConst.Consist.ItemId.DN2007:
                case KeyConst.Consist.ItemId.DN2008:
                    return new Consist_DN2007to08();
                case KeyConst.Consist.ItemId.DN2009:
                    return new Consist_DN2009();
                case KeyConst.Consist.ItemId.DN2010:
                    return new Consist_DN2010();
                case KeyConst.Consist.ItemId.DP3001:
                    return new Consist_DP3001();
                case KeyConst.Consist.ItemId.DP3002:
                    return new Consist_DP3002();
                case KeyConst.Consist.ItemId.DP3003:
                    return new Consist_DP3003();
                case KeyConst.Consist.ItemId.DP3004:
                    return new Consist_DP3004();
                case KeyConst.Consist.ItemId.DP3005:
                    return new Consist_DP3005();
                case KeyConst.Consist.ItemId.DP3006:
                case KeyConst.Consist.ItemId.DP3007:
                    return new Consist_DP3006to07();
                case KeyConst.Consist.ItemId.DN3001:
                    return new Consist_DN3001();
                case KeyConst.Consist.ItemId.DN3002:
                    return new Consist_DN3002();
                case KeyConst.Consist.ItemId.DN3003:
                    return new Consist_DN3003();
                case KeyConst.Consist.ItemId.DN3004:
                    return new Consist_DN3004();
                case KeyConst.Consist.ItemId.DN3005:
                case KeyConst.Consist.ItemId.DN3007:
                    return new Consist_DN3005_07();
                case KeyConst.Consist.ItemId.DN3006:
                case KeyConst.Consist.ItemId.DN3008:
                    return new Consist_DN3006_08();
                case KeyConst.Consist.ItemId.DN3009:
                case KeyConst.Consist.ItemId.DN3010:
                    return new Consist_DN3009to10();
                case KeyConst.Consist.ItemId.DP4001:
                    return new Consist_DP4001();
                case KeyConst.Consist.ItemId.DP4002:
                    return new Consist_DP4002();
                case KeyConst.Consist.ItemId.DN4001:
                case KeyConst.Consist.ItemId.DN4002:
                case KeyConst.Consist.ItemId.DN4003:
                case KeyConst.Consist.ItemId.DN4004:
                    return new Consist_DN4001to04();
                default:
                    return new Consist_Undefined();
            }
        }

    }
}
