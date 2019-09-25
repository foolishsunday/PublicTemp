using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Consist.Calc
{
    public interface IMeasureResult
    {
        string ResultText(string consistId);
        bool IsResultOk();
    }
}
