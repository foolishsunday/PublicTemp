using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using XPCar.Common;
using XPCar.Database;
using XPCar.Prj.Bind;
using XPCar.Prj.Flow;
using XPCar.Prj.Model;
using XPCar.Timers;
using static XPCar.Common.KeyConst;

namespace XPCar.Prj.Controller
{
    public delegate void AppendCanMsgHandle(CanMsgRich model);
    public delegate void UpdateCalcStateHandle(string text);

    public class CanMsgController: CanMsgRich
    {
        public event AppendCanMsgHandle AppendCanMsg;
        public event UpdateCalcStateHandle UpdateCalcState;

        public static readonly object MsgLocker = new object();

        private MsgBig _MsgBig;

        private ThreadTimer _UpdateMsgTimer;
        private int _Index;
        private bool _PauseCan;
        private bool _LastLineCursorMove;
        public void Init()
        {

            _MsgBig = new MsgBig();
            _MsgBig.Init();

            _UpdateMsgTimer = new ThreadTimer(UpdateMsgTick);
            _UpdateMsgTimer.Interval = 2000;

            //SetCanContinue();
            SetCanPause(false);
            _Index = 0;

            _LastLineCursorMove = false;
        }
       
        public void AddModel(CanMsgRich model)
        {
            try
            {
                _Index++;
                model.ObjectNo = this._Index;
                _UpdateMsgTimer.Stop();
                _UpdateMsgTimer.Start();

                AppendCanMsg(model);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }

        //delete for big data source at 2019.08.03
        //public DataTable DataSourceTotal()
        //{
        //    DbService db = new DbService();
        //    return db.QueryMsgAll();
        //}
        //end
        //public DataTable DataSourceLight()
        //{
        //    return _MsgLight.Datatable();
        //}
        //add for big data source at 2019.08.03
        public DataTable DataSourceBig()
        {
            return _MsgBig.Datatable();
        }
        //end
        public void AddRow(CanMsgRich model)
        {
            //_MsgLight.AddRow(model);
            _MsgBig.AddRow(model);  //add for big data source at 2019.08.03
            //if (_MsgBig.IsExceeded(10000))
            //{
            //    _MsgBig.RemoveAt();
            //}
            //_MsgLight.KeepRows(Prj.MainController.Config.KeepRowCount);
        }
        public void Reset()
        {
            _Index = 0;
            //_MsgLight.Reset();
            _MsgBig.Reset();  //add for big data source at 2019.08.03
        }

        //TODO:Can Msg停止后，计时触发：把数据提交到数据库
        private void UpdateMsgTick(object state)
        {
            _UpdateMsgTimer.Stop();

            UpdateCalcState(KeyConst.MdiText_Calc.Calculating); //底部工具栏显示：计算中...

            Prj.RepositoryManager.WakeupCommit(1);
            Thread.Sleep(300);//等待提交数据库完成

            Prj.RepositoryManager.WakeupCommit(3);
            Thread.Sleep(200);

            Prj.WaveController.WackupDraw();
            Prj.StatisticsController.AddStatisticsData();
            Thread.Sleep(200);

            SetLastLineCursor(false);

            UpdateCalcState(KeyConst.MdiText_Calc.CalcFinish);//底部工具栏显示：计算完成

        }
        public void SetCanPause()
        {
            this._PauseCan = true;
        }
        public void SetCanContinue()
        {
            this._PauseCan = false;
        }
        public void SetCanPause(bool isPause)
        {
            if(isPause)
                this._PauseCan = true;
            else
                this._PauseCan = false;
        }
        public bool IsPause()
        {
            return this._PauseCan;
        }

        //add for big data source at 2019.08.03
        public DataTable PauseData()
        {
            return _MsgBig.PauseData();
        }
        public void SetLastLineCursor(bool isMove)
        {
            _LastLineCursorMove = isMove;
        }
        public bool IsMoveToLastLine()
        {
            return _LastLineCursorMove;
        }
    }
}
