﻿using System;
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
#if ST_9980AP_DC
                //ST-9980A+
                System.Diagnostics.Process.Start(root + "\\msiexec.exe", "/x {8FAC54EA-6926-4AAF-8B87-D55CD71C5178} /qr");
#elif ST_9980A_DC
                System.Diagnostics.Process.Start(root + "\\msiexec.exe", "/x {4C2B4A1E-044D-466D-B4DD-B7C9C22D00B6} /qr");
#elif ST_990_DC
                System.Diagnostics.Process.Start(root + "\\msiexec.exe", "/x {0381654C-8517-4241-BE86-61AE09276D89} /qr");
#elif ST_9980BP
                System.Diagnostics.Process.Start(root + "\\msiexec.exe", "/x {49FD6722-EF0F-473D-AE03-0C7E211E8F3B} /qr");
#endif
            }
        }
    }
}
