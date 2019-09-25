using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_CST : Access_Common
    {
        private string CST = KeyConst.CanMsgId.CST;
        public void GetCST(DbService db)
        {
            this._Data = db.QueryConsistMsg(CST);
        }
    }
}
