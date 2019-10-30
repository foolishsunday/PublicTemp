using System.Collections.Generic;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_CRO : Access_Common
    {
        private string CRO = KeyConst.CanMsgId.CRO;
        private string SPN2830 = "SPN2830";
        public void GetCRO(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRO);
        }
        public void GetCRO_SPN2830_AA(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRO, "SPN2830", "AA");
        }
        public void GetCRO_SPN2830_00(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRO, "SPN2830", "00");
        }
        public void GetBeforeMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistBeforeMsg(CRO, msg[0].ObjectNo);
        }
        public void GetBeforeMsgSPN2830_AA(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistBeforeMsgBySpn(CRO, msg[0].ObjectNo, SPN2830, "AA");
        }
    }
}
