using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Protocol
{
    public static class ConstCmd
    {
        //public const byte TYPE_REQUEST_BYTE1 = 0x30;
        //public const byte TYPE_REQUEST_BYTE2 = 0x31;

        //public const byte TYPE_REQUEST_BIT1 = 0x30;
        //public const byte TYPE_REQUEST_BIT2 = 0x32;

        //public const byte TYPE_SET_CMD1 = 0x30;
        //public const byte TYPE_SET_CMD2 = 0x33;

        //public const byte CMD_OPEN_CAN1 = 0x35;
        //public const byte CMD_OPEN_CAN2 = 0x30;

        public static class CmdType
        {
            public const string REQUEST_BYTE = "01";
            public const string REQUEST_BIT = "02";
            public const string SETTING = "03";
        }
        //发送
        public static class CmdEncode
        {
            public const string CMD_CAN = "50";     
            public const string SYS_START_STOP = "30";
            public const string CONSIST_START = "70";
            public const string BASE_DATA = "01";
            public const string ALARM_GET = "40";

            public const string DC_GET = "80";
            public const string AC_GET = "02";
            public const string HANDSHAKE_GET = "11";
            public const string CHARGE_PARA_GET = "12";
            public const string CHARGING_GET = "13";
            public const string CHARGE_STOP_GET = "14";

            public const string HANDSHAKE_SET = "31";
            public const string CHARGE_PARA_SET = "32";
            public const string CHARGING_SET = "33";
            public const string CHARGE_STOP_SET = "34";
            public const string UPGRADE = "10";
            public const string DC_SET = "80";
            public const string AC_SET = "20";
            public const string VER_GET = "03"; 
        }
        public static class CmdContent
        {
            public const string OPEN_CAN = "00000001";
            public const string CLOSE_CAN = "00000000";
            public const string SYS_START= "00000001";
            public const string SYS_STOP = "00000000";
            public const string BASE_DATA = "0000000000000000";
            public const string ALARM_GET = "00000000";

            public const string TEST_CONSIST = "0000000000000000";
            public const string HANDSHAKE = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";//110个0
            public const string CHARGE_PARA = "000000000000000000000000000000000000";//36个
            public const string CHARGING = "000000000000000000000000000000000000000000000000000000000000000000";//66个
            public const string CHARGE_STOP = "0000000000000000";//18个
            public const string UPGRADE = "00000000";
            public const string DC_GET = "0000000000000000";
            public const string AC_GET = "0000000000000000";
            public const string VER_GET = "0000000000000000";//16个
        }

        //回复
        public static class CmdAck
        {
            public const string UNDEFINED = "0000";

            public const string CAN = "4350";
            public const string SYS_START = "4330";
            public const string CONSIST = "4370";

            public const string BASE_INFO = "4101";

            public const string DC_GET = "4180";
            public const string AC_GET = "4102";
            public const string ALARM_GET = "4240";
            public const string HANDSHAKE_GET = "4111";
            public const string CHARGE_PARA_GET = "4112";
            public const string CHARGING_GET = "4113";
            public const string CHARGE_STOP_GET = "4114";
            public const string CHARGE_WRONG_GET = "4115";
            public const string AC_INTEROP_GET = "4120";


            public const string HANDSHAKE_SET = "4331";
            public const string CHARGE_PARA_SET = "4332";
            public const string CHARGING_SET = "4333";
            public const string CHARGE_STOP_SET = "4334";
            public const string CHARGE_WRONG_SET = "4335";
            public const string UPGRADE_ACK = "4310";
            public const string DC_SET = "4380";
            public const string AC_SET = "4320";//设置交流，回复

            public const string VER_GET = "4103";
        }

        //此处只为内容长度，须剪掉帧头、帧尾、校验码数量
        public static class FrameLen    
        {
            public const int DLC_LEN = 2;//加了dlc之后为2

            public const int UNDEFINED = 0;
            public const int CAN = 36 - 12 + DLC_LEN;
            public const int BASE_INFO = 46 - 12;
            public const int SYS_START = 20 - 12;

            public const int CHARGE_WRONG_GET = 46 - 12;
            public const int CHARGE_WRONG_SET = 20 - 12;
  

            public const int DC_GET = 16;
            public const int AC_GET = 136;
            public const int HANDSHAKE_GET = 22;//34
            public const int CHARGE_PARA_GET = 34;
            public const int CHARGING_GET = 24;//34
            public const int CHARGE_STOP_GET = 16;//34

            public const int HANDSHAKE_SET = 110;
            public const int CHARGE_PARA_SET = 36;
            public const int CHARGING_SET = 66;
            public const int CHARGE_STOP_SET = 18;

            public const int DC_SET = 16;
            public const int AC_SET = 16;

            public const int CONSIST = 16;
            public const int UPGRADE_ACK = 8;

            public const int ALARM_GET = 8;
            public const int AC_INTEROP_GET = 16;
            public const int VER_GET = 16;
        }

    }
}
