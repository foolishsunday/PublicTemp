using System;
using XPCar.Prj.Model;

namespace XPCar.Prj.Flow
{
    //add for 时间增量
    //add for 时序控制图
    public class ValueManager
    {
        public DateTime PreMsgCreateTime { get; set; } = DateTime.Parse("2000-01-01 12:00:00.000");
        public void Reset()
        {
            PreMsgCreateTime = DateTime.Parse("2000-01-01 12:00:00.000");
            FirstCreateTime = DateTime.Parse("2000-01-01 00:00:00.000");
        }
        public DateTime FirstCreateTime { get; set; } = DateTime.Parse("2000-01-01 00:00:00.000");
        public bool IsFirstMsg()//add for 实时时间
        {
            if (PreMsgCreateTime.Year == 2000)
                return true;
            else
                return false;
        }
    }
}
