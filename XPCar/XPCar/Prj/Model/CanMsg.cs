using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class CanMsg
    {
        public int ObjectNo { get; set; }
        public string Direction { get; set; }
        public string CreateTimestamp { get; set; }
        public string TimeIncrement { get; set; }   //add for 时间增量
        public string Id { get; set; }
        public int Dlc { get; set; }
        public string MsgData { get; set; }
        public string MsgText { get; set; }
    }
}
