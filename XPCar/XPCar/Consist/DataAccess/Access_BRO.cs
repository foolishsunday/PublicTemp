using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_BRO : Access_Common
    {
        private string BRO = KeyConst.CanMsgId.BRO;
        public void GetBRO(DbService db)
        {
            this._Data = db.QueryConsistMsg(BRO);
        }
        public void GetBRO_SPN2829_AA(DbService db)
        {
            this._Data = db.QueryConsistMsg(BRO,"SPN2829","AA");
        }
        public void GetBRO_SPN2829_00(DbService db)
        {
            this._Data = db.QueryConsistMsg(BRO, "SPN2829", "00");
        }
        public void GetAfter_SPN2829_00(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistAfter(BRO, "SPN2829", "00", msg[0].ObjectNo);
        }
    }
}
