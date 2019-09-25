using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_BEM : Access_Common
    {
        private string BEM = KeyConst.CanMsgId.BEM;

        public void GetBEM(DbService db)
        {
            this._Data = db.QueryConsistMsg(BEM);
        }
        public void GetBEM_SPN3901_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(BEM, "SPN3901", "01");
        }
        public void GetBEM_SPN3902_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(BEM, "SPN3902", "01");
        }
        public void GetBEM_SPN3904_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(BEM, "SPN3904", "01");
        }
        public void GetBEM_SPN3903_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(BEM, "SPN3903", "01");
        }
        public void GetBEM_SPN3905_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(BEM, "SPN3905", "01");
        }
        public void GetBEM_SPN3906_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(BEM, "SPN3906", "01");
        }
        public void GetBEM_SPN3907_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(BEM, "SPN3907", "01");
        }
    }
}
