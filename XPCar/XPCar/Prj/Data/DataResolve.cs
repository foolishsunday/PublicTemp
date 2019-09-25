using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Prj.Model;

namespace XPCar.Prj.Data
{
    public class DataResolve
    {
        private List<CanMsgRich> _List;
        private List<CanMsg> _GridlList;
        public DataResolve()
        {
            _List = new List<CanMsgRich>();
            _GridlList = new List<CanMsg>();
        }
        public void Clear()
        {
            _List.Clear();
        }
        public void Add(List<CanMsgRich> lists)
        {
            _List.AddRange(lists);
        }
        public List<CanMsgRich> List()
        {
            return this._List;
        }
        public List<CanMsg> CanList()
        {
            _GridlList.Clear();
            if (_List != null && _List.Count > 0)
            {
                foreach (CanMsgRich rich in this._List)
                {
                    CanMsg canMsg = rich;
                    _GridlList.Add(canMsg);
                }
            }
            return _GridlList;
        }
        public List<ConsistMsg> ConsistList()
        {
            List<ConsistMsg> lists = new List<ConsistMsg>();
            foreach (CanMsgRich rich in this._List)
            {
                ConsistMsg consist = new ConsistMsg();
                consist = rich.ConsistMsg;
                lists.Add(consist);
            }
            return lists;
        }
        public void AddModel(CanMsgRich model)
        {
            _List.Add(model);
        }
        public void AddRange(List<CanMsgRich> data)
        {
            if (data != null && data.Count > 0)
            {
                _List.AddRange(data);
            }
        }
    }
}
