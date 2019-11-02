using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BMV : Access_Common
    {
        private string BMV = KeyConst.CanMsgId.BMV;
        public void GetBMV(DbService db)
        {
            this._Data = db.QueryConsistMsg(BMV);
        }
        public void GetMutiEnd(DbService db)
        {
            this._Data = db.QueryConsistMutiEnd(BMV);
        }
    }
}
