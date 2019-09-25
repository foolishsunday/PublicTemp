using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_Any : Access_Common
    {
        public void GetAll(DbService db)
        {
            this._Data = db.QueryConsistMsgExceptUndefined();
        }
        public void GetCXX_Msg(DbService db)
        {
            this._Data = db.QueryConsistMsg_CXX_Msg();
        }
    }
}
