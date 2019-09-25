using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPCar.Client;
using XPCar.Common;

namespace XPCar
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Encrypt.Encryption en = new Encrypt.Encryption();//不能省略，否则出错
            int ret = Encrypt.TimeClass.InitReg();
            string warning = Function.ReturnRegisterWarning(ret);

            //ret = 3;
            if (ret == 0)
            {
                Application.Run(new frmMain());
            }
            else
            {
                Application.Run(new frmLogin(warning));
            }
            //Application.Run(new frmMain());
        }
    }
}
