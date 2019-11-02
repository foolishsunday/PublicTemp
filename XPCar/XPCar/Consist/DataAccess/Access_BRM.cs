using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BRM : Access_Common
    {
        private string BRM = KeyConst.CanMsgId.BRM;

        public void GetBRM(DbService db)
        {
            this._Data = db.QueryConsistMsg(BRM);
        }
        public void GetMutiEnd(DbService db)
        {
            this._Data = db.QueryConsistMutiEnd(BRM);
        }
    }
}
