using System;
using System.Collections.Generic;

using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Msg
{
    public class Msg_MutiPackageReady : MsgCommon
    {
        private string TestReady = "充电机准备接收多包报文";
        private string TestEnd= "充电机完成接收多包报文";
        private string TestReject = "充电机拒绝接收多包报文";

        public override CanMsgRich DecodeMsgData(string symbol, List<byte> content)
        {
            CanMsgRich model = new CanMsgRich();
            string text;
            try
            {
                KeyConst.TransitState ack = GetTransitAck(content);
                if (ack == KeyConst.TransitState.Ready)
                {
                    text = this.TestReady;
                    model.ConsistMsg.IsPackageReady = 1;
                }
                else if (ack == KeyConst.TransitState.Finish)
                {
                    model.ConsistMsg.IsPackageEnd = 1;//最后一包
                    text = this.TestEnd;
                }
                else
                {
                    model.ConsistMsg.IsPackageReady = 2;//拒绝接收
                    text = this.TestReject;
                }
                model.MsgText = Function.AppendTextToMsgHead(symbol, text);
                return model;
            }
            catch (Exception ex)
            {
                model.MsgText = "Tranlate Error!";
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return model;
            }
        }

        private KeyConst.TransitState GetTransitAck(List<byte> content)
        {
            string readyOrFinish = BaseConvert.AsciiBytes2String(content, 0, 2);

            if (readyOrFinish == "11")
                return KeyConst.TransitState.Ready;
            else if (readyOrFinish == "13")
            {
                return KeyConst.TransitState.Finish;
            }
            else
                return KeyConst.TransitState.Reject;
        }
    }
}
