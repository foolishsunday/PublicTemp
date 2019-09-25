using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Prj.Model;

namespace XPCar.Consist.DataAccess
{
    public class Access_Common
    {
        protected List<ConsistMsg> _Data;
        public List<ConsistMsg> Data { get { return this._Data; } }
        public bool IsNullData()
        {
            if (_Data == null || _Data.Count == 0)
                return true;
            else
                return false;
        }
    }
}
