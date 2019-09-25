using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode
{
    public abstract class DecodePackageCommon
    {
        public abstract void DecodePackage(EachFrameModel package);
    }
}
