using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XPCar.Timers;

namespace XPCar.Component
{
    public delegate void HandleCommStateImage(Image img);
    public partial class WarningLight : PictureBox
    {
        public event HandleCommStateImage ComStateImage;
        private Image _RedImg;
        private Image _GrayImg;
        private Image _GreenImg;
        private ThreadTimer _Timer;

        private Image _FlashImg;
        private int _FlashFlag;

        private bool _Enable;
        public WarningLight():base()
        {
            _Timer = new ThreadTimer(Timer_Tick);
            _GrayImg = XPCar.Properties.Resources.Ball_gray;
            _RedImg = XPCar.Properties.Resources.Ball_red;
            _GreenImg = XPCar.Properties.Resources.Ball_green;
            base.Image = _GrayImg;
            _Enable = false;
        }
        //public WarningLight(IContainer container)
        //{
        //    container.Add(this);

        //    InitializeComponent();
        //}
        //public WarningLight(IContainer container)
        //{
        //    container.Add(this);

        //    InitializeComponent();
        //}
        private void Timer_Tick(object state)
        {
            if (_Enable == false) return;

            if (_FlashFlag == 0)
            {
                _FlashFlag = 1;
                base.Image = _FlashImg;
            }
            else
            {
                _FlashFlag = 0;
                base.Image = _GrayImg;
            }
            ComStateImage(base.Image);
        }
        public void OnRed()
        {
            _Timer.Stop();
            _Enable = false;

            base.Image = _RedImg;
        }
        public void OnGreen()
        {
            _Timer.Stop();
            _Enable = false;

            base.Image = _GreenImg;
            ComStateImage(base.Image);
        }

        public void Off()
        {
            _Timer.Stop();
            _Enable = false;

            base.Image = _GrayImg;
            ComStateImage(base.Image);
        }

        public void FlashRed(int millisecond)
        {
            _FlashImg = _RedImg;

            _FlashFlag = 1;
            base.Image = _FlashImg;

            _Timer.Interval = millisecond;
            _Timer.Start();

            _Enable = true;
            ComStateImage(base.Image);
        }
        public void FlashGreen(int millisecond)
        {
            _FlashImg = _GreenImg;

            _FlashFlag = 1;
            base.Image = _FlashImg;

            _Timer.Interval = millisecond;
            _Timer.Start();

            _Enable = true;
            ComStateImage(base.Image);
        }
    }
}
