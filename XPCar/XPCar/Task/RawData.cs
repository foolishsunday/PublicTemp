using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Task
{
    public class RawData
    {
        public RawData()
        { }
        //public RawData(TaskCommon.TaskName taskName,byte[] buf)
        //{
        //    this.TaskName = taskName;
        //    this.Buffer = buf;
        //}
        //public TaskCommon.TaskName TaskName { get; set; }
        public byte[] Buffer { get; set; }
    }
}
