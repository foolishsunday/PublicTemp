using System.Collections.Generic;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_BRM : Access_Common
    {
        private string BRM = KeyConst.CanMsgId.BRM;

        public void GetBRM(DbService db)
        {
            this._Data = db.QueryConsistMsg(BRM);
        }
        public void GetMutiEnd(DbService db)
        {
            this._Data = db.QueryConsistMutiEnd(BRM);
        }
        public void GetMutiReady(DbService db)
        {
            this._Data = db.QueryConsistMutiReady(BRM);
        }
        public void GetAfterMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistAfter(BRM, msg[0].ObjectNo);
        }
    }
}
