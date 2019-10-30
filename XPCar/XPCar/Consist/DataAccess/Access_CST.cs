using System.Collections.Generic;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_CST : Access_Common
    {
        private string CST = KeyConst.CanMsgId.CST;
        public void GetCST(DbService db)
        {
            this._Data = db.QueryConsistMsg(CST);
        }
        public void GetBeforeMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistBeforeMsg(CST, msg[0].ObjectNo);
        }
    }
}
