CREATE TABLE TestItemsReport(
	
	ObjectNo INT NULL,
	ItemId   TEXT    PRIMARY KEY NOT NULL,
	CreateTimestamp TEXT NULL,
	ResultInView TEXT    NULL,
	Remarks TEXT    NULL,
	TestText1 TEXT    NULL,
	TestResult1 TEXT    NULL,
	TestText2 TEXT    NULL,
	TestResult2 TEXT    NULL,
	TestText3 TEXT    NULL,
	TestResult3 TEXT    NULL,
	TestText4 TEXT    NULL,
	TestResult4 TEXT    NULL,
	TestSummary TEXT    NULL
);
CREATE TABLE TestConfig(
	
	ObjectNo INT NULL,
	ItemId   TEXT    PRIMARY KEY NOT NULL,
	StartTestTime TEXT NULL

);
CREATE TABLE CanMsg(
	
	ObjectNo INTEGER NULL,
	Direction   TEXT    NULL,
	CreateTimestamp TEXT    NULL,
	TimeIncrement TEXT NULL,
	Id TEXT    NULL,
	Dlc INTEGER    NULL,
	MsgData TEXT    NULL,
	MsgText TEXT    NULL
);
alter table student add column name TEXT;


CREATE TABLE ConsistMsg(
		ObjectNo integer NULL,     
        MsgName  TEXT    NULL,
        CreateTimestamp  TEXT    NULL,
        Dlc      integer    NULL,
        SPN2560  TEXT    NULL,
        SPN3901  TEXT    NULL,
        SPN3902  TEXT    NULL,
        SPN3903  TEXT    NULL,
        SPN3904  TEXT    NULL,
        SPN3905  TEXT    NULL,
        SPN3906  TEXT    NULL,
        SPN3907  TEXT    NULL,
        SPN2829  TEXT    NULL,
        SPN2830  TEXT    NULL,

        Version  TEXT    NULL,
        SPN2601  TEXT    NULL,
        SPN3921  TEXT    NULL,
        SPN3922  TEXT    NULL,
        SPN3923  TEXT    NULL,
        SPN3924  TEXT    NULL,
        SPN3925  TEXT    NULL,
        SPN3926  TEXT    NULL,
		SPN3927  TEXT    NULL,
        SPN3090  TEXT    NULL,
        SPN3095  TEXT    NULL,
		SPN3096  TEXT    NULL,
		SPN3929  TEXT    NULL,
		MutiLength integer NULL,
		PackageId integer NULL,
		IsLastPackage integer NULL,
		TextId integer NULL
);

CREATE TABLE TestInterop(
		ObjectNo integer NULL,     
        OpName  TEXT    NULL,
		TestNumber TEXT    NULL,
		TestPurpose  TEXT    NULL,
		TestStep  TEXT    NULL,
		TestJudge  TEXT    NULL,
		TestResult TEXT NULL
        
);
CREATE TABLE TestAC(
		ObjectNo integer NULL,     
        OpName  TEXT    NULL,
		TestNumber TEXT    NULL,
		TestPurpose  TEXT    NULL,
		TestStep  TEXT    NULL,
		TestJudge  TEXT    NULL,
		TestResult TEXT NULL       
);
Insert into TestAC values(1,'连接确认测试','','','','','');
Insert into TestAC values(2,'充电准备就绪测试','','','','','');
Insert into TestAC values(3,'启动和充电阶段测试','','','','','');
Insert into TestAC values(4,'正常充电结束测试','','','','','');
Insert into TestAC values(5,'充电连接控制时序测试','','','','','');
Insert into TestAC values(6,'CC断线测试','','','','','');
Insert into TestAC values(7,'CP断线测试','','','','','');
Insert into TestAC values(8,'CP接地测试','','','','','');
Insert into TestAC values(9,'保护接地导体连续性丢失测试','','','','','');
Insert into TestAC values(10,'输出过流测试','','','','','');
Insert into TestAC values(11,'断开开关S2测试','','','','','');
Insert into TestAC values(12,'CP回路电压限值测试','','','','','');


Insert into TestItemsReport values(1, 'BP1001','','','','','','','','','','','');
Insert into TestItemsReport values(2, 'BP1002','','','','','','','','','','','');
Insert into TestItemsReport values(3, 'BP1003','','','','','','','','','','','');
Insert into TestItemsReport values(4, 'BN1001','','','','','','','','','','','');
Insert into TestItemsReport values(5, 'BN1002','','','','','','','','','','','');
Insert into TestItemsReport values(6, 'BN1003','','','','','','','','','','','');
Insert into TestItemsReport values(7, 'BN1004','','','','','','','','','','','');
Insert into TestItemsReport values(8, 'BN1005','','','','','','','','','','','');
Insert into TestItemsReport values(9, 'BN1006','','','','','','','','','','','');
Insert into TestItemsReport values(10,'BN1007','','','','','','','','','','','');
Insert into TestItemsReport values(11,'BN1008','','','','','','','','','','','');
Insert into TestItemsReport values(12,'BN1009','','','','','','','','','','','');
Insert into TestItemsReport values(13,'BN1010','','','','','','','','','','','');
Insert into TestItemsReport values(14,'BP2001','','','','','','','','','','','');
Insert into TestItemsReport values(15,'BP2002','','','','','','','','','','','');
Insert into TestItemsReport values(16,'BP2003','','','','','','','','','','','');
Insert into TestItemsReport values(17,'BN2001','','','','','','','','','','','');
Insert into TestItemsReport values(18,'BN2002','','','','','','','','','','','');
Insert into TestItemsReport values(19,'BN2003','','','','','','','','','','','');
Insert into TestItemsReport values(20,'BN2004','','','','','','','','','','','');
Insert into TestItemsReport values(21,'BN2005','','','','','','','','','','','');
Insert into TestItemsReport values(22,'BN2006','','','','','','','','','','','');
Insert into TestItemsReport values(23,'BN2007','','','','','','','','','','','');
Insert into TestItemsReport values(24,'BP3001','','','','','','','','','','','');
Insert into TestItemsReport values(25,'BP3002','','','','','','','','','','','');
Insert into TestItemsReport values(26,'BP3003','','','','','','','','','','','');
Insert into TestItemsReport values(27,'BP3004','','','','','','','','','','','');
Insert into TestItemsReport values(28,'BP3005','','','','','','','','','','','');
Insert into TestItemsReport values(29,'BN3001','','','','','','','','','','','');
Insert into TestItemsReport values(30,'BN3002','','','','','','','','','','','');
Insert into TestItemsReport values(31,'BN3003','','','','','','','','','','','');
Insert into TestItemsReport values(32,'BN3004','','','','','','','','','','','');
Insert into TestItemsReport values(33,'BN3005','','','','','','','','','','','');
Insert into TestItemsReport values(34,'BN3006','','','','','','','','','','','');
Insert into TestItemsReport values(35,'BN3007','','','','','','','','','','','');
Insert into TestItemsReport values(36,'BN3008','','','','','','','','','','','');
Insert into TestItemsReport values(37,'BP4001','','','','','','','','','','','');
Insert into TestItemsReport values(38,'BP4002','','','','','','','','','','','');
Insert into TestItemsReport values(39,'BP4003','','','','','','','','','','','');
Insert into TestItemsReport values(40,'BN4001','','','','','','','','','','','');
Insert into TestItemsReport values(41,'BN4002','','','','','','','','','','','');
Insert into TestItemsReport values(42,'BN4003','','','','','','','','','','','');



