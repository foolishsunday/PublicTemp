using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BSD : Access_Common
    {
        private string BSD = KeyConst.CanMsgId.BSD;
        public void GetBSD(DbService db)
        {
            this._Data = db.QueryConsistMsg(BSD);
        }
    }
}
