/************************************************************************
 *                                                                      *
 *  Program : FKDefine.h                                                *
 *                                                                      *
 *  Purpose : Define Header For PEFIS Fingerkeeper 6.0 family.          *
 *                                                                      *
 *  Compile : Microsoft Visual C++ .NET                                 *
 *                                                                      *
 *  Version : 2.40                                                      *
 *                                                                      *
 *  Create  : 2008/03/12 Wednesday        -Ver1.00-    By PEFIS         *
 *  Update  : 2008/04/22 Tuesday          -Ver1.01-    By PEFIS         *
 *  Update  : 2008/05/05 Monday           -Ver2.00-    By PEFIS         *
 *  Update  : 2008/05/19 Monday           -Ver2.10-    By PEFIS         *
 *  Update  : 2008/05/28 Monday           -Ver2.20-    By PEFIS         *
 *  Update  : 2008/07/22 Tuesday          -Ver2.40-    By PEFIS         *
 *  Update  : 2008/11/20 Thursday         -Ver2.44-    By PEFIS         *
 *  Update  : 2008/11/20 Thursday         -Ver2.44-    By PEFIS         *
 *                                                                      *
 *  Copyright (C) 2008  PEFIS Electronic Technology Co.,Ltd.            *
 *     All Rights Reserved.                                             *
 *                                                                      *
 ************************************************************************/

#ifndef _INC_FKDEFINEINFO
#define _INC_FKDEFINEINFO

/******************************************************************/
/*                       Bell   Structure                         */
/******************************************************************/
#define MAX_BELLCOUNT_DAY  24
typedef struct tagBELLINFO {
    BYTE    mValid[MAX_BELLCOUNT_DAY];
    BYTE    mHour[MAX_BELLCOUNT_DAY];
    BYTE    mMinute[MAX_BELLCOUNT_DAY];
} BELLINFO;


///////////  Bell Control ///////////
#define MAX_BELLCOUNT			15      // Max Bell count
#define MAX_BELLCOUNT_WEEK		7

#define	BELLKIND_NONE			0
#define	BELLKIND_BUZZER			1
#define	BELLKIND_BELL			2
#define	BELLKIND_BUZZERBELL		3

/*--- Bell Time Infomation ---*/
typedef struct tagBELLTIMEINFO1 {
	unsigned char	Mark;
	unsigned char	WeekDay;
	unsigned char	Reserve[2];
	unsigned char	Valid[MAX_BELLCOUNT_DAY];
	unsigned char	Hour[MAX_BELLCOUNT_DAY];
	unsigned char	Minute[MAX_BELLCOUNT_DAY];
	unsigned char	BellKind[MAX_BELLCOUNT_DAY];
} BELLTIMEINFO1;				/* 100byte	*/

/*--- Bell Infomation ---*/
typedef struct tagBELLINFO1 {
	unsigned char	BellHoldTime;
	unsigned char	Reserve[3];
	BELLTIMEINFO1	BellTime[MAX_BELLCOUNT_WEEK];
} BELLINFO1;					/* 704byte    */

//{ [2012/11/21 Wed 09:09] lih ---------------------------------
// 영태스타에서 새로 제기한 사양에서는 한주일분의 종울림설정을 하게 되여 있다.
// 이때 매일 최대 30번의 종을 울리며 종울림시간은 초단위로 지정한다. 
#define MAX_BELLCOUNT_DAY_30		30 

//-- Bell info of a day
typedef struct tagBELLTIMEINFO2 {
	unsigned char	Mark;
	unsigned char	WeekDay;
	unsigned char	Reserve[2];
	unsigned char	Valid[MAX_BELLCOUNT_DAY_30];
	unsigned char	Hour[MAX_BELLCOUNT_DAY_30];
	unsigned char	Minute[MAX_BELLCOUNT_DAY_30];
	unsigned char	Second[MAX_BELLCOUNT_DAY_30];
	unsigned char	BellKind[MAX_BELLCOUNT_DAY_30];
} BELLTIMEINFO2;	// 154 byte

