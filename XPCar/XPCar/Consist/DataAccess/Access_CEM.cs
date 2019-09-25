using XPCar.Common;
using XPCar.Database;

namespace XPCar.Consist.DataAccess
{
    public class Access_CEM : Access_Common
    {
        private string CEM = KeyConst.CanMsgId.CEM;

        public void GetCEM(DbService db)
        {
            this._Data = db.QueryConsistMsg(CEM);
        }
        public void GetCEM_SPN3921_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(CEM, "SPN3921", "01");
        }
        public void GetCEM_SPN3922_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(CEM, "SPN3922", "01");
        }
        public void GetCEM_SPN3923_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(CEM, "SPN3923", "01");
        }
        public void GetCEM_SPN3924_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(CEM, "SPN3924", "01");
        }
        public void GetCEM_SPN3925_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(CEM, "SPN3925", "01");
        }
        public void GetCEM_SPN3926_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(CEM, "SPN3926", "01");
        }
        public void GetCEM_SPN3927_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(CEM, "SPN3927", "01");
        }
    }
}
