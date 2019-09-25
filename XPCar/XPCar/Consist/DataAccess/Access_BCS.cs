using System;
using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BCS : Access_Common
    {
        private string BCS = KeyConst.CanMsgId.BCS;
        public void GetBCS(DbService db)
        {
            this._Data = db.QueryConsistMsg(BCS);
        }
        //public void GetBCSAfterDatetime(DbService db, string datetime)
        //{
        //    string now = DateTime.Now.ToString(KeyConst.TextFormat.Date);
        //    this._Data = db.QueryConsistMsg_BetweenDatetime(BCS, datetime, now);
        //}
        //public void GetBCSafterObjectNo(DbService db, int objectNo)
        //{
        //    this._Data = db.QueryConsistMsg_ByObjectNo(BCS, objectNo);
        //}
    }
}