//-- Bell info of a week
typedef struct tagBELLINFO2 {
	unsigned char	BellHoldTime;
	unsigned char	Reserve[3];
	BELLTIMEINFO2	BellTime[MAX_BELLCOUNT_WEEK];
} BELLINFO2;		// 1082 byte
//} [2012/11/21 Wed 09:09] lih ---------------------------------

/******************************************************************/
/*                             Structure                          */
/******************************************************************/

#define MAX_PASSCTRLGROUP_COUNT  50
#define MAX_PASSCTRL_COUNT        7 // Pass Count Max Value
typedef struct tagPASSTIME {
    BYTE    StartHour;          	// Door open enable start time(hour)
    BYTE    StartMinute;            // Door open enable start time(minute)
    BYTE    EndHour;                // Door open enable end time(hour)
    BYTE    EndMinute;              // Door open enable end time(minute)
} PASSTIME;

typedef struct tagPASSCTRLTIME {
    PASSTIME    mPassCtrlTime[MAX_PASSCTRL_COUNT];
} PASSCTRLTIME;

#define MAX_USERPASSINFO_COUNT    3
typedef struct tagUSERPASSINFO {
    BYTE   UserPassID[MAX_USERPASSINFO_COUNT];
} USERPASSINFO;

#define MAX_GROUPPASSKIND_COUNT   5
#define MAX_GROUPPASSINFO_COUNT   3
typedef struct tagGROUPPASSINFO {
    BYTE   GroupPassID[MAX_GROUPPASSINFO_COUNT];
} GROUPPASSINFO;

#define MAX_GROUPMATCHINFO_COUNT  10
typedef struct tagGROUPMATCHINFO {
    WORD  GroupMatch[MAX_GROUPMATCHINFO_COUNT];
} GROUPMATCHINFO;

typedef struct tagDEV_INFO // 2016-04-28 Newpub
{
	BYTE	DeviceID[32];
	BYTE	reserved[224];
} DEVICEINFO;	// size = 256 bytes

/******************************************************************/
/*                            Constant                            */
/******************************************************************/
//=============== Protocol Type ===============//
#define PROTOCOL_TCPIP             0    // TCP/IP
#define PROTOCOL_UDP               1    // UDP


//=============== Backup Number Constant ===============//
#define BACKUP_MIN					0
#define BACKUP_FP_0					0	// Finger 0
#define BACKUP_FP_1					1	// Finger 1
#define BACKUP_FP_2					2	// Finger 2
#define BACKUP_FP_3					3	// Finger 3
#define BACKUP_FP_4					4	// Finger 4
#define BACKUP_FP_5					5	// Finger 5
#define BACKUP_FP_6					6	// Finger 6
#define BACKUP_FP_7					7	// Finger 7
#define BACKUP_FP_8					8	// Finger 8
#define BACKUP_FP_9					9	// Finger 9
#define BACKUP_PSW					10	// Password
#define BACKUP_CARD					11	// Card
#define BACKUP_FACE					12	// Face data
#define BACKUP_PALMVEIN_0					13
#define BACKUP_PALMVEIN_3					(BACKUP_PALMVEIN_0 + 3)
#define BACKUP_IRIS_0				(BACKUP_PALMVEIN_0 + 4)
#define BACKUP_IRIS_1				(BACKUP_PALMVEIN_0 + 5)
#define BACKUP_IRIS_2				(BACKUP_PALMVEIN_0 + 6)
#define BACKUP_VEIN_0				20	// VEIN data 0
#define BACKUP_VEIN_9				(BACKUP_VEIN_0 + 9)	// VEIN data 19
#define BACKUP_PHOTO				50
#define BACKUP_MAX					60