public const string BP1001 ="BP1001";
public const string BP1002 ="BP1002";
public const string BP1003 ="BP1003";
public const string BN1001 ="BN1001";
public const string BN1002 ="BN1002";
public const string BN1003 ="BN1003";
public const string BN1004 ="BN1004";
public const string BN1005 ="BN1005";
public const string BN1006 ="BN1006";
public const string BN1007 ="BN1007";
public const string BN1008 ="BN1008";
public const string BN1009 ="BN1009";
public const string BN1010 ="BN1010";
public const string BP2001 ="BP2001";
public const string BP2002 ="BP2002";
public const string BP2003 ="BP2003";
public const string BN2001 ="BN2001";
public const string BN2002 ="BN2002";
public const string BN2003 ="BN2003";
public const string BN2004 ="BN2004";
public const string BN2005 ="BN2005";
public const string BN2006 ="BN2006";
public const string BN2007 ="BN2007";
public const string BP3001 ="BP3001";
public const string BP3002 ="BP3002";
public const string BP3003 ="BP3003";
public const string BP3004 ="BP3004";
public const string BP3005 ="BP3005";
public const string BN3001 ="BN3001";
public const string BN3002 ="BN3002";
public const string BN3003 ="BN3003";
public const string BN3004 ="BN3004";
public const string BN3005 ="BN3005";
public const string BN3006 ="BN3006";
public const string BN3007 ="BN3007";
public const string BN3008 ="BN3008";
public const string BP4001 ="BP4001";
public const string BP4002 ="BP4002";
public const string BP4003 ="BP4003";
public const string BN4001 ="BN4001";
public const string BN4002 ="BN4002";
public const string BN4003 ="BN4003";


Insert into TestConfig values(1, 'DP1001','');
Insert into TestConfig values(2, 'DP1002','');
Insert into TestConfig values(3, 'DP1003','');
Insert into TestConfig values(4, 'DN1001','');
Insert into TestConfig values(5, 'DN1002','');
Insert into TestConfig values(6, 'DN1003','');
Insert into TestConfig values(7, 'DN1004','');
Insert into TestConfig values(8, 'DP2001','');
Insert into TestConfig values(9, 'DP2002','');
Insert into TestConfig values(10,'DP2003','');
Insert into TestConfig values(11,'DN2001','');
Insert into TestConfig values(12,'DN2002','');
Insert into TestConfig values(13,'DN2003','');
Insert into TestConfig values(14,'DN2004','');
Insert into TestConfig values(15,'DN2005','');
Insert into TestConfig values(16,'DN2006','');
Insert into TestConfig values(17,'DN2007','');
Insert into TestConfig values(18,'DN2008','');
Insert into TestConfig values(19,'DN2009','');
Insert into TestConfig values(20,'DN2010','');
Insert into TestConfig values(21,'DP3001','');
Insert into TestConfig values(22,'DP3002','');
Insert into TestConfig values(23,'DP3003','');
Insert into TestConfig values(24,'DP3004','');
Insert into TestConfig values(25,'DP3005','');
Insert into TestConfig values(26,'DP3006','');
Insert into TestConfig values(27,'DP3007','');
Insert into TestConfig values(28,'DN3001','');
Insert into TestConfig values(29,'DN3002','');
Insert into TestConfig values(30,'DN3003','');
Insert into TestConfig values(31,'DN3004','');
Insert into TestConfig values(32,'DN3005','');
Insert into TestConfig values(33,'DN3006','');
Insert into TestConfig values(34,'DN3007','');
Insert into TestConfig values(35,'DN3008','');
Insert into TestConfig values(36,'DN3009','');
Insert into TestConfig values(37,'DN3010','');
Insert into TestConfig values(38,'DP4001','');
Insert into TestConfig values(39,'DP4002','');
Insert into TestConfig values(40,'DN4001','');
Insert into TestConfig values(41,'DN4002','');
Insert into TestConfig values(42,'DN4003','');
Insert into TestConfig values(41,'DN4004','');


select * from ConsistMsg where CreateTimestamp between '20190715 10:05:14 110' and '20190715 10:05:14 204'

Insert into TestItemsReport values(1, 'DP1001','','','','','','','','','','','','');
Insert into TestItemsReport values(2, 'DP1002','','','','','','','','','','','','');
Insert into TestItemsReport values(3, 'DP1003','','','','','','','','','','','','');
Insert into TestItemsReport values(4, 'DN1001','','','','','','','','','','','','');
Insert into TestItemsReport values(5, 'DN1002','','','','','','','','','','','','');
Insert into TestItemsReport values(6, 'DN1003','','','','','','','','','','','','');
Insert into TestItemsReport values(7, 'DN1004','','','','','','','','','','','','');
Insert into TestItemsReport values(8, 'DP2001','','','','','','','','','','','','');
Insert into TestItemsReport values(9, 'DP2002','','','','','','','','','','','','');
Insert into TestItemsReport values(10,'DP2003','','','','','','','','','','','','');
Insert into TestItemsReport values(11,'DN2001','','','','','','','','','','','','');
Insert into TestItemsReport values(12,'DN2002','','','','','','','','','','','','');
Insert into TestItemsReport values(13,'DN2003','','','','','','','','','','','','');
Insert into TestItemsReport values(14,'DN2004','','','','','','','','','','','','');
Insert into TestItemsReport values(15,'DN2005','','','','','','','','','','','','');
Insert into TestItemsReport values(16,'DN2006','','','','','','','','','','','','');
Insert into TestItemsReport values(17,'DN2007','','','','','','','','','','','','');
Insert into TestItemsReport values(18,'DN2008','','','','','','','','','','','','');
Insert into TestItemsReport values(19,'DN2009','','','','','','','','','','','','');
Insert into TestItemsReport values(20,'DN2010','','','','','','','','','','','','');
Insert into TestItemsReport values(21,'DP3001','','','','','','','','','','','','');
Insert into TestItemsReport values(22,'DP3002','','','','','','','','','','','','');
Insert into TestItemsReport values(23,'DP3003','','','','','','','','','','','','');
Insert into TestItemsReport values(24,'DP3004','','','','','','','','','','','','');
Insert into TestItemsReport values(25,'DP3005','','','','','','','','','','','','');
Insert into TestItemsReport values(26,'DP3006','','','','','','','','','','','','');
Insert into TestItemsReport values(27,'DP3007','','','','','','','','','','','','');
Insert into TestItemsReport values(28,'DN3001','','','','','','','','','','','','');
Insert into TestItemsReport values(29,'DN3002','','','','','','','','','','','','');
Insert into TestItemsReport values(30,'DN3003','','','','','','','','','','','','');
Insert into TestItemsReport values(31,'DN3004','','','','','','','','','','','','');
Insert into TestItemsReport values(32,'DN3005','','','','','','','','','','','','');
Insert into TestItemsReport values(33,'DN3006','','','','','','','','','','','','');
Insert into TestItemsReport values(34,'DN3007','','','','','','','','','','','','');
Insert into TestItemsReport values(35,'DN3008','','','','','','','','','','','','');
Insert into TestItemsReport values(36,'DN3009','','','','','','','','','','','','');
Insert into TestItemsReport values(37,'DN3010','','','','','','','','','','','','');
Insert into TestItemsReport values(38,'DP4001','','','','','','','','','','','','');
Insert into TestItemsReport values(39,'DP4002','','','','','','','','','','','','');
Insert into TestItemsReport values(40,'DN4001','','','','','','','','','','','','');
Insert into TestItemsReport values(41,'DN4002','','','','','','','','','','','','');
Insert into TestItemsReport values(42,'DN4003','','','','','','','','','','','','');
Insert into TestItemsReport values(43,'DN4004','','','','','','','','','','','','');

                public const string DP1001= "DP1001";
                public const string DP1002= "DP1002";
                public const string DP1003= "DP1003";
                public const string DN1001= "DN1001";
                public const string DN1002= "DN1002";
                public const string DN1003= "DN1003";
                public const string DN1004= "DN1004";
                public const string DP2001= "DP2001";
                public const string DP2002= "DP2002";
                public const string DP2003= "DP2003";
                public const string DN2001= "DN2001";
                public const string DN2002= "DN2002";
                public const string DN2003= "DN2003";
                public const string DN2004= "DN2004";
                public const string DN2005= "DN2005";
                public const string DN2006= "DN2006";
                public const string DN2007= "DN2007";
                public const string DN2008= "DN2008";
                public const string DN2009= "DN2009";
                public const string DN2010= "DN2010";
                public const string DP3001= "DP3001";
                public const string DP3002= "DP3002";
                public const string DP3003= "DP3003";
                public const string DP3004= "DP3004";
                public const string DP3005= "DP3005";
                public const string DP3006= "DP3006";
                public const string DP3007= "DP3007";
                public const string DN3001= "DN3001";
                public const string DN3002= "DN3002";
                public const string DN3003= "DN3003";
                public const string DN3004= "DN3004";
                public const string DN3005= "DN3005";
                public const string DN3006= "DN3006";
                public const string DN3007= "DN3007";
                public const string DN3008= "DN3008";
                public const string DN3009= "DN3009";
                public const string DN3010= "DN3010";
                public const string DP4001= "DP4001";
                public const string DP4002= "DP4002";
                public const string DN4001= "DN4001";
                public const string DN4002= "DN4002";
                public const string DN4003= "DN4003";
                public const string DN4004= "DN4004";

