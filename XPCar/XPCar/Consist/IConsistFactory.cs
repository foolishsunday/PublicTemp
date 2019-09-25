using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;

namespace XPCar.Consist
{
    public interface IConsistFactory
    {
        Function.ConsistResult CreateConsistMachine(string msgName);
    }
}
