using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
namespace FKRealSvrOcxTcpSample
{
    public partial class Form1 : Form
    {
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

            LOG_OPEN_DOOR = 64,               // Door Open
            LOG_OPEN_THREAT = 128,             // Door Open as threat
        };

        //=============== IOMode of GeneralLogData ===============//
        public enum enumGLogIOMode
        {
            LOG_IOMODE_IO = 0,
            LOG_IOMODE_IN1 = 1,
            LOG_IOMODE_OUT1 = 2,
            LOG_IOMODE_IN2 = 3,
            LOG_IOMODE_OUT2 = 4,
            LOG_IOMODE_IN3 = 5,
            LOG_IOMODE_OUT3 = 6,
            LOG_IOMODE_IN4 = 7,
            LOG_IOMODE_OUT4 = 8,
        };
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
            LOG_FORCE_OPEN_DOOR = 11,          // Door Open
            LOG_FORCE_CLOSE_DOOR_ = 12,         // Door Open
            LOG_ALARM_DOOR_ = 13,         // Door Open
        }

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


        public static String GetStringVerifyMode(Int32 nVerifyMode)
        {
            String vRet = "";
            int vByteCount = 4;
            byte[] vbyteKind = new byte[vByteCount];
            int vFirstKind, vSecondKind;
            vbyteKind = BitConverter.GetBytes(nVerifyMode);
            for (int nIndex = vByteCount - 1; nIndex >= 0; nIndex--)
            {
                vFirstKind = vSecondKind = vbyteKind[nIndex];
                vFirstKind = vFirstKind & 0xF0;
                vSecondKind = vSecondKind & 0x0F;
                vFirstKind = vFirstKind >> 4;
                if (vFirstKind == 0) break;
                if (nIndex < vByteCount - 1)
                    vRet += "+";
                switch (vFirstKind)
                {
                   
                   
                    case (int)enumVerifyKind.VK_FP: vRet += "FP"; break;
                    case (int)enumVerifyKind.VK_PASS: vRet += "PASS"; break;
                    case (int)enumVerifyKind.VK_CARD: vRet += "CARD"; break;
                    case (int)enumVerifyKind.VK_FACE: vRet += "FACE"; break;
                    case (int)enumVerifyKind.VK_FINGERVEIN: vRet += "FINGER VEIN"; break;
                    case (int)enumVerifyKind.VK_IRIS: vRet += "IRIS"; break;
                    case (int)enumVerifyKind.VK_VOICE: vRet += "VOICE"; break;
                    case (int)enumVerifyKind.VK_PALMVEIN: vRet += "PALM VEIN"; break;
                    case (int)enumVerifyKind.VK_VFACE: vRet += "VFACE"; break;
                }
                if (vSecondKind == 0) break;
                vRet += "+";
                switch (vSecondKind)
                {
                    case (int)enumVerifyKind.VK_FP: vRet += "FP"; break;
                    case (int)enumVerifyKind.VK_PASS: vRet += "PASS"; break;
                    case (int)enumVerifyKind.VK_CARD: vRet += "CARD"; break;
                    case (int)enumVerifyKind.VK_FACE: vRet += "FACE"; break;
                    case (int)enumVerifyKind.VK_FINGERVEIN: vRet += "FINGER VEIN"; break;
                    case (int)enumVerifyKind.VK_IRIS: vRet += "IRIS"; break;
                    case (int)enumVerifyKind.VK_VOICE: vRet += "VOICE"; break;
                    case (int)enumVerifyKind.VK_PALMVEIN: vRet += "PALM VEIN"; break;
                    case (int)enumVerifyKind.VK_VFACE: vRet += "VFACE"; break;
                }
            }
            //nVerifyMode.
            if (vRet == "") vRet = "--";
            return vRet;
        }

        public static void GetIoModeAndDoorMode(Int32 nIoMode, ref int vIoMode, ref int vDoorMode)
        {
            int vByteCount = 4;
            byte[] vbyteKind = new byte[vByteCount];
            byte[] vbyteDoorMode = new byte[vByteCount];
            vbyteKind = BitConverter.GetBytes(nIoMode);
            vIoMode = vbyteKind[0];
            for (int nIndex = 0; nIndex < 3; nIndex++)
            {
                vbyteDoorMode[nIndex] = vbyteKind[nIndex + 1];
            }
            vbyteDoorMode[3] = 0;
            vDoorMode = BitConverter.ToInt32(vbyteDoorMode, 0);


        }

        public static long GetLong(string asVal)
        {
            try
            {
                return Convert.ToInt32(asVal);
            }
            catch
            {
                return 0;
            }
        }

        public static int GetInt(string asVal)
        {
            try
            {
                return Convert.ToInt32(asVal);
            }
            catch
            {
                return 0;
            }
        }

       
       public static byte[] StringToByteArray(string hex)
       {
           return Enumerable.Range(0, hex.Length)
                            .Where(x => x % 2 == 0)
                            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                            .ToArray();
       }


        //=============== Error code ===============//
        public const int    RUN_SUCCESS = 1;
        public const int    RUNERR_NOSUPPORT = 0;
        public const int    RUNERR_UNKNOWNERROR = -1;
        public const int    RUNERR_NO_OPEN_COMM = -2;
        public const int    RUNERR_WRITE_FAIL = -3;
        public const int    RUNERR_READ_FAIL = -4;
        public const int    RUNERR_INVALID_PARAM = -5;
        public const int    RUNERR_NON_CARRYOUT = -6;
        public const int    RUNERR_DATAARRAY_END = -7;
        public const int    RUNERR_DATAARRAY_NONE = -8;
        public const int    RUNERR_MEMORY = -9;
        public const int    RUNERR_MIS_PASSWORD = -10;
        public const int    RUNERR_MEMORYOVER = -11;
        public const int    RUNERR_DATADOUBLE = -12;
        public const int    RUNERR_MANAGEROVER = -14;
        public const int    RUNERR_FPDATAVERSION = -15;

        public const string gstrNoDevice = "No Device";
        
        //==========================================//
        private bool mbOpenFlag;
        private int fnCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtHostPort.Text = "7005";   // default port to receive realtime log
            EnableButtons(true);
            SetupLogListview();
        }

        private void EnableButtons(bool aEnableFlag)
        {
            txtHostPort.Enabled = aEnableFlag;
            btnOpenPort.Enabled = aEnableFlag;
            btnClosePort.Enabled = !aEnableFlag;
        }

        private void SetupLogListview()
        {
            string[] strLogItem = new string[] {
		        "No",
		        "EnrollNo",
		        "VerifyMode",
		        "InOut",
		        "DateTime",
		        "IP",
		        "Port",
		        "DevID",
		        "SerialNo",
		        "RouterIP",
                "HolidayName",
                "DoorOpen",
                "Temperture"
	        };
                        
            lvwLogList.Items.Clear();
            lvwLogList.Columns.Clear();
            foreach (string strTmp in strLogItem)
            {
                lvwLogList.Columns.Add(strTmp, 80, HorizontalAlignment.Center);
            }

            lvwLogList.Columns[0].Width = 60;
            lvwLogList.Columns[0].TextAlign = HorizontalAlignment.Right;
            lvwLogList.Columns[1].Width = 60;
            lvwLogList.Columns[2].Width = 120;
            lvwLogList.Columns[4].Width = 140;
        }

       
        public string ReturnResultPrint(int anResultCode)
        {
            string retval = null;
            switch (anResultCode)
            {
                case RUN_SUCCESS:
                    retval = "Successful!";
                    break;
                case RUNERR_NOSUPPORT:
                    retval = "No support";
                    break;
                case RUNERR_UNKNOWNERROR:
                    retval = "Unknown error";
                    break;
                case RUNERR_NO_OPEN_COMM:
                    retval = "No Open Comm";
                    break;
                case RUNERR_WRITE_FAIL:
                    retval = "Write Error";
                    break;
                case RUNERR_READ_FAIL:
                    retval = "Read Error";
                    break;
                case RUNERR_INVALID_PARAM:
                    retval = "Parameter Error";
                    break;
                case RUNERR_NON_CARRYOUT:
                    retval = "execution of command failed";
                    break;
                case RUNERR_DATAARRAY_END:
                    retval = "End of data";
                    break;
                case RUNERR_DATAARRAY_NONE:
                    retval = "Nonexistence data";
                    break;
                case RUNERR_MEMORY:
                    retval = "Memory Allocating Error";
                    break;
                case RUNERR_MIS_PASSWORD:
                    retval = "License Error";
                    break;
                case RUNERR_MEMORYOVER:
                    retval = "full enrolldata & can`t put enrolldata";
                    break;
                case RUNERR_DATADOUBLE:
                    retval = "this ID is already  existed.";
                    break;
                case RUNERR_MANAGEROVER:
                    retval = "full manager & can`t put manager.";
                    break;
                case RUNERR_FPDATAVERSION:
                    retval = "mistake fp data version.";
                    break;
                default:
                    retval = "Unknown error";
                    break;
            }
            return retval;
        }
        private void showLogImage(String astrBuffer)
        {
            byte[] bytImg = null;
            object varImg;
            try
            {
                bytImg = StringToByteArray(astrBuffer);
                if (bytImg.Length < 1)
                    return;
                varImg = new System.Runtime.InteropServices.VariantWrapper(bytImg);
                axAxImage1.SetJpgImage(ref varImg);
            }
            catch (Exception e)
            {
            }
        }
        private bool funcShowGeneralLogDataToGrid(
            long aEnrollNumber, 
            long aVerifyMode, 
            long aInOutMode, 
            DateTime adtLog, 
            bool abDrawFlag, 
            string astrRemoteIP, 
            long anRemotePort, 
            long anDeviceID, 
            string astrSerialNo, 
            string astrRouterIP)
        {
            ListViewItem vItem;
            string strTmp = null;
            int vIoMode = 0, vDoorMode = 0, vPrevDoorMode = 0;
            vItem = new ListViewItem();
            vItem.Text = Convert.ToString(lvwLogList.Items.Count + 1);

            vItem.SubItems.Add(Convert.ToString(aEnrollNumber));

            if (aVerifyMode < 256)
            {
                switch (aVerifyMode % (int)enumGLogVerifyMode.LOG_OPEN_DOOR)
                {
                    case (int)enumGLogVerifyMode.LOG_FPVERIFY:          //1
                        strTmp = "Fp"; break;
                    case (int)enumGLogVerifyMode.LOG_PASSVERIFY:        //2
                        strTmp = "Password"; break;
                    case (int)enumGLogVerifyMode.LOG_CARDVERIFY:        //3
                        strTmp = "Card"; break;
                    case (int)enumGLogVerifyMode.LOG_FPPASS_VERIFY:     //4
                        strTmp = "Fp+Password"; break;
                    case (int)enumGLogVerifyMode.LOG_FPCARD_VERIFY:     //5
                        strTmp = "Fp+Card"; break;
                    case (int)enumGLogVerifyMode.LOG_PASSFP_VERIFY:     //6
                        strTmp = "Password+Fp"; break;
                    case (int)enumGLogVerifyMode.LOG_CARDFP_VERIFY:     //7
                        strTmp = "Card+Fp"; break;
                    case (int)enumGLogVerifyMode.LOG_FACEVERIFY:        //20
                        strTmp = "Face"; break;
                    case (int)enumGLogVerifyMode.LOG_FACECARDVERIFY:    //21
                        strTmp = "Face+Card"; break;
                    case (int)enumGLogVerifyMode.LOG_FACEPASSVERIFY:    //22
                        strTmp = "Face+Pass"; break;
                    case (int)enumGLogVerifyMode.LOG_PASSFACEVERIFY:    //23
                        strTmp = "Pass+Face"; break;
                    case (int)enumGLogVerifyMode.LOG_CARDFACEVERIFY:    //24
                        strTmp = "Card+Face"; break;
                    case (int)enumGLogVerifyMode.LOG_FACEFPVERIFY:    //25
                        strTmp = "Face+Fp"; break;


                    case (int)enumGLogVerifyMode.LOG_CLOSE_DOOR:    //10
                        vPrevDoorMode = (int)enumGLogDoorMode.LOG_CLOSE_DOOR;
                        break;
                    case (int)enumGLogVerifyMode.LOG_OPEN_HAND:    //11
                        vPrevDoorMode = (int)enumGLogDoorMode.LOG_OPEN_HAND;
                        break;
                    case (int)enumGLogVerifyMode.LOG_PROG_OPEN:    //12
                        vPrevDoorMode = (int)enumGLogDoorMode.LOG_PROG_OPEN;
                        break;
                    case (int)enumGLogVerifyMode.LOG_PROG_CLOSE:    //13
                        vPrevDoorMode = (int)enumGLogDoorMode.LOG_PROG_CLOSE;
                        break;
                    case (int)enumGLogVerifyMode.LOG_OPEN_IREGAL:    //14
                        vPrevDoorMode = (int)enumGLogDoorMode.LOG_OPEN_IREGAL;
                        break;
                    case (int)enumGLogVerifyMode.LOG_CLOSE_IREGAL:    //15
                        vPrevDoorMode = (int)enumGLogDoorMode.LOG_CLOSE_IREGAL;
                        break;
                    case (int)enumGLogVerifyMode.LOG_OPEN_COVER:    //16
                        vPrevDoorMode = (int)enumGLogDoorMode.LOG_OPEN_COVER;
                        break;
                    case (int)enumGLogVerifyMode.LOG_CLOSE_COVER:    //17
                        vPrevDoorMode = (int)enumGLogDoorMode.LOG_CLOSE_COVER;
                        break;

                    default:
                        break;

                }

                if (aVerifyMode / (int)enumGLogVerifyMode.LOG_OPEN_THREAT == 1)
                    vPrevDoorMode = (int)enumGLogDoorMode.LOG_OPEN_DOOR_THREAT;
                else if (aVerifyMode / (int)enumGLogVerifyMode.LOG_OPEN_DOOR == 1)
                    vPrevDoorMode = (int)enumGLogDoorMode.LOG_OPEN_DOOR;
            }
            else
            {
                strTmp = GetStringVerifyMode((int)aVerifyMode);
            }

            vItem.SubItems.Add(strTmp);

            GetIoModeAndDoorMode((int)aInOutMode, ref vIoMode, ref vDoorMode);
            if (vDoorMode == 0)
                vDoorMode = vPrevDoorMode;
            if (vDoorMode == 0)
                strTmp = "( " + vIoMode + " )";
            else
                strTmp = "( " + vIoMode + " ) &    ";
            switch (vDoorMode)
            {
                case (int)enumGLogDoorMode.LOG_CLOSE_DOOR:
                    strTmp += "Close Door"; break;
                case (int)enumGLogDoorMode.LOG_OPEN_HAND:
                    strTmp += "Hand Open"; break;
                case (int)enumGLogDoorMode.LOG_PROG_OPEN:
                    strTmp += "Prog Open"; break;
                case (int)enumGLogDoorMode.LOG_PROG_CLOSE:
                    strTmp += "Prog Close"; break;
                case (int)enumGLogDoorMode.LOG_OPEN_IREGAL:
                    strTmp += "Illegal Open"; break;
                case (int)enumGLogDoorMode.LOG_CLOSE_IREGAL:
                    strTmp += "Illegal Close"; break;
                case (int)enumGLogDoorMode.LOG_OPEN_COVER:
                    strTmp += "Cover Open"; break;
                case (int)enumGLogDoorMode.LOG_CLOSE_COVER:
                    strTmp += "Cover Close"; break;
                case (int)enumGLogDoorMode.LOG_OPEN_DOOR:
                    strTmp += "Open door"; break;
                case (int)enumGLogDoorMode.LOG_OPEN_DOOR_THREAT:
                    strTmp += "Open Door as Threat"; break;
                case (int)enumGLogDoorMode.LOG_ALARM_DOOR_:
                    strTmp += "Alarm Door Open"; break;
                 case (int)enumGLogDoorMode.LOG_FORCE_OPEN_DOOR:
                    strTmp += "Force Open"; break;
                
                    
                case (int)enumGLogDoorMode.LOG_FORCE_CLOSE_DOOR_:
                    strTmp += "Force Close"; break;

                //vstrTmp = "--"; break;
            }
            if (strTmp == "") strTmp = "--";

            vItem.SubItems.Add(strTmp);

            strTmp = Convert.ToString(adtLog);
            vItem.SubItems.Add(strTmp);

            vItem.SubItems.Add(astrRemoteIP);

            vItem.SubItems.Add(Convert.ToString(anRemotePort));

            vItem.SubItems.Add(Convert.ToString(anDeviceID));

            vItem.SubItems.Add(astrSerialNo);

            vItem.SubItems.Add(astrRouterIP);

            lvwLogList.Items.Add(vItem);

            if ((lvwLogList.Items.Count > 12))
            {
                lvwLogList.EnsureVisible(lvwLogList.Items.Count - 12);
            }

            lblTotal.Text = "Total : " + lvwLogList.Items.Count;
            return true;
        }

        private bool ShowGeneralLogDataToGrid(
           int anCount,
           string astrLogId,
           string astrEnrollNumber,
           string astrVerifyMode,
           string astrInOutMode,
           String adtLog,
           bool abDrawFlag,
           string astrRemoteIP,
           long anRemotePort,
           string astrDeviceID,
           string holidayName,
           string doorOpen,
           string temperature)
        {
            ListViewItem vItem;
            string strTmp = null;
            int vIoMode = 0, vDoorMode = 0;
            vItem = new ListViewItem();
            vItem.Text = Convert.ToString(lvwLogList.Items.Count + 1);

            vItem.SubItems.Add(astrEnrollNumber);



            vItem.SubItems.Add(astrVerifyMode);

            vItem.SubItems.Add(astrInOutMode);

            //strTmp = Convert.ToString(adtLog);
            vItem.SubItems.Add(adtLog);

            vItem.SubItems.Add(astrRemoteIP);

            vItem.SubItems.Add(Convert.ToString(anRemotePort));

            vItem.SubItems.Add(astrDeviceID);
            vItem.SubItems.Add("");
            vItem.SubItems.Add(astrRemoteIP);

            vItem.SubItems.Add(holidayName);

            vItem.SubItems.Add(doorOpen);

            try
            {
                float vTemp = (float)Convert.ToInt32(temperature) / 10;
                vItem.SubItems.Add(vTemp.ToString().Trim());
            }
            catch (Exception e)
            {
                vItem.SubItems.Add(" -- ");
            }

            
           

            lvwLogList.Items.Add(vItem);

            if ((lvwLogList.Items.Count > 12))
            {
                lvwLogList.EnsureVisible(lvwLogList.Items.Count - 12);
            }

            lblTotal.Text = "Total : " + lvwLogList.Items.Count;
            return true;
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {

           
            int svrPort = 0;
            int retCode = 0;

            btnOpenPort.Enabled = false;
            svrPort = Convert.ToInt32(txtHostPort.Text);
            retCode = AxRealSvrOcxTcp1.OpenNetwork(svrPort);
            if (retCode == RUN_SUCCESS)
            {
                mbOpenFlag = true;
                EnableButtons(false);
            }
            else
            {
                MessageBox.Show (ReturnResultPrint(retCode), "error");
                btnClosePort.Enabled = true;
            }

            btnClearList_Click(sender, e);
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            int svrPort = 0;

            svrPort = Convert.ToInt32(txtHostPort.Text);
            if (mbOpenFlag == true)
            {
                AxRealSvrOcxTcp1.CloseNetwork(svrPort);
                mbOpenFlag = false;
                EnableButtons(true);
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            fnCount = 0;
            lblTotal.Text = "Total : 0";
            SetupLogListview();
        }

        private void AxRealSvrOcxTcp1_OnReceiveGLogDataExtend(object sender, AxRealSvrOcxTcpLib._DRealSvrOcxTcpEvents_OnReceiveGLogDataExtendEvent e)
        {
            funcShowGeneralLogDataToGrid(e.anSEnrollNumber, e.anVerifyMode, e.anInOutMode, e.anLogDate, true, e.astrDeviceIP, e.anDevicePort, e.anDeviceID, e.astrSerialNo, e.astrRootIP);
        }

        private void AxRealSvrOcxTcp1_OnReceiveGLogTextOnDoorOpen(object sender, AxRealSvrOcxTcpLib._DRealSvrOcxTcpEvents_OnReceiveGLogTextOnDoorOpenEvent e)
        {
            String vstrLogId;
            String vstrEnrollNumber;
            String vstrDeviceID;
            String vstrVerifyMode;
            String vstrInOutMode;  
            String vstrDate;
            String vDate;
            String vstrResponse;
            String vstrEmergency;
            String vstrIsSupportStringID;
            String vStrHolidayName;
            String vStrDoorOpen;
            String vStrTemperature;
            JObject jobjTest = JObject.Parse(e.astrLogText);

            vstrLogId = jobjTest["log_id"].ToString();
            vstrEnrollNumber = jobjTest["user_id"].ToString();
            vstrDeviceID = jobjTest["fk_device_id"].ToString();
            vstrVerifyMode = jobjTest["verify_mode"].ToString();
            vstrInOutMode = jobjTest["io_mode"].ToString();
            vstrDate = jobjTest["io_time"].ToString();
            try
            {
                vStrTemperature = jobjTest["temperature"].ToString();
            }
            catch (Exception ex)
            {
                vStrTemperature = "";
            }
            try
            {
                vStrHolidayName = jobjTest["holiday_name"].ToString();
                vStrDoorOpen = jobjTest["holiday_name"].ToString();
                int vDoorOpen = Convert.ToInt32(vStrDoorOpen);
                vStrDoorOpen = (vDoorOpen > 0)? "Open":"Close";
            }
            catch (Exception ex)
            {
                vStrHolidayName = "";
                vStrDoorOpen = "";
            }
            vDate = vstrDate.Substring(0, 4) + "-"+
                    vstrDate.Substring(4, 2) + "-" +
                    vstrDate.Substring(6, 2) + " " +
                    vstrDate.Substring(8, 2) + ":" +
                    vstrDate.Substring(10, 2) + ":" +
                    vstrDate.Substring(12, 2);
            
            fnCount++;
            ShowGeneralLogDataToGrid(fnCount, vstrLogId, vstrEnrollNumber, vstrVerifyMode, vstrInOutMode, vDate, true, e.astrClientIP, e.anClientPort, vstrDeviceID, vStrHolidayName, vStrDoorOpen, vStrTemperature);
            txtStatus.Text = "Last Log :{ user_id: " + vstrEnrollNumber + ", io_time :" + vDate + "}";
            showLogImage(e.astrLogImage);
            
            JObject jobjRespond = new JObject();
            jobjRespond.Add("log_id", vstrLogId);
            jobjRespond.Add("result", "OK");
            try
            {
                vstrEmergency = jobjTest["emergency"].ToString();
                vstrIsSupportStringID = jobjTest["is_support_string_id"].ToString();

                if (vstrEmergency.Equals("yes"))
                {
                    if (txtActiveId.Text != "" && txtActiveId.Text == vstrEnrollNumber)
                    {
                        jobjRespond.Add("mode", "open");
                    }
                    else
                    {
                        jobjRespond.Add("mode", "nothing");
                    }
                }
                else
                {
                    jobjRespond.Add("mode", "nothing");
                }
            }
            catch (Exception ex)
            {
                jobjRespond.Add("mode", "nothing");
            }
            vstrResponse = jobjRespond.ToString();
            vstrResponse = vstrResponse.Replace("\n", String.Empty);
            vstrResponse = vstrResponse.Replace("\r", String.Empty);
            vstrResponse = vstrResponse.Replace("\t", String.Empty);
            AxRealSvrOcxTcp1.SendRtLogResponseV3(e.astrClientIP, e.anClientPort, vstrResponse);
        }

        private void AxRealSvrOcxTcp1_OnReceiveGLogTextAndImage(object sender, AxRealSvrOcxTcpLib._DRealSvrOcxTcpEvents_OnReceiveGLogTextAndImageEvent e)
        {
            String vstrLogId;
            String vstrEnrollNumber;
            String vstrDeviceID;
            String vstrVerifyMode;
            String vstrInOutMode;
            String vstrDate;
            String vDate;
            String vstrResponse;
            String vStrHolidayName;
            String vStrDoorOpen;
            String vStrTemperature;
            JObject jobjTest = JObject.Parse(e.astrLogText);

            vstrLogId = jobjTest["log_id"].ToString();
            vstrEnrollNumber = jobjTest["user_id"].ToString();
            vstrDeviceID = jobjTest["fk_device_id"].ToString();
            vstrVerifyMode = jobjTest["verify_mode"].ToString();
            vstrInOutMode = jobjTest["io_mode"].ToString();
            vstrDate = jobjTest["io_time"].ToString();
            vDate = vstrDate.Substring(0, 4) + "-" +
                    vstrDate.Substring(4, 2) + "-" +
                    vstrDate.Substring(6, 2) + " " +
                    vstrDate.Substring(8, 2) + ":" +
                    vstrDate.Substring(10, 2) + ":" +
                    vstrDate.Substring(12, 2);
            try
            {
                vStrTemperature = jobjTest["temperature"].ToString();
            }
            catch (Exception ex)
            {
                vStrTemperature = "";
            }
            try
            {
                vStrHolidayName = jobjTest["holiday_name"].ToString();
                vStrDoorOpen = jobjTest["door_open_status"].ToString();
                int vDoorOpen = Convert.ToInt32(vStrDoorOpen);
                vStrDoorOpen = (vDoorOpen > 0) ? "Open" : "Close";
            }
            catch (Exception ex)
            {
                vStrHolidayName = "";
                vStrDoorOpen = "";
            }
            fnCount++;
            ShowGeneralLogDataToGrid(fnCount, vstrLogId, vstrEnrollNumber, vstrVerifyMode, vstrInOutMode, vDate, true, e.astrClientIP, e.anClientPort, vstrDeviceID, vStrHolidayName, vStrDoorOpen, vStrTemperature);
            txtStatus.Text = "Last Log :{ user_id: " + vstrEnrollNumber + ", io_time :" + vDate + "}";
            JObject jobjRespond = new JObject();
            jobjRespond.Add("log_id", vstrLogId);
            jobjRespond.Add("result", "OK");
            vstrResponse = jobjRespond.ToString();
            vstrResponse = vstrResponse.Replace("\n", String.Empty);
            vstrResponse = vstrResponse.Replace("\r", String.Empty);
            vstrResponse = vstrResponse.Replace("\t", String.Empty);
            vstrResponse = vstrResponse.Replace(" ", String.Empty);
            showLogImage(e.astrLogImage);
            AxRealSvrOcxTcp1.SendResponse(e.astrClientIP, e.anClientPort, vstrResponse);
        }
    }
}
