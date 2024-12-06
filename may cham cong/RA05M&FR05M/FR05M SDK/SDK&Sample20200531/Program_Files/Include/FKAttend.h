/************************************************************************
 *                                                                      *
 *  Program : FKAttend.h                                                *
 *                                                                      *
 *  Purpose : Interface Function For PEFIS Fingerkeeper 6.0 family.     *
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
 *  Update  : 2008/09/22 Monday           -Ver2.43-    By PEFIS         *
 *                                                                      *
 *  Copyright (C) 2008  PEFIS Electronic Technology Co.,Ltd.            *
 *     All Rights Reserved.                                             *
 *                                                                      *
 ************************************************************************/

#ifndef _INC_FKATTENDINFO
#define _INC_FKATTENDINFO

#ifdef _FKATTEND
	#define FP_EXPORT __declspec(dllexport) APIENTRY
#else
	#define FP_EXPORT __declspec(dllimport) APIENTRY
#endif

//{-------------------------------------------------------------------------------------------------
// Connection
long FP_EXPORT FK_ConnectComm(long nMachineNo, long anComPort, long anBaudRate, const char* astrTelNumber, long anWaitDialTime, long anLicense, long anComTimeOut);
long FP_EXPORT FK_ConnectNet(long anMachineNo, const char* astrIpAddress, long anNetPort, long anTimeOut, long anProtocolType, long anNetPassword, long anLicense);
long FP_EXPORT FK_ConnectGPRS(const char* astrMachineNo, const char* astrIpAddress, long anNetPort,long anTimeOut, long anProtocolType, long anNetPassword, long anLicense);
long FP_EXPORT FK_ConnectUSB(long anMachineNo, long anLicense);
void FP_EXPORT FK_DisConnect(long anHandleIndex);
//}

//{-------------------------------------------------------------------------------------------------
// Error processing
long FP_EXPORT FK_GetLastError(long anHandleIndex);

long FP_EXPORT FK_GetIsSupportStringID(long anHandleIndex);

//}

//{-------------------------------------------------------------------------------------------------
// Device Setting
long FP_EXPORT FK_EnableDevice(long anHandleIndex, unsigned char nEnableFlag);
void FP_EXPORT FK_PowerOnAllDevice(long anHandleIndex);
long FP_EXPORT FK_PowerOffDevice(long anHandleIndex);
long FP_EXPORT FK_GetDeviceStatus(long anHandleIndex, long anStatusIndex, long* apnValue);
long FP_EXPORT FK_GetDeviceTime(long anHandleIndex, DATE* apnDateTime);
long FP_EXPORT FK_GetDeviceTime_1(long anHandleIndex, long* apnYear, long* apnMonth, long* apnDay, long* apnHour, long* apnMinute, long* apnSec, long* apnDayOfWeek);
long FP_EXPORT FK_SetDeviceTime(long anHandleIndex, DATE anDateTime);
long FP_EXPORT FK_SetDeviceTime_1(long anHandleIndex, long anYear, long anMonth, long anDay, long anHour, long anMinute, long anSec, long anDayOfWeek);
long FP_EXPORT FK_GetDeviceInfo(long anHandleIndex, long anInfoIndex, long* apnValue);
long FP_EXPORT FK_SetDeviceInfo(long anHandleIndex, long anInfoIndex, long anValue);
long FP_EXPORT FK_GetProductData(long anHandleIndex, long anDataIndex, char** apstrValue);
long FP_EXPORT FK_GetDeviceVersion(long anHandleIndex, long* apnVersion);
//}

//{-------------------------------------------------------------------------------------------------
// Log Data
long FP_EXPORT FK_LoadSuperLogData(long anHandleIndex, long anReadMark);
long FP_EXPORT FK_GetSuperLogData(long anHandleIndex, long* apnSEnrollNumber, long* apnGEnrollNumber, long* apnManipulation, long* apnBackupNumber, DATE* apnDateTime);

