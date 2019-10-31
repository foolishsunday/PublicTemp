using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class OffsetConfig
    {
        public OffsetConfig()
        {
            Std1s = 200;
            Std5s = 500;
            Std10s = 3000;
            Std10ms = 3;
            Std50ms = 10;
        }
        public int Std1s { get; set; }
        public int Std5s { get; set; }
        public int Std10s { get; set; }
        public int Std10ms { get; set; }
        public int Std50ms { get; set; }
    }
}
