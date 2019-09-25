#define PRODUCT
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System;

using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using XPCar.Prj.Model;
using System.Threading;
using XPCar.Database;
using XPCar.Common;
using XPCar.Prj.Bind;
using System.Diagnostics;

namespace XPCar.Client
{
    //public delegate void PauseDataHandle(DataTable dt);

    public partial class frmMsgCan : UserControl
    {
        //public event PauseDataHandle HandlePauseData;
        private DataTable _Data;
        public frmMsgCan()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            DoubleBuffer();

            Prj.Prj.CanMsgController.AppendCanMsg += this.HandleAppendCanMsg;
            //Prj.Prj.CanMsgController.DisplayLight += this.HandleDisplayLight;
            //Prj.Prj.CanMsgController.DisplayDbSource += this.HandleDisplaySource;

            dgvMsgCan.ReadOnly = true;

            //dgvMsgCan.DataSource = Prj.Prj.CanMsgController.DataSourceLight();//for test
            //dgvMsgCan.DataSource = Prj.Prj.CanMsgController.DataSourceBig();
            dgvMsgCan.ColumnCount = 8;//add for 时间增量
            SetColumnsWidth();

            //Virtual Mode
            dgvMsgCan.VirtualMode = true;
            dgvMsgCan.CellValueNeeded += this.InsertCell;
            AddHeaderText();
            //
        }
        private void SetColumnsWidth()
        {
            dgvMsgCan.Columns[0].Width = 55;
            dgvMsgCan.Columns[1].Width = 65;
            dgvMsgCan.Columns[2].Width = 150;
            dgvMsgCan.Columns[3].Width = 80;//add for 时间增量
            dgvMsgCan.Columns[4].Width = 70;
            dgvMsgCan.Columns[5].Width = 30;
            dgvMsgCan.Columns[6].Width = 160;

        }
        private void AddHeaderText()
        {
            dgvMsgCan.ColumnCount = 8;
            dgvMsgCan.Columns[0].HeaderText = KeyConst.HeaderText.OBJECT_NO;
            dgvMsgCan.Columns[1].HeaderText = KeyConst.HeaderText.DIRECTION;
            dgvMsgCan.Columns[2].HeaderText = KeyConst.HeaderText.CREATE_TIME;
            dgvMsgCan.Columns[3].HeaderText = KeyConst.HeaderText.TIME_INCREMENT;//add for 时间增量
            dgvMsgCan.Columns[4].HeaderText = KeyConst.HeaderText.MSG_ID;
            dgvMsgCan.Columns[5].HeaderText = KeyConst.HeaderText.DLC;
            dgvMsgCan.Columns[6].HeaderText = KeyConst.HeaderText.MSG_DATA;
            dgvMsgCan.Columns[7].HeaderText = KeyConst.HeaderText.MSG_TEXT;
        }
        private void DoubleBuffer()
        {
            #region 双缓冲
            //设置窗体的双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            //利用反射设置DataGridView的双缓冲
            Type dgvType = this.dgvMsgCan.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dgvMsgCan, true, null);
            #endregion 双缓冲
        }
        private void InsertCell(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex == dgvMsgCan.RowCount)
            {
                return;
            }
            if (!Prj.Prj.CanMsgController.IsPause())
                _Data = Prj.Prj.CanMsgController.DataSourceBig();
            if (_Data != null && _Data.Rows.Count > 0)
            {
                if (e.ColumnIndex == 0)
                {
                    e.Value = _Data.Rows[e.RowIndex][0].ToString();
                }
                else if (e.ColumnIndex == 1)
                {
                    e.Value = _Data.Rows[e.RowIndex][1].ToString();
                }
                else if (e.ColumnIndex == 2)
                {
                    e.Value = _Data.Rows[e.RowIndex][2].ToString();
                }
                else if (e.ColumnIndex == 3)
                {
                    e.Value = _Data.Rows[e.RowIndex][3].ToString();
                }
                else if (e.ColumnIndex == 4)
                {
                    e.Value = _Data.Rows[e.RowIndex][4].ToString();
                }
                else if (e.ColumnIndex == 5)
                {
                    e.Value = _Data.Rows[e.RowIndex][5].ToString();
                }
                else if (e.ColumnIndex == 6)
                {
                    e.Value = _Data.Rows[e.RowIndex][6].ToString();
                }
                else if (e.ColumnIndex == 7)//add for 时间增量
                {
                    e.Value = _Data.Rows[e.RowIndex][7].ToString();
                }
                //MoveToLastIndex();
                if (Prj.Prj.CanMsgController.IsMoveToLastLine() && !Prj.Prj.CanMsgController.IsPause())
                    MoveToLastLine();
            }
        }

        //DecodePackage -> CanMsgController -> frmMsgCan ->CanMsgController
        private void HandleAppendCanMsg(CanMsgRich model)
        {
            Action async = delegate ()
            {
                if (!Prj.Prj.CanMsgController.IsPause())
                {
                    Prj.Prj.CanMsgController.AddRow(model);
                    Prj.Prj.CanMsgController.SetLastLineCursor(true);
                    dgvMsgCan.Rows.Add();
                    MoveToLastLine();//for test
                }
            };
            this.BeginInvoke(async);
        }
       
        //private void HandleDisplayLight()
        //{

        //    Action async = delegate ()
        //    {
        //        dgvMsgCan.DataSource = Prj.Prj.CanMsgController.DataSourceLight();  //切换DataSource为小数据源
        //        MoveToLastIndex();
        //    };
        //    this.BeginInvoke(async);

        //}
        //private void HandleDisplaySource(DataTable dt)
        //{
        //    Action async = delegate ()
        //    {
        //        //dgvMsgCan.DataSource = dt;    //delete for big data source at 2019.08.03
        //        //dgvMsgCan.DataSource = Prj.Prj.CanMsgController.DataSourceBig();
        //        MoveToLastIndex();
        //    };
        //    this.BeginInvoke(async);

        //}
        //public void BindingLightData()
        //{
        //    dgvMsgCan.DataSource = Prj.Prj.CanMsgController.DataSourceLight();
        //}

        //public void PauseDataSource()
        //{
        //    //delete for big data source at 2019.08.03
        //    //DbService db = new DbService();
        //    //dgvMsgCan.DataSource = db.QueryMsgAll();
        //    //MoveToLastIndex();
        //    //end

        //    //add for big data source at 2019.08.03
        //    ThreadPool.QueueUserWorkItem(a =>
        //    {
        //        DataTable dt = Prj.Prj.CanMsgController.PauseData();
        //        HandlePauseData(dt);
        //    }, null);
        //    //end
        //}
        //private void DisplayPauseData(DataTable dt)
        //{
        //    Action async = delegate ()
        //    {
        //        Stopwatch sw = new Stopwatch();
        //        sw.Start();
        //        dgvMsgCan.DataSource = dt;
        //        MoveToLastIndex();
        //        sw.Stop();
        //        long span = sw.ElapsedMilliseconds;

        //    };
        //    this.BeginInvoke(async);
        //}

        private void MoveToLastLine()
        {
            if (dgvMsgCan != null)
            {
                int cnt = dgvMsgCan.Rows.Count;
                if (cnt > 0)
                    dgvMsgCan.FirstDisplayedScrollingRowIndex = cnt - 1;
            }
        }
        public void ClearCanMsg()
        {
            dgvMsgCan.Rows.Clear();
        }
    }
}
