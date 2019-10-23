using System;
using System.Collections.Generic;

using XPCar.Common;
using XPCar.Prj.Model;
using XPCar.Protocol.Decode.Msg.MsgSorts;

namespace XPCar.Protocol.Decode.Msg
{
    public class MsgManager
    {
        public MsgManager()
        {
        }
        public CanMsgRich DecodeMsgData(string flowId, List<byte> content)
        {
            string symbol = string.Empty;
            CanMsgRich model = new CanMsgRich();
            try
            {
                MsgCommon machine = CreateDecodeMsgMachine(flowId);   
                symbol = FindMsgSymbol(flowId, content);

                if (flowId != KeyConst.CanMsgId.MUTI_PACKAGE_TEXT)
                {
                    model = machine.DecodeMsgData(symbol, content);
                    if (flowId == KeyConst.CanMsgId.MUTI_PACKAGE_HEAD)  //是否多包的首包
                    {
                        model.ConsistMsg.IsLastPackage = 1;//此处IsLastPackage当作IsFirstPackage来用
                    }
                }
                else //多包 正文
                {
                    int index = GetMuitPckgIndex(content);

                    if (index == Prj.Prj.MutiPackage.GetCountPlan())    //最后一包
                    {
                        Prj.Prj.MutiPackage.AppendContentPackage(content);  //先附加包，再解析
                        machine = CreateDecodeMsgMachine(symbol);
                        model = machine.DecodeMsgData(symbol, Prj.Prj.MutiPackage.GetMutiContent());    //解析所有包
                        model.ConsistMsg.MutiLength = Prj.Prj.MutiPackage.GetAppendCnt();               //获取实际包数 for Consist Test
           
                    }
                    else
                    {
                        model = machine.DecodeMsgData(symbol, content);     //先解析当前包：for解析出第几包
                        Prj.Prj.MutiPackage.AppendContentPackage(content);  //再附加包
                        //Prj.Prj.MutiPackage.Finish = false;                 //标记未完成解包
                    }
                }
                model.ConsistMsg.PackageId = SetPackageId(flowId);
                model.ConsistMsg.TextId = SetPackageTextId(flowId);
                model.Symbol = symbol;
                model.ConsistMsg.MsgName = symbol;
  
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return model;
        }

        private MsgCommon CreateDecodeMsgMachine(string idFlow)
        {
            switch (idFlow)
            {
                case KeyConst.CanMsgId.BHM:
                    return new Msg_BHM();
                case KeyConst.CanMsgId.CHM:
                    return new Msg_CHM();
                case KeyConst.CanMsgId.CRM:
                    return new Msg_CRM();
                case KeyConst.CanMsgId.MUTI_PACKAGE_HEAD:
                    return new Msg_MutiPackageHead();
                case KeyConst.CanMsgId.MUTI_PACKAGE_READY:
                    return new Msg_MutiPackageReady();
                case KeyConst.CanMsgId.MUTI_PACKAGE_TEXT:
                    return new Msg_MutiPackageText();
                case KeyConst.CanMsgId.BRM:
                    return new Msg_BRM();
                case KeyConst.CanMsgId.BCP:
                    return new Msg_BCP();
                case KeyConst.CanMsgId.CTS:
                    return new Msg_CTS();
                case KeyConst.CanMsgId.CML:
                    return new Msg_CML();
                case KeyConst.CanMsgId.BRO:
                    return new Msg_BRO();
                case KeyConst.CanMsgId.CRO:
                    return new Msg_CRO();
                case KeyConst.CanMsgId.BCL:
                    return new Msg_BCL();
                case KeyConst.CanMsgId.BCS:
                    return new Msg_BCS();
                case KeyConst.CanMsgId.CCS:
                    return new Msg_CCS();
                case KeyConst.CanMsgId.BSM:
                    return new Msg_BSM();
                case KeyConst.CanMsgId.BMV:
                    return new Msg_BMV();
                case KeyConst.CanMsgId.BMT:
                    return new Msg_BMT();
                case KeyConst.CanMsgId.BSP:
                    return new Msg_BSP();
                case KeyConst.CanMsgId.BST:
                    return new Msg_BST();
                case KeyConst.CanMsgId.CST:
                    return new Msg_CST();
                case KeyConst.CanMsgId.BSD:
                    return new Msg_BSD();
                case KeyConst.CanMsgId.CSD:
                    return new Msg_CSD();
                case KeyConst.CanMsgId.BEM:
                    return new Msg_BEM();
                case KeyConst.CanMsgId.CEM:
                    return new Msg_CEM();
                default:
                    return new Msg_Undefined();
            }
        }

        private string FindMsgSymbol(string flowId, List<byte> content)
        {
            string symbol = flowId;
            if (flowId == KeyConst.CanMsgId.MUTI_PACKAGE_HEAD)
            {
                Prj.Prj.MutiPackage.UpdateMutiPackage_Head(content);    //更新多包信息
                symbol = Prj.Prj.MutiPackage.GetSymbol();  //多包symbol
            }
            else if (flowId == KeyConst.CanMsgId.MUTI_PACKAGE_READY)
            {
                Prj.Prj.MutiPackage.UpdateMutiPackage_Ready(content);
                symbol = Prj.Prj.MutiPackage.GetSymbol();
            }
            else if (flowId == KeyConst.CanMsgId.MUTI_PACKAGE_TEXT)
            {
                symbol = Prj.Prj.MutiPackage.GetSymbol();
            }
            else { }
            return symbol;
        }
        private int GetMuitPckgIndex(List<byte> content)
        {
            try
            {
                string[] arr = Function.SplitMsgData(content);
                int index = Convert.ToInt32(arr[0], 16);
                return index;
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return 0;
        }

        private int SetPackageId(string flowId)
        {
            if (flowId == KeyConst.CanMsgId.MUTI_PACKAGE_HEAD || flowId == KeyConst.CanMsgId.MUTI_PACKAGE_READY || flowId == KeyConst.CanMsgId.MUTI_PACKAGE_TEXT)
            {
                return Prj.Prj.MutiPackage.GetCurrentPackageId();
            }
            else
                return 0;
        }
        private int SetPackageTextId(string flowId)
        {
            if (flowId == KeyConst.CanMsgId.MUTI_PACKAGE_TEXT)
            {
                return Prj.Prj.MutiPackage.GetCurrentTextId();
            }
            else
                return 0;
        }
    }
}
