using System;

namespace XPCar.Prj.Flow
{
    //add for 时间增量
    public class ValueManager
    {
        public DateTime PreMsgCreateTime { get; set; } = DateTime.Parse("2000-01-01 12:00:00.000");
        public void Reset()
        {
            PreMsgCreateTime = DateTime.Parse("2000-01-01 12:00:00.000");
            FirstCreateTime = DateTime.Parse("2000-01-01 00:00:00.000");
        }
        public DateTime FirstCreateTime { get; set; } = DateTime.Parse("2000-01-01 00:00:00.000");
    }
}