long FP_EXPORT FK_GetSuperLogData_StringID(long anHandleIndex, char** apnSEnrollNumber, char** apnGEnrollNumber, long* apnManipulation, long* apnBackupNumber, DATE* apnDateTime);


long FP_EXPORT FK_GetSuperLogData_1(long anHandleIndex, long* apnSEnrollNumber, long* apnGEnrollNumber, long* apnManipulation, long* apnBackupNumber, long* apnYear, long* apnMonth, long* apnDay, long* apnHour, long* apnMinute, long* apnSec);

long FP_EXPORT FK_EmptySuperLogData(long anHandleIndex);


long FP_EXPORT FK_LoadGeneralLogData(long anHandleIndex, long anReadMark);
long FP_EXPORT FK_GetGeneralLogData(long anHandleIndex, long* apnEnrollNumber, long* apnVerifyMode, long* apnInOutMode, DATE* apnDateTime);
long FP_EXPORT FK_GetGeneralLogData_StringID(long anHandleIndex, char** apnEnrollNumber, long* apnVerifyMode, long* apnInOutMode, DATE* apnDateTime);
long FP_EXPORT FK_GetGeneralLogData_1(long anHandleIndex, long* apnEnrollNumber, long* apnVerifyMode, long* apnInOutMode, long* apnYear, long* apnMonth, long* apnDay, long* apnHour, long* apnMinute, long* apnSec);
long FP_EXPORT FK_EmptyGeneralLogData(long anHandleIndex);

long FP_EXPORT FK_USBLoadSuperLogDataFromFile(long anHandleIndex, const char* astrFilePath);
long FP_EXPORT FK_USBLoadGeneralLogDataFromFile(long anHandleIndex, const char* astrFilePath);

//}

//{-------------------------------------------------------------------------------------------------
// Bell Time
long FP_EXPORT FK_GetBellTime(long anHandleIndex, long* apnBellCount, void* aptBellInfo);
long FP_EXPORT FK_GetBellTimeWithString(long anHandleIndex, long* apnBellCount, char** apstrBellInfo);
long FP_EXPORT FK_SetBellTime(long anHandleIndex, long anBellCount, void* aptBellInfo);
long FP_EXPORT FK_SetBellTimeWithString(long anHandleIndex, long anBellCount, const char* astrBellInfo);
//}

//{-------------------------------------------------------------------------------------------------
// Enroll Data, User Name, Message
long FP_EXPORT FK_EnableUser(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long anEnableFlag);
long FP_EXPORT FK_EnableUser_StringID(long anHandleIndex, char* apEnrollNumber, long anBackupNumber, long anEnableFlag);
long FP_EXPORT FK_ModifyPrivilege(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long anMachinePrivilege);
long FP_EXPORT FK_ModifyPrivilege_StringID(long anHandleIndex, char* apEnrollNumber, long anBackupNumber, long anMachinePrivilege);
long FP_EXPORT FK_BenumbAllManager(long anHandleIndex);

long FP_EXPORT FK_ReadAllUserID(long anHandleIndex);
long FP_EXPORT FK_GetAllUserID(long anHandleIndex, long* apnEnrollNumber, long* apnBackupNumber, long* apnMachinePrivilege, long* apnEnableFlag);
long FP_EXPORT FK_GetAllUserID_StringID(long anHandleIndex, char** apEnrollNumber, long* apnBackupNumber, long* apnMachinePrivilege, long* apnEnableFlag);
long FP_EXPORT FK_GetEnrollData(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long* apnMachinePrivilege, void* apEnrollData, long* apnPassWord);
long FP_EXPORT FK_GetEnrollData_StringID(long anHandleIndex, char* apEnrollNumber, long anBackupNumber, long* apnMachinePrivilege, void* apEnrollData, long* apnPassWord);
long FP_EXPORT FK_GetEnrollDataWithString(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long* apnMachinePrivilege, char** apstrEnrollData);
long FP_EXPORT FK_PutEnrollData(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long anMachinePrivilege, void* apEnrollData, long anPassWord);
long FP_EXPORT FK_PutEnrollData_StringID(long anHandleIndex, char* apEnrollNumber, long anBackupNumber, long anMachinePrivilege, void* apEnrollData, long anPassWord);

