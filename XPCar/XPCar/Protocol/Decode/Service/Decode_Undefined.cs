using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Service
{
    public class Decode_Undefined : DecodePackageCommon
    {

        public override void DecodePackage(EachFrameModel package)
        {
            try
            {
                List<byte> buf = package.Buffer;
                int i = 0;
                string text = "";
                for (i = 0; i < buf.Count(); i++)
                    text += Convert.ToString(buf[i], 16) + " ";
                Log.Warn(System.Reflection.MethodBase.GetCurrentMethod().Name, "Decode_Undefined: Can not decode data = " + text);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
     
    }
}

