using XPCar.Common;
using XPCar.Database;


namespace XPCar.Consist.DataAccess
{
    public class Access_CRO : Access_Common
    {
        private string CRO = KeyConst.CanMsgId.CRO;
        public void GetCRO(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRO);
        }
        public void GetCRO_SPN2830_AA(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRO, "SPN2830", "AA");
        }
        public void GetCRO_SPN2830_00(DbService db)
        {
            this._Data = db.QueryConsistMsg(CRO, "SPN2830", "00");
        }
    }
}
