using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Service
{
    public class Decode_BaseInfo : DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            List<byte> buf = package.Buffer;
            //string[] arr = Function.SplitMsgData(content);
            BaseInfo info = DecodeBaseInfo(buf);
            Prj.Prj.RcvdProtocolManager.DoUpdateBaseInfo(info);
            Prj.Prj.WaveController.SetWaveBaseInfo(info);
        }
        private BaseInfo DecodeBaseInfo(List<byte> buf)
        {
            BaseInfo info = new BaseInfo();
            info.ChargeV = DecodeChargeV(buf);
            info.ChargeI = DecodeChargeI(buf);
            info.DC_P_Temp = DecodeDCP(buf);
            info.DC_M_Temp = DecodeDCM(buf);
            info.AmbientTemp = DecodeAmbientTemp(buf);
            info.CC1Volt = DecodeCC1Volt(buf);
            info.CC2Volt = DecodeCC2Volt(buf);
            info.AssistVolt = DecodeAssistVolt(buf);
            info.ChargeState = DecodeChargeState(buf);
            return info;
        }
        private string DecodeChargeV(List<byte> buf)
        {
            byte[] bytes = BaseConvert.CutLists(buf, 9, 4);
            int val = BaseConvert.Convert4AsciiToInt32(bytes);
            double v = Function.ShrinkCntTimes(val, 10);
            return v.ToString("f1");
        }
        private string DecodeChargeI(List<byte> buf)
        {
            byte[] bytes = BaseConvert.CutLists(buf, 13, 4);
            int val = BaseConvert.Convert4AsciiToInt32(bytes);
            double v = Function.ShrinkCntTimes(val, 10);
            return v.ToString("f1");
        }
        private string DecodeDCP(List<byte> buf)
        {
            byte[] bytes = BaseConvert.CutLists(buf, 17, 4);
            int val = BaseConvert.Convert4AsciiToInt32(bytes);
            double v = Function.ShrinkCntTimes(val, 10);
            return v.ToString("f1");
        }
        private string DecodeDCM(List<byte> buf)
        {
            byte[] bytes = BaseConvert.CutLists(buf, 21, 4);
            int val = BaseConvert.Convert4AsciiToInt32(bytes);
            double v = Function.ShrinkCntTimes(val, 10);
            return v.ToString("f1");
        }
        private string DecodeAmbientTemp(List<byte> buf)
        {
            byte[] bytes = BaseConvert.CutLists(buf, 25, 4);
            int val = BaseConvert.Convert4AsciiToInt32(bytes);
            double v = Function.ShrinkCntTimes(val, 10);
            return v.ToString("f1");
        }
        private string DecodeCC1Volt(List<byte> buf)
        {
            byte[] bytes = BaseConvert.CutLists(buf, 29, 4);
            int val = BaseConvert.Convert4AsciiToInt32(bytes);
            double v = Function.ShrinkCntTimes(val, 10);
            return v.ToString("f1");
        }
        private string DecodeCC2Volt(List<byte> buf)
        {
            byte[] bytes = BaseConvert.CutLists(buf, 33, 4);
            int val = BaseConvert.Convert4AsciiToInt32(bytes);
            double v = Function.ShrinkCntTimes(val, 10);
            return v.ToString("f1");
        }
        private string DecodeAssistVolt(List<byte> buf)
        {
            byte[] bytes = BaseConvert.CutLists(buf, 37, 4);
            int val = BaseConvert.Convert4AsciiToInt32(bytes);
            double v = Function.ShrinkCntTimes(val, 10);
            return v.ToString("f1");
        }
        private string DecodeChargeState(List<byte> buf)
        {
            List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.BASE_INFO);
            string[] arr = Function.SplitMsgData(content);
            string state = arr[ConstCmd.FrameLen.BASE_INFO / 2 - 1];
            string result = GetChargeStateText(state);
            return result;
        }
        //车模拟器
        private string GetChargeStateText(string state)
        {
            switch (state.ToUpper())
            {
                case "00":
                    return "空闲状态";
                case "01":
                    return "等待低压辅助电源";
                case "02":
                    return "等待握手报文";
                case "03":
                    return "等待辨识报文SPN2563=0x00";
                case "04":
                    return "等待辨识报文SPN2563=0x01";
                case "05":
                    return "等待CTS、CML报文";
                case "06":
                    return "等待CRO_00报文";
                case "07":
                    return "等待CRO_AA报文";
                case "08":
                    return "等待充电开始";
                case "09":
                    return "充电中";
                case "0A":
                    return "等待充电中止报文";
                case "0B":
                    return "等待充电机充电统计";
                case "0C":
                    return "充电结束";
                default:
                    return "Undefined";
            }
        }
    }
}
