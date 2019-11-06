using SQLiteSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Database
{
    public class DbService
    {

        public bool BigDataInsert<T>(List<T> lists) where T : class
        {

            try
            {
              
                using (var db = DbContext.GetInstance())
                {

                    if (db.SqlBulkCopy(lists))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                string typeName = lists.GetType().ToString();
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()" + "Type of lists = " + typeName, ex);
                throw new Exception(ex.ToString());
                //return false;
            }

        }
        public bool BulkInsert(List<CanMsg> lists)
        {
            using (var db = DbContext.GetInstance())
            {
                db.InsertRange(lists);
                return true;
            }
        }
        public List<T> QueryModel<T>() where T : new()
        {
            using (var db = DbContext.GetInstance())
            {
                List<T> lists = db.Queryable<T>().ToList();
                return lists;
            }
        }
        //public DataTable QueryMsgAll()
        //{
        //    DataTable dt = null;
        //    string sql = string.Format("Select ObjectNo as {0}, Direction as {1}, CreateTimestamp as {2}, Id as {3}, Dlc as {4}, MsgData as {5}, MsgText as {6} from CanMsg;",
        //        KeyConst.HeaderText.OBJECT_NO,
        //        KeyConst.HeaderText.DIRECTION,
        //        KeyConst.HeaderText.CREATE_TIME,
        //        KeyConst.HeaderText.MSG_ID,
        //        KeyConst.HeaderText.DLC,
        //        KeyConst.HeaderText.MSG_DATA,
        //        KeyConst.HeaderText.MSG_TEXT);
        //    using (var db = DbContext.GetInstance())
        //    {
        //        dt = db.GetDataTable(sql);
        //    }
        //    return dt;
        //}
        public DataTable QueryConsistItemsAll()
        {
            try
            {
                DataTable dt = null;
                string sql = string.Format("Select itemid as {0}, condition as {1}, step as {2}, result as {3} from ConsistItems;",
                    "编号",
                    "前置条件",
                    "测试步骤",
                    "预期结果");
                using (var db = DbContext.GetInstance())
                {
                    dt = db.GetDataTable(sql);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return null;
            }
        }
        public DataTable QueryTestACAll()
        {
            try
            {
                DataTable dt = null;
                string sql = string.Format("Select ObjectNo as {0}, OpName as {1}, TestResult as {2} from TestAC;",
                    "编号",
                    "测试项目",
                    "测试结果");
                using (var db = DbContext.GetInstance())
                {
                    dt = db.GetDataTable(sql);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return null;
            }
        }
        public DataTable QueryConsistItemsMap()
        {
            try
            {
                DataTable dt = null;
                string sql = string.Format("Select itemid, bit from ConsistItems;");
                using (var db = DbContext.GetInstance())
                {
                    dt = db.GetDataTable(sql);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return null;
            }
        }
        //public int DeleteCanMsg()
        //{
        //    int num = 0;
        //    using (var db = DbContext.GetInstance())
        //    {
        //        num = db.ExecuteCommand("delete from CanMsg;");
        //    }
        //    return num;
        //}
        //public int DeleteConsistMsg()
        //{
        //    int num = 0;
        //    using (var db = DbContext.GetInstance())
        //    {
        //        num = db.ExecuteCommand("delete from ConsistMsg;");
        //    }
        //    return num;
        //}
        public void DeleteConsistResult()
        {
            int num = 0;
            using (var db = DbContext.GetInstance())
            {
                num = db.ExecuteCommand("Update TestItemsReport Set TestText1='', TestResult1='', TestSummary='', CreateTimestamp='';");
            }
        }
        public void DeleteAllResult()
        {
            int num = 0;
            using (var db = DbContext.GetInstance())
            {
                num = db.ExecuteCommand("delete from CanMsg;");
                num = db.ExecuteCommand("delete from ConsistMsg;");
                num = db.ExecuteCommand("Update TestInterop Set TestResult='';");
            }
        }
        //public void Update<T>(List<T> lists) where T : class
        //{
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            db.UpdateRange(lists);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }
        //}
        public bool Update<T>(T obj) where T : class
        {
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    bool ret = db.Update(obj);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        public bool UpdateTestInterop(int objNo, string result)
        {
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    bool ret = db.Update<TestInterop>(new { TestResult = result }, it => it.ObjectNo == objNo);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        public void DeleteTestInteropResult()
        {
            int num = 0;
            using (var db = DbContext.GetInstance())
            {
                num = db.ExecuteCommand("Update TestInterop Set TestResult='';");
            }
        }
        public void DeleteTestACResult()
        {
            int num = 0;
            using (var db = DbContext.GetInstance())
            {
                num = db.ExecuteCommand("Update TestAC Set TestResult='';");
            }
        }
        public bool UpdateTestAC(int objNo, string result)
        {
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    bool ret = db.Update<TestAC>(new { TestResult = result }, it => it.ObjectNo == objNo);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        #region ConsistMsg
        //public List<ConsistMsg> QueryConsistMsg_BetweenDatetime(string symbol, string time1, string time2)
        //{
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            var lists = db.SqlQuery<ConsistMsg>("select * from ConsistMsg where MsgName=@MsgName between CreateTimestamp=@time1 and CreateTimestamp=@time2",
        //                new { MsgName = symbol, time1 = time1, time2 = time2 });
        //            return lists;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }

        //    return null;
        //}
        //public List<ConsistMsg> QueryConsistMsg_ByObjectNo(string symbol, int objectNo)
        //{
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            var lists = db.SqlQuery<ConsistMsg>("select * from ConsistMsg where MsgName=@MsgName and ObjectNo > @ObjectNo",
        //                new { MsgName = symbol, ObjectNo = objectNo });
        //            return lists;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }

        //    return null;
        //}
        //public List<ConsistMsg> QueryConsistMsg_BetweenDatetime(string symbol, string colName, string value, string time1, string time2)
        //{
        //    List<ConsistMsg> consist = new List<ConsistMsg>();
        //    string text = string.Format("{0} = '{1}'", colName, value);
        //    string between = string.Format("{0} and {1}", time1, time2);
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == symbol).Where(text).Where(between).ToList();
        //            return lists;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }
        //    return null;
        //}
        public List<ConsistMsg> QueryMutiPckgConsistMsg(string msgName)
        {
            string isFirstPackage = "1";
            List<ConsistMsg> consist = new List<ConsistMsg>();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    consist = db.SqlQuery<ConsistMsg>("select * from ConsistMsg where MsgName=@MsgName and IsFirstPackage=@IsFirstPackage",
                        new { MsgName = msgName, IsFirstPackage = isFirstPackage });
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistMsg(string msgName)
        {
            List<ConsistMsg> consist = new List<ConsistMsg>();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    consist = db.SqlQuery<ConsistMsg>("select * from ConsistMsg where MsgName=@MsgName", new { MsgName = msgName });
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistMutiEnd(string msgName)
        {
            List<ConsistMsg> consist = new List<ConsistMsg>();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    consist = db.SqlQuery<ConsistMsg>("select * from ConsistMsg where MsgName=@MsgName and IsPackageEnd = 1;", new { MsgName = msgName });
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistMutiReady(string msgName)
        {
            List<ConsistMsg> consist = new List<ConsistMsg>();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    consist = db.SqlQuery<ConsistMsg>("select * from ConsistMsg where MsgName=@MsgName and IsPackageReady = 1;", new { MsgName = msgName });
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistMutiReadyOrReject(string msgName)
        {
            List<ConsistMsg> consist = new List<ConsistMsg>();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    consist = db.SqlQuery<ConsistMsg>("select * from ConsistMsg where MsgName=@MsgName and (IsPackageReady = 1 or IsPackageReady = 2);", new { MsgName = msgName });
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistBeforeMsg(string msgName, int objNo)
        {
            List<ConsistMsg> consist = new List<ConsistMsg>();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    consist = db.SqlQuery<ConsistMsg>("select * from ConsistMsg where MsgName=@MsgName and ObjectNo<@ObjectNo", new { MsgName = msgName, ObjectNo = objNo });
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistAfterMsgBySpn(string msgName, string spn, string val, int objNo)
        {
            List<ConsistMsg> consist = new List<ConsistMsg>();
            try
            {
                string condition = string.Format("{0} = '{1}'", spn, val);
                using (var db = DbContext.GetInstance())
                {

                    var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == msgName).Where(condition).Where(con => con.ObjectNo > objNo).ToList();
                    return lists;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistBeforeMsgBySpn(string msgName, int objNo, string spn, string spnVal)
        {
            string text = string.Format("{0} = '{1}' and ObjectNo < '{2}'", spn, spnVal, objNo);

            List<ConsistMsg> consist = new List<ConsistMsg>();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == msgName).Where(text).ToList();
                    return lists;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistMsgExceptUndefined()
        {
            List<ConsistMsg> consist = new List<ConsistMsg>();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    consist = db.SqlQuery<ConsistMsg>("select * from ConsistMsg where MsgName != 'UNDEFINED' ");
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistMsg_CXX_Msg()
        {
            List<ConsistMsg> consist = new List<ConsistMsg>();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    consist = db.SqlQuery<ConsistMsg>("select * from ConsistMsg where MsgName like 'C%'; ");
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistMsg_CXX_ExceptPara(string msgName)
        {
            List<ConsistMsg> consist = new List<ConsistMsg>();
            string query = string.Format("select * from ConsistMsg where MsgName like 'C%' and MsgName != '{0}';", msgName);
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    consist = db.SqlQuery<ConsistMsg>(query);
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return consist;
        }
        public List<ConsistMsg> QueryConsistMsg(string symbol, string colName, string value)
        {
            //List<ConsistMsg> lists = new List<ConsistMsg>();
            string text = string.Format("{0} = '{1}'", colName, value);
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == symbol).Where(text).ToList() ;
                    return lists;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

            return null;
        }
        public List<ConsistMsg> QueryConsistMsgMutiSpnOr(string msgName,  string text)
        {


            try
            {
                using (var db = DbContext.GetInstance())
                {
                    var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == msgName).Where(text).ToList();
                    return lists;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

            return null;
        }
        public List<ConsistMsg> QueryConsistAfter(string msgName, string spn, string val, int objNo)
        {

            try
            {
                string condition = string.Format("{0} = '{1}'", spn, val);

                using (var db = DbContext.GetInstance())
                {
                    var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == msgName).Where(condition).Where(con => con.ObjectNo > objNo).ToList();
                    return lists;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

            return null;
        }
        public List<ConsistMsg> QueryConsistAfter(string msgName, int objNo)
        {

            try
            {
                using (var db = DbContext.GetInstance())
                {
                    var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == msgName).Where(con => con.ObjectNo > objNo).ToList();
                    return lists;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

            return null;
        }

        //public ConsistMsg QueryConsistMsg_FirstMsg(string symbol)
        //{
        //    ConsistMsg ele = new ConsistMsg();
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            ele = db.Queryable<ConsistMsg>().Where(c => c.MsgName == symbol).First();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }

        //    return ele;
        //}
        //public ConsistMsg QueryConsistMsgFirstElement()
        //{
        //    ConsistMsg ele = new ConsistMsg();
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            ele = db.Queryable<ConsistMsg>().Select("*").First();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }

        //    return ele;
        //}
        //public ConsistMsg QueryConsistMsgLastElement(string symbol, string colName, string value)
        //{
        //    ConsistMsg ele = new ConsistMsg();
        //    string text = string.Format("{0} = '{1}'", colName, value);
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == symbol).Where(text).OrderBy("CreateTimestamp desc").ToList();
        //            if (lists != null && lists.Count > 0)
        //                ele = (ConsistMsg)lists[0];

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }

        //    return ele;
        //}
        //public ConsistMsg QueryConsistMsgFirstElement(string symbol, string colName, string value)
        //{
        //    ConsistMsg ele = new ConsistMsg();
        //    string text = string.Format("{0} = '{1}'", colName, value);
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == symbol).Where(text).ToList();
        //            if (lists != null && lists.Count > 0)
        //                ele = (ConsistMsg)lists[0];

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }

        //    return ele;
        //}
        //public ConsistMsg QueryConsistMsgFirstElement(string symbol, string colName, string value)
        //{
        //    ConsistMsg ele = new ConsistMsg();
        //    string text = string.Format("{0} = '{1}'", colName, value);
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == symbol).Where(text).ToList();
        //            if (lists != null && lists.Count > 0)
        //                ele = (ConsistMsg)lists[0];

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }

        //    return ele;
        //}
        //public ConsistMsg QueryConsistMsgLastElement(string msgName)
        //{
        //    ConsistMsg ele = new ConsistMsg();
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            var lists = db.Queryable<ConsistMsg>().Where(it => it.MsgName == msgName).OrderBy("CreateTimestamp desc").ToList();
        //            if (lists != null && lists.Count > 0)
        //                ele = (ConsistMsg)lists[0];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }
        //    return ele;
        //}
        #endregion ConsistMsg
        public TestItemsReport QueryReport(string itemid)
        {
            TestItemsReport report = new TestItemsReport();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    var lists = db.Queryable<TestItemsReport>().Where(it => it.ItemId == itemid).ToList();
                    if (lists != null && lists.Count > 0)
                        report = (TestItemsReport)lists[0];

                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return report;
        }
        //public TestConfig QueryTestConfig(string symbol)
        //{
        //    TestConfig test = new TestConfig(); ;
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            var lists = db.Queryable<TestConfig>().Where(it => it.ItemId == symbol).ToList();
        //            if (lists != null && lists.Count > 0)
        //                test = (TestConfig)lists[0];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }
        //    return test;
        //}
       
        public List<TestInterop> QueryTestInteropAll()
        {
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    var list = db. Queryable<TestInterop>().ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return null;
            }

        }
        //public List<TestAC> QueryTestACAll()
        //{
        //    try
        //    {
        //        using (var db = DbContext.GetInstance())
        //        {
        //            var list = db.Queryable<TestAC>().ToList();
        //            return list;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //        return null;
        //    }

        //}
        public DataTable QueryTestInterop()
        {
            try
            {
                DataTable dt = null;
                string sql = string.Format("Select ObjectNo as '{0}', OpName as '{1}' from TestInterop;",
                    KeyConst.HeaderText.INTEROP_NO,
                    KeyConst.HeaderText.INTEROP_NAME);
                using (var db = DbContext.GetInstance())
                {
                    dt = db.GetDataTable(sql);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return null;
            }
        }
        public TestInterop QueryTestInteropItem(int objNo)
        {
            TestInterop report = new TestInterop();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    var lists = db.Queryable<TestInterop>().Where(it => it.ObjectNo == objNo).ToList();
                    if (lists != null && lists.Count > 0)
                        report = (TestInterop)lists[0];

                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return report;
        }
        public TestAC QueryTestACItem(int objNo)
        {
            TestAC report = new TestAC();
            try
            {
                using (var db = DbContext.GetInstance())
                {
                    var lists = db.Queryable<TestAC>().Where(it => it.ObjectNo == objNo).ToList();
                    if (lists != null && lists.Count > 0)
                        report = (TestAC)lists[0];

                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return report;
        }
     
    }
}
