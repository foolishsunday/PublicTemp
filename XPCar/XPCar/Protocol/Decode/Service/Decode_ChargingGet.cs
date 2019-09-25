using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Service
{
    public class Decode_ChargingGet : DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            try
            {
                List<byte> buf = package.Buffer;
                List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.CHARGING_GET);
                string[] arr = Function.SplitMsgData(content);
                GetCharging data = new GetCharging();
                int i = 0;

                data.OutputV = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.OutputI = DecodeCommonShrink10Keep1(arr[i++], arr[i++]);
                data.ChargeTime = DecodeChargeTime(arr[i++], arr[i++]);
                data.PermitState = DecodePermitState(arr[i++]);
                string str = arr[i++];
                data.ConditionPause = DecodeConditionPause(str);
                data.ManPause = DecodeManPause(str);
                data.TroublePause = DecodeTroublePause(str);
                data.BMSPause = DecodeBMSPause(str);

                //故障
                str = arr[i++];
                data.HighTempTrouble = DecodeHighTempTrouble(str);
                data.ConnTrouble = DecodeConnTrouble(str);
                data.InnerTrouble = DecodeInnerTrouble(str);
                data.TransferTrouble = DecodeTransferTrouble(str);

                str = arr[i++];
                data.EmergencyStopTrouble = DecodeEmergencyTrouble(str);
                data.OtherTrouble = DecodeOtherTrouble(str);

                str = arr[i++];
                data.MismatchI = DecodeMismatchI(str);
                data.UnusualV = DecodeUnusualV(str);

                Prj.Prj.GeneralController.RefreshCharging(data);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        //X1-X2
        private string DecodeCommonShrink10Keep1(string high, string low)
        {
            double result = Function.Shrink10Keep1ByStr(low, high);
            return result.ToString("f1");
        }
        private string DecodePermitState(string arr)
        {
            if (arr.ToUpper() == "01")
                return "充电允许";
            else
                return "充电暂停";
        }
        private string DecodeChargeTime(string high, string low)
        {
            int val = BaseConvert.HexStr2Int32(high + low);
            return val.ToString();
        }
        #region 中止
        private string DecodeConditionPause(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 0, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.AchievedConditionPaused);
            return text;
        }
        private string DecodeManPause(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 2, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.ManPaused);
            return text;
        }
        private string DecodeTroublePause(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 4, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.TroublePaused);
            return text;
        }
        private string DecodeBMSPause(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 6, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.BMSPaused);
            return text;
        }
        #endregion

        #region 故障
        private string DecodeHighTempTrouble(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 0, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.HighTemp);
            return text;
        }
        private string DecodeConnTrouble(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 2, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.Trouble);
            return text;
        }
        private string DecodeInnerTrouble(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 4, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.HighTemp);
            return text;
        }
        private string DecodeTransferTrouble(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 6, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.EnergyTransfer);
            return text;
        }
        private string DecodeEmergencyTrouble(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 0, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.EmergencyStop);
            return text;
        }
        private string DecodeOtherTrouble(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 2, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.Trouble);
            return text;
        }
        #endregion

        #region 中止充电错误原因
        private string DecodeMismatchI(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 0, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.Mismatched);
            return text;
        }
        private string DecodeUnusualV(string str)
        {
            int val = BaseConvert.HexStr2Int32(str);
            string result = BaseConvert.GetBitsFromHex(val, 2, 2);
            string text = Function.MatchStateText(result, KeyConst.MatchClass.StateName.Unusual);
            return text;
        }
        #endregion
    }
}