long FP_EXPORT FK_GetEncrptEnrolledData(long anHandleIndex, long anBackupNumber,void* apEnrollData, long anPassWord,long anEncrptFlag);//2015-05-27 Newpub

long FP_EXPORT FK_GetEncrptEnrolledDataWithString(long anHandleIndex, long anBackupNumber,void* apEnrollData, char* apPassWord,long anEncrptFlag);


long FP_EXPORT FK_PutEnrollDataWithString(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long anMachinePrivilege, const char* astrEnrollData);
long FP_EXPORT FK_SaveEnrollData(long anHandleIndex);

long FP_EXPORT FK_DeleteEnrollData(long anHandleIndex, long anEnrollNumber, long anBackupNumber);
long FP_EXPORT FK_DeleteEnrollData_StringID(long anHandleIndex, char* apEnrollNumber, long anBackupNumber);
long FP_EXPORT FK_EmptyEnrollData(long anHandleIndex);
long FP_EXPORT FK_ClearKeeperData(long anHandleIndex);

long FP_EXPORT FK_GetUserName(long anHandleIndex, long anEnrollNumber, char** apstrUserName);
long FP_EXPORT FK_GetUserName_StringID(long anHandleIndex, char* apEnrollNumber, char** apstrUserName);
long FP_EXPORT FK_SetUserName(long anHandleIndex, long anEnrollNumber, const char* astrUserName);
long FP_EXPORT FK_SetUserName_StringID(long anHandleIndex, char* apEnrollNumber, const char* astrUserName);

long FP_EXPORT FK_GetNewsMessage(long anHandleIndex, long anNewsId, char** apstrNews);
long FP_EXPORT FK_SetNewsMessage(long anHandleIndex, long anNewsId, const char* astrNews);

long FP_EXPORT FK_GetUserNewsID(long anHandleIndex, long anEnrollNumber, long* apnNewsId); 
long FP_EXPORT FK_SetUserNewsID(long anHandleIndex, long anEnrollNumber, long anNewsId);
//}

//{-------------------------------------------------------------------------------------------------
// Access Control
long FP_EXPORT FK_GetDoorStatus(long anHandleIndex, long* apnStatusVal);
long FP_EXPORT FK_SetDoorStatus(long anHandleIndex, long anStatusVal);
long FP_EXPORT FK_GetPassTime(long anHandleIndex, long anPassTimeID, void* apPassTime, long anPassTimeSize);
long FP_EXPORT FK_GetPassTimeWithString(long anHandleIndex, long anPassTimeID, char** apstrPassTime);
long FP_EXPORT FK_SetPassTime(long anHandleIndex, long anPassTimeID, void* apPassTime, long anPassTimeSize);
long FP_EXPORT FK_SetPassTimeWithString(long anHandleIndex, long anPassTimeID, const char* astrPassTime);

