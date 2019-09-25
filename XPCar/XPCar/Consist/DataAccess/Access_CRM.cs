using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_CRM : Access_Common
    {
        private string CRM = KeyConst.CanMsgId.CRM;
        private string SPN2560 = "SPN2560";

        public void GetCRM(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRM);
        }
        public void GetCRM_SPN2560_AA(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRM, SPN2560,"AA");
        }
        public void GetCRM_SPN2560_00(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRM, SPN2560, "00");
        }
    }
}
