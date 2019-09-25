using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolChargeStopSet : EncodeProtocol
    {
        public EncodeProtocolChargeStopSet(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolChargeStopSet()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.CHARGE_STOP_SET);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];
        }
        public bool AddContent(SettingChargeStop data)
        {
            try
            {
                bool isSuccess = true;

                isSuccess &= EncodePauseSoc(data.PauseSoc);
                isSuccess &= EncodeCommonStrMultiply100(data.MinSingleV);
                isSuccess &= EncodeCommonStrMultiply100(data.MaxSingleV);
                isSuccess &= EncodeTemp(data.MinTemp);
                isSuccess &= EncodeTemp(data.MaxTemp);
                isSuccess &= EncodeCommon2HexStr(data.BSDPeriod);

                return isSuccess;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodePauseSoc(string soc)
        {
            try
            {
                int num = Convert.ToInt32(soc);
                return EncodeCommon1Int(num);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeTemp(string str)
        {
            try
            {
                int num = Convert.ToInt32(str) + 50;
                return EncodeCommon1Int(num);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
    }
}