long FP_EXPORT FK_GetUserPassTime(long anHandleIndex, long anEnrollNumber, long* apnGroupID, void* apUserPassTimeInfo, long anUserPassTimeInfoSize);
long FP_EXPORT FK_GetUserPassTime_StringID(long anHandleIndex, char* apEnrollNumber, long* apnGroupID, void* apUserPassTimeInfo, long anUserPassTimeInfoSize);
long FP_EXPORT FK_GetUserPassTimeWithString(long anHandleIndex, long anEnrollNumber, long* apnGroupID, char** apstrUserPassTimeInfo);
long FP_EXPORT FK_SetUserPassTime(long anHandleIndex, long anEnrollNumber, long anGroupID, void* apUserPassTimeInfo, long anUserPassTimeInfoSize);
long FP_EXPORT FK_SetUserPassTime_StringID(long anHandleIndex, char* anEnrollNumber, long anGroupID, void* apUserPassTimeInfo, long anUserPassTimeInfoSize);
long FP_EXPORT FK_SetUserPassTimeWithString(long anHandleIndex, long anEnrollNumber, long anGroupID, const char* astrUserPassTimeInfo);
long FP_EXPORT FK_GetGroupPassTime(long anHandleIndex, long anGroupID, void* apGroupPassTimeInfo, long anGroupPassTimeInfoSize);
long FP_EXPORT FK_GetGroupPassTimeWithString(long anHandleIndex, long anGroupID, char** apstrGroupPassTimeInfo);
long FP_EXPORT FK_SetGroupPassTime(long anHandleIndex, long anGroupID, void* apGroupPassTimeInfo, long anGroupPassTimeInfoSize);
long FP_EXPORT FK_SetGroupPassTimeWithString(long anHandleIndex, long anGroupID, const char* astrGroupPassTimeInfo);
long FP_EXPORT FK_GetGroupMatch(long anHandleIndex, void* apGroupMatchInfo, long anGroupMatchInfoSize);
long FP_EXPORT FK_GetGroupMatchWithString(long anHandleIndex, char** apstrGroupMatchInfo);
long FP_EXPORT FK_SetGroupMatch(long anHandleIndex, void* apnGroupMatchInfo, long anGroupMatchInfoSize);
long FP_EXPORT FK_SetGroupMatchWithString(long anHandleIndex, const char* astrGroupMatchInfo);
long FP_EXPORT FK_GetVerifyMode(long anHandleIndex, long anEnrollNumber, long* apnVerifyMode);
long FP_EXPORT FK_SetVerifyMode(long anHandleIndex, long anEnrollNumber, long anVerifyMode);
//}

//{-------------------------------------------------------------------------------------------------
// Etc Functions
long FP_EXPORT FK_ConnectGetIP(char** apstrComName);

long FP_EXPORT FK_GetAdjustInfo(long anHandleIndex, long* apnAdjustedState, long* apnAdjustedMonth, long* apnAdjustedDay, long* apnAdjustedHour, long* apnAdjustedMinute, long* apnRestoredState, long* apnRestoredMonth, long* apnRestoredDay, long* apnRestoredHour, long* apnRestoredMinte);
long FP_EXPORT FK_SetAdjustInfo(long anHandleIndex, long anAdjustedState, long anAdjustedMonth, long anAdjustedDay, long anAdjustedHour, long anAdjustedMinute, long anRestoredState, long anRestoredMonth, long anRestoredDay, long anRestoredHour, long anRestoredMinte);

long FP_EXPORT FK_GetAccessTime(long anHandleIndex, long anEnrollNumber, long* apnAccessTime);
long FP_EXPORT FK_SetAccessTime(long anHandleIndex, long anEnrollNumber, long anAccessTime);

long FP_EXPORT FK_SetFontName(long anHandleIndex, const char* astrFontName, long anFontType);

long FP_EXPORT FK_GetRealTimeInfo(long anHandleIndex, void* apRealTimeInfo);
long FP_EXPORT FK_SetRealTimeInfo(long anHandleIndex, void* apRealTimeInfo);

long FP_EXPORT FK_GetServerNetInfo(long anHandleIndex, char** apstrServerIPAddress, long* apServerPort, long* apServerRequest);
long FP_EXPORT FK_SetServerNetInfo(long anHandleIndex, const char*  astrServerIPAddress, long  anServerPort, long  anServerRequest);
//}

//{-------------------------------------------------------------------------------------------------
// USB File

// old
long FP_EXPORT FK_SetUSBModel(long anHandleIndex, long anModel);
// new
long FP_EXPORT FK_SetUDiskFileFKModel(long anHandleIndex, const char* astrFKModel);

long FP_EXPORT FK_GetUSBEnrollDataIsSupportStringID(long anHandleIndex);
long FP_EXPORT FK_GetLogDataIsSupportStringID(long anHandleIndex);

