using System.Collections.Generic;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_BCS : Access_Common
    {
        private string BCS = KeyConst.CanMsgId.BCS;
        public void GetBCS(DbService db)
        {
            this._Data = db.QueryConsistMsg(BCS);
        }
        public void GetBeforeMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistBeforeMsg(BCS, msg[0].ObjectNo);
        }
        public void GetMutiReady(DbService db)
        {
            this._Data = db.QueryConsistMutiReady(BCS);
        }
    }
}
