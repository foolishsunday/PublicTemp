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
        //public List<CanMsg> MsgLists;
        //public MsgBig()
        //{
        //    MsgLists = new List<CanMsg>();
        //}
        public void AddRow(CanMsgRich model)
        {
            try
            {
                //this._Datatable.Rows.Add(model.ObjectNo, model.Direction, model.CreateTimestamp, model.Id, model.Dlc, model.MsgData, model.MsgText);

                //add for 时间增量
                if(Prj.ValueManager.EnableTranslate)
                    this._Datatable.Rows.Add(model.ObjectNo, model.Direction, model.CreateTimestamp, model.TimeIncrement, model.Id, model.Dlc, model.MsgData, model.MsgText);
                else
                    this._Datatable.Rows.Add(model.ObjectNo, model.Direction, model.CreateTimestamp, model.TimeIncrement, model.Id, model.Dlc, model.MsgData, "");
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        //public bool IsExceeded(int cnt)
        //{
        //    if (this._Datatable != null)
        //    {
        //        if (this._Datatable.Rows.Count > cnt)
        //            return true;
        //        else
        //            return false;
        //    }
        //    else
        //        return false;

        //}
        //public void RemoveAt()
        //{
        //    if (this._Datatable != null)
        //        this._Datatable.Rows.RemoveAt(0);
        //}
    }
}
