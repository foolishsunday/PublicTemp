using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BSP : Access_Common
    {
        private string BSP = KeyConst.CanMsgId.BSP;
        public void GetBSP(DbService db)
        {
            this._Data = db.QueryConsistMsg(BSP);
        }
        public void GetMutiEnd(DbService db)
        {
            this._Data = db.QueryConsistMutiEnd(BSP);
        }
        public void GetMutiReady(DbService db)
        {
            this._Data = db.QueryConsistMutiReady(BSP);
        }
        public void GetMutiReadyOrReject(DbService db)
        {
            this._Data = db.QueryConsistMutiReadyOrReject(BSP);
        }
    }
}
