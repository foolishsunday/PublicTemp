using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BCP : Access_Common
    {
        private string BCP = KeyConst.CanMsgId.BCP;

        public void GetBCP(DbService db)
        {
            this._Data = db.QueryConsistMsg(BCP);
        }
    }
}
