using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;
using XPCar.Protocol.Decode.Msg;

namespace XPCar.Protocol.Decode.Service
{
    public class Decode_CanMsg : DecodePackageCommon
    {
        private string _Direction = "读取";
        //private int _Dlc = 8;
        public override void DecodePackage(EachFrameModel package)
        {
            CanMsgRich canGridRich;

            try
            {
                List<byte> buf = package.Buffer;
                int dlc;
                dlc = DecodeDlc(buf);
                //dlc = 8;
                List<byte> contentBytes = new List<byte>();

                string msgId = CutMsgId(buf);
                string msgData = CutMsgData(buf, ref contentBytes);
                string flowId = Function.GetMsgFlow(msgId);    //"1CECF456" -> PACKAGE_READY

                MsgManager msgManager = new MsgManager();

                canGridRich = msgManager.DecodeMsgData(flowId, contentBytes);
                canGridRich.Direction = this._Direction;
                canGridRich.Dlc = dlc;
                //canGridRich.CreateTime = DateTime.Now;//add for 实时时间
                canGridRich.CreateTime = DecodeDatetime(buf);
                canGridRich.Id = msgId;
                canGridRich.MsgData = Function.AppendSpaceIn2Char(msgData, dlc);
                canGridRich.CreateTimestamp = canGridRich.CreateTime.ToString(KeyConst.TextFormat.Date);

                //时间增量
                if (Prj.Prj.ValueManager.IsFirstMsg()) //说明该报文为第一条报文,add for 实时时间
                {
                    if (canGridRich.ConsistMsg.MsgName != "UNDEFINED")//第一条报文，且不为非标
                    {
                        canGridRich.TimeIncrement = "0";
                        Prj.Prj.ValueManager.FirstCreateTime = canGridRich.CreateTime;
                        canGridRich.SpanTime = 0;
                    }
                }
                else
                {
                    TimeSpan span = canGridRich.CreateTime - Prj.Prj.ValueManager.PreMsgCreateTime;
                    canGridRich.TimeIncrement = span.Hours.ToString().PadLeft(2, '0') + KeyConst.Punctuation.Colon
                                        + span.Minutes.ToString().PadLeft(2, '0') + KeyConst.Punctuation.Colon
                                        + span.Seconds.ToString().PadLeft(2, '0') + KeyConst.Punctuation.Space
                                        + span.Milliseconds.ToString("f0");
                    canGridRich.SpanTime = (canGridRich.CreateTime - Prj.Prj.ValueManager.FirstCreateTime).TotalMilliseconds;

                }
                Prj.Prj.ValueManager.PreMsgCreateTime = canGridRich.CreateTime;

                canGridRich.ConsistMsg.Dlc = dlc;
                canGridRich.ConsistMsg.CreateTimestamp = canGridRich.CreateTimestamp;

                Prj.Prj.CanMsgController.AddModel(canGridRich);//加入显示buffer
                Prj.Prj.CSVManager.AddModel(canGridRich);   //加入写CSV buffer
                Prj.Prj.WaveController.AddModel(canGridRich);   //加入画时序图

                canGridRich.ConsistMsg.ObjectNo = canGridRich.ObjectNo;

                Prj.Prj.RepositoryManager.AddToStocker(canGridRich);//加入写DB buffer
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private int DecodeDlc(List<byte> buf)
        {
            byte[] dlcs = BaseConvert.CutLists(buf, 9, 2);
            string str= BaseConvert.AsciiBytes2String(dlcs);
            int dlc = BaseConvert.HexStr2Int32(str);
            return dlc;
        }
        private string CutMsgId(List<byte> buf)
        {
            byte[] idBytes = BaseConvert.CutLists(buf, 9 + ConstCmd.FrameLen.DLC_LEN, 8);   //截取byte
            string msgId = BaseConvert.AsciiBytes2String(idBytes); //byte[]转string
            return msgId;
        }
        private string CutMsgData(List<byte> buf,ref List<byte> contentBytes)
        {
            contentBytes = BaseConvert.CutLists2Lists(buf, 17 + ConstCmd.FrameLen.DLC_LEN, 16);    //截取msg内容
            string msgData = BaseConvert.AsciiBytes2String(BaseConvert.CutLists(contentBytes, 0, 16));
            return msgData;
        }
        private DateTime DecodeDatetime(List<byte> buf)//add for 实时时间
        {
            byte[] data = BaseConvert.CutLists(buf, 35, 18);   //截取时间
            string[] arr = Function.SplitMsgData(data);
            int i = 0;

            string high = arr[i++];
            string low = arr[i++];

            int year = BaseConvert.HexStr2Int32(high + low);
            if (year < 2000 || year > 2999)
                year = 2010;

            int month = BaseConvert.HexStr2Int32(arr[i++]);
            if (month < 1 || month > 12)
                month = 1;


            int day = BaseConvert.HexStr2Int32(arr[i++]);
            if (day < 1 || day > 31)
                day = 1;

            int hour = BaseConvert.HexStr2Int32(arr[i++]);
            if (hour < 0 || hour > 24)
                hour = 0;

            int minute = BaseConvert.HexStr2Int32(arr[i++]);
            if (minute < 0 || minute > 59)
                minute = 0;

            int second = BaseConvert.HexStr2Int32(arr[i++]);
            if (second < 0 || second > 59)
                second = 0;

            high = arr[i++];
            low = arr[i++];
            int ms = BaseConvert.HexStr2Int32(high + low);
            if (ms > 999 || ms < 0)
                ms = 0;


            DateTime date = new DateTime(year, month, day, hour, minute, second, ms);
            return date;

        }
    }
}
