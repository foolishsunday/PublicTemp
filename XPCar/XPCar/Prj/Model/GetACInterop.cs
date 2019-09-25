using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Prj.Model
{
    public class GetACInterop
    {
        /// <summary>
        /// A枪开关
        /// </summary>
        public string AGun_S { get; set; }
        /// <summary>
        /// A枪风扇控制
        /// </summary>
        public string AGun_FanCtrl { get; set; }
        /// <summary>
        /// A枪CC断开控制
        /// </summary>
        public string AGun_CCCtrl { get; set; }
        /// <summary>
        /// A枪CP断开控制
        /// </summary>
        public string AGun_CPCtrl { get; set; }
        /// <summary>
        /// A枪CP接地控制
        /// </summary>
        public string AGun_CPGround { get; set; }
        /// <summary>
        /// A枪PE断开控制
        /// </summary>
        public string AGun_PECtrl { get; set; }
        /// <summary>
        /// A枪CC电阻检测控制
        /// </summary>
        public string AGun_CCResCtrl { get; set; }
        /// <summary>
        /// A枪定时充电控制
        /// </summary>
        public string AGun_TimeChargeCtrl { get; set; }
        /// <summary>
        /// B枪开关
        /// </summary>
        public string BGun_S { get; set; }
        /// <summary>
        /// B枪风扇控制
        /// </summary>
        public string BGun_FanCtrl { get; set; }
        /// <summary>
        /// B枪CC断开控制
        /// </summary>
        public string BGun_CCCtrl { get; set; }
        /// <summary>
        /// B枪CP断开控制
        /// </summary>
        public string BGun_CPCtrl { get; set; }
        /// <summary>
        /// B枪CP接地控制
        /// </summary>
        public string BGun_CPGround { get; set; }
        /// <summary>
        /// B枪PE断开控制
        /// </summary>
        public string BGun_PECtrl { get; set; }
        /// <summary>
        /// B枪CC电阻检测控制
        /// </summary>
        public string BGun_CCResCtrl { get; set; }
        /// <summary>
        /// B枪定时充电控制
        /// </summary>
        public string BGun_TimeChargeCtrl { get; set; }

        /// <summary>
        /// 表示按键状态的二进制数据X1-X2
        /// </summary>
        public string BinaryStateX1X2 { get; set; }
        /// <summary>
        /// 表示按键状态的二进制数据X3-X4
        /// </summary>
        public string BinaryStateX3X4 { get; set; }
    }
}
