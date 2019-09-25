using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;
using XPCar.Protocol;

namespace XPCar.Prj.Data
{
    public class DataCollection : DecodeProtocol
    {
        List<byte> _RawData;
        //int _State;
        //int _Pos;
        public DataCollection()
        {
            _RawData = new List<byte>();
            //_State = 0;
            //_Pos = 0;
        }
        public void Init()
        {
            this.Clear();
        }
        public void Clear()
        {
            _RawData.Clear();
        }
        public void AddBuf(byte[] buf)
        {
            _RawData.AddRange(buf);
        }
        public void AddList(List<byte> lists)
        {
            _RawData.AddRange(lists);
        }
        public List<byte> GetList()
        {
            return this._RawData;
        }

        public List<EachFrameModel> VerifyAndPackage()
        {
            if (!VerifyProtocolLength(this._RawData))           //长度不足
            {
                return null;
            }
            List<EachFrameModel> lists = new List<EachFrameModel>();
            lists = this.VerifyProtocolFormat(ref this._RawData);   
            return lists;
        }

        public bool VerifyProtocolLength(List<byte> buf)
        {
            if (buf.Count < 12)
                return false;
            else
                return true;
        }
       
    }
}
