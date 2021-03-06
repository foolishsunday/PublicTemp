﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPCar.Common;

namespace XPCar.Client.Statistics
{
    public partial class frmStatistics : UserControl
    {
        public frmStatistics()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            dgvStatistics.ReadOnly = true;
            AddHeaderText();
            SetColumnsWidth();
            Prj.Prj.StatisticsController.DoStatisticsData += this.HandleStatisticsData;


            //禁止自动排序
            for (int i = 0; i < this.dgvStatistics.Columns.Count; i++)
            {
                this.dgvStatistics.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            Prj.Prj.StatisticsController.InitStatisticsData();
        }
        private void AddHeaderText()
        {
            //dgvStatistics.ColumnCount = 5;
            //dgvStatistics.Columns[0].HeaderText = KeyConst.HeaderText.MSG_NAME;
            //dgvStatistics.Columns[1].HeaderText = KeyConst.HeaderText.MSG_COUNT;
            //dgvStatistics.Columns[2].HeaderText = KeyConst.HeaderText.MIN_INTERVAL;
            //dgvStatistics.Columns[3].HeaderText = KeyConst.HeaderText.MAX_INTERVAL;
            //dgvStatistics.Columns[4].HeaderText = KeyConst.HeaderText.AVG_INTERVAL;
            dgvStatistics.DataSource = Prj.Prj.StatisticsController.DataBind();

        }
        private void SetColumnsWidth()
        {
            dgvStatistics.RowHeadersWidth = 50;
            dgvStatistics.Columns[0].Width = 100;
            dgvStatistics.Columns[1].Width = 100;
            dgvStatistics.Columns[2].Width = 100;
            dgvStatistics.Columns[3].Width = 100;
        }
        private void HandleStatisticsData(DataTable dt)
        {
            //Action async = delegate ()
            //{
            //    dgvStatistics.DataSource = dt;
            //};
            //this.BeginInvoke(async);
        }

        private void dgvStatistics_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
