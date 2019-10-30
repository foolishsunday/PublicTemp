using System.Collections.Generic;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_CRM : Access_Common
    {
        private string CRM = KeyConst.CanMsgId.CRM;
        private string SPN2560 = "SPN2560";

        public void GetCRM(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRM);
        }
        public void GetCRM_SPN2560_AA(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRM, SPN2560,"AA");
        }
        public void GetCRM_SPN2560_00(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRM, SPN2560, "00");
        }
        public void GetBeforeMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistBeforeMsg(CRM, msg[0].ObjectNo);
        }
        public void GetBeforeMsgSPN2560_AA(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistBeforeMsgBySpn(CRM, msg[0].ObjectNo,SPN2560,"AA");
        }
    }
}