Insert into TestInterop values(1,'充电模式和连接方式检查','D0.0001或A1.0001或I1.0001','检查所采用的充电模式和连接方式是否符合要求','----供电设备采用的充电模式应符合GB/T 18487.1—2015中5.1规定的对应的电动汽车充电模式使用条件;
----充电机应为连接方式C(含连接方式C下的电缆组件);
----交流充电桩应为连接方式A或连接方式B或连接方式C(含连接方式C下的电缆组件);
----缆上控制与保护装置应为连接方式B(带有功能盒的电缆组件)','车辆插座与车辆插头应能正常连接,不产生干涉','');
Insert into TestInterop values(2,'接口结构尺寸复核','C0.0001(车辆插头)或C0.0002(车辆插座)或C1.0001(车辆插头)或C1.0002(车辆插座)或C1.0003(供电插头)或C1.0004(供电插座)','检查充电接口的结构尺寸是否在允许公差范围内。','a)使用参考附录B规定的专用量规、分度值为0.02 mm的游标卡尺或类似度量仪器分别对直流充电接口(车辆插头、车辆插座)、交流充电接口(车辆插头、车辆插座、供电插头、供电插座)的关键尺寸进行检查;
b)如使用参考附录B规定的专用量规进行测试.其插入力应不大于GB/T 20234.1--2015中6.4规定的最大拔出力。所有量规的粗糙度全部为0.8,硬度为HRC58~62,量规的平行度、垂直度和对称度等形位公差按GB/T 1184--1996中规定公差H级。','--直流充电接口车辆插头、车辆插座)的结构尺寸应符合GB/T 20234.3--2015 附录A的规定;
--交流充电接口(车辆插头、车辆插座、供电插头、供电插座)的结构尺寸应符合GB/T20234.2--2015附录A的规定。','');
Insert into TestInterop values(3,'接头空间尺寸复核','C0.0101(车辆插头)或C1.0101(车辆插头)或C1.0103(供电插头)','检查车辆插头或供电插头的正常操作空间是否符合要求。','a)使用三坐标测试仪或类似度量仪器分别对直流充电车辆插头、交流充电车辆插头、交流充电供电插头的外围轮廓进行检查;
b)或者使用符合 GB/T 20234.3--2015 附录C规定的最大外围轮廓尺寸的模具对直流充电车辆插头进行检查;使用符合GB/T 20234.2--2015附录C规定的最大外围轮廓尺寸的模具分别对交流充电车辆插头、交流充电供电插头进行检查。','--直流充电车辆插头的外围轮廓尺寸应符合GB/T 20234.3--2015附录C的规定;
--交流充电车辆插头、交流充电供电插头的外围轮廓尺寸应符合GB/T 20234.2--2015附录C的规定。','');
Insert into TestInterop values(4,'插座空间尺寸复核','C1.0104(供电插座)','检查交流充电供电插座的正常操作空间是否符合要求。','使用符合GB/T 20234.2--2015 附录C规定的最大外围轮廓尺寸的标准插头对交流充电供电插座进行检查。','交流充电供电插座与交流充电供电插头应能正常连接，不产生干涉。','');
Insert into TestInterop values(5,'连接确认测试','D0.1001','检查充电机是否能通过测量检测点1的电E值判断车辆插头与车辆插座的连接状态并进人对应的充电状态;通过测量检测点2的电压值.判断车辆插头内等效电阻R3是否正常。','a)状态0:车辆插头未插人车辆插座时，检查该阶段检测点1的电压值和充电状态;
b)状态1/状态2:将车辆插头插入车辆插座中，检查该阶段检测点1的电压值和充电状态;
c)状态3:车辆插头与车辆插座完全连接后，检查该阶段检测点1的电压值、检测点2的电压值、充电状态;
d)检查该阶段车辆接口锁止状态。','--车辆接口连接确认应符合GB/T 18487.1--2015中B.3.2的规定;
--在车辆接口连接过程中,检测点1的电压值及充电状态应符合表2的规定;
--在车辆接口完全连接后,检测点2的电压值应符合表2的规定,即等效电阻R3正常:在车辆接口完全连接后绝缘检测输出电压前,车辆插头电子锁应可靠锁止','');
Insert into TestInterop values(6,'自检阶段测试','D0.2001','检查充电机的自检阶段是否正常。','a)绝缘检测开始前,分别模拟正常的电池嘴电压(K1 和K2外侧电压<10 V)、不正常的电池端电压(K1和K2外侧电压≥10 V),进行步骤b)至步骤g);
b)分别模拟车辆通信握手报文内的最高允许充电总电压在充电机输出电压范围内、超过充电机输出电压范围上限值,低于充电机输出电压范围下限值;
c)检查该阶段K3和K4状态、K1和K2状态,测量车辆接口的低压辅助供电回路的电压值和电流值;
d)测量绝缘检测时稳定输出后充电直流回路的电压值;
e)绝缘检测完成后,检查从稳定输出的绝缘电压开始下降的变化时刻(或泄放投切开关闭合时刻)到车辆接口电压降至 60V DC以下的时间、K1和K2状态;
f)检查该阶段通信状态;
g)检查该阶段车辆接口锁止状态。','--绝缘检测开始前，当检测到不正常的电池端电压时充电机应不允许充电;
--当车辆通信握手报文内的最高允许充电总电压低于充电机输出电压范围下限值时，充电机应不允许充电;
--充电机自检阶段K1和K2、K3和K4状态变化应符合GB/T 18487.1--2015 中B.3.3的规定，且充电机先输出稳定的绝缘检测电压值后,再闭合K1和K2进行绝缘检测;
--绝缘检测的输出电压应为车辆通信握手报文内的最高允许充电总电压和充电机额定电压二者中的较小值;
--充电机低压辅助供电回路的电压值和电流值应符合GB/T 18487.1--2015中B.1 的规定:
--绝缘检测完成后,泄放过程应符合GB/T 18487.1--2015中B.4.2的规定;
--该阶段通信状态应符合GBT 18487.1- 2015 中B.6和GB/T 27930--2015 中对应阶段的规定;
--该阶段车辆插头电子锁应可靠锁止。','');
Insert into TestInterop values(7,'充电准备就绪测试','D0.3001','检查充电机的充电准备就绪是否正常。','a)分别模拟正常的车辆端电池电压(接触器外端电压与通信报文电池电压误差范围≤±5%且在充电机正常输出电压范围内)、非正常车辆端电池电压(接触器外端电压与通信报文电池电压误差范围>±5%和/或不在充电机正常输出电压范围内)，检查该阶段K1和K2状态、充电状态;
b)检查该阶段通信状态;
c)检查该阶段车辆接口锁止状态。','--当检测到车辆端电池电压不正常时,充电机应不允许充电;
--充电机充电准备就绪应符合GB/T184871--2015中B.3.4的规定，且充电机应在其输出电压比接触器外端电压低(1V~10V)时闭合K1和K2;
--该阶段通信状态应符合GB/T 18487.1- 2015中B.6和GB/T 27930--2015 中对应阶段的规定;
--该阶段车辆插头电子锁应可靠锁止','');
Insert into TestInterop values(8,'充电阶段测试','D0.4001','在充电过程中，检查充电机是否能根据电池充电需求参数实时调整充电电压和充电电流。','a)充电过程中，利用车辆BMS模拟软件发送“电池充电需求”报文，检查该阶段充电状态;
b)充电过程中、按照6.3.5.1、6.3.5.2、6.3.5.3中的规定分别进行输出电压控制误差测试、输出电流控制误差测试、输出电流调整时问测试;
c)检查该阶段通信状态;
d)检查该阶段车辆接口锁止状态。','--充电机充电阶段应符合GB/T 18487.1--2015中B.3.5的规定;
--充电过程中，输出电压控制误差、输出电流控制误差输出电流调整时间分别应符合6.3.5.1、6.3.5.2、6.3.5.3的规定;
--该阶段通信状态应符合GB/T 18487.1--2015 中B.6和GB/T 27930--2015 中对应阶段的规定;
--该阶段车辆插头电子锁应可靠锁止。','');
Insert into TestInterop values(9,'正常充电结束测试','D0.5001','检查充电机在满足充电结束条件或收到充电中止报文时的充电结束是否正常。','a)主动中止充电测试:
  1)在正常充电过程中，对充电机实施停止充电指令.检查该阶段充电状态、KI和K2状态、
