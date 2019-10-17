using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Consist.Calc
{
    public class MeasureFormat : IMeasureResult
    {
        private List<ConsistMsg> _Data;
        private string _MsgName;
        private bool _IsResultOk;
        public MeasureFormat(List<ConsistMsg> lists, string msgName)
        {
            _Data = lists;
            _MsgName = msgName;
            _IsResultOk = true;
        }
        public string ResultText(string consistId)
        {
            if (_Data != null && _Data.Count > 0)
            {
                return _MsgName + "格式" + KeyConst.Punctuation.Colon + KeyConst.Consist.Result.Qualified + KeyConst.Punctuation.Space + Environment.NewLine;
            }
            else
            {
                _IsResultOk = false;
                return _MsgName + "格式" + KeyConst.Punctuation.Colon + KeyConst.Consist.Result.Unqualified + KeyConst.Punctuation.Space + Environment.NewLine;
            }
        }
        public bool IsResultOk()
        {
            return _IsResultOk;
        }
    }
}
