using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using XPCar.Database;

namespace XPCar.Prj.Controller
{
    public class ConsistController
    {
        public Hashtable ConsistMap { get; set; }
        public int ItemIndex { get; set; }
        public bool ConsistStarted { get; set; }
        public string SelectedMsgName { get; set; } //点击测试按钮后
        public string ClickMsgName { get; set; }    //未点击测试按钮，只选中
        public ConsistController()
        {
            ConsistMap = new Hashtable();
            ItemIndex = -1;
            ConsistStarted = false;
        }
        public void SetConsistMap(DbService db)
        {
            DataTable dt = db.QueryConsistItemsMap();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ConsistMap.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
            }
        }
        public int GetItemBitsNum(string itemid)
        {
            if (ConsistMap.ContainsKey(itemid))
            {
                return Convert.ToInt32(ConsistMap[itemid]);
            }
            else
                return 0;
        }
        public void Reset()
        {
            ItemIndex = -1;
        }
    }
}
