using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class StatisticsData
    {
        public int HitCount { get; set; }
        public long MinInterval { get; set; }
        public long MaxInterval { get; set; }
        public double AvgInterval { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public StatisticsData()
        {
        }
        public StatisticsData(int hitCount, long min, long max, double avg, string beginDate, string endDate)
        {
            this.HitCount = hitCount;
            this.MinInterval = min;
            this.MaxInterval = max;
            this.AvgInterval = avg;
            this.BeginDate = beginDate;
            this.EndDate = endDate;
        }
    }
}
