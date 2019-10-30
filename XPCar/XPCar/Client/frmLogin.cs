using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPCar.Common;

namespace XPCar.Client
{
    public partial class frmLogin : Form
    {
        private string _Warning;
        public frmLogin(string warning)
        {
            InitializeComponent();
            _Warning = warning;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
#if ST_9980AP_DC
            lblLoginTitle.Text = KeyConst.WinLabel.ST9980AP;
#elif ST_9980A_DC
            lblLoginTitle.Text = KeyConst.WinLabel.ST9980A;
#elif ST_9980AP_AC
            lblLoginTitle.Text = KeyConst.WinLabel.ST9980AP_AC;
#endif

            tbMachineCode.Text = Encrypt.DeviceHelper.GetMachineCode();
            if (_Warning != "" && _Warning != "软件已注册！")
            {
                MessageBox.Show(_Warning);
            }
            else if (_Warning == "软件已注册！")
            {
                BtnResgister_Click(null, null);
                return;
            }
            lblRegState.Visible = true;
            lblRegState.Text = _Warning;
        }

        private void BtnResgister_Click(object sender, EventArgs e)
        {
            try
            {
                string machineCode = GetMachineCode();
                lblRegState.Text = GetRegisterDate(machineCode);
                
            }
            catch
            {
                lblRegState.Text = "出现错误,请联系管理员！";
            }
            lblRegState.Visible = true;
        }
        private string GetMachineCode()
        {
            string serialNo = Encrypt.TimeClass.ReadSetting("", "SerialNumber", "-1");
            string machineCode = tbMachineCode.Text;
            return machineCode;
        }
        private string GetRegisterDate(string machineCode)
        {
            string text="";
            try
            {
                string regCode = tbRegCode.Text.Substring(0, 64);
                Encrypt.Encryption encryption = new Encrypt.Encryption();
                string stdRegCode = Encrypt.Encryption.Encrypt(machineCode, Encrypt.Encryption.CRYPTO_KEY);
      
                if (regCode == stdRegCode)
                {
                    string time = tbRegCode.Text.Substring(64);

                    text = "该软件已经成功注册。" + System.Environment.NewLine;

                    string decryptTime = Encrypt.Encryption.Decrypt(time, Encrypt.Encryption.CRYPTO_KEY);
                    if (decryptTime == "99991231")
                    {
                        text += "取得永久使用权限。" + System.Environment.NewLine;
                    }
                    else
                    {
                        decryptTime = decryptTime.Substring(0, 4) + "/" + decryptTime.Substring(4, 2) + "/" + decryptTime.Substring(6, 2);
                        text += "软件试用期到" + decryptTime + System.Environment.NewLine;
                    }
                    //写入注册表
                    Encrypt.TimeClass.WriteSetting("", "SerialNumber", regCode + time);
                }
                else
                    text = "注册码与本机不一致,请联系管理员！";                
            }
            catch(Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            return text;
        }
    }
}
