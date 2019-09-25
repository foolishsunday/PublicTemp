using System;
using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BCL : Access_Common
    {
        private string BCL = KeyConst.CanMsgId.BCL;
        public void GetBCL(DbService db)
        {
            this._Data = db.QueryConsistMsg(BCL);
        }
        //public void GetBCLAfterDatetime(DbService db, string datetime)
        //{
        //    string now = DateTime.Now.ToString(KeyConst.TextFormat.Date);
        //    this._Data = db.QueryConsistMsg_BetweenDatetime(BCL, datetime, now);
        //}
        //public void GetBCLafterObjectNo(DbService db, int objectNo)
        //{
        //    this._Data = db.QueryConsistMsg_ByObjectNo(BCL, objectNo);
        //}
    }
}
