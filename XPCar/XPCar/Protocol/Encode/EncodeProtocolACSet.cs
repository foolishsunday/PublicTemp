using System;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolACSet : EncodeProtocol
    {
        public EncodeProtocolACSet(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolACSet()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.AC_SET);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];
        }
        public bool AddContent(SettingACInterop data)
        {
            try
            {
                bool isSuccess = true;

                isSuccess &= EncodeIoState(data.HexState);

                return isSuccess;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeIoState(string text)
        {
            try
            {
                byte[] content = ProtocolHelper.ConvertCharToBytes(text);
                this.Content.AddRange(content);
                return true;
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }

        }
        private void EncodeReserve()
        {
            try
            {
                byte[] content = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                this.Content.AddRange(content);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
    }
}
