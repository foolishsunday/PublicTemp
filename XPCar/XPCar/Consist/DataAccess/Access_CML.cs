
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_CML : Access_Common
    {
        private string CML = KeyConst.CanMsgId.CML;
        public void GetCML(DbService db)
        {
            this._Data = db.QueryConsistMsg(CML);
        }
        public void GetBeforeMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistBeforeMsg(CML, msg[0].ObjectNo);
        }
    }
}