K3和K4状态;
  2)停止充电时,按照6.3.5.4的规定进行输出电流停止速率测试;
  3)充电结束,检查K1 和K2的状态,并记录从泄放投切开关闭合的时刻到K1和K2前端电
压降至60VDC以下的时间;
  4)检查该阶段通信状态;
  5)检查该阶段车辆接口锁止状态。
b)被动中止充电测试:
  1)在正常充电过程中,利用车辆BMS模拟软件发送"BMS中止充电”报文和"BMS统计数据"报文,检查该阶段充电状态、K1和K2状态、K3和K4状态;
  2)停止充电时,按照6.3.5.4的规定进行输出电流停止速率测试;
  3)充电结束,检查K1和K2的状态,并记录从泄放投切开关闭合的时刻到K1和K2前端电压降至60V DC以下的时间;
  4)检查该阶段通信状态;
  5)检查该阶段车辆接口锁止状态。','--充电机正常条件下充电结束应符合GB/T 18487.1--2015中B.3.6的规定;
--停止充电时,输出电流停止速率应符合6.3.5.4的规定;
--充电结束后,泄放过程应符合GB/T 18487.1--2015 中B.4.2的规定;
--该阶段通信状态应符合 GB/T 18487.1--2015中B.6和GB/T 27930--2015中对应阶段的规定,中止充电报文中的结東充电原因应符合实际动作情况;
--充电结束后,达到解锁条件,车辆插头电子锁应能正确解锁。','');
Insert into TestInterop values(10,'充电连接控制时序测试','D0.6001','检查充电机的充电连接控制过程和间隔时间是否满足要求','利用车辆BMS模拟软件与被测充电机进行通信,模拟车辆接口连接状态K5和K6状态,电池状态等检查充电连接控制过程中检测点的电压值、K1和K2状态、K3和K4状态、充电状态、通信状态、车辆接口锁止状态、充电状态转换的间隔时间。','充电机充电连接控制时序和充电状态流程应符合GB/T 18187.1--2015 中B.5的规定，通信状态应符合GB/T 18487.1--2015中B.6和GB/T 27930--2015中对应阶段的规定。','');
Insert into TestInterop values(11,'通信中断测试','D0.4501','在充电过程中，检查充电机在通信超时时是否能停止充电，是否能进行三次握手辨识阶段的连接且在重新连接成功后是否能正常充电。','a)保持通信故障测试:
  1)在正常充电过程中(除了充电结束阶段).模拟通信超时(采用如通信线S+断线、通信线S断线、通信线S+和S之间短路、车辆BMS模拟软件停止发送报文等故障方式中的一种)。检查该阶段通信状态、充电状态、K1和K2状态.K3和K4状态、车辆接口锁止状态;
  2)保持通信故障状态，检查充电机是否能进行三次握手辨识阶段的连接、该阶段充电状态、K1和K2状态、K3和K4状态、车辆接口锁止状态。
b)重新连接响应测试:
  1)在正常充电过程中(除了充电结束阶段),模拟通信超时，检查该阶段通信状态、充电状态、K1和K2状态、K3和K4状态、车辆接口锁止状态;
  2)当检测到被测充电机进人握手辨识阶段时，利用车辆BMS模拟软件与其正常通信，检查重新连接后的通信状态、充电状态,K1和K2状态、K3和K4状态、车辆接口锁止状态;通信中断(重新连接发生三次通信超时)时，检查该阶段通信状态、充电状态、K1和K2状态、K3和K4状态、车辆接口锁止状态。
