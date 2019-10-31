using System;
using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_BSM : Access_Common
    {
        private string BSM = KeyConst.CanMsgId.BSM;
        public void GetBSM(DbService db)
        {
            this._Data = db.QueryConsistMsg(BSM);
        }
        public void GetBSM_SPN3096_00(DbService db)
        {
            this._Data = db.QueryConsistMsg(BSM, "SPN3096", "00");
        }
        public void GetBSM_SPN3096_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(BSM, "SPN3096", "01");
        }
    }
}
