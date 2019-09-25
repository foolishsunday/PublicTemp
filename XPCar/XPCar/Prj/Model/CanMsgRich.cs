using System;

namespace XPCar.Prj.Model
{
    public class CanMsgRich : CanMsg
    {
        //public int ObjectNo;
        //public string Direction;
        //public DateTime CreateTime;
        //public string Id;
        //public int Dlc;
        //public string MsgData;
        //public string MsgText;

        public string Symbol;

        public DateTime CreateTime;
        public int MaxIndex;

        public ConsistMsg ConsistMsg;
        public CanMsgRich()
        {
            ConsistMsg = new ConsistMsg();
        }
    }
}
