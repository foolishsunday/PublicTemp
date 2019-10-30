using System.Collections.Generic;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_CCS : Access_Common
    {
        private string CCS = KeyConst.CanMsgId.CCS;
        public void GetCCS(DbService db)
        {
            this._Data = db.QueryConsistMsg(CCS);
        }
        public void GetBeforeMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistBeforeMsg(CCS, msg[0].ObjectNo);
        }
    }
}