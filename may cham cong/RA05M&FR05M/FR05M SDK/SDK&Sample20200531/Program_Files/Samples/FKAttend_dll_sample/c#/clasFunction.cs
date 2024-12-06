using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FKAttendDllCSSample;

public class GlobalConstants
{
	public const string  gstrNoDevice = "No Device";
	public const short MAX_BELLCOUNT_DAY = 24;
	public const short MAX_PASSCTRLGROUP_COUNT= 50;
	public const short MAX_PASSCTRL_COUNT = 7;
	public const short MAX_USERPASSINFO_COUNT = 3;
	public const short MAX_GROUPPASSINFO_COUNT = 3;
	public const short MAX_GROUPMATCHINFO_COUNT = 10;
	public const short NEWS_EXTEND = 2;
	public const short NEWS_STANDARD = 1;

	public const short SIZE_BELLINFO = 72;
	public const short SIZE_PASSTIME = 4;
	public const short SIZE_PASSCRLTIME = 28;
	public const short SIZE_USERPASSINFO = 3;
	public const short SIZE_GROUPPASSINFO = 3;
	public const short SIZE_GROUPMATCHINFO = 20;
    public const short MAX_HOLIDAY_COUNT = 50;
}


//******************************************************************/
//*                            Structure                           */
//******************************************************************/

struct BELLINFO
{
	[ MarshalAs( UnmanagedType.ByValArray, SizeConst=GlobalConstants.MAX_BELLCOUNT_DAY )]
	public byte[] mValid;
	[ MarshalAs( UnmanagedType.ByValArray, SizeConst=GlobalConstants.MAX_BELLCOUNT_DAY )]
	public byte[] mHour;
	[ MarshalAs( UnmanagedType.ByValArray, SizeConst=GlobalConstants.MAX_BELLCOUNT_DAY )]
	public byte[] mMinute;
};//72byte

//--- Pass Control Time ---
struct PASSTIME
{
	public 	byte StartHour;
	public 	byte StartMinute;
	public 	byte EndHour;
	public 	byte EndMinute;
};//4byte

		//--- Pass Control Time Infomation ---
struct PASSCTRLTIME
{
	[ MarshalAs( UnmanagedType.ByValArray, SizeConst=GlobalConstants.MAX_PASSCTRL_COUNT )]
	public PASSTIME[] PassCtrlTime;
};//28byte

struct USERPASSINFO
{
	[ MarshalAs( UnmanagedType.ByValArray, SizeConst=GlobalConstants.MAX_USERPASSINFO_COUNT )]
	public byte[] UserPassID;
};
//3byte

struct GROUPPASSINFO
{
	[ MarshalAs( UnmanagedType.ByValArray, SizeConst=GlobalConstants.MAX_GROUPPASSINFO_COUNT )]
	public byte[] GroupPassID;
};
//3byte


struct GROUPMATCHINFO
{
	[ MarshalAs( UnmanagedType.ByValArray, SizeConst=GlobalConstants.MAX_GROUPMATCHINFO_COUNT)]
	public short[] GroupMatch;
};
//20byte

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct MyString
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public string Value;

    public static implicit operator string(MyString source)
    {
        return source.Value;
    }

    public static implicit operator MyString(string source)
    {
        return new MyString { Value = source };
    }
}

        struct HOLIDAYINFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = GlobalConstants.MAX_HOLIDAY_COUNT)]
            public byte[] mValid;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = GlobalConstants.MAX_HOLIDAY_COUNT)]
            public byte[] mMonth;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = GlobalConstants.MAX_HOLIDAY_COUNT)]
            public byte[] mDay;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = GlobalConstants.MAX_HOLIDAY_COUNT)]
            public byte[] mOpenDoor;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = GlobalConstants.MAX_HOLIDAY_COUNT)]
            public MyString[] mHolidayName;
        };//3400byte

//=============== USBModel Kind  ===============//
public enum enumUSBModelKind
{
	FK625_FP1000 = 2001,
	FK625_FP2000 = 2002,
	FK625_FP3000 = 2003,
	FK625_FP5000 = 2004,
	FK625_FP10000 = 2005,
	FK625_FP30000 = 2006,
	FK625_ID30000 = 2007,
	FK635_FP700 = 3001,
	FK635_FP3000 = 3002,
	FK635_FP10000 = 3003,
	FK635_ID30000 = 3004,
	FK723_FP1000 = 4001,
	FK725_FP1000 = 5001,
	FK725_FP1500 = 5002,
	FK725_ID5000 = 5003,
	FK725_ID30000 = 5004,
	FK735_FP500 = 6001,
	FK735_FP3000 = 6002,
	FK735_ID30000 = 6003,
	FK925_FP3000 = 7001,
	FK935_FP3000 = 8001,
};
//=============== Protocol Type ===============//
public enum enumProtocolType
{
	PROTOCOL_TCPIP = 0,               // TCP/IP
	PROTOCOL_UDP = 1,                  // UDP
};

