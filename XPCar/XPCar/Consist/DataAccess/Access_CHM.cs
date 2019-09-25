using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_CHM : Access_Common
    {
        private string CHM = KeyConst.CanMsgId.CHM;
        public void GetCHM(DbService db)
        {
            this._Data = db.QueryConsistMsg(CHM);
        }
    }
}
