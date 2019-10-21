using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Consist.Calc;
using XPCar.Consist.DataAccess;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Prj.Controller
{
    public delegate void UpdateStatisticsData(DataTable data);
    public class StatisticsController
    {
        private DataTable _Data;
        protected List<ConsistMsg> _ConsistMsg;
        public event UpdateStatisticsData DoStatisticsData;
        public StatisticsController()
        {
            Init();
        }
        private void Init()
        {
            _Data = new DataTable();
            _Data.Columns.Add(KeyConst.HeaderText.MSG_NAME);
            _Data.Columns.Add(KeyConst.HeaderText.MSG_COUNT);
            _Data.Columns.Add(KeyConst.HeaderText.MIN_INTERVAL);
            _Data.Columns.Add(KeyConst.HeaderText.MAX_INTERVAL);
            _Data.Columns.Add(KeyConst.HeaderText.AVG_INTERVAL);
            _Data.Columns.Add(KeyConst.HeaderText.BeginDate);
            _Data.Columns.Add(KeyConst.HeaderText.EndDate);

        }
        private List<ConsistMsg> GetDbData(string msgName)
        {
            DbService db = new DbService();
            List<ConsistMsg> lists = db.QueryConsistMsg(msgName);
            return lists;
        }
        public StatisticsData Measure(string msgName)
        {
            StatisticsData sd = new StatisticsData();
            List<ConsistMsg> lists = GetDbData(msgName);
            if (lists == null || lists.Count == 0)
            {
                sd = new StatisticsData(0, 0, 0, 0, "0", "0");
                return sd;
            }
            MeasureInterval mi = new MeasureInterval(lists, msgName);
            mi.GenerateIntervalList();
            sd.HitCount = lists.Count;
            sd.MinInterval = mi.MinInterval();
            sd.MaxInterval = mi.MaxInterval();
            sd.AvgInterval = mi.AvgInterval();
            sd.BeginDate = mi.BeginDate();
            sd.EndDate = mi.EndDate();
            return sd;
        }
        public void InitStatisticsData()
        {
            try
            {
                AddStatisticsData();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

        }
        public void AddStatisticsData()
        {
            try
            {
                _Data.Clear();
                AddModel("BHM");
                AddModel("CHM");
                AddModel("BRM");
                AddModel("CRM");
                AddModel("BCP");
                AddModel("BRO");
                AddModel("CTS");
                AddModel("CML");
                AddModel("CRO");
                AddModel("BCL");
                AddModel("BCS");
                AddModel("BSM");
                AddModel("BST");
                AddModel("CCS");
                AddModel("CST");
                AddModel("BSD");
                AddModel("CSD");
                AddModel("BEM");
                AddModel("CEM");
                AddModel("BSP");
                AddModel("BMT");
                AddModel("BMV");
                AddModel("UNDEFINED");
                if (DoStatisticsData != null)
                    DoStatisticsData(_Data);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void AddModel(string msgName)
        {
            StatisticsData sd = Measure(msgName);
            _Data.Rows.Add(msgName, sd.HitCount, sd.MinInterval, sd.MaxInterval, sd.AvgInterval, sd.BeginDate, sd.EndDate);
        }
        public void Reset()
        {
            InitStatisticsData();
        }
        public DataTable DataBind()
        {
            return _Data;
        }
    }
}
