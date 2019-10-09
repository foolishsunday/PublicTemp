using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Prj.Model;
using XPCar.Protocol.Decode.Service;

namespace XPCar.Protocol.Decode
{
    public class DecodeManager : IDecodePackageFactory
    {
        public void CreateDecodeMachine(List<EachFrameModel> lists)
        {
            DecodePackageCommon dpc;
            if (lists != null && lists.Count > 0)
            {
                foreach (EachFrameModel model in lists)
                {
                    dpc = CreateMachineByName(model.Cmd);
                    if (dpc != null)
                        dpc.DecodePackage(model);
                }
                lists.Clear();
            }
        }
        private DecodePackageCommon CreateMachineByName(string cmd)
        {
            switch (cmd)
            {
                case ConstCmd.CmdAck.CAN:
                    return new Decode_CanMsg();
                case ConstCmd.CmdAck.BASE_INFO:
                    return new Decode_BaseInfo();
                case ConstCmd.CmdAck.CHARGE_PARA_GET:
                    return new Deocde_ChargeParaGet();
                case ConstCmd.CmdAck.CHARGE_STOP_GET:
                    return new Decode_ChargeStopGet();
                case ConstCmd.CmdAck.CHARGING_GET:
                    return new Decode_ChargingGet();
                case ConstCmd.CmdAck.HANDSHAKE_GET:
                    return new Decode_Handshake();
                case ConstCmd.CmdAck.CONSIST:
                case ConstCmd.CmdAck.HANDSHAKE_SET:
                case ConstCmd.CmdAck.CHARGE_PARA_SET:
                case ConstCmd.CmdAck.CHARGING_SET:
                case ConstCmd.CmdAck.CHARGE_STOP_SET:
                case ConstCmd.CmdAck.SYS_START:
                case ConstCmd.CmdAck.AC_SET:
                case ConstCmd.CmdAck.TIME_SYNC://add for 实时时间
                    return new Decode_Discard();
                case ConstCmd.CmdAck.UPGRADE_ACK:
                    return new Decode_Upgrade();
                case ConstCmd.CmdAck.DC_GET:
                    return new Decode_DCGet();
                case ConstCmd.CmdAck.DC_SET:
                    return new Decode_DCSet();
                case ConstCmd.CmdAck.AC_GET:
                    return new Decode_ACGet();
                case ConstCmd.CmdAck.ALARM_GET:
                    return new Decode_AlarmGet();
                case ConstCmd.CmdAck.AC_INTEROP_GET:
                    return new Decode_ACInteropGet();
                case ConstCmd.CmdAck.VER_GET:
                    return new Decode_VerGet();
                default:
                    return new Decode_Undefined();
            }
            //return null;
        }


    }
}
