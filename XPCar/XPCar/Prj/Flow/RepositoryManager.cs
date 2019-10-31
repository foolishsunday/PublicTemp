using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using XPCar.Common;
using XPCar.Consist;
using XPCar.Database;
using XPCar.Prj.Data;
using XPCar.Prj.Model;
using XPCar.Timers;

namespace XPCar.Prj.Flow
{
    public delegate void UpdateConsistResultHandle(string msgName, Function.ConsistResult result);
    public enum ConsistConfigMsgStyle
    {
        None,
        CommitStartDate,
        CommitEndDate
    }
    public class RepositoryManager : IDisposable
    {
        private DataResolve _Stocker;
        private DataResolve _Repository;
        private Thread _Thread;
        private EventWaitHandle _Wakeup;
        private bool _isDisposed;

        private static readonly object _Locker = new object();
        public event UpdateConsistResultHandle UpdateConsistResult;
        private ThreadTimer _TestTimer;
        private DbTaskState _TaskState;
        public RepositoryManager()
        {
            _Stocker = new DataResolve();
            _Repository = new DataResolve();
            _Thread = new Thread(FunctionWorkStore);

            _Wakeup = new AutoResetEvent(false);
            _Thread.Start();

            _TaskState = new DbTaskState();
        }
        ~RepositoryManager()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)//_isDisposed为false表示没有进行手动dispose
            {
                if (disposing)
                {
                    //清理托管资源
                }
                _Thread.Abort();
                _Wakeup.Close();
            }
            _isDisposed = true;
        }
        public void AddToStocker(CanMsgRich rich)
        {
            lock (_Locker)
            {
                _Stocker.AddModel(rich);
            }
            _Wakeup.Set();
        }
        public void Reset()
        {
            lock (_Locker)
            {
                _Stocker.Clear();
            }
            DbService db = new DbService();
            db.DeleteAllResult();
            //db.DeleteCanMsg();
            //db.DeleteConsistMsg();

        }
        private void StockerMoveToRepository()
        {
            _Repository.AddRange(_Stocker.List());
            _Stocker.Clear();
        }

        //TODO:数据提交数据库
        private void FunctionWorkStore()
        {
            while (true)
            {

                if (_Stocker.List().Count > 250 || _TaskState.IsCanMsgCommitEnable())
                {
                    lock (_Locker)
                    {
                        StockerMoveToRepository();//移到仓库
                    }
                }

                if (_Repository.List().Count > 250 || _TaskState.IsCanMsgCommitEnable())
                {
                    CommitToRespository();  //仓库提交DB
                    _TaskState.DisableCanMsgCommit();

                }

                if (Prj.ConsistController.ConsistStarted)
                {
                    if (_TaskState.GetConsistConfigMsg() == ConsistConfigMsgStyle.CommitStartDate)
                    {
                        CommitToTestStart();
                        _TaskState.SetConsistConfigMsg(ConsistConfigMsgStyle.None);
                    }
                    else if (_TaskState.GetConsistConfigMsg() == ConsistConfigMsgStyle.CommitEndDate)
                    {
                        CommitConsistResult();
                        _TaskState.SetConsistConfigMsg(ConsistConfigMsgStyle.None);
                        Prj.GeneralController.RefreshAutoConsistResult();
                    }
                    else { }
                }
                _Wakeup.WaitOne();
            }
        }
        public void WakeupCommit(int state)
        {
            if (state == 1)//提交CanMsg
            {
                _TaskState.EnableCanMsgCommit();
            }
            else if (state == 2)//提交协议一致性计时开始时间
            {
                _TaskState.SetConsistConfigMsg(ConsistConfigMsgStyle.CommitStartDate);
            }
            else if (state == 3)//提交协议一致性计时结束时间
            {

                _TaskState.SetConsistConfigMsg(ConsistConfigMsgStyle.CommitEndDate);
            }
            _Wakeup.Set();
        }
        private void CommitToRespository()
        {
            DbService db = new DbService();
            if (_Repository.CanList() != null && _Repository.CanList().Count > 0)
            {
                //TODO:提交CanMsg表
                try
                {
                    db.BigDataInsert(_Repository.CanList());
                }
                catch(Exception ex)
                {
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()" + "-> CanMsg Error!", ex);
                }

                try
                {
                    //TODO:提交ConsistMsg表
                    List<ConsistMsg> lists = _Repository.ConsistList();
                    if (lists != null && lists.Count > 0)
                        db.BigDataInsert(lists);

                    _Repository.Clear();
                    //db.BigDataInsert(_Repository.CanList());
                }
                catch (Exception ex)
                {
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()" + "-> ConsistMsg Error!", ex);
                }

            }
        }
        private void CommitConsistResult()
        {
            ConsistFactoryManager consistCalc = new ConsistFactoryManager();
            string msgName = string.Empty;
            if (!string.IsNullOrEmpty(Prj.ConsistController.SelectedMsgName))
                msgName = Prj.ConsistController.SelectedMsgName.Replace(".", "");

            Function.ConsistResult ret = consistCalc.CreateConsistMachine(msgName);
            if (UpdateConsistResult != null)
                UpdateConsistResult(msgName, ret);
        }

        private void CommitToTestStart()
        {
            DbService db = new DbService();
            TestConfig test = new TestConfig();
            test.ItemId = Prj.ConsistController.SelectedMsgName.Replace(".", "");
            test.StartTestTime = DateTime.Now.ToString(KeyConst.TextFormat.Date);
            db.Update<TestConfig>(test);
        }
        public void SetConsistTimeMode(string msgName)
        {
            switch (msgName.Replace(".", "").ToUpper())
            {
                //case KeyConst.Consist.ItemId.BN1001:
                //case KeyConst.Consist.ItemId.BN1002:
                //    SetTimer(63000, true);
                //    break;
                default://不计时
                    SetTimer(0, false);
                    break;
            }
        }
        private void SetTimer(int interval, bool isStart)
        {

            if (isStart)
            {
                if (_TestTimer != null)
                {
                    _TestTimer.Stop();
                }
                else
                {
                    _TestTimer = new ThreadTimer(ConsistTest_Tick);
                }
                _TestTimer.Interval = interval;
                _TestTimer.Start();
            }
            else
            {
                if (_TestTimer != null)
                {
                    _TestTimer.Stop();
                }
            }
        }
        //定时触发WakeupCommit，以计算一致性测试结果
        private void ConsistTest_Tick(object state)
        {
            WakeupCommit(3);
            _TestTimer.Stop();
        }
        public void ResetConsistResult()
        {
            DbService db = new DbService();
            db.DeleteConsistResult();
        }
    }
}
