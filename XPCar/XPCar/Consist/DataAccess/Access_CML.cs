
using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_CML : Access_Common
    {
        private string CML = KeyConst.CanMsgId.CML;
        public void GetCML(DbService db)
        {
            this._Data = db.QueryConsistMsg(CML);
        }
    }
}
