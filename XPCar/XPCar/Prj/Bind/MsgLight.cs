using System;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Prj.Bind
{
    public class MsgLight : BaseTable
    {
        public void AddRow(CanMsgRich model)
        {
            try
            {
                SetIndex(model.ObjectNo);
                this._Datatable.Rows.Add(model.ObjectNo, model.Direction, model.CreateTimestamp, model.Id, model.Dlc, model.MsgData, model.MsgText);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
    }
}
