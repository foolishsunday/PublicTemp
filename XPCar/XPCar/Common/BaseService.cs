using System;
using System.Threading;
using System.Windows.Forms;

namespace XPCar.Common
{
    public class BaseService
    {
        protected void ShowMessageBox(string text)
        {
            ThreadPool.QueueUserWorkItem(a =>
            {
                MessageBox.Show(text);
            }, null);
        }
    }
}
