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
            //text += "周期" + KeyConst.Punctuation.Colon;
            _Std = StandarNormalInterval(consistId);
            try
            {
                if (_MsgName == KeyConst.CanMsgId.BRM || _MsgName == KeyConst.CanMsgId.BCP || _MsgName == KeyConst.CanMsgId.BCS
                    || _MsgName == KeyConst.CanMsgId.BMV || _MsgName == KeyConst.CanMsgId.BSP)
                {
                    CalPeriodPackageInterval();
                    text += GetMinPeriodTestText(consistId);
                    text += GetMaxPeriodTestText(consistId);
                }
                else
                {
                    _Intervals = Function.CalcInterval(_Data);

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
        public void GenerateIntervalList()
        {
            try
            {
                if (_MsgName == KeyConst.CanMsgId.BRM || _MsgName == KeyConst.CanMsgId.BCP || _MsgName == KeyConst.CanMsgId.BCS
                    || _MsgName == KeyConst.CanMsgId.BMV || _MsgName == KeyConst.CanMsgId.BSP)
                {
                    CalPeriodPackageInterval();
                }
                else
                {
                    _Intervals = Function.CalcInterval(_Data);//一个完整多包里，包与包之间的间隔
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
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

                text = _MsgName + "最小周期" + KeyConst.Punctuation.Colon + min + KeyConst.Punctuation.Space + result + KeyConst.Punctuation.Space + Environment.NewLine;
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

                text += _MsgName + "最大周期" + KeyConst.Punctuation.Colon + max
                    + KeyConst.Punctuation.Space + result + KeyConst.Punctuation.Space + Environment.NewLine;

            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return text;

        }
        //private string GetMinIntervalTestText(string consistId)
        //{
        //    string text = string.Empty;
        //    try
        //    {
        //        string result;
        //        string min = MinInterval().ToString();
        //        if (IsMinGapOk(consistId))
        //        {
        //            result = KeyConst.Consist.Result.Qualified;
        //        }
        //        else
        //        {
        //            result = KeyConst.Consist.Result.Unqualified;
        //            _IntervalResult &= false;
        //        }
        //        text = _MsgName + "最小间隔" + KeyConst.Punctuation.Colon + min + KeyConst.Punctuation.Space + result + KeyConst.Punctuation.Space;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }
        //    return text;

        //}
        //private string GetMaxIntervalTestText(string consistId)
        //{
        //    string text = string.Empty;
     
        //    try
        //    {
        //        string result;
        //        string max = MaxInterval().ToString();
        //        if (IsMaxGapOk(consistId))
        //        {
        //            result = KeyConst.Consist.Result.Qualified;
        //        }
        //        else
        //        {
        //            result = KeyConst.Consist.Result.Unqualified;
        //            _IntervalResult &= false;
        //        }

        //        text = _MsgName + "最大间隔" + KeyConst.Punctuation.Colon + max + KeyConst.Punctuation.Space + result + KeyConst.Punctuation.Space;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }
        //    return text;

        //}
        //private void CalInnerPackageGap()
        //{
        //    try
        //    {
        //        var distinct = _Data.GroupBy(r => r.PackageId);
        //        foreach (var item in distinct)
        //        {
        //            int itemKey = Convert.ToInt32(item.Key.ToString());
        //            var pckgData = _Data.Where(r => r.PackageId == itemKey).OrderBy(o => o.ObjectNo).ToList();
        //            List<long> interval = Function.CalcInterval(pckgData);
        //            _Intervals.Clear();
        //            _Intervals.AddRange(interval);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
        //    }
        //}
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
        public long MaxInterval()
        {
            if (_Intervals.Count == 0)
                return 0;
            return _Intervals.Max();
        }
        public long MinInterval()
        {
            if (_Intervals.Count == 0)
                return 0;
            return _Intervals.Min();
        }

        public double AvgInterval()
        {
            if (_Intervals.Count == 0)
                return 0;
            double avg = _Intervals.Average();
            return Math.Round(avg, 3);
        }
        public int NonstandardIntervalCnt()
        {
            int cnt = 0;
            for (int i = 0; i < _Intervals.Count; i++)
            {
                if (_Intervals[i] < _Std[0] || _Intervals[i] > _Std[1])
                    cnt++;
            }
            return cnt;
        }
        public string BeginDate()
        {
            return _Data[0].CreateTimestamp;
        }
        public string EndDate()
        {
            return _Data[_Data.Count()-1].CreateTimestamp;
        }
        private long[] StandarNormalInterval(string consistId)
        {
            //double offset = Convert.ToDouble(Prj.Prj.MainController.Config.StandardSet.Std50ms) / 100F;
            //double offset10ms = Prj.Prj.MainController.Config.StandardSet.Std10ms;
            double offset = Convert.ToDouble(Prj.Prj.MainController.OffsetConfig.Std50ms) / 100F;
            double offset10ms = Prj.Prj.MainController.OffsetConfig.Std10ms;
            long[] lens = new long[5];
            switch (_MsgName)
            {
                case KeyConst.CanMsgId.BHM:
                case KeyConst.CanMsgId.CHM:
                case KeyConst.CanMsgId.CRM:
                case KeyConst.CanMsgId.BRM://
                case KeyConst.CanMsgId.CML:
                case KeyConst.CanMsgId.BRO:
                case KeyConst.CanMsgId.CRO:
                case KeyConst.CanMsgId.BCS://
                case KeyConst.CanMsgId.BSM://
                case KeyConst.CanMsgId.BSD:
                case KeyConst.CanMsgId.CSD:
                case KeyConst.CanMsgId.BEM:
                case KeyConst.CanMsgId.CEM:
                    lens[0] = (long)(250 * (1 - offset));
                    lens[1] = (long)(250 * (1 + offset));

                    return lens;
                //case KeyConst.CanMsgId.BCP:
                //    lens[0] = (long)(500 * (1 - offset));
                //    lens[1] = (long)(500 * (1 + offset));
                //    lens[2] = (long)(10 - offset10ms);
                //    lens[3] = (long)(10 + offset10ms);
                //    lens[4] = 500;
                //    return lens;
                case KeyConst.CanMsgId.BCP://
                case KeyConst.CanMsgId.CTS:
                    lens[0] = (long)(500 * (1 - offset));
                    lens[1] = (long)(500 * (1 + offset));
                    return lens;
                case KeyConst.CanMsgId.BCL:
                case KeyConst.CanMsgId.CCS:
                    lens[0] = (long)(50 * (1 - offset));
                    lens[1] = (long)(50 * (1 + offset));
                    return lens;
                case KeyConst.CanMsgId.BST:
                case KeyConst.CanMsgId.CST:
                    lens[0] = (long)(10 - offset10ms);
                    lens[1] = (long)(10 + offset10ms);
                    return lens;

                default:
                    return lens;
            }

        }
        //private bool IsMinGapOk(string consistId)
        //{
        //    if (MinInterval() >= _Std[2] && MinInterval() <= _Std[3])
        //        return true;
        //    else
        //        return false;
        //}
        //private bool IsMaxGapOk(string consistId)
        //{
        //    if (MaxInterval() >= _Std[2] && MaxInterval() <= _Std[3])
        //        return true;
        //    else
        //        return false;
        //}
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
    }
}
