﻿using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Service
{
    public class Decode_AlarmGet : DecodePackageCommon
    {
        public override void DecodePackage(EachFrameModel package)
        {
            List<byte> buf = package.Buffer;
            List<byte> content = BaseConvert.CutLists2Lists(buf, 9, ConstCmd.FrameLen.ALARM_GET);
            string[] arr = Function.SplitMsgData(content);
            int i = 0;
            string alarm = DecodeAlarm(arr[i++], arr[i++], arr[i++], arr[i++]);
            Prj.Prj.GeneralController.RefreshAlarm(alarm);
        }
        private string DecodeAlarm(string str1, string str2, string str3, string str4)
        {
            string bin;
            bin = BaseConvert.HexStr2BinaryStr(8, str1);
            bin += BaseConvert.HexStr2BinaryStr(8, str2);
            bin += BaseConvert.HexStr2BinaryStr(8, str3);
            bin += BaseConvert.HexStr2BinaryStr(8, str4);
            for (int i = 0; i < 32; i++)
            {
                string bit = bin.Substring(i, 1);
                if (bit == "1")
                {
                    return GetAlarmText(i);
                }
            }
            return "正常";
        }
        private string GetAlarmText(int alarmIndex)
        {
            switch (alarmIndex)
            {
                case 0:
                    return "紧急停机";
                case 1:
                    return "DC+温度过高";
                case 2:
                    return "DC-温度过高";
                case 3:
                    return "BMS板温度过高";
                case 4:
                    return "绝缘检测异常";
                case 5:
                    return "电池电压异常";
                case 6:
                    return "电池反接";
                case 7:
                    return "电池反接";
                case 8:
                    return "车辆BMS通讯异常";
                case 9:
                    return "接触器K1K2粘连";
                case 10:
                    return "风扇故障";
                case 11:
                    return "放电电阻异常";
                case 12:
                    return "接地故障";
                case 13:
                    return "模块通信中断";
                case 14:
                    return "系统输出过压";
                case 15:
                    return "系统输出过流";
                case 16:
                    return "模块故障";
                case 17:
                    return "模块限流";
                case 18:
                    return "模块风扇故障";
                case 19:
                    return "输入过压";
                case 20:
                    return "输入欠压";
                case 21:
                    return "模块输出过压";
                case 22:
                    return "模块输出欠压";
                default:
                    return "Undefined";
            }
        }
    }
}
