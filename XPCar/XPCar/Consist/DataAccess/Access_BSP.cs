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
    }
}
