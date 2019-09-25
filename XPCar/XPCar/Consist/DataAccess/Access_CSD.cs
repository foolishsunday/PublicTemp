using System;
using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_CSD : Access_Common
    {
        private string CSD = KeyConst.CanMsgId.CSD;
        public void GetCSD(DbService db)
        {
            this._Data = db.QueryConsistMsg(CSD);
        }
    }
}
