using System.Collections.Generic;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_BCL : Access_Common
    {
        private string BCL = KeyConst.CanMsgId.BCL;
        public void GetBCL(DbService db)
        {
            this._Data = db.QueryConsistMsg(BCL);
        }
        public void GetBeforeMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistBeforeMsg(BCL, msg[0].ObjectNo);
        }
    }
}