long FP_EXPORT FK_USBReadAllEnrollDataFromFile(long anHandleIndex, const char* astrFilePath);
long FP_EXPORT FK_USBReadAllEnrollDataCount(long anHandleIndex, long* apnValue);
long FP_EXPORT FK_USBGetOneEnrollData(long anHandleIndex, long* apnEnrollNumber, long* apnBackupNumber, long* apnMachinePrivilege, void* apEnrollData, long* apnPassWord, long* apnEnableFlag, char** apstrEnrollName);
long FP_EXPORT FK_USBGetOneEnrollData_StringID(long anHandleIndex, char** apEnrollNumber, long* apnBackupNumber, long* apnMachinePrivilege, void* apEnrollData, long* apnPassWord, long* apnEnableFlag, char** apstrEnrollName);

long FP_EXPORT FK_USBGetOneEnrollDataWithString(long anHandleIndex, long*  apnEnrollNumber, long* apnBackupNumber, long* apnMachinePrivilege, char** apstrEnrollData, long* apnEnableFlag, char** apstrEnrollName);
long FP_EXPORT FK_USBGetOneEnrollData_1(long* apnEnrollNumber, long* apnBackupNumber, long* apnVerifyMode, long* apnMachinePrivilege, void* apEnrollData, long* apnPassWord, long* apnEnableFlag, char** apstrEnrollName);
long FP_EXPORT FK_USBGetOneEnrollDataWithString_1(long* apnEnrollNumber, long* apnBackupNumber, long* apnVerifyMode, long* apnMachinePrivilege, char** apstrEnrollData, long* apnEnableFlag, char** apstrEnrollName);

long FP_EXPORT FK_USBSetOneEnrollData(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long anMachinePrivilege, void* apEnrollData, long anPassWord, long anEnableFlag, const char* astrEnrollName);
long FP_EXPORT FK_USBSetOneEnrollData_StringID(long anHandleIndex, char* apEnrollNumber, long anBackupNumber, long anMachinePrivilege, void* apEnrollData, long anPassWord, long anEnableFlag, const char* astrEnrollName);
long FP_EXPORT FK_USBSetOneEnrollDataWithString(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long anMachinePrivilege, const char* astrEnrollData, long anEnableFlag, const char* astrEnrollName);
long FP_EXPORT FK_USBSetOneEnrollData_1(long anEnrollNumber, long anBackupNumber, long anVerifyMode, long anMachinePrivilege, long* apnEnrollData, long anPassWord, long anEnableFlag, const char* astrEnrollName);
long FP_EXPORT FK_USBSetOneEnrollDataWithString_1(long anEnrollNumber, long anBackupNumber, long anVerifyMode, long anMachinePrivilege, const char* astrEnrollData, long anEnableFlag, const char* astrEnrollName);
long FP_EXPORT FK_USBWriteAllEnrollDataToFile(long anHandleIndex, const char* astrFilePath);

long FP_EXPORT FK_USBReadAllEnrollDataFromFile_Color(long anHandleIndex, const char* astrFilePath);
long FP_EXPORT FK_USBGetOneEnrollData_Color(long anHandleIndex, long* apnEnrollNumber, long* apnBackupNumber, long* apnMachinePrivilege, void* apEnrollData, long* apnPassWord, long* apnEnableFlag, char** apstrEnrollName, long anNewsKind);
long FP_EXPORT FK_USBGetOneEnrollDataWithString_Color(long anHandleIndex, long* apnEnrollNumber, long* apnBackupNumber, long* apnMachinePrivilege, char** apstrEnrollData, long* apnEnableFlag, char** apstrEnrollName, long anNewsKind);

