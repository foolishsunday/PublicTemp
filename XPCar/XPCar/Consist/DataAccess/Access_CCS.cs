using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_CCS : Access_Common
    {
        private string CCS = KeyConst.CanMsgId.CCS;
        public void GetCCS(DbService db)
        {
            this._Data = db.QueryConsistMsg(CCS);
        }
    }
}