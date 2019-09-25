using System;
using System.Collections.Generic;
using XPCar.Common;
using XPCar.Prj.Model;


namespace XPCar.Protocol.Decode.Msg.MsgSorts
{
    public class Msg_BRO : MsgCommon
    {
        private string MsgHeadLine = "电池充电准备就绪状态";

        private string TestFinishCharge = "BMS完成充电准备";
        private string TestUnfinishCharge = "BMS未完成充电准备";

        private string JudgeFinishCharge = "AA";
        private string JudgeInvalid = "FF";
        public override CanMsgRich DecodeMsgData(string symbol, List<byte> content)
        {
            CanMsgRich model = new CanMsgRich();

            string text = string.Empty;
            try
            {
                string[] arr = Function.SplitMsgData(content);
                string val = arr[0].ToUpper();
                if (val == JudgeFinishCharge)
                {
                    text = TestFinishCharge;
                }
                else if (val == JudgeInvalid)
                {
                    text = TestUnfinishCharge;
                }
                model.ConsistMsg.SPN2829 = val;

                model.MsgText = Function.AppendTextToMsgHead(symbol, this.MsgHeadLine) + text;
                return model;
            }
            catch (Exception ex)
            {
                model.MsgText = "Tranlate Error!";
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return model;
        }
    }
}
