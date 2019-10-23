using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using XPCar.Timers;
using System.Threading;
using XPCar.Common;
using System.Diagnostics;

namespace XPCar.Client
{
    public partial class frmUpgrade : UserControl
    {
        private ThreadTimer _Timer1000ms;
        private ThreadTimer _TimerError;
        public frmUpgrade()
        {
            InitializeComponent();
            Init();

        }
        public void DisposeResource()
        {
            if (_Timer1000ms != null)
                _Timer1000ms.Stop();
            if (_TimerError != null)
                _TimerError.Stop();
            Prj.Prj.TimerManager.Start();
        }
        private void Init()
        {
            this.tlpUpgrade.Dock = DockStyle.Fill;
            //Prj.Prj.UpgradeController.UpdateUpgradeState += this.HandleUpdateUpgradeState;
            InitTimer();
        }
        private void InitTimer()
        {
            _Timer1000ms = new ThreadTimer(Timer1000ms_Tick);
            _Timer1000ms.Interval = 1000;

            _TimerError = new ThreadTimer(TimerError_Tick);
            _TimerError.Interval = 1000;
        }

        private void BtnUpgrade_Click(object sender, EventArgs e)
        {
            //必须先把所有发送cmd关闭
            Prj.Prj.TimerManager.Stop();

            Action async_clear = delegate ()
            {
                rtbBin.Text = "";
                tbUpgradeState.Clear();
            };
            this.BeginInvoke(async_clear);


            if (string.IsNullOrEmpty(Prj.Prj.UpgradeController.BinPath))
            {
                Action async = delegate ()
                {
                    rtbBin.Text = "文件路径为空！请先选择正确的文件！";
                };
                this.BeginInvoke(async);
                return;
            }

            Prj.Prj.UpgradeController.SetEnableUpgradeState();
            Prj.Prj.SendProtocolManager.SendUpdgradeRequest();
            _Timer1000ms.Stop();
            _Timer1000ms.Start();

        }

        private void BtnOpenBin_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "bin文件(*.bin)|*.bin|所有文件(*.*)|*.*";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Prj.Prj.UpgradeController.BinPath = dialog.FileName;
            }
            Action async = delegate ()
            {
                tbUpgradePath.Text = Prj.Prj.UpgradeController.BinPath;
            };
            this.BeginInvoke(async);

        }
        private void DisplayBin(byte[] binchar)
        {
            if (binchar == null || binchar.Length == 0) return;

            string text = "";
            foreach (byte c in binchar)
            {
                text += c.ToString("X2");
                text += " ";
            }
            Action async = delegate ()
            {
                rtbBin.Text = text;
                tbBinLen.Text = binchar.Length.ToString();
            };
            this.BeginInvoke(async);
        }
        public void HandleUpdateUpgradeState(string state)
        {
            try
            {
                Action async = delegate ()
                {
                    this.tbUpgradeState.Text = state;
                };
                this.BeginInvoke(async);
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        private void Timer1000ms_Tick(object state)
        {
            _Timer1000ms.Cnt++;

            if (Prj.Prj.UpgradeController.IsRequestUpgrade())
            {
                Prj.Prj.UpgradeController.SetDisableUpgradeState();
                _TimerError.Start();
                if (tbUpgradeState.Text == "准备就绪")
                {
                    Thread.Sleep(200);
                    string path = Prj.Prj.UpgradeController.BinPath;
                    _Timer1000ms.Stop();
                    if (!string.IsNullOrEmpty(path))
                        UpgradingBin(path);
                    Thread.Sleep(200);
                }
            }
            if (_Timer1000ms.Cnt >= 60)
            {
                _Timer1000ms.Stop();
            }

        }
        private void UpgradingBin(string path)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);

                int len;
                byte[] binchar = new byte[] { };

                len = (int)fs.Length;   //获取bin文件长度
                binchar = br.ReadBytes(len);
                //sw.Stop();
                //long span = sw.ElapsedMilliseconds;
                Prj.Prj.SendProtocolManager.SendUpdgradeFile(binchar);
                DisplayBin(binchar);
                br.Close();
                br.Dispose();
                fs.Close();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            finally
            {
                if (br != null)
                    br.Close();
                if (fs != null)
                    fs.Close();
            }
        }
        private void UpgradeText(string text)
        {
            Action async = delegate ()
            {
                this.tbUpgradeState.Text = text;
            };
            this.BeginInvoke(async);
        }
        private void TimerError_Tick(object state)
        {
            _TimerError.Cnt++;
            string text = tbUpgradeState.Text;
            if (_TimerError.Cnt >= 30)
            {
                if (text != "升级成功" && text != "升级失败")
                {
                    text = "发生错误";
                    UpgradeText(text);
                    Prj.Prj.TimerManager.Start();
                }
                _TimerError.Stop();
            }
            if (text == "升级成功" || text == "升级失败" || text == "发生错误")
            {
                Prj.Prj.TimerManager.Start();
                _TimerError.Stop();
            }
        }
    }
}
