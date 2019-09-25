using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Consist.Calc
{
    public class MeasureInterval: IMeasureResult
    {
        private List<ConsistMsg> _Data;
        private List<long> _Intervals;
        private string _MsgName;
        private bool _IntervalResult;
        private long[] _Std;
        private int _DistinctCnt;
        public MeasureInterval(List<ConsistMsg> data, string msgName)
        {
            _Data = data;
            _IntervalResult = true;
            _MsgName = msgName;
            _Intervals = new List<long>();
            _DistinctCnt = 0;
        }
        public string ResultText(string consistId)
        {
            string text = string.Empty;
            text += "周期" + KeyConst.Punctuation.Colon;
            _Std = StandarNormalInterval(consistId);
            try
            {
                if (_MsgName == KeyConst.CanMsgId.BRM
                || _MsgName == KeyConst.CanMsgId.BCP
                || _MsgName == KeyConst.CanMsgId.BCS
                || _MsgName == KeyConst.CanMsgId.BMV
                || _MsgName == KeyConst.CanMsgId.BSP)
                {
                    CalPeriodPackageInterval();
                    text += GetMinPeriodTestText(consistId);
                    text += GetMaxPeriodTestText(consistId);

                    //CalInnerPackageGap();
                    //text += GetMinIntervalTestText(consistId);
                    //text += GetMaxIntervalTestText(consistId);
                }
                else
                {
                    _Intervals = Function.CalcInterval(_Data);//一个完整多包里，包与包之间的间隔

                    text += GetMinPeriodTestText(consistId);
                    text += GetMaxPeriodTestText(consistId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return text;
        }
        private string GetMinPeriodTestText(string consistId)
        {
            string text = string.Empty;
     
            try
            {
                string result;
                string min = MinInterval().ToString();
                if (IsMinPeriodOk(consistId))
                {
                    result = KeyConst.Consist.Result.Qualified;
                }
                else
                {
                    result = KeyConst.Consist.Result.Unqualified;
                    _IntervalResult &= false;
                }
                //if (_DistinctCnt != 1)
                //{
                //    if (IsMinPeriodOk(consistId))
                //    {
                //        result = KeyConst.Consist.Result.Qualified;
                //    }
                //    else
                //    {
                //        result = KeyConst.Consist.Result.Unqualified;
                //        _IntervalResult &= false;
                //    }
                //}
                //else//只有一条数据
                //{
                //    result = KeyConst.Consist.Result.Qualified;
                //    min = _Std[4].ToString();
                //}
                text = _MsgName + "最小周期" + KeyConst.Punctuation.Colon + min + KeyConst.Punctuation.Space + result + KeyConst.Punctuation.Space;
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return text;

        }

        private string GetMaxPeriodTestText(string consistId)
        {
            string text = string.Empty;

            try
            {
                string result;
                string max = MaxInterval().ToString();
                if (IsMaxPeriodOk(consistId))
                {
                    result = KeyConst.Consist.Result.Qualified;
                }
                else
                {
                    result = KeyConst.Consist.Result.Unqualified;
                    _IntervalResult &= false;
                }
                //if (_DistinctCnt != 1)
                //{
                //    if (IsMaxPeriodOk(consistId))
                //    {
                //        result = KeyConst.Consist.Result.Qualified;
                //    }
                //    else
                //    {
                //        result = KeyConst.Consist.Result.Unqualified;
                //        _IntervalResult &= false;
                //    }
                //}
                //else//只有一条数据
                //{

                //    result = KeyConst.Consist.Result.Qualified;
                //    max = _Std[4].ToString();
                //}

                text += _MsgName + "最大周期" + KeyConst.Punctuation.Colon + max
                    + KeyConst.Punctuation.Space + result + KeyConst.Punctuation.Space;

            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return text;

        }
        private string GetMinIntervalTestText(string consistId)
        {
            string text = string.Empty;
            try
            {
                string result;
                string min = MinInterval().ToString();
                if (IsMinGapOk(consistId))
                {
                    result = KeyConst.Consist.Result.Qualified;
                }
                else
                {
                    result = KeyConst.Consist.Result.Unqualified;
                    _IntervalResult &= false;
                }
                text = _MsgName + "最小间隔" + KeyConst.Punctuation.Colon + min + KeyConst.Punctuation.Space + result + KeyConst.Punctuation.Space;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return text;

        }
        private string GetMaxIntervalTestText(string consistId)
        {
            string text = string.Empty;
     
            try
            {
                string result;
                string max = MaxInterval().ToString();
                if (IsMaxGapOk(consistId))
                {
                    result = KeyConst.Consist.Result.Qualified;
                }
                else
                {
                    result = KeyConst.Consist.Result.Unqualified;
                    _IntervalResult &= false;
                }

                text = _MsgName + "最大间隔" + KeyConst.Punctuation.Colon + max + KeyConst.Punctuation.Space + result + KeyConst.Punctuation.Space;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return text;

        }
        private void CalInnerPackageGap()
        {
            try
            {
                var distinct = _Data.GroupBy(r => r.PackageId);
                foreach (var item in distinct)
                {
                    int itemKey = Convert.ToInt32(item.Key.ToString());
                    var pckgData = _Data.Where(r => r.PackageId == itemKey).OrderBy(o => o.ObjectNo).ToList();
                    List<long> interval = Function.CalcInterval(pckgData);
                    _Intervals.Clear();
                    _Intervals.AddRange(interval);
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void CalPeriodPackageInterval()
        {
            try
            {
                var distinct = _Data.Distinct(new LambdaComparer<ConsistMsg>((a,b) => a.PackageId == b.PackageId, obj => obj.ToString().GetHashCode())).ToList();
                _DistinctCnt = distinct.Count;
                List<long> period = Function.CalcInterval(distinct);
                _Intervals.Clear();
                _Intervals.AddRange(period);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private long MaxInterval()
        {
            return _Intervals.Max();
        }
        private long MinInterval()
        {
            return _Intervals.Min();
        }

        private long[] StandarNormalInterval(string consistId)
        {
            long[] lens = new long[5];
            switch (_MsgName)
            {
                case KeyConst.CanMsgId.BHM:
                case KeyConst.CanMsgId.BEM:
                case KeyConst.CanMsgId.BRO:
                case KeyConst.CanMsgId.BSM:
                case KeyConst.CanMsgId.BSD:
                case KeyConst.CanMsgId.CHM:
                case KeyConst.CanMsgId.CRM:
                case KeyConst.CanMsgId.CEM:
                case KeyConst.CanMsgId.CRO:
                case KeyConst.CanMsgId.CSD:
                    lens[0] = 250 - KeyConst.Consist.TimeError.Std250ms_PositiveNegative;
                    lens[1] = 250 + KeyConst.Consist.TimeError.Std250ms_PositiveNegative;
                    return lens;
                case KeyConst.CanMsgId.BRM:
                case KeyConst.CanMsgId.BCS:
                    lens[0] = 250 - KeyConst.Consist.TimeError.Std250ms_PositiveNegative;
                    lens[1] = 250 + KeyConst.Consist.TimeError.Std250ms_PositiveNegative;
                    lens[2] = 10 - KeyConst.Consist.TimeError.Std10ms_PositiveNegative3ms;
                    lens[3] = 10 + KeyConst.Consist.TimeError.Std10ms_PositiveNegative3ms;
                    if (_MsgName == KeyConst.CanMsgId.BRM)
                    {
                        lens[4] = 250;
                    }
                    else
                    {
                        lens[4] = 500;
                    }
                    return lens;
                case KeyConst.CanMsgId.BCP:
                    lens[0] = 500 - KeyConst.Consist.TimeError.Std250ms_PositiveNegative;
                    lens[1] = 500 + KeyConst.Consist.TimeError.Std250ms_PositiveNegative;
                    lens[2] = 10 - KeyConst.Consist.TimeError.Std10ms_PositiveNegative3ms;
                    lens[3] = 10 + KeyConst.Consist.TimeError.Std10ms_PositiveNegative3ms;
                    lens[4] = 500;
                    return lens;
                case KeyConst.CanMsgId.CTS:
                    lens[0] = 500 - KeyConst.Consist.TimeError.Std250ms_PositiveNegative;
                    lens[1] = 500 + KeyConst.Consist.TimeError.Std250ms_PositiveNegative;
                    return lens;
                case KeyConst.CanMsgId.BCL:
                case KeyConst.CanMsgId.CCS:
                    lens[0] = 50 - 5;
                    lens[1] = 50 + 5;
                    return lens;
                case KeyConst.CanMsgId.BST:
                case KeyConst.CanMsgId.CST:
                    lens[0] = 10 - KeyConst.Consist.TimeError.Std10ms_PositiveNegative3ms;
                    lens[1] = 10 + KeyConst.Consist.TimeError.Std10ms_PositiveNegative3ms;
                    return lens;

                default:
                    return lens;
            }

        }
        private bool IsMinGapOk(string consistId)
        {
            //long[] std = StandarNormalInterval(consistId);
            if (MinInterval() >= _Std[2] && MinInterval() <= _Std[3])
                return true;
            else
                return false;
        }
        private bool IsMaxGapOk(string consistId)
        {
            //long[] std = StandarNormalInterval(consistId);
            if (MaxInterval() >= _Std[2] && MaxInterval() <= _Std[3])
                return true;
            else
                return false;
        }
        private bool IsMinPeriodOk(string consistId)
        {
            //long[] std = StandarNormalInterval(consistId);
            if (MinInterval() >= _Std[0] && MinInterval() <= _Std[1])
                return true;
            else
                return false;
        }
        private bool IsMaxPeriodOk(string consistId)
        {
            //long[] std = StandarNormalInterval(consistId);
            if (MaxInterval() >= _Std[0] && MaxInterval() <= _Std[1])
                return true;
            else
                return false;
        }
        public bool IsResultOk()
        {
            return _IntervalResult;
        }
        public bool CommitResultToSummary(bool result)
        {
            _IntervalResult &= result;
            return _IntervalResult;
        }
    }
}