long FP_EXPORT FK_USBSetOneEnrollData_Color(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long anMachinePrivilege, void* apEnrollData, long anPassWord, long anEnableFlag, const char* astrEnrollName, long anNewsKind);
long FP_EXPORT FK_USBSetOneEnrollDataWithString_Color(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long anMachinePrivilege, const char* astrEnrollData, long anEnableFlag, const char* astrEnrollName, long anNewsKind);
long FP_EXPORT FK_USBWriteAllEnrollDataToFile_Color(long anHandleIndex, const char* astrFilePath, long anNewsKind);
//오피스에서 BS로 올라온 자료를 U판으로 변환해달라는 요구를 받고 자료변환함수를 새로추가하였다.
long FP_EXPORT FK_USBConvertDataFromBSToSDK(long anHandleIndex, long anBackUpNumber, const char* apstrEnrollData,long anstrEnrollSize,void* apEnrollData,long anBufferSize);
//오피스에서 u판자료를 만들때 (BS에서올라온 자료로) 문자렬로 된 ID를 넣어달라는 요구를 받고 함수 2개를 추가한다. 문자렬아이디는 PostInfo마당에 들어가게 된다.
long FP_EXPORT FK_USBSetOneEnrollData_2(long anHandleIndex, long anEnrollNumber, long anBackupNumber, long anMachinePrivilege, void* apEnrollData, long anPassWord, long anEnableFlag, const char* astrEnrollName,const char* astrStringID);
long FP_EXPORT FK_USBGetOneEnrollData_2(long anHandleIndex, long* apnEnrollNumber, long* apnBackupNumber, long* apnMachinePrivilege, void* apEnrollData, long* apnPassWord, long* apnEnableFlag, char** apstrEnrollName,char** apstrStringID);

//}

//}

//{-------------------------------------------------------------------------------------------------
// Post/Shift (HTML version)
long FP_EXPORT FK_GetOneShiftInfo(long anHandleIndex, long anShiftNumber, long* apnShiftSHour, long* apnShiftSMinute, long* apnShiftEHour, long* apnShiftEMinute, char** apstrShiftName);
long FP_EXPORT FK_SetOneShiftInfo(long anHandleIndex, long anShiftNumber, long anShiftSHour, long anShiftSMinute, long anShiftEHour, long anShiftEMinute, const char* astrShiftName);
long FP_EXPORT FK_GetOnePostInfo(long anHandleIndex, long anPostNumber, char** apstrPostName, long* apnShiftNumber1, long* apnShiftNumber2, long* apnShiftNumber3, long* apnShiftNumber4);
long FP_EXPORT FK_SetOnePostInfo(long anHandleIndex, long anPostNumber, const char* astrPostName, long anShiftNumber1, long anShiftNumber2, long anShiftNumber3, long anShiftNumber4);
long FP_EXPORT FK_GetUserInfo(long anHandleIndex, long anEnrollNumber, char** apstrUserName,  long* apnNewKind, long* apnVerifyMode, long* apnPostID, long* apnShiftNumber1, long* apnShiftNumber2, long* apnShiftNumber3, long* apnShiftNumber4);
long FP_EXPORT FK_SetUserInfo(long anHandleIndex, long anEnrollNumber, const char* astrUserName, long anNewKind,  long anVerifyMode, long anPostID, long anShiftNumber1, long anShiftNumber2, long anShiftNumber3, long anShiftNumber4);


//{----------------------------------------------------------------------------------
// Post/Shift (EXCEL version)

// max length of name buffer of post, user info
#define NAME_UTF16_CHAR_COUNT_FKDLL	64
#define NAME_BYTE_COUNT_FKDLL		(2*NAME_UTF16_CHAR_COUNT_FKDLL)

// time slot (hour, minute)
typedef struct tagTIME_SLOT_HM_FKDLL {
	unsigned char	StartH;
	unsigned char	StartM;
	unsigned char	EndH;
	unsigned char	EndM;
} TIME_SLOT_HM_FKDLL;	// size = 4 byte

// time slot of one shift (am, pm, ov)
typedef struct tagSHIFT_TIME_SLOT_FKDLL {
	TIME_SLOT_HM_FKDLL	AMTimeSlot;		// 0, 4
	TIME_SLOT_HM_FKDLL	PMTimeSlot;		// 4, 4
	TIME_SLOT_HM_FKDLL	OVTimeSlot;		// 8, 4
} SHIFT_TIME_SLOT_FKDLL;	// size = 12 Bytes

typedef struct tagPOST_NAME_FKDLL {
	unsigned char	PostName[NAME_BYTE_COUNT_FKDLL];		// 0, 128	
} POST_NAME_FKDLL;	 // 256 Bytes

