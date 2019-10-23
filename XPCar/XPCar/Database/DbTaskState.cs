using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Prj.Flow;

namespace XPCar.Database
{
    public class DbTaskState
    {
        private int _ConsistCommit;
        private int _CanMsgCommit;
        private ConsistConfigMsgStyle _ConsistConfigCommit;
        private bool IsConsistConfigStart { get; set; }
        public DbTaskState()
        {
            _ConsistCommit = 0;
            _CanMsgCommit = 0;
            _ConsistConfigCommit = ConsistConfigMsgStyle.None;
            IsConsistConfigStart = true;
        }
        public bool IsConsistCommitEnable()
        {
            if (_ConsistCommit == 1)
                return true;
            else return false;
        }
        public bool IsCanMsgCommitEnable()
        {
            if (_CanMsgCommit == 1)
                return true;
            else return false;
        }
        public ConsistConfigMsgStyle GetConsistConfigMsg()
        {
            return _ConsistConfigCommit;
        }
        public void SetConsistConfigMsg(ConsistConfigMsgStyle state)
        {
            _ConsistConfigCommit = state;
        }

        public void DisableCanMsgCommit()
        {
            _CanMsgCommit = 0;
        }
        public void EnableCanMsgCommit()
        {
            _CanMsgCommit = 1;
        }

    }
}