注:只在充电阶段通信超时/中断时.检查KI和K2状态。','--充电中出现通信超时或通信中断.充电机中止充电过程应符合GB/T 18487.1--2015 中B.3.7.3的规定;
--充电机发送错误报文中的超时报文类型应符合实际动作情况，且有告警提示:
--当重新连接(握手辨识阶段)且与车辆匹配成功后，充电机应能I确进人充电阶段;通信中断后，达到解锁条件，车辆插头电子锁应能正确解锁;
--通信中断后.当充电机再次充电时，应重新插拔充电连接装置。','');
Insert into TestInterop values(12,'开关S断开测试','D0.4502','在充电过程中，检查充电机在开关S断开时是香能停止充电。','a)使电子锁失效后进行测试;
b)在正常充电过程中，模拟开关S由闭合变为断开,检查该阶段通信状态、充电状态、K1和K2状态。','--充电中出现该故障，充电机中止充电过程应符合GB/T 18487.1--2015 中B.3.7.4的规定
--充电机发送中止充电报文中的结束充电原因应符合实际动作情况,且有告警提示。','');
Insert into TestInterop values(13,'车辆接口断开测试','D0.4503','在充电过程中，检查充电机在车辆接口断开时是否能停止充电。','在正常充电过程中，模拟车辆接口断开，即车辆接口CC1断线检查该阶段通信状态、充电状态、K1和K2状态、K3和K4状态、车辆接口锁止状态。','--充电中出现该故障，充电机应在100 ms内发送中止充电报文并断开K1和K2.K3和K4应在充电机发完统计报文和收到车辆统计报文之后才可断开;
--充电机发送中止充电报文中的结束充电原因应符合实际动作情况，且有告警提示;充电结束后,达到解锁条件，车辆插头电子锁应能正确解锁','');
Insert into TestInterop values(14,'输出电压超过车辆允许值测试','D0.4504','在充电过程中，检查充电机输出电压大手车辆最高允许充电总电压时是否能停止无电。','在正常充电过程中，使充电直流回路电压高于车辆最高允许充电总电压，检查该阶段通信状态、充电状态、K1和K2状态,K3和K4状态、车辆接口锁止状态。','--充电中出现该故障，充电机中止充电过程应符合GB/T 18487.1--2015中B.3.7.6的规定;
--充电机发送中止充电报文中的结束充电原因应符合实际动作情况，且有告警提示;
--充电结束后.达到解锁条件.车辆插头电子锁应能正确解锁。','');
Insert into TestInterop values(15,'绝缘故障测试','D0.2501','检查充电前充电机检测到绝缘水平下降至要求值以下时是否允许充电。','a)在绝缘检测前, 选择如下测试电阻Rt(使用的测试电阻的精度至少为±3%)，分别在充电直流回路DC+与PE之间或DC-与PE之间进行非对称绝缘测试、DC+与PE之间和DC-与PE之间进行对称绝缘测试，测试电压为充电机的额定输出电压;
  ●设置 100 Ω/V< Rt≤500 Ω/V.检查该阶段是否有绝缘异常提示,是否允许充电;
  ●设置 Rt≤100 Ω/V.检查该阶段是否有绝缘故障告警,是否允许充电;
b)绝缘检测完成后.检查泄放过程中充电接口电压降到60V DC以下的时间,KI和K2状态;
c)检查该阶段车辆接口锁止状态。','--充电机绝缘检测应符合GB/T 18487.1--2015中B.4.1和B.4.2的规定;
--绝缘检测完成后，泄放过程应符合GB/T 18487.1--2015 中B.4.2的规定:
--当绝缘故障时，达到解锁条件，车辆插头电子锁应能正确解锁。','');
Insert into TestInterop values(16,'保护接地导体连续性丢失测试','D0.4505','在充电过程中，检查充电机在失去保护接地导体电气连续性时是否能停止充电。','在正常充电过程中,模拟充电机保护接地导体电气连续性丢失(不含车辆接口内PE断针),检查该阶段充电状态、K1和K2状态、车辆接口锁止状态。','--充电中出现该故障,充电机中止充电过程应符合GB/T 18487.1--2015 中5.2.1.2的规定;
--充电机发送中止充电报文中的结束充电原因应符合实际动作情况,且有告警提示;
--充电结束后,达到解锁条件,车辆插头电子锁应能正确解锁。','');
Insert into TestInterop values(17,'其他充电故障测试','D0.4506','在充电过程中,检查充电机在出现不能维续充电故障或交流电源停电时是否能停止充电。','a)在正常充电过程中分别模拟出现不能继续充电故障(根据制造商提供的故障声明类型，参见附录C)和交流电源停电,检查该阶段通信状态、充电状态、KI和K2状态、K3和K4状态、车辆接口锁止状态;
b)交流电源停电测试结束后,保持充电用连接装置处于完全连接状态,恢复对被测充电机的交流供电检查该阶段通信状态、充电状态、K1和K2状态、K3和K4状态、车辆接口锁止状态。','--充电中出现不能继续充电故障时,充电机应在100 ms内发送中止充电报文并断开K1和K2,K3和K4应在充电机发完统计报文和收到车辆统计报文之后才可断开;充电机发送中止充电报文中的结束充电原因应符合实际动作情况,且有告警提示;
--充电中发生交流电源停电时,充电机中止充电过程应符合GB/T 18487.1--2015 中B.4.3的规定.恢复供电后充电机应不能继续本次充电且不能发送停电前的充电阶段报文;充电结束后,达到解锁条件,车辆插头电子锁应能正确解锁。','');
Insert into TestInterop values(18,'输出电压控制误差测试','D0.4101','检查充电机输出电压是否满足车辆充电需求。','a)充电机设置在恒压状态下运行,在正常充电过程中,利用车辆BMS模拟软件发送的“电池充电需求”,设置充电电压需求值U0在充电机输出电压上限、下限范围内，稳定输出后利用测试仪器分别测量实际输出电压UM;
b)测得的输出电压控制误差按式(1)计算:
   ΔU=UM - U0 ·······(1)式中:
U0 -- BMS设定的充电电压需求值;
UM--充电机实际输出电压测量值;
ΔU--充电机输出电压控制误差;','输出电压控制误差应符合NB/T 33001中输出电压误差的规定。','');
Insert into TestInterop values(19,'输出电流控制误差测试','D0.4102','检查充电机输出电流是否满足车辆充电需求。','a) 充电机设置在恒流状态下运行，在正常充电过程中，利用车辆BMS模拟软件发送的“电池充电需求”，设置充电电流需求值I0,在被测充电机输出电流上限、下限范围内，稳定输出后利用测试仪器分别测量实际输出电流IM;
b) 测得的输出电流控制误差按式(2)计算:
  ΔI=IM - I0 ·······2)式中:
  I0--BMS设定的充电电流需求值;
  IM--充电机实际输出电流测量值;
  ΔI--充电机输出电流控制误差。','输出电流控制误差应符合NB/T33001中输出电流误差的规定。','');
Insert into TestInterop values(20,'输出电流调整时间测试','D0.4103','检查充电机是否能在规定时间内响应BMS充电电流需求','a)充电机设置在恒流状态下运行，在正常充电过程中。利用车辆BMS模拟软件发送的“电池充电需求",设置充电电流需求值I在被测充电机输出电流上限、下限范围内，当BMS发送的充电电流需求值从I0调整至目标值IN时，见图4.利用测试仪器测量从BMS开始发送充电电流需求值IN的时刻至实际电流输出月标值的间隔时间Td;
b)调整充电电压在被测充电机输出电压上限、下限范围内，重复以上步骤;
c)输出电流调整时间应满足式(3):
  Td≤|IN – I0|/dImin ·······3)式中:
IN--BMS设定的充电电流需求月标值;
  I0--BMS设定的充电电流需求 当前值:
  dImin--最小充电速率,20A/s;
  Td--充电机输出电流调整时间。','--输出电流调整时间应不超过表3的要求;
