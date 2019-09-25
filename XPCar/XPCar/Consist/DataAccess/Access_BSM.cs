using System;
using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BSM : Access_Common
    {
        private string BSM = KeyConst.CanMsgId.BSM;
        public void GetBSM(DbService db)
        {
            this._Data = db.QueryConsistMsg(BSM);
        }
        //public void GetBSMAfterDatetime(DbService db, string datetime)
        //{
        //    string now = DateTime.Now.ToString(KeyConst.TextFormat.Date);
        //    this._Data = db.QueryConsistMsg_BetweenDatetime(BSM, datetime, now);
        //}
        //public void GetBSMafterObjectNo(DbService db, int objectNo)
        //{
        //    this._Data = db.QueryConsistMsg_ByObjectNo(BSM, objectNo);
        //}
    }
}
