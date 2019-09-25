using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolDCSet : EncodeProtocol
    {
        public EncodeProtocolDCSet(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolDCSet()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.DC_SET);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];
        }
        public void AddContent(SettingDC data)
        {
            try
            {
                EncodeInt32(data.RValue);
                EncodeEnlarge10(data.BatVolt);
                EncodeIoState(data.IoState);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void EncodeInt32(int val)
        {
            EncodeCommonIntUse2Byte(val);
        }
        private void EncodeEnlarge10(double val)
        {
            int num = (int)val * 10;
            EncodeCommonIntUse2Byte(num);
        }
        private void EncodeIoState(string text)
        {
            byte[] content = ProtocolHelper.ConvertCharToBytes(text);
            this.Content.AddRange(content);
        }
    }
}
