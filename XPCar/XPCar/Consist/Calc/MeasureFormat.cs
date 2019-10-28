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
            string judge = KeyConst.Consist.Result.Qualified;
            if (_Data != null && _Data.Count > 0)
            {
                judge = GetFormatJudge(consistId);
            }
            else
            {
                judge = SetFormatUnqualified();
            }
            return _MsgName + "格式" + KeyConst.Punctuation.Colon + judge + KeyConst.Punctuation.Space + Environment.NewLine;
        }
        public bool IsResultOk()
        {
            return _IsResultOk;
        }
        private string GetFormatJudge(string consistId)
        {
            ConsistMsg first = _Data[0];
            ConsistMsg last = _Data[_Data.Count - 1];
            string ret = string.Empty;
            string spn = string.Empty;

            if (_MsgName == "CRM")
            {
                if (consistId == "DP1002" || consistId == "DN1001" || consistId == "DN1002" || consistId == "DN1003")
                {
                    spn = first.SPN2560;
                    ret = "SPN2560=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "00");
                }
                else if (consistId == "DN1004" || consistId=="DN2001" || consistId == "DN2002")
                {
                    spn = first.SPN2560;
                    ret = "SPN2560=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "AA");
                }
                else
                    ret = SetFormatQualified();
            }
            else if (_MsgName == "CEM")
            {
                if (consistId == "DN1001" || consistId == "DN1002" || consistId == "DN1003")
                {
                    spn = first.SPN3921;
                    ret = "SPN3921=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "01");
                }
                else if (consistId == "DN1004" || consistId == "DN2001" || consistId == "DN2002")
                {
                    spn = first.SPN3922;
                    ret = "SPN3922=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "01");
                }
                else if (consistId == "DN2003" || consistId == "DN2004" || consistId == "DN2005" || consistId == "DN2006" || consistId == "DN2007" || consistId == "DN2008")
                {
                    spn = first.SPN3923;
                    ret = "SPN3923=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "01");
                }
                else if (consistId == "DN3001" || consistId == "DN3003" || consistId == "DN3005" || consistId == "DN3007")
                {
                    spn = first.SPN3924;
                    ret = "SPN3924=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "01");
                }
                else if (consistId == "DN2010" || consistId == "DN3002" || consistId == "DN3004" || consistId == "DN3006" || consistId == "DN3008")
                {
                    spn = first.SPN3925;
                    ret = "SPN3925=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "01");
                }
                else if (consistId == "DN3009" || consistId == "DN3010")
                {
                    spn = first.SPN3926;
                    ret = "SPN3926=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "01");
                }
                else if (consistId == "DN4001" || consistId == "DN4002" || consistId == "DN4003" || consistId == "DN4004")
                {
                    spn = first.SPN3927;
                    ret = "SPN3927=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "01");
                }
                else
                    ret = SetFormatQualified();
            }
            else if (_MsgName == "CRO")
            {
                if (consistId == "DN2007")
                {
                    spn = first.SPN2830;
                    ret = "SPN2830=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "00");
                }
                else if(consistId == "DN2010" || consistId=="DN3001" || consistId == "DN3002" || consistId == "DN3003" || consistId == "DN3004")
                {
                    spn = first.SPN2830;
                    ret = "SPN2830=" + spn + KeyConst.Punctuation.Space;
                    ret += SpnEqualStr(spn, "AA");
                }
                else
                    ret = SetFormatQualified();
            }
            else
                ret = SetFormatQualified();
            return ret;
        }
        private string SetFormatQualified()
        {
            _IsResultOk = true;
            return KeyConst.Consist.Result.Qualified;
        }
        private string SetFormatUnqualified()
        {
            _IsResultOk = true;
            return KeyConst.Consist.Result.Qualified;
        }
        private string SpnEqualStr(string spn, string qulifiedStr)
        {
            if (spn == qulifiedStr)
                return SetFormatUnqualified();
            else
                return SetFormatUnqualified();
        }
    }
}