//=============== Manipulation of SuperLogData ===============//
#define LOG_ENROLL_USER            3    // Enroll-User
#define LOG_ENROLL_MANAGER         4    // Enroll-Manager
#define LOG_ENROLL_DELFP           5    // FP Delete
#define LOG_ENROLL_DELPASS         6    // Pass Delete
#define LOG_ENROLL_DELCARD         7    // Card Delete
#define LOG_LOG_ALLDEL             8    // LogAll Delete
#define LOG_SETUP_SYS              9    // Setup Sys
#define LOG_SETUP_TIME            10    // Setup Time
#define LOG_SETUP_LOG             11    // Setup Log
#define LOG_SETUP_COMM            12    // Setup Comm
#define LOG_PASSTIME              13    // Pass Time Set
#define LOG_SETUP_DOOR            14    // Door Set Log

//=============== VerifyMode of GeneralLogData ===============//
#define LOG_FPVERIFY               1    // Fp Verify
#define LOG_PASSVERIFY             2    // Pass Verify
#define LOG_CARDVERIFY             3    // Card Verify
#define LOG_FPPASSVERIFY          4    // Pass+Fp Verify
#define LOG_FPCARDVERIFY          5    // Card+Fp Verify
#define LOG_PASSFPVERIFY          6    // Pass+Fp Verify
#define LOG_CARDFPVERIFY          7    // Card+Fp Verify
#define LOG_CARDPASSVERIFY        9    // Card+Fp Verify
//modify 2015-10-15 일부상수값들을 통일짓기 위해서 변경시킨다.

#define LOG_FACEVERIFY			  20    // Face Verify
#define LOG_FACECARDVERIFY		  21    // Face+Card Verify
#define LOG_FACEPASSVERIFY		  22    // Face+Pass Verify
#define LOG_CARDFACEVERIFY		  23    // Card+Face Verify
#define LOG_PASSFACEVERIFY		  24    // Pass+Face Verify

#define LOG_NEW_FPVERIFY               0x10000000    // Fp Verify
#define LOG_NEW_PASSVERIFY             0x20000000    // Pass Verify
#define LOG_NEW_CARDVERIFY             0x30000000   // Card Verify
#define LOG_NEW_FPPASS_VERIFY          0x12000000    // Pass+Fp Verify
#define LOG_NEW_FPCARD_VERIFY          0x13000000    // Card+Fp Verify
#define LOG_NEW_PASSFP_VERIFY          0x21000000    // Pass+Fp Verify
#define LOG_NEW_CARDFP_VERIFY          0x31000000    // Card+Fp Verify
#define LOG_NEW_CARDPASS_VERIFY        0x32000000    // Card+Fp Verify
//modify 2015-10-15 일부상수값들을 통일짓기 위해서 변경시킨다.

#define LOG_NEW_FACEVERIFY			  0x40000000    // Face Verify
#define LOG_NEW_FACECARDVERIFY		  0x43000000    // Face+Card Verify
#define LOG_NEW_FACEPASSVERIFY		  0x42000000    // Face+Pass Verify
#define LOG_NEW_CARDFACEVERIFY		  0x34000000    // Card+Face Verify
#define LOG_NEW_PASSFACEVERIFY		  0x24000000    // Pass+Face Verify


#define LOG_CLOSE_DOOR            1    // Door Close
#define LOG_OPEN_HAND             2    // Hand Open
#define LOG_PROG_OPEN             3    // PC   Open
#define LOG_PROG_CLOSE            4    // PC   Close
#define LOG_OPEN_IREGAL           5    // Illegal Open
#define LOG_CLOSE_IREGAL          6    // Illegal Close
#define LOG_OPEN_COVER            7    // Cover Open
#define LOG_CLOSE_COVER           8    // Cover Close
#define LOG_OPEN_DOOR             9    // Door Open
#define LOG_OPEN_THREAT           10    // Door Open threat

//=============== IOMode of GeneralLogData ===============//
#define LOG_IOMODE_IO                 0
#define LOG_IOMODE_IN1                1
#define LOG_IOMODE_OUT1               2
#define LOG_IOMODE_IN2                3
#define LOG_IOMODE_OUT2               4
#define LOG_IOMODE_IN3                5
#define LOG_IOMODE_OUT3               6
#define LOG_IOMODE_IN4                7
#define LOG_IOMODE_OUT4               8

