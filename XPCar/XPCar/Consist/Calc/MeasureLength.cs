using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Consist.Calc
{
    public class MeasureLength : IMeasureResult
    {
        private List<ConsistMsg> _Data;
        private bool _LengthResult;
        private string _MsgName;
        public MeasureLength(List<ConsistMsg> lists, string msgName)
        {
            _MsgName = msgName;
            _Data = lists;
        }

        public string ResultText(string consistId)
        {
            int std = 0;
            int dataLen = 0;
            string text;
            //获取标准长度
            switch (_MsgName)
            {
                case KeyConst.CanMsgId.BHM:
                    std = 2;
                    break;
                case KeyConst.CanMsgId.BRM:
                    std = 49;
                    break;
                case KeyConst.CanMsgId.BCL:
                    std = 5;
                    break;
                case KeyConst.CanMsgId.CSD:
                case KeyConst.CanMsgId.CML:
                case KeyConst.CanMsgId.CRM:
                    std = 8;
                    break;
                case KeyConst.CanMsgId.BSM:
                case KeyConst.CanMsgId.BSD:
                case KeyConst.CanMsgId.CCS:
                case KeyConst.CanMsgId.CTS:
                    std = 7;
                    break;
                case KeyConst.CanMsgId.BST:
                case KeyConst.CanMsgId.CST:
                case KeyConst.CanMsgId.BEM:
                case KeyConst.CanMsgId.CEM:
                    std = 4;
                    break;
                case KeyConst.CanMsgId.CHM:
                    std = 3;
                    break;
                case KeyConst.CanMsgId.BCP:
                case KeyConst.CanMsgId.BCS:
                    std = 14;
                    break;
                case KeyConst.CanMsgId.BRO:
                case KeyConst.CanMsgId.CRO:
                    std = 1;
                    break;
            }

            //获取实际数据长度
            if (_MsgName == KeyConst.CanMsgId.BRM || _MsgName == KeyConst.CanMsgId.BSP 
                || _MsgName == KeyConst.CanMsgId.BCS || _MsgName == KeyConst.CanMsgId.BCP)
            {
                dataLen = GetDataLen_Special(_Data, dataLen);
            }

            else
            {
                dataLen = GetDataLen_Common(_Data, std);
                if (_MsgName == KeyConst.CanMsgId.BMT || _MsgName == KeyConst.CanMsgId.BMV)//长度不定，不作比较
                {
                    _LengthResult = true;
                    text = KeyConst.Consist.Result.Qualified;
                    return _MsgName + "长度" + KeyConst.Punctuation.Colon + dataLen + KeyConst.Punctuation.Space + text + KeyConst.Punctuation.Space;
                }
            }
              

            if (dataLen == std)
            {
                _LengthResult = true;
                text = KeyConst.Consist.Result.Qualified;
                dataLen = SpecialMutiQualifiedLen(_MsgName, std);

            }
            else
            {
                _LengthResult = false;
                text = KeyConst.Consist.Result.Unqualified;
            }
            return _MsgName + "长度" + KeyConst.Punctuation.Colon + dataLen + KeyConst.Punctuation.Space + text + KeyConst.Punctuation.Space;
        }
        private int SpecialMutiQualifiedLen(string msgName, int std)
        {
            if (msgName == KeyConst.CanMsgId.BCP)
                return 13;
            else if (msgName == KeyConst.CanMsgId.BCS)
                return 9;
            else
                return std;
        }
        public bool IsResultOk()
        {
            return _LengthResult;
        }
        public bool GetLengthResult()
        {
            return _LengthResult;
        }

        //根据TextId得到包数*7的字节长度
        private int GetDataLen_Special(List<ConsistMsg> lists, int std)
        {
            Hashtable ht = new Hashtable();
            if (lists == null || lists.Count == 0)
                return 0;

            int len = 0;
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].TextId != 0)
                {
                    int id = lists[i].TextId;
                    if (!ht.ContainsKey(id))
                    {
                        ht.Add(id, 1);
                        len = 1;
                    }
                    else
                    {
                        len++;
                        ht[id] = len;
                    }
                    //if (lists[i].MutiLength != std)
                    //    return lists[i].MutiLength;
                }
            }
            if (ht != null && ht.Count != 0)
            {
                foreach (int value in ht.Values)
                {
                    if (std != value * 7)
                        return value * 7;
                }
            }     
            return std;
        }
        private int GetDataLen_Common(List<ConsistMsg> lists, int std)
        {

            var distinct = lists.GroupBy(r => r.Dlc);
            foreach (var item in distinct)
            {
                int itemKey = Convert.ToInt32(item.Key.ToString());
                if (std != itemKey)
                    return itemKey;
                else
                    return itemKey;
            }
            return 0;
        }
   
    }
}