#define MAX_SHIFT_COUNT_FKDLL			24
#define MAX_POST_COUNT_FKDLL			16
#define MAX_DAY_IN_MONTH_FKDLL			31

#define VER2_POST_SHIFT_INFO_FKDLL			2
#define LEN_POST_SHIFT_INFO_V2_FKDLL		2476

typedef struct tagPOST_SHIFT_INFO_FKDLL {
	DWORD		    		StructSize;									// 0, 4
	DWORD		    		StructVer;									// 4, 4
	SHIFT_TIME_SLOT_FKDLL	ShiftTime[MAX_SHIFT_COUNT_FKDLL];			// 8, 288 (=12*24)
	POST_NAME_FKDLL			Post[MAX_POST_COUNT_FKDLL];					// 296, 2048 (=128*16)
	unsigned char			CompanyName[NAME_BYTE_COUNT_FKDLL];			// 2344, 128
	unsigned char			Reserved[4];								// 2472, 4
} POST_SHIFT_INFO_FKDLL;	// size = 2476 byte

long FP_EXPORT FK_GetPostShiftInfo(long anHandleIndex, void* apPostShiftInfo,  long* apnPostShiftInfoLen);
long FP_EXPORT FK_SetPostShiftInfo(long anHandleIndex, void* apPostShiftInfo,  long anPostShiftInfoLen);

#define VER2_USER_SHIFT_INFO_FKDLL			2
#define LEN_USER_SHIFT_INFO_V2_FKDLL		184

typedef struct tagUSER_SHIFT_INFO_FKDLL
{
	DWORD	StructSize;			// 0, 4
	DWORD	StructVer;			// 4, 4
	DWORD	UserID;				// 8, 4
	DWORD	Reserved;			// 12, 4
	BYTE	NameCode[NAME_BYTE_COUNT_FKDLL];	// 16, 128
	DWORD	PostID;								// 144, 4
	WORD	YearAssigned;						// 148, 2
	WORD	MonthAssigned;						// 150, 2
	BYTE	StartWeekdayOfMonth;				// 152, 1
	BYTE	ShiftID[MAX_DAY_IN_MONTH_FKDLL];	// 153, 31	
} USER_SHIFT_INFO_FKDLL;	// size = 184 bytes


#define VER2_USER_SHIFT_INFO_STRING_ID_FKDLL			3
#define LEN_USER_SHIFT_INFO_STRING_ID_V2_FKDLL		196
#define USER_ID_LEN 16
typedef struct tagUSER_SHIFT_INFO_STRING_ID_FKDLL
{
	DWORD	StructSize;			// 0, 4
	DWORD	StructVer;			// 4, 4
	BYTE	UserID[USER_ID_LEN];				// 8, 4
	DWORD	Reserved;			// 12, 4
	BYTE	NameCode[NAME_BYTE_COUNT_FKDLL];	// 16, 128
	DWORD	PostID;								// 144, 4
	WORD	YearAssigned;						// 148, 2
	WORD	MonthAssigned;						// 150, 2
	BYTE	StartWeekdayOfMonth;				// 152, 1
	BYTE	ShiftID[MAX_DAY_IN_MONTH_FKDLL];	// 153, 31	
} USER_SHIFT_INFO_STRING_ID_FKDLL;	// size = 196 bytes

long FP_EXPORT FK_GetUserInfoEx(long anHandleIndex, long anEnrollNumber, void* apUserInfo,  long* apnUserInfoLen);
long FP_EXPORT FK_SetUserInfoEx(long anHandleIndex, long anEnrollNumber, void* apUserInfo,  long anUserInfoLen);

long FP_EXPORT FK_GetUserInfoEx_StringID(long anHandleIndex, char* apEnrollNumber, void* apUserInfo,  long* apnUserInfoLen);
long FP_EXPORT FK_SetUserInfoEx_StringID(long anHandleIndex, char* apEnrollNumber, void* apUserInfo,  long anUserInfoLen);
//}

