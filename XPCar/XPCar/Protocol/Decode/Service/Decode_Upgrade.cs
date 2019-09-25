using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Prj.Model;
namespace XPCar.Protocol.Decode.Service
{
    public class Decode_Upgrade : DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            try
            {
                List<byte> buf = package.Buffer;

                List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.UPGRADE_ACK);
                string[] arr = Function.SplitMsgData(content);
                Prj.Prj.UpgradeController.SetUpgradeState(arr[3].ToUpper());
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
    }
}
