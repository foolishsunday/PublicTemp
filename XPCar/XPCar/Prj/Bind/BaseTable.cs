using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Prj.Bind
{
    public class BaseTable
    {
        protected DataTable _Datatable;
        protected int _Index;

        public BaseTable()
        {
            this._Index = 0;
        }
        public void Init()
        {
            try
            {
                _Datatable = new DataTable();
                _Datatable.Clear();

                DataColumn num = new DataColumn(KeyConst.HeaderText.OBJECT_NO);
                num.DataType = typeof(int);
                _Datatable.Columns.Add(num);

                _Datatable.Columns.Add(KeyConst.HeaderText.DIRECTION);
                _Datatable.Columns.Add(KeyConst.HeaderText.CREATE_TIME);
                _Datatable.Columns.Add(KeyConst.HeaderText.TIME_INCREMENT);
                _Datatable.Columns.Add(KeyConst.HeaderText.MSG_ID);

                DataColumn dlc = new DataColumn(KeyConst.HeaderText.DLC);
                dlc.DataType = typeof(int);
                _Datatable.Columns.Add(dlc);

                _Datatable.Columns.Add(KeyConst.HeaderText.MSG_DATA);
                _Datatable.Columns.Add(KeyConst.HeaderText.MSG_TEXT);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        public DataTable Datatable()
        {
            return _Datatable;
        }
        public DataTable PauseData()
        {
            if (_Datatable != null && _Datatable.Rows.Count > 0)
            {
                //var query = _Datatable.AsEnumerable();
                //return query.OrderBy(x => x.Field<int>("帧序号")).CopyToDataTable<DataRow>();
                return _Datatable.AsEnumerable().OrderBy(x => x.Field<int>("帧序号")).CopyToDataTable<DataRow>();
            }
            return null;
        }

        //public void KeepRows(int cnt)
        //{
        //    if (this._Index > cnt)
        //    {
        //        this._Datatable.Rows.RemoveAt(0);
        //    }
        //}
        //public int GetIndex()
        //{
        //    return this._Index;
        //}
        public void SetIndex(int index)
        {
            this._Index = index;
        }
        public void Clear()
        {
            this._Datatable.Clear();
        }
        public void Reset()
        {
            Clear();
            this._Index = 0;
        }
    }
}
