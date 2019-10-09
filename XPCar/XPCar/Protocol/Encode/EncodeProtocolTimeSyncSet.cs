using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;

namespace XPCar.Protocol.Encode
{
    //add for 实时时间
    public class EncodeProtocolTimeSyncSet : EncodeProtocol
    {
        public EncodeProtocolTimeSyncSet(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolTimeSyncSet()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.TIME_SYNC);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];

        }
        public void AddContent()
        {
            try
            {
                bool result = true;
                DateTime now = DateTime.Now;

                result &= EncodeCommonIntUse2Byte(now.Year);
                result &= EncodeCommon1Int(now.Month);
                result &= EncodeCommon1Int(now.Day);
                result &= EncodeCommon1Int(now.Hour);
                result &= EncodeCommon1Int(now.Minute);
                result &= EncodeCommon1Int(now.Second);
                result &= EncodeCommonIntUse2Byte(now.Millisecond);

            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
    }
}