//=============== Machine Privilege ===============//
#define MP_NONE                    0    // General user
#define MP_ALL                     1    // Manager
// 이 상수값들은 이전의 MP_NONE, MP_ALL의 확장이다.
// 2013-12-23 썬전오피스로부터 사용자의 권한을 원래의 권한외에 2가지 더 추가해달라는 요구가 제기되여 추가한다.
// Super관리자, 일반관리자, 등록관리자(사용자의 등록만을 담당한 관리자)
#define MP_MANAGER_SUPER		1
#define MP_MANAGER_GENERAL		2
#define MP_MANAGER_REGISTRAR	3
// 2016-03-16 Newpub 
//광저우 호우쑨에서 사용자를 하나 더 추가 해달라는 요구가 제기되여 추가한다.
#define MP_MANAGER_CUSTOM		4


//=============== Index of  GetDeviceStatus ===============//
#define	GET_MANAGERS               1
#define	GET_USERS                  2
#define	GET_FPS                    3
#define	GET_PSWS                   4
#define	GET_SLOGS                  5
#define	GET_GLOGS                  6
#define	GET_ASLOGS                 7
#define	GET_AGLOGS                 8
#define	GET_CARDS                  9
#define	GET_FACES                  10
// ... ... 
#define	GET_VEINS                  28

//=============== Index of  GetDeviceInfo ===============//
#define DI_CHKSUM				   0
#define DI_MANAGERS                1    // Numbers of Manager
#define	DI_DEVICEID				   2    // DeviceID    Insert of 2010.06.18
#define DI_LANGAUGE                3    // Language
#define DI_POWEROFF_TIME           4    // Auto-PowerOff Time
#define DI_LOCK_CTRL               5    // Lock Control
#define DI_GLOG_WARNING            6    // General-Log Warning
#define DI_SLOG_WARNING            7    // Super-Log Warning
#define DI_VERIFY_INTERVALS        8    // Verify Interval Time
#define DI_RSCOM_BPS               9    // Comm Buadrate
#define DI_DATE_SEPARATE          10    // Date Separate Symbol
#define DI_VOICE_OUT			  12		
#define DI_FACILITY_CODE          13  
#define DI_NETENABLE			  14    // Network Enable
#define DI_DATE_FORMAT            22    //  DI_DATE_FORMAT <-> DI_BELLCOUNT
#define DI_DISP_FALG			  16
#define DI_LCDKIND				  17	
#define DI_LCDCONTRAST			  18	
#define DI_CMOSKIND				  19
#define DI_TRESHOLD1N			  20
#define DI_TRESHOLD11			  21
#define DI_BELLCOUNT			  15    //  DI_DATE_FORMAT <-> DI_BELLCOUNT
#define DI_USEIDCARD			  23	
#define DI_VERIFY_KIND            24    // VerrifyKind
#define DI_VERIFYFUNC			  25
#define DI_USERS485				  26
#define DI_POWERKEYUSE			  27
#define DI_DOOROPENTIME			  28
#define DI_WIEGANDUSED			  29
#define DI_DOORSENSORKIND		  30
#define DI_LOCKDELAY			  31
#define DI_IPADDRESS		      32    // IP Address
#define DI_TCPPASSWORD			  36	
#define DI_PORTNO				  40	
#define DI_MACADDR0				  42	
#define DI_MACADDR1				  43
#define DI_MACADDR2				  44	
#define DI_MACADDR3				  45
#define DI_MACADDR4				  46
#define DI_MACADDR5				  47
#define DI_SUBNETMASK			  48	
#define DI_GATEWAY				  52	
#define DI_SERVERIPADDR			  56
#define DI_SERVERPORTNO			  60
#define DI_SERVERREQUEST		  62
#define DI_CHKSUMEX				  64
#define DI_USERS232				  65
#define DI_ALARMDELAY			  66
#define DI_SENSORDELAY			  67
#define DI_INVALIDALARM			  68
#define DI_KEYBEEP				  69
#define DI_PSTARTHOUR			  70
#define DI_PSTARTMIN			  71
#define DI_PENDHOUR				  72
#define DI_PENDMIN				  73	
#define DI_USEPREVIEW			  74
#define DI_LURKIN			      75
#define DI_UNLOCKMODE			  76
#define DI_MULTIUSERS		      77    // MultiUser
#define DI_USEJOBNO				  78			  	
#define DI_LOCKMODE				  79
#define DI_MENUPASS               80
#define DI_USESHIFTKEY			  84	
#define DI_SCREENSAVER			  85
#define DI_VOLUME				  86
#define DI_CARDREADER             87
#define DI_DEVICEID1			  88
#define DI_SHOWFPIMAGE			  90
#define DI_SLEEPTIME			  91
#define DI_DORRKIND				  92			
#define DI_USET9				  93	

