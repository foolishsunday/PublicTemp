using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BMT : Access_Common
    {
        private string BMT = KeyConst.CanMsgId.BMT;
        public void GetBMT(DbService db)
        {
            this._Data = db.QueryConsistMsg(BMT);
        }
        public void GetMutiEnd(DbService db)
        {
            this._Data = db.QueryConsistMutiEnd(BMT);
        }
        public void GetMutiReady(DbService db)
        {
            this._Data = db.QueryConsistMutiReady(BMT);
        }
        public void GetMutiReadyOrReject(DbService db)
        {
            this._Data = db.QueryConsistMutiReadyOrReject(BMT);
        }
    }
}