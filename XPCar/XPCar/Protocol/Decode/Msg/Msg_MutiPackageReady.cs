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
        public override CanMsgRich DecodeMsgData(string symbol, List<byte> content)
        {
            CanMsgRich model = new CanMsgRich();
            string text;
            try
            {
                if (IsReady(content))
                    text = this.TestReady;
                else
                {
                    model.ConsistMsg.IsPackageEnd = 1;//最后一包
                    text = this.TestEnd;
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

        private bool IsReady(List<byte> content)
        {
            string readyOrFinish = BaseConvert.AsciiBytes2String(content, 0, 2);

            if (readyOrFinish == "11")
                return true;
            else  //"13"
                return false;
        }
    }
}
