using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Controller
{
    public class ACController
    {
        /// <summary>
        /// 当前选中第几行（从0开始算起）
        /// </summary>
        public int ItemIndex { get; set; }
        /// <summary>
        /// 当前选中的测试项目
        /// </summary>
        public string ClickMsgName { get; set; }

        /// <summary>
        /// 当前选中的测试项目编号(ItemIndex+1)
        /// </summary>
        public int SelectedObjNo { get; set; }
        public ACController()
        {
            SelectedObjNo = -1;
        }
    }
}
