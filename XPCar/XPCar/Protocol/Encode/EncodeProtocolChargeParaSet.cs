using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Encode
{
    public class EncodeProtocolChargeParaSet : EncodeProtocol
    {
        public EncodeProtocolChargeParaSet(EncodeProtocol encodeProtocol) : base(encodeProtocol)
        {

        }
        public EncodeProtocolChargeParaSet()
        {
            byte[] cmdType = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdType.SETTING);
            byte[] cmd = ProtocolHelper.ConvertCharToBytes(ConstCmd.CmdEncode.CHARGE_PARA_SET);

            this.CmdTypeHigh = cmdType[0];
            this.CmdTypeLow = cmdType[1];
            this.CmdHigh = cmd[0];
            this.CmdLow = cmd[1];

        }

        private bool EncodeMaxTemp(string str)
        {
            try
            {
                int temp = Convert.ToInt32(str) + 50;
                str = BaseConvert.Int32ToHexStr(temp);
                string result = str.PadLeft(2, '0');
                byte[] content = ProtocolHelper.ConvertCharToBytes(result);
                this.Content.AddRange(content);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        private bool EncodeReadyState(string state)
        {
            try
            {
                bool isSuccess = true;
                byte[] content = ProtocolHelper.ConvertCharToBytes(state);
                this.Content.AddRange(content);
                return isSuccess;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
   
        public bool AddContent(SettingChargePara data)
        {
            try
            {
                //X1-X2 电池最高允许充电电压
                bool result = EncodeCommonStrMultiply100(data.MaxSingleV);

                //X3-X4 最高允许充电电流
                result &= EncodeCommonStrMultiply10(data.MaxChargeI);

                //X5-X6 蓄电池标称总能量
                result &= EncodeCommonStrMultiply10(data.Energy);

                //X7-X8 最高允许充电电压
                result &= EncodeCommonStrMultiply10(data.MaxChargeV);

                //X9 最高允许温度
                result &= EncodeMaxTemp(data.MaxTemp);

                //X10-X11 动力蓄电池荷电状态
                result &= EncodeCommonStrMultiply10(data.SOC);

                //X12-X13 动力蓄电池当前电池电压
                result &= EncodeCommonStrMultiply10(data.CurBatVolt);

                //X14-X15 BCP报文周期
                result &= EncodeCommon2HexStr(data.BCPPeriod);

                //X16 车辆准备就绪状态
                result &= EncodeReadyState(data.ReadyState);

                //X17 BRO报文报文周期
                result &= EncodeCommon2HexStr(data.BROPeriod);


                return result;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }

        }
    }
}
