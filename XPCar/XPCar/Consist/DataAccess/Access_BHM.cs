using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BHM : Access_Common
    {
        private string BHM = KeyConst.CanMsgId.BHM;
        public void GetBHM(DbService db)
        {
            this._Data = db.QueryConsistMsg(BHM);
        }
    }
}