--输出电流目标值的控制误差应符合6.3.5.2的规定。','');
Insert into TestInterop values(21,'输出电流停止速率测试','D0.5101','检查充电机在满足充电结束条件或收到充电中止报文时输出电流停止速率。','a) 主动中止充电测试:
  1)在正常充电过程中,主动实施停止充电指令,记录充电机从稳定输出的电流开始下降的变化时刻Ts,并利用测试仪器测量当前实际输出电流值;
  2)充电结束过程,记录直流输出电流降至5 A的时刻Ts。计算输出电流停止速率。
b)被动中止充电测试:
  1)在正常充电过程中，利用车辆BMS模拟软件发送"BMS中止充电报文”，记录当前时刻Ts，并利用测试仪器测量实际输出电流值;
  2)充电结束过程、记录直流输出电流降至5 A的时刻Ts,计算输出电流停止速率。','输出电流停止速率应不小于100 A/s。','');
Insert into TestInterop values(22,'冲击电流测试','D0.3101','在充电准备就绪阶段，检查充电机在闭合K1和K2时，从车辆到充电机、或者充电机到车辆的冲击电流是否满足要求。','在充电准备就绪阶段时，利用车辆BMS模拟软件与其正常通信模拟正常的车辆端电池电压并闭合K5和K6,利用测量仪器测量被测充电机在闭合Kl和K2时，从车辆到充电机、或者充电机到车辆产生的冲击电流。','冲击电流应符合GB/T 18487.1--2015 中9.7的规定。','');
Insert into TestInterop values(23,'控制导引电压限值测试','D0.6002','检查充电机对检测点1的电压值的判断和响应是否正确。','a)限值内测试: 
  1)车辆接口完全连接后，通过调整车辆控制器模拟盒内等效电阻R4，使检测点1的电压值在正常充电范围(见表2.即[3.65V, 4.37V])内,启动充电检查该阶段通信状态、充电状态、K1和K2状态;
  2)在正常充电过程中,通过调整车辆控制器模拟盒内等效电阻R4,使检测点1的电压值在正常充电范围(见表2.即[3.65V, 4.37V])内,检查该阶段通信状态、充电状态、K1和K2状态。
b)超限值测试:
  1)车辆接口完全连接后,通过调整车辆控制器模拟盒内等效电阻R4,使检测点1的电压值超过标称值误差范围[见表2.即(0V, 3.2V)或(4.8V, +∞V)],启动充电，检查该阶段通信状态、充电状态、K1和K2状态;
  2)在正常充电过程中,通过调整车辆控制器模拟盒内等效电阻R4,使检测点1的电压值超过标称值误差范围[见表2,即(0V, 3.2 V)或(4.8V, +∞V)],检查该阶段通信状态、充电状态、K1和K2状态。
c)车端电阻最值测试:车辆接口完全连接后，将车辆控制器模拟盒内等效电阻R4分别设置在GB/T 18487.1--2015中表B.1规定的最大值和最小值,启动充电检查该阶段通信状态、充电状态、K1和K2状态。','--在充电前或充电过程中,当检测点1的电压值在正常充电范围内时,充电机应允许充电或正常充电;
--在充电前或充电过程中,当检测点1的电压值超过标称值误差范围时,充电机应不允许充电或停止充电;
--充电机发送中止充电报文中的结束充电原因应符合实际动作情况,且有告警提示。','');