//=============== Backup Number Constant ===============//
public enum enumBackupNumberType
{
    BACKUP_FP_0 = 0,        // Finger 0
    BACKUP_FP_1 = 1,        // Finger 1
    BACKUP_FP_2 = 2,        // Finger 2
    BACKUP_FP_3 = 3,        // Finger 3
    BACKUP_FP_4 = 4,        // Finger 4
    BACKUP_FP_5 = 5,        // Finger 5
    BACKUP_FP_6 = 6,        // Finger 6
    BACKUP_FP_7 = 7,        // Finger 7
    BACKUP_FP_8 = 8,        // Finger 8
    BACKUP_FP_9 = 9,        // Finger 9
    BACKUP_PSW = 10,        // Password
    BACKUP_CARD = 11,       // Card
    BACKUP_FACE = 12,       // Face
	BACKUP_PALMVEIN_0 = 13,
    BACKUP_PALMVEIN_1 = 14,
    BACKUP_PALMVEIN_2 = 15 ,
    BACKUP_PALMVEIN_3 = 16 ,
    BACKUP_VEIN_0 = 20,     // Vein 0
    BACKUP_VFACE = 30,     // VFace 0
    BACKUP_PHOTO = 50,     // photo 0
};
//=============== Manipulation of SuperLogData ===============//
public enum enumSuperLogInfo
{
	LOG_ENROLL_USER = 3,               // Enroll-User
	LOG_ENROLL_MANAGER = 4,            // Enroll-Manager
	LOG_ENROLL_DELFP = 5,              // FP Delete
	LOG_ENROLL_DELPASS = 6,            // Pass Delete
	LOG_ENROLL_DELCARD = 7,            // Card Delete
	LOG_LOG_ALLDEL = 8,                // LogAll Delete
	LOG_SETUP_SYS = 9,                 // Setup Sys
	LOG_SETUP_TIME = 10,               // Setup Time
	LOG_SETUP_LOG = 11,                // Setup Log
	LOG_SETUP_COMM = 12,               // Setup Comm
	LOG_PASSTIME = 13,                 // Pass Time Set
	LOG_SETUP_DOOR = 14,               // Door Set Log
};
//=============== VerifyMode of GeneralLogData ===============//
public enum enumGLogVerifyMode
{
	LOG_FPVERIFY = 1,                 // Fp Verify
	LOG_PASSVERIFY = 2,               // Pass Verify
	LOG_CARDVERIFY = 3,               // Card Verify
	LOG_FPPASS_VERIFY = 4,            // Pass+Fp Verify
	LOG_FPCARD_VERIFY = 5,            // Card+Fp Verify
	LOG_PASSFP_VERIFY = 6,            // Pass+Fp Verify
	LOG_CARDFP_VERIFY = 7,            // Card+Fp Verify
	LOG_JOB_NO_VERIFY = 8,            // Job number Verify
	LOG_CARDPASS_VERIFY = 9,          // Card+Pass Verify
	LOG_CLOSE_DOOR = 10,              // Door Close
	LOG_OPEN_HAND = 11,               // Hand Open
	LOG_PROG_OPEN = 12,               // Open by PC
	LOG_PROG_CLOSE = 13,              // Close by PC
	LOG_OPEN_IREGAL = 14,             // Iregal Open
	LOG_CLOSE_IREGAL = 15,            // Iregal Close
	LOG_OPEN_COVER = 16,              // Cover Open
	LOG_CLOSE_COVER = 17,             // Cover Close

    LOG_FACEVERIFY = 20,                // Face Verify
    LOG_FACECARDVERIFY = 21,            // Face+Card Verify
    LOG_FACEPASSVERIFY = 22,            // Face+Pass Verify
    LOG_CARDFACEVERIFY = 23,            // Card+Face Verify
    LOG_PASSFACEVERIFY = 24,            // Pass+Face Verify
    LOG_FACEFPVERIFY = 25,            // Face + FP Verify

	LOG_OPEN_DOOR = 32,               // Door Open
	LOG_OPEN_THREAT = 48,             // Door Open as threat
};
//=============== IOMode of GeneralLogData ===============//
public enum enumGLogIOMode
{
	LOG_MODE_IO = 0,  // General
	LOG_MODE_IN1 = 1, // IN1
	LOG_MODE_IN2 = 2, // IN2
	LOG_MODE_IN3 = 3, // IN3
	LOG_MODE_OUT1 = 4, // OUT1
	LOG_MODE_OUT2 = 5, // OUT2
	LOG_MODE_OUT3 = 6, // OUT3
};
//=============== Machine Privilege ===============//
public enum enumMachinePrivilege
{
	MP_NONE = 0,                       // General user
	MP_ALL = 1,                        // Manager
};
//=============== Index of  GetDeviceStatus ===============//
public enum enumGetDeviceStatus
{
	GET_MANAGERS = 1,
	GET_USERS = 2,
	GET_FPS = 3,
	GET_PSWS = 4,
	GET_SLOGS = 5,
	GET_GLOGS = 6,
	GET_ASLOGS = 7,
	GET_AGLOGS = 8,
	GET_CARDS = 9,
    GET_FACES = 11,
    GET_PHOTOS = 10,

