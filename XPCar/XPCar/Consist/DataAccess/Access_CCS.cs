﻿using System.Collections.Generic;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_CCS : Access_Common
    {
        private string CCS = KeyConst.CanMsgId.CCS;
        public void GetCCS(DbService db)
        {
            this._Data = db.QueryConsistMsg(CCS);
        }
        public void GetCCS_SPN3929_00(DbService db)
        {
            this._Data = db.QueryConsistMsg(CCS, "SPN3929", "00");
        }
        public void GetCCS_SPN3929_01(DbService db)
        {
            this._Data = db.QueryConsistMsg(CCS, "SPN3929", "01");
        }
        public void GetBeforeMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistBeforeMsg(CCS, msg[0].ObjectNo);
        }
        public void Get_SPN3929_01_AfterMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistAfterMsgBySpn(CCS, "SPN3929", "01", msg[0].ObjectNo);
        }
        public void Get_SPN3929_00_AfterMsg(DbService db, List<ConsistMsg> msg)
        {
            this._Data = db.QueryConsistAfterMsgBySpn(CCS, "SPN3929", "00", msg[0].ObjectNo);
        }
    }
}