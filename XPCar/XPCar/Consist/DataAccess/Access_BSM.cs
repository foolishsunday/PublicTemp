using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

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
        public void GetBSM_SPN_DP3003(DbService db)
        {
            string query = string.Format(" SPN3090='{0}' OR SPN3090='{1}' OR SPN3091='{2}' OR SPN3091='{3}' OR SPN3092='{4}' OR SPN3093='{5}' OR SPN3094='{6}' OR SPN3095='{7}';",
                "01", "10", "01", "10", "01", "01", "01", "01", "01");
            this._Data = db.QueryConsistMsgMutiSpnOr(BSM, query);
        }
        public void GetBSM_SPN_DP3004(DbService db)
        {
            string query = string.Format(" SPN3092='{0}' OR SPN3093='{1}' OR SPN3094='{2}' OR SPN3095='{3}';",
                "10", "10", "10", "10");
            this._Data = db.QueryConsistMsgMutiSpnOr(BSM, query);
        }
        //public void GetBSM_NoCharging(DbService db)
        //{
        //    string query = string.Format(" SPN3090='{0}' AND SPN3091='{1}' AND SPN3092='{2}' AND SPN3093='{3}' AND SPN3094='{4}' AND SPN3095='{5}' AND SPN3096='{6}';",
        //        "00", "00", "00", "00", "00", "00", "00");
        //    this._Data = db.QueryConsistMsgMutiSpnOr(BSM, query);
        //}
        //public void GetBSM_PermitCharging(DbService db)
        //{
        //    string query = string.Format(" SPN3090='{0}' AND SPN3091='{1}' AND SPN3092='{2}' AND SPN3093='{3}' AND SPN3094='{4}' AND SPN3095='{5}' AND SPN3096='{6}';",
        //        "00", "00", "00", "00", "00", "00", "01");
        //    this._Data = db.QueryConsistMsgMutiSpnOr(BSM, query);
        //}
        public void GetBSM_AfterLastMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistAfter(BSM,"SPN3096", "00", msg[msg.Count-1].ObjectNo);
        }
    }
}
