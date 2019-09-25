using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Database;
using XPCar.Prj.Model;

namespace XPCar.Consist
{
    public abstract class ConsistCommon
    {
        public abstract TestItemsReport GenerateReport(DbService db, string msgName);
    }
}