//{----------------------------------------------------------------------------------
// Photo image transfer
long FP_EXPORT FK_GetEnrollPhoto(long anHandleIndex, long anEnrollNumber, void* apPhotoImage, long* apnPhotoLength);
long FP_EXPORT FK_SetEnrollPhoto(long anHandleIndex, long anEnrollNumber, void* apPhotoImage, long anPhotoLength);
long FP_EXPORT FK_DeleteEnrollPhoto(long anHandleIndex, long anEnrollNumber);

long FP_EXPORT FK_GetEnrollPhoto_StringID(long anHandleIndex, char* apEnrollNumber, void* apPhotoImage, long* apnPhotoLength);
long FP_EXPORT FK_SetEnrollPhoto_StringID(long anHandleIndex, char* apEnrollNumber, void* apPhotoImage, long anPhotoLength);
long FP_EXPORT FK_DeleteEnrollPhoto_StringID(long anHandleIndex, char* apEnrollNumber);

long FP_EXPORT FK_GetLogPhoto(long anHandleIndex, long anEnrollNumber, long anYear, long anMonth, long anDay, long anHour, long anMinute, long anSec, void* apPhotoImage, long* apnPhotoLength);
long FP_EXPORT FK_GetLogPhoto_StringID(long anHandleIndex, char* apEnrollNumber, long anYear, long anMonth, long anDay, long anHour, long anMinute, long anSec, void* apPhotoImage, long* apnPhotoLength);
//}

// Check whether specific enroll data type is supported on FK machine
long FP_EXPORT FK_IsSupportedEnrollData(long anHandleIndex, long anBackupNumber, long* apSupportFlag);

//{ Download file from PC to FK machine
long FP_EXPORT FK_DownloadFile(long anHandleIndex, const char* astrFileName, void* apBuffer, long anBufLen);
long FP_EXPORT FK_GetUploadFileLength(long anHandleIndex, const char* astrFileName, long* apnFileLen);
long FP_EXPORT FK_UploadFile(long anHandleIndex, const char* astrFileName, void* apBuffer, long anBufLen);
//}

//{ Access Control(Haoshun FK) function
long FP_EXPORT FK_HS_GetTimeZone(long anHandleIndex, void* apOneTimeZone);
long FP_EXPORT FK_HS_SetTimeZone(long anHandleIndex, void* apOneTimeZone);

long FP_EXPORT FK_HS_GetUserWeekPassTime(long anHandleIndex, void* apUserWeekPassTime);
long FP_EXPORT FK_HS_SetUserWeekPassTime(long anHandleIndex, void* apUserWeekPassTime);


long FP_EXPORT FK_HS_GetWeekOpenDoorTime(long anHandleIndex, void* apWeekOpenDoorTime);
long FP_EXPORT FK_HS_SetWeekOpenDoorTime(long anHandleIndex, void* apWeekOpenDoorTime);
//}

long FP_EXPORT FK_SetCurCodePage(long anHandleIndex, long anCurCodePage);

long FP_EXPORT FK_GetDeviceInfoWithString(long anHandleIndex, const char* astrFieldName, char** astrFieldValue);
long FP_EXPORT FK_SetDeviceInfoWithString(long anHandleIndex, const char* astrFieldName, const char* astrFieldValue);

// All purpose function using string
long FP_EXPORT FK_ExecCommand(long anHandleIndex, const char* astrCommand, char** apstrResult);

// All purpose function using structure
long FP_EXPORT FK_ExtCommand(long anHandleIndex, void* apCmdStruct);

long FP_EXPORT FK_ConvertToSDKData(long anHandleIndex, long anBackUpNumber,void* apInBuffer, long apInBufferSize, void* apOutBuffer, long* apOutBufferSize);
long FP_EXPORT FK_ConvertFromSDKData(long anHandleIndex, long anBackUpNumber,void* apInBuffer, long apInBufferSize, void* apOutBuffer, long* apOutBufferSize);
#endif //!_INC_FKATTENDINFO
/************************************************************************
 *                                                                      *
 *                        End of file : FKAttend.h                      *
 *                                                                      *
 ************************************************************************/