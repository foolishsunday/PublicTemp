using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Msg
{
    public class Msg_MutiPackageText : MsgCommon
    {
        private string MsgHeadLine = "多包报文";
        //private string TestLastPckg = "该报文为最后一包";
        public override CanMsgRich DecodeMsgData(string symbol, List<byte> content)
        {
            CanMsgRich model = new CanMsgRich();
            string text;
            int i = 0;
            string[] arr = Function.SplitMsgData(content);
            try
            {
                //model.IsLastPackage = false;

                string sCurPckgCnt = arr[i++];
                int curPckgCnt = Convert.ToInt32(sCurPckgCnt, 16);
    
                if (curPckgCnt < Prj.Prj.MutiPackage.GetCountPlan())
                {
                    text = string.Format("该报文为第{0}包", curPckgCnt) + KeyConst.Punctuation.Space;
                }
                else
                {
                    //model.IsLastPackage = true;
                    return model;
                }
                model.MsgText = Function.AppendTextToMsgHead(symbol, MsgHeadLine)+ text;
                return model;
            }
            catch (Exception ex)
            {
                model.MsgText = "Tranlate Error!";
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return model;
            }
        }
    }
}
