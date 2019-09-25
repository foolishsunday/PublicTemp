using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Uninstall
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
            //Application.Run(new Form1());
            DialogResult dr = MessageBox.Show("确认卸载产品?", "卸载产品", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                string root = System.Environment.SystemDirectory;
#if DC_TEST_9980AP
                //ST-9980A+
                System.Diagnostics.Process.Start(root + "\\msiexec.exe", "/x {8FAC54EA-6926-4AAF-8B87-D55CD71C5178} /qr");
#elif DC_TEST_9980A
                 System.Diagnostics.Process.Start(root + "\\msiexec.exe", "/x {4C2B4A1E-044D-466D-B4DD-B7C9C22D00B6} /qr");
#endif
            }
        }
    }
}