#define DI_VerifyKindExt		  94	

//=============== Baudrate = value of DI_RSCOM_BPS ===============//
#define BPS_9600                   3
#define BPS_19200                  4
#define BPS_38400                  5
#define BPS_57600                  6
#define BPS_115200                 7

//=============== Product Data Index ===============//
#define PRODUCT_SERIALNUMBER       1    // Serial Number
#define PRODUCT_BACKUPNUMBER       2    // Backup Number
#define PRODUCT_CODE               3    // Product code
#define PRODUCT_NAME               4    // Product name
#define PRODUCT_WEB                5    // Product web
#define PRODUCT_DATE               6    // Product date
#define PRODUCT_SENDTO             7    // Product sendto

//=============== Door Status ===============//
#define DOOR_CONTROLRESET           0
#define DOOR_OPEND                 1
#define DOOR_CLOSED                2
#define DOOR_COMMNAD               3

//=============== Error code ===============//
#define RUN_SUCCESS                1    // Successful
#define RUNERR_NOSUPPORT           0    // No support
#define RUNERR_UNKNOWNERROR       -1    // Unknown error
#define RUNERR_NO_OPEN_COMM       -2    // No Open Comm
#define RUNERR_WRITE_FAIL         -3    // Write Error
#define RUNERR_READ_FAIL          -4    // Read Error
#define RUNERR_INVALID_PARAM      -5    // Parameter Error
#define RUNERR_NON_CARRYOUT       -6    // execution of command failed.
#define RUNERR_DATAARRAY_END      -7    // End of  data array
#define RUNERR_DATAARRAY_NONE     -8    // None of  data array
#define RUNERR_MEMORY             -9    // Memory Allocating Error
#define RUNERR_MIS_PASSWORD      -10    // mistake password
#define RUNERR_MEMORYOVER        -11    // full enrolldata & can`t put enrolldata
#define RUNERR_DATADOUBLE        -12    // this ID is already  existed.
#define RUNERR_MANAGEROVER       -14    // full manager & can`t put manager
#define RUNERR_FPDATAVERSION     -15    // mistake fp data version.
#define RUNERR_LOGINOUTMODE	     -16    // mistake logdata In/Out mode.  insert 2010/09/19 by chang chol hak

/*이 상수값들이 샘플의 대조확인상수값들과 차이나는 리유는 원래정의를 하지안고 수값으로 했었기때문이다.
또한 이 값은 SDK에서만 리용하므로 차이나도 일없다고 생각한다.
앞으로 생겨나는 자료를 하나씩 정의 하면 된다.*/
#define ENROLL_DATA_PASS	0
#define ENROLL_DATA_IDCARD	1
#define ENROLL_DATA_FP		2
#define ENROLL_DATA_FACE	3
#define ENROLL_DATA_PALMVEIN	4
#define ENROLL_DATA_IRIS	5
#define ENROLL_DATA_FINGERVEIN	6

#endif //!_INC_FKDEFINEINFO
/************************************************************************
 *                                                                      *
 *                        End of file : FKDefine.h                      *
 *                                                                      *
 ************************************************************************/