/***********************************************************************************************************/
/***********************************************************************************************************/
/***********************************************************************************************************/
/***********************************************************************************************************/
/***********************************************************************************************************/
Insert into TestInterop values(1,'充电连接方式和检查','D0.0001','检查所采用的充电模式和连接方式是否符合要求。','通过目测进行检查。','——充电机应为连接方式C（含连接方式C下的电缆组件）；','');
Insert into TestInterop values(2,'连接确认测试','D0.1001','检查充电机是否能通过测量检测点1的电压值判断车辆插头与车辆插座的连接状态，并进入对应的充电状态；通过测量检测点2的电压值，检查车辆插头内等效电阻R3是否正确。','a）状态0：车辆插头未插入车辆插座时，检查检测点1的电压值和充电状态；
b）状态1/状态2：将车辆插头插入车辆插座中，检查检测点1的电压值和充电状态；
c）状态3：车辆插头与车辆插座完全连接后，检查检测点1的电压值、检测点2的电压值、充电状态；
d）检查该阶段车辆接口锁止状态。','——状态0：检测点1电压6±0.8V、检测点2电压12±0.8V、开关S闭合、充电接口断开、电子锁断开、不可充电；
——状态1：检测点1电压12±0.8V、检测点2电压12±0.8V、开关S断开、充电接口断开、电子锁断开、不可充电；
——状态2：检测点1电压6±0.8V、检测点2电压6±0.8V、开关S断开、充电接口连接中、电子锁断开、不可充电；
——状态3：检测点1电压4±0.8V、检测点2电压6±0.8V、开关S闭合、充电接口完全连接、电子锁闭合、可充电。','');
Insert into TestInterop values(3,'自检阶段测试','D0.2001','检查充电机的自检阶段是否正常。','a）绝缘检测开始前，分别模拟正常的电池端电压（K1和K2外侧电压<10V）、不正常的电池端电压（K1和K2外侧电压≥10V），进行步骤b）至步骤g）；
b）分别模拟车辆通信握手报文内的最高允许充电总电压在充电机输出电压范围内、超过充电机输出电压范围上限值、低于充电机输出电压范围下限值；
c）检查该阶段K3和K4状态、K1和K2状态，测量辅助供电回路的电压值和电流值；
d）测量绝缘检测时稳定输出后充电直流回路的电压值；
e）绝缘检测完成后，检查泄放过程中充电接口电压降到60V DC以下的时间、K1和K2状态；
f）检查该阶段通信状态；
g）检查该阶段车辆接口锁止状态。','——绝缘检测开始前，当检测到不正常的电池端电压时，充电机应不允许充电；
——当车辆通信握手报文内的最高允许充电总电压低于充电机输出电压范围下限值时，充电机应不允许充电；
——充电机自检阶段车辆接口完全连接后先闭合K3和K4，使辅助供电回路导通；再闭合K1和K2，进行绝缘检测；自检完成后断开K1和K2；且充电机先输出稳定的绝缘检测电压值后，再闭合K1和K2进行绝缘检测；
——绝缘检测的输出电压应为车辆通信握手报文内的最高允许充电总电压和充电机额定电压二者中的较小值；
——充电机低压辅助供电回路的电压值12±0.6V和电流值10A；
——绝缘检测完成后，泄放回路应在充电连接器断开后1s内将供电接口电压降到60VDC以下；
——绝缘检测开始前，充电机周期发送CHM报文；绝缘检测完成后，充电机周期发送0x00的CRM报文；
——此阶段车辆插头电子锁应可靠锁止。','');
Insert into TestInterop values(4,'充电准备就绪测试','D0.3001','检查充电机的充电准备就绪是否正常。','a）分别模拟正常的车辆端电池电压（接触器外端电压与通信报文电池电压误差范围≤±5%且在充电机正常输出电压范围内）、非正常车辆端电池电压（接触器外端电压与通信报文电池电压误差范围>±5%和/或不在充电机正常输出电压范围内），检查该阶段K1和K2状态、充电状态；
b）检查该阶段通信状态；
c）检查该阶段车辆接口锁止状态。','——模拟正常的车辆端电池电压（接触器外端电压与通信报文电池电压误差范围≤±5%且在充电机正常输出电压范围内）
1）充电桩准备就绪允许充电，CRO报文0x00变为0xAA
2）电子锁处于闭合状态
——模拟非正常车辆端电池电压（接触器外端电压与通信报文电池电压误差范围>±5%或不在充电机正常输出电压范围内）
充电桩准备未就绪不允许充电，CRO报文0x00不变为0xAA
电子锁处于闭合状态','');
Insert into TestInterop values(5,'充电阶段测试','D0.4001','在充电过程中，检查充电机是否能根据电池充电需求参数实时调整充电电压和充电电流。','a）充电过程中，利用车辆BMS模拟软件发送“电池充电需求”报文，检查该阶段充电状态；
b）充电过程中，按照D0.4101、D0.4102、D0.4103中的规定分别进行输出电压控制误差测试、输出电流控制误差测试、输出电流调整时间测试；
c）检查该阶段通信状态；
d）检查该阶段车辆接口锁止状态。','——充电机根据电池充电需求参数实时调整充电电压和充电电流，并发送充电状态信息；
——充电过程中，输出电压控制误差、输出电流控制误差、输出电流调整时间分别应符合D0.4101、D0.4102、D0.4103的规定；
——充电过程中，充电机周期发送CCS报文；
——充电过程中，车辆插头电子锁应可靠锁止。','');
Insert into TestInterop values(6,'正常充电结束测试','D0.5001','检查充电机在满足充电结束条件或收到充电中止报文时的充电结束是否正常。','a)主动中止充电测试：
1.在正常充电过程中，对充电机实施停止充电指令，检查该阶段充电状态、K1和K2状态、K3和K4状态；
2.停止充电时，按照D0.5101的规定进行输出电流停止速率测试；
充电结束，检查K1和K2的状态，并记录从泄放投切开关闭合的时刻到K1和K2前端电压降至60VDC 以下的时间；
3.检查该阶段通信状态；
4.检查该阶段车辆接口锁止状态；
b）被动中止充电测试：
1.在正常充电过程中，利用车辆BMS模拟软件发送“BMS中止充电”报文和“BMS统计数据”报文，检查该阶段充电状态、K1和K2状态、K3和K4状态；
2.停止充电时，按照6.3.5.4的规定进行输出电流停止速率测试；
3.充电结束，检查K1和K2的状态，并记录从泄放投切开关闭合的时刻到K1和K2前端电压降至60VDC 以下的时间；
4.检查该阶段通信状态；
5.检查该阶段车辆接口锁止状态；','——在正常充电过程中，对充电机实施停止充电指令，充电机开始周期发送“充电机中止报文”，并控制充电机停止充电，当充电电流小于5A时断开K1K2，并再次投入泄放电路，然后再断开K3K4；在正常充电过程中，充电机收到车辆BMS发送的“BMS中止充电”报文，开始周期发送“充电机中止报文”，并控制充电机停止充电，当充电电流小于等于5A时断开K1K2。
——停止充电时，输出电流停止速率应不小于100A/s；
——充电结束后，泄放回路应在充电连接器断开后1s内将供电接口电压降到60VDC以下；
——充电机主动中止充电，发送中止原因“人工中止”的CST报文；充电机收到车辆BMS发送的“BMS中止充电”报文，发送中止原因“BMS中止”的CST报文；
——充电结束后，达到解锁条件，车辆插头电子锁应能正确解锁。','');
Insert into TestInterop values(7,'充电连接控制时序测试','D0.6001','充电连接控制时序测试','利用车辆BMS模拟软件与被测充电机进行通信，模拟车辆接口连接状态、K5和K6状态、电池状态等，检查充电连接控制过程中检测点1的电压值、K1和K2状态、K3和K4状态、充电状态、通信状态、车辆接口锁止状态、充电状态转换的间隔时间。','充电机充电连接控制时序和充电状态流程应符合GB/T 18487.1—2015中B.5的规定，通信状态应符合GB/T 18487.1—2015中B.6和GB/T 27930—2015中对应阶段的规定。','');
Insert into TestInterop values(8,'通讯中断测试','D0.4501','在充电过程中，检查充电机在通讯超时时是否能停止充电，是否能进行三次握手辨识阶段的连接，且在重新连接成功后是否能正常充电。','a)保持通信故障测试：
1.在正常充电过程中(除了充电结束阶段) ，模拟通信超时(采用如通信线 S+ 断线、通信线S-断线、通信线 S+ 和 S-之间短路、车辆 BMS 模拟软件停止发送报文等故障方式中的一种) ，检查该阶段通信状态、充电状态、K1 和 K2 状态、K3 和 K4 状态、车辆接口锁止状态；
2.保持通信故障状态，检查充电机是否能进行三次握手辨识阶段的连接、该阶段充电状态、Kl 和 K2 状态、K3 和 K4 状态、车辆接口锁止状态。
b）重新连接响应测试：
1.在正常充电过程中(除了充电结束阶段) ，模拟通信超时，检查该阶段通信状态、充电状态、Kl 和 K2 状态、K3 和 K4 状态、车辆接口锁止状态；
当检测到被测充电机进入握手辨识阶段时，利用车辆 BMS 模拟软件与其正常通信，检查重新连接后的通信状态、充电状态、K1 和 K2 状态、K3 和 K4 状态、车辆接口锁止状态；
2.通信中断(重新连接发生三次通信超时)时，检查该阶段通信状态、充电状态、 K1 和 K2 状态、K3 和 K4 状态、车辆接口锁止状态。
注： 只在充电阶段通信超时/中断时，检查 Kl 和 K2 状态。','——充电中出现通信超时，充电机停止充电并在10s内断开Kl、K2、K5、K6；充电中出现3次通信超时即确认通信中断，应在10s内断开Kl、K2、K3、K4、K5、K6；
——充电机发送错误报文中的超时报文类型应符合实际动作情况，且有告警提示；
——当重新连接(握手辨识阶段)且与车辆匹配成功后，充电机应能正确进入充电阶段；
——通信中断后，达到解锁条件，车辆插头电子锁应能正确解锁；
——通信中断后，当充电机再次充电时，应重新插拔充电连接装置。','');
Insert into TestInterop values(9,'开关S断开测试','D0.4502','在充电过程中，检查充电机在开关S断开时是否能停止充电。','a）使电子锁失效后进行测试；
b）在正常充电过程中，模拟开关S由闭合变为断开，检查该阶段通信状态、充电状态、K1和K2状态。','——充电中出现该故障，充电机应在50ms内将输出电流降至5A或以下；
——充电机发送中止充电报文中的结束充电原因应符合实际动作情况，且有告警提示。','');
Insert into TestInterop values(10,'车辆接口断开测试','D0.4503','在充电过程中，检查充电机在车辆接口断开时是否能停止充电。','在正常充电过程中，模拟车辆接口断开，即车辆接口CC1断线，检查该阶段通信状态、充电状态、K1和K2状态、K3和K4状态、车辆接口锁止状态。','——充电中出现该故障，充电机应在 100 ms内发送中止充电报文并断开 K1 和 K2，K3 和 K4 应在充电机发完统计报文和收到车辆统计报文之后才可断开；
——充电机发送中止充电报文中的结束充电原因应符合实际动作情况，且有告警提示；
——充电结束后，达到解锁条件，车辆插头电子锁应能正确解锁。','');
Insert into TestInterop values(11,'输出电压超过车辆允许值测试','D0.4504','在充电过程中，检查充电机输出电压大于车辆最高允许充电总电压时是否能停止充电。','在正常充电过程中，使充电直流回路电压高于车辆最高允许充电总电压，检查该阶段通信状态、充电状态、K1和K2状态、K3和K4状态、车辆接口锁止状态。','——充电中出现该故障，充电机应在1s内停止充电，并断开K1、K2、K3、K4；
——充电机发送中止充电报文中的结束充电原因应符合实际动作情况，且有告警提示；
——充电结束后，达到解锁条件，车辆插头电子锁应能正确解锁','');
Insert into TestInterop values(12,'绝缘故障测试','D0.2501','检查充电前充电机检测到绝缘水平下降至要求值以下时是否允许充电。','a)在绝缘检测前，选择如下测试电阻Rt（使用的测试电阻的精度为±3%），分别在充电直流回路DC+与PE之间或DC-与PE之间进行非对称绝缘测试、DC+与PE之间和DC-与PE之间进行对称绝缘测试，测试电压为充电机的额定输出电压；
设置100Ω/V< Rt≤500Ω/V，检查该阶段是否有绝缘异常提示，是否允许充电；
设置Rt≤100Ω/V，检查该阶段是否有绝缘故障告警，是否允许充电；
b）绝缘检测完成后，检查泄放过程中充电接口电压降到60V DC以下的时间、K1和K2状态；
c）检查该阶段车辆接口锁止状态。','分别在充电直流回路DC+与PE之间或DC-与PE之间进行非对称绝缘测试；DC+与PE之间和DC-与PE之间进行对称绝缘测试
a）设置100Ω/V<Rt≤500Ω/V，有绝缘异常提示，允许充电
b)设置Rt≤100Ω/V，有绝缘故障告警，不允许充电
c)绝缘检测完成后，泄放回路应在充电连接器断开后1s内将供电接口电压降到60VDC以下；
d)当绝缘故障时，达到解锁条件，车辆插头电子锁应能正确解锁。','');
Insert into TestInterop values(13,'保护接地导体连续性丢失测试','D0.4505','在充电过程中，检查充电机在失去保护接地导体电气连续性时是否能停止充电。','在正常充电过程中，模拟充电机保护接地导体电气连续性丢失(不含车辆接口内 PE 断针)，检查该阶段充电状态、 K1 和 K2 状态、车辆接口锁止状态。','——充电中出现该故障，充电机应在100ms内切断电源；
——充电机发送中止充电报文中的结束充电原因应符合实际动作情况，且有告警提示；
——充电结束后，达到解锁条件，车辆插头电子锁应能正确解锁。','');
Insert into TestInterop values(14,'其他充电故障测试','D0.4506','在充电过程中，检查充电机在出现不能继续充电故障或交流电源停电时是否能停止充电。','a）在正常充电过程中，分别模拟出现不能继续充电故障（根据制造商提供的故障声明类型，参见附录C）和交流电源停电，检查该阶段通信状态、充电状态、K1和K2状态、K3和K4状态、车辆接口锁止状态；
b）交流电源停电测试结束后，保持充电用连接装置处于完全连接状态，恢复对被测充电机的交流供电，检查该阶段通信状态、充电状态、K1和K2状态、K3和K4状态、车辆接口锁止状态。','——充电中出现不能继续充电故障时，充电机应在 100 ms内发送中止充电报文并断开 K1 和 K2 ， K3 和 K4 应在充电机发完统计报文和收到车辆统计报文之后才可断开；充电机发送中止充电报文中的结束充电原因应符合实际动作情况，且有告警提示；
——充电中发生交流电源停电时，非车载充电机应在1s以内断开K1、K2或通过泄放回路在1s以内将供电接口电压降到60VDC以下，恢复供电后充电机应不能继续本次充电且不能发送停电前的充电阶段报文；
——充电结束后，达到解锁条件，车辆插头电子锁应能正确解锁。','');
Insert into TestInterop values(15,'冲击电流测试','D0.3101','在充电准备就绪阶段，检查充电机在闭合 K1 和 K2 时，从车辆到充电机、或者充电机到车辆的冲击电流是否满足要求。','在充电准备就绪阶段时，利用车辆BMS模拟软件与其正常通信，模拟正常的车辆端电池电压并闭合K5和K6，利用测量仪器测量被测充电机在闭合接触器K1和K2时，从车辆到充电机、或者充电机到车辆产生的冲击电流。','——冲击电流（峰值）应控制在20A以下。','');
Insert into TestInterop values(16,'输出电压控制误差测试','D0.4101','检查充电机输出电压是否满足车辆充电需求。','a）充电机设置在恒压状态下运行，在正常充电过程中，利用车辆BMS模拟软件发送的“电池充电需求”，设置充电电压需求值U0在充电机输出电压上限、下限范围内，稳定输出后利用测试仪器分别测量实际输出电压UM；
b）测得的输出电压控制误差按公式（1）计算：

ΔU  =  UM — U0……………………………（1）
式中：
U0 —— BMS设定的充电电压需求值；
UM —— 充电机实际输出电压测量值；
ΔU —— 充电机输出电压控制误差；','——输出电压控制误差应不超过±0.5%BMS设定的充电电压需求值。','');
Insert into TestInterop values(17,'输出电流控制误差测试','D0.4102','检查充电机输出电流是否满足车辆充电需求。','a）充电机设置在恒流状态下运行，在正常充电过程中，利用车辆BMS模拟软件发送的“电池充电需求”，设置充电电流需求值I0在被测充电机输出电流上限、下限范围内，稳定输出后利用测试仪器分别测量实际输出电流IM；
b）测得的输出电流控制误差按公式（2）计算：
ΔI =  IM —I0 ………………………………（2）
式中：
I0 —— BMS设定的充电电流需求值；
IM —— 充电机实际输出电流测量值；
ΔI —— 充电机输出电流控制误差。','——当BMS设定的充电电流需求值小于30A时，充电机输出电流控制误差应不超过±0.3A；当BMS设定的充电电流需求值大于等于30A时，充电机输出电流控制误差应不超过±1%BMS设定的充电电流需求值。','');
Insert into TestInterop values(18,'输出电流调整时间测试','D0.4103','检查充电机是否能在规定时间内响应BMS充电电流需求。','充电机设置在恒流状态下运行，在正常充电过程中，利用车辆BMS模拟软件发送的“电池充电需求”，设置充电电流需求值I在被测充电机输出电流上限、下限范围内，当BMS发送的充电电流需求值从Io调整至目标值IN时，见GB/T 34657.1-2017图，利用测试仪器测量电流到达目标值的间隔时间Td；','——当电流变化值ΔI≤20A时，输出电流下降调整时间不应超过1s；当电流变化值ΔI>20A时，输出电流下降调整时间不应超过ΔI/20s；
——输出电流目标值的控制误差应符合D0.4102中的规定。','');
Insert into TestInterop values(19,'输出电流停止速率测试','D0.5101','检查充电机在满足充电结束条件或收到充电中止报文时输出电流停止速率。','检查充电机在满足充电结束条件或收到充电中止报文时输出电流停止速率。','——输出电流停止速率应不小于100A/s。','');




