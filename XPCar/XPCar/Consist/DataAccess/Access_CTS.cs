using System;
using XPCar.Common;
using XPCar.Database;


namespace XPCar.Consist.DataAccess
{
    public class Access_CTS : Access_Common
    {
        private string CTS = KeyConst.CanMsgId.CTS;
        public void GetCTS(DbService db)
        {
            this._Data = db.QueryConsistMsg(CTS);
        }
    }
}
