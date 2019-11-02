using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Protocol.Decode.Msg
{
    public class Msg_MutiPackageHead:MsgCommon
    {
        private string TestBRM = "BMS和车辆辨识报文";
        private string TestBCP = "动力蓄电池充电参数";
        private string TestBCS = "电池充电总状态";
        private string TestBMV = "单体动力蓄电池电压";
        private string TestBSP = "动力蓄电池预留报文";
        private string TestBMT = "动力蓄电池温度报文";
        private string TestUndefined = "Undefined CMD";

        private string TestEnd = "多包报文 首报文";
        private string TestCnt = "总共包数";
        public override CanMsgRich DecodeMsgData(string symbol, List<byte> content)
        {
            CanMsgRich model = new CanMsgRich();
            string text = string.Empty;
            try
            {
                switch (symbol)
                {
                    case KeyConst.CanMsgId.BCP:
                        text = TestBCP;
                        break;
                    case KeyConst.CanMsgId.BRM:
                        text = TestBRM;
                        break;
                    case KeyConst.CanMsgId.BCS:
                        text = TestBCS;
                        break;
                    case KeyConst.CanMsgId.BMV:
                        text = TestBMV;
                        break;
                    case KeyConst.CanMsgId.BSP:
                        text = TestBSP;
                        break;
                    case KeyConst.CanMsgId.BMT:
                        text = TestBMT;
                        break;
                    default:
                        text = TestUndefined;
                        break;
                }
                int cnt = Prj.Prj.MutiPackage.GetCountPlan();
                model.MsgText = Function.AppendTextToMsgHead(symbol, text) + TestEnd + KeyConst.Punctuation.Space
                    + TestCnt + KeyConst.Punctuation.Colon + cnt.ToString();
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
