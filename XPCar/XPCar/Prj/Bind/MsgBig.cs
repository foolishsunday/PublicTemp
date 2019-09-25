using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Prj.Model;
using XPCar.Common;
using System.Data;

namespace XPCar.Prj.Bind
{
    public class MsgBig : BaseTable
    {
        public List<CanMsg> MsgLists;
        public MsgBig()
        {
            MsgLists = new List<CanMsg>();
        }
        public void AddRow(CanMsgRich model)
        {
            try
            {
                //this._Datatable.Rows.Add(model.ObjectNo, model.Direction, model.CreateTimestamp, model.Id, model.Dlc, model.MsgData, model.MsgText);

                //add for 时间增量
                this._Datatable.Rows.Add(model.ObjectNo, model.Direction, model.CreateTimestamp, model.TimeIncrement, model.Id, model.Dlc, model.MsgData, model.MsgText);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

    }
}