    GET_PALMVEIN = 40,
};
//=============== Index of  GetDeviceInfo ===============//
public enum enumGetDeviceInfo
{
	DI_MANAGERS = 1,                   // Numbers of Manager
	DI_MACHINENUM = 2,                 // Device ID
	DI_LANGAUGE = 3,                   // Language
	DI_POWEROFF_TIME = 4,              // Auto-PowerOff Time
	DI_LOCK_CTRL = 5,                  // Lock Control
	DI_GLOG_WARNING = 6,               // General-Log Warning
	DI_SLOG_WARNING = 7,               // Super-Log Warning
	DI_VERIFY_INTERVALS = 8,           // Verify Interval Time
	DI_RSCOM_BPS = 9,                  // Comm Buadrate
	DI_DATE_SEPARATE = 10,             // Date Separate Symbol
	DI_VERIFY_KIND = 24,               // Verify Kind Symbol
    DI_MULTIUSERS = 77,                // MultiUser
    DI_NETENABLE = 14,                 // Network Enable
    DI_ALARMDELAY = 66,                // Alarm Output Delay Time
    DI_BELLCOUNT = 15,
    DI_SENSORDELAY = 67,               // Sensor Output Delay Time
    DI_VERIFYFUNC = 25,                  
    DI_MACADDR0	=  42

};
//=============== Baudrate = value of DI_RSCOM_BPS ===============//
public enum enumBaudrate
{
	BPS_9600 = 3,
	BPS_19200 = 4,
	BPS_38400 = 5,
	BPS_57600 = 6,
	BPS_115200 = 7,
};
//=============== Product Data Index ===============//
public enum enumProductInfo
{
	PRODUCT_SERIALNUMBER = 1,     // Serial Number
	PRODUCT_BACKUPNUMBER = 2,     // Backup Number
	PRODUCT_CODE = 3,             // Product code
	PRODUCT_NAME = 4,             // Product name
	PRODUCT_WEB = 5,              // Product web
	PRODUCT_DATE = 6,             // Product date
	PRODUCT_SENDTO = 7,           // Product sendto
};
//=============== Door Status ===============//
public enum enumDoorStatus
{
	DOOR_CONROLRESET = 0,
	DOOR_OPEND = 1,
	DOOR_CLOSED = 2,
	DOOR_COMMNAD = 3,
};

public enum enumDoorOpenStatus
{
    DOOR_CLOSED = 0,
    DOOR_OPEND = 1,
 };
//=============== Error code ===============//
public enum enumErrorCode
{
	RUN_SUCCESS = 1,
	RUNERR_NOSUPPORT = 0,
	RUNERR_UNKNOWNERROR = -1,
	RUNERR_NO_OPEN_COMM = -2,
	RUNERR_WRITE_FAIL = -3,
	RUNERR_READ_FAIL = -4,
	RUNERR_INVALID_PARAM = -5,
	RUNERR_NON_CARRYOUT = -6,
	RUNERR_DATAARRAY_END = -7,
	RUNERR_DATAARRAY_NONE = -8,
	RUNERR_MEMORY = -9,
	RUNERR_MIS_PASSWORD = -10,
	RUNERR_MEMORYOVER = -11,
	RUNERR_DATADOUBLE = -12,
	RUNERR_MANAGEROVER = -14,
	RUNERR_FPDATAVERSION = -15,
};

public enum enumVerifyKind
{
    VK_NONE = 0,
    VK_FP = 1,
    VK_PASS = 2,
    VK_CARD = 3,
    VK_FACE = 4,
    VK_FINGERVEIN = 5,
    VK_IRIS = 6,
    VK_PALMVEIN = 7,
    VK_VOICE = 8,
    VK_VFACE = 9,
}
public enum enumGLogDoorMode
{

    LOG_CLOSE_DOOR = 1,                // Door Close
    LOG_OPEN_HAND = 2,                 // Hand Open
    LOG_PROG_OPEN = 3,                 // Open by PC
    LOG_PROG_CLOSE = 4,                // Close by PC
    LOG_OPEN_IREGAL = 5,               // Illegal Open
    LOG_CLOSE_IREGAL = 6,              // Illegal Close
    LOG_OPEN_COVER = 7,                // Cover Open
    LOG_CLOSE_COVER = 8,               // Cover Close
    LOG_OPEN_DOOR = 9,                 // Door Open
    LOG_OPEN_DOOR_THREAT = 10,         // Door Open
    LOG_FORCE_OPEN_DOOR = 11,                 // Door Open
    LOG_FORCE_CLOSE_DOOR_ = 12,         // Door Open
}