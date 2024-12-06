using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FKAttendDllCSSample
{
	/// <summary>
	/// frmSystemInfo 的摘要说明。
	/// </summary>
	public class frmSystemInfo : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Button cmdGetDeviceTime;
        public System.Windows.Forms.Button cmdGetDeviceInfo;
		public System.Windows.Forms.Button PowerOffDevice;
		public System.Windows.Forms.Button cmdSetDeviceInfo;
		public System.Windows.Forms.ComboBox cmbSatus;
		public System.Windows.Forms.TextBox txtSetDevInfo;
		public System.Windows.Forms.Button cmdGetDeviceStaus;
		public System.Windows.Forms.CheckBox chkEnableDevice;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblStatus;
		public System.Windows.Forms.Label lblMessage;
		public System.Windows.Forms.Button cmdSetDeviceTime;
        public Button cmdGetMacAddress;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		public frmSystemInfo()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.cmdGetDeviceTime = new System.Windows.Forms.Button();
            this.cmdGetDeviceInfo = new System.Windows.Forms.Button();
            this.PowerOffDevice = new System.Windows.Forms.Button();
            this.cmdSetDeviceInfo = new System.Windows.Forms.Button();
            this.cmbSatus = new System.Windows.Forms.ComboBox();
            this.txtSetDevInfo = new System.Windows.Forms.TextBox();
            this.cmdGetDeviceStaus = new System.Windows.Forms.Button();
            this.chkEnableDevice = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cmdSetDeviceTime = new System.Windows.Forms.Button();
            this.cmdGetMacAddress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdGetDeviceTime
            // 
            this.cmdGetDeviceTime.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetDeviceTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetDeviceTime.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetDeviceTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetDeviceTime.Location = new System.Drawing.Point(13, 71);
            this.cmdGetDeviceTime.Name = "cmdGetDeviceTime";
            this.cmdGetDeviceTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetDeviceTime.Size = new System.Drawing.Size(130, 32);
            this.cmdGetDeviceTime.TabIndex = 21;
            this.cmdGetDeviceTime.Text = "GetDeviceTime";
            this.cmdGetDeviceTime.UseVisualStyleBackColor = false;
            this.cmdGetDeviceTime.Click += new System.EventHandler(this.cmdGetDeviceTime_Click);
            // 
            // cmdGetDeviceInfo
            // 
            this.cmdGetDeviceInfo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetDeviceInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetDeviceInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetDeviceInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetDeviceInfo.Location = new System.Drawing.Point(13, 223);
            this.cmdGetDeviceInfo.Name = "cmdGetDeviceInfo";
            this.cmdGetDeviceInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetDeviceInfo.Size = new System.Drawing.Size(130, 32);
            this.cmdGetDeviceInfo.TabIndex = 26;
            this.cmdGetDeviceInfo.Text = "GetDeviceInfo";
            this.cmdGetDeviceInfo.UseVisualStyleBackColor = false;
            this.cmdGetDeviceInfo.Click += new System.EventHandler(this.cmdGetDeviceInfo_Click);
            // 
            // PowerOffDevice
            // 
            this.PowerOffDevice.BackColor = System.Drawing.SystemColors.Control;
            this.PowerOffDevice.Cursor = System.Windows.Forms.Cursors.Default;
            this.PowerOffDevice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerOffDevice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PowerOffDevice.Location = new System.Drawing.Point(181, 71);
            this.PowerOffDevice.Name = "PowerOffDevice";
            this.PowerOffDevice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PowerOffDevice.Size = new System.Drawing.Size(130, 32);
            this.PowerOffDevice.TabIndex = 25;
            this.PowerOffDevice.Text = "ResetDevice";
            this.PowerOffDevice.UseVisualStyleBackColor = false;
            this.PowerOffDevice.Click += new System.EventHandler(this.PowerOffDevice_Click);
            // 
            // cmdSetDeviceInfo
            // 
            this.cmdSetDeviceInfo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetDeviceInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSetDeviceInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSetDeviceInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetDeviceInfo.Location = new System.Drawing.Point(181, 223);
            this.cmdSetDeviceInfo.Name = "cmdSetDeviceInfo";
            this.cmdSetDeviceInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSetDeviceInfo.Size = new System.Drawing.Size(130, 32);
            this.cmdSetDeviceInfo.TabIndex = 27;
            this.cmdSetDeviceInfo.Text = "SetDeviceInfo";
            this.cmdSetDeviceInfo.UseVisualStyleBackColor = false;
            this.cmdSetDeviceInfo.Click += new System.EventHandler(this.cmdSetDeviceInfo_Click);
            // 
            // cmbSatus
            // 
            this.cmbSatus.BackColor = System.Drawing.SystemColors.Window;
            this.cmbSatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbSatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSatus.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "40"});
            this.cmbSatus.Location = new System.Drawing.Point(121, 180);
            this.cmbSatus.Name = "cmbSatus";
            this.cmbSatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSatus.Size = new System.Drawing.Size(88, 27);
            this.cmbSatus.TabIndex = 32;
            // 
            // txtSetDevInfo
            // 
            this.txtSetDevInfo.AcceptsReturn = true;
            this.txtSetDevInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtSetDevInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSetDevInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetDevInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSetDevInfo.Location = new System.Drawing.Point(347, 180);
            this.txtSetDevInfo.MaxLength = 0;
            this.txtSetDevInfo.Name = "txtSetDevInfo";
            this.txtSetDevInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSetDevInfo.Size = new System.Drawing.Size(98, 26);
            this.txtSetDevInfo.TabIndex = 29;
            // 
            // cmdGetDeviceStaus
            // 
            this.cmdGetDeviceStaus.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetDeviceStaus.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetDeviceStaus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetDeviceStaus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetDeviceStaus.Location = new System.Drawing.Point(338, 223);
            this.cmdGetDeviceStaus.Name = "cmdGetDeviceStaus";
            this.cmdGetDeviceStaus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetDeviceStaus.Size = new System.Drawing.Size(130, 32);
            this.cmdGetDeviceStaus.TabIndex = 28;
            this.cmdGetDeviceStaus.Text = "GetDeviceStatus";
            this.cmdGetDeviceStaus.UseVisualStyleBackColor = false;
            this.cmdGetDeviceStaus.Click += new System.EventHandler(this.cmdGetDeviceStaus_Click);
            // 
            // chkEnableDevice
            // 
            this.chkEnableDevice.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkEnableDevice.BackColor = System.Drawing.SystemColors.Control;
            this.chkEnableDevice.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkEnableDevice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableDevice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkEnableDevice.Location = new System.Drawing.Point(181, 109);
            this.chkEnableDevice.Name = "chkEnableDevice";
            this.chkEnableDevice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkEnableDevice.Size = new System.Drawing.Size(130, 32);
            this.chkEnableDevice.TabIndex = 23;
            this.chkEnableDevice.Text = "DisableDevice";
            this.chkEnableDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEnableDevice.UseVisualStyleBackColor = false;
            this.chkEnableDevice.CheckedChanged += new System.EventHandler(this.chkEnableDevice_Click);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(242, 185);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(99, 23);
            this.Label1.TabIndex = 33;
            this.Label1.Text = "Status Value:";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Location = new System.Drawing.Point(27, 185);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStatus.Size = new System.Drawing.Size(88, 23);
            this.lblStatus.TabIndex = 31;
            this.lblStatus.Text = "Paramerter:";
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMessage.Location = new System.Drawing.Point(13, 15);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMessage.Size = new System.Drawing.Size(463, 28);
            this.lblMessage.TabIndex = 30;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdSetDeviceTime
            // 
            this.cmdSetDeviceTime.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetDeviceTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSetDeviceTime.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSetDeviceTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetDeviceTime.Location = new System.Drawing.Point(13, 111);
            this.cmdSetDeviceTime.Name = "cmdSetDeviceTime";
            this.cmdSetDeviceTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSetDeviceTime.Size = new System.Drawing.Size(130, 32);
            this.cmdSetDeviceTime.TabIndex = 24;
            this.cmdSetDeviceTime.Text = "SetDeviceTime";
            this.cmdSetDeviceTime.UseVisualStyleBackColor = false;
            this.cmdSetDeviceTime.Click += new System.EventHandler(this.cmdSetDeviceTime_Click);
            // 
            // cmdGetMacAddress
            // 
            this.cmdGetMacAddress.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetMacAddress.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetMacAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetMacAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetMacAddress.Location = new System.Drawing.Point(338, 71);
            this.cmdGetMacAddress.Name = "cmdGetMacAddress";
            this.cmdGetMacAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetMacAddress.Size = new System.Drawing.Size(130, 32);
            this.cmdGetMacAddress.TabIndex = 34;
            this.cmdGetMacAddress.Text = "Get MAC";
            this.cmdGetMacAddress.UseVisualStyleBackColor = false;
            this.cmdGetMacAddress.Click += new System.EventHandler(this.cmdGetMacAddress_Click);
            // 
            // frmSystemInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(489, 275);
            this.Controls.Add(this.cmdGetMacAddress);
            this.Controls.Add(this.cmdGetDeviceTime);
            this.Controls.Add(this.cmdGetDeviceInfo);
            this.Controls.Add(this.PowerOffDevice);
            this.Controls.Add(this.cmdSetDeviceInfo);
            this.Controls.Add(this.cmbSatus);
            this.Controls.Add(this.txtSetDevInfo);
            this.Controls.Add(this.cmdGetDeviceStaus);
            this.Controls.Add(this.chkEnableDevice);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cmdSetDeviceTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSystemInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage System Info";
            this.Load += new System.EventHandler(this.frmSystemInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private void frmSystemInfo_Load(object sender, System.EventArgs e)
		{
			cmbSatus.SelectedIndex = 0;
		}

		private void cmdGetDeviceTime_Click(object sender, System.EventArgs e)
		{
			DateTime vdwDate = DateTime.Now;
			string strDataTime;
			int vnResultCode;

			cmdGetDeviceTime.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if(vnResultCode != (int)enumErrorCode. RUN_SUCCESS)
			{ 
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdGetDeviceTime.Enabled = true;
				return;
			}
	        
			vnResultCode = frmMain.FK_GetDeviceTime(frmMain.gnCommHandleIndex, ref vdwDate);
			if(vnResultCode ==(int)enumErrorCode. RUN_SUCCESS)
			{
				strDataTime = "Date = " + vdwDate.ToLongDateString() + ", Time = " + vdwDate.ToLongTimeString();
				lblMessage.Text = strDataTime;
			}
			else
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
	        

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdGetDeviceTime.Enabled = true;
		}

		private void cmdSetDeviceTime_Click(object sender, System.EventArgs e)
		{
			DateTime vdwDate;
			int vnResultCode;

			cmdSetDeviceTime.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if(vnResultCode != (int)enumErrorCode. RUN_SUCCESS)
            {
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdSetDeviceTime.Enabled = true;
				return;
			}

			vdwDate = DateTime.Now;
			vnResultCode = frmMain.FK_SetDeviceTime(frmMain.gnCommHandleIndex, vdwDate);
			lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdSetDeviceTime.Enabled = true;
		}
/*		private void cmdPowerOn_Click(object sender, System.EventArgs e)
		{    
			frmMain.FK_PowerOnAllDevice(frmMain.gnCommHandleIndex);
		  
		}
*/	
		private void PowerOffDevice_Click(object sender, System.EventArgs e)
		{
			int vnResultCode;

			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_PowerOffDevice(frmMain.gnCommHandleIndex);
			lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);	
		}
	
		private void chkEnableDevice_Click(object sender, System.EventArgs e)
		{
			byte vnFlag;
			int vnResultCode;

			lblMessage.Text = "Working...";
			Application.DoEvents();

			if(chkEnableDevice.CheckState == CheckState.Unchecked)
				vnFlag = 1;
			else
				vnFlag = 0;


			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex,vnFlag);
			lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			if(chkEnableDevice.CheckState == CheckState.Unchecked)
				chkEnableDevice.Text = "DisableDevice";
			else
				chkEnableDevice.Text = "EnableDevice";
        
		}
  
		private void cmdGetDeviceInfo_Click(object sender, System.EventArgs e)
		{
			int vnInfoIndex;
			int vnValue = 0;
			long vnResultCode;

			cmdGetDeviceInfo.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if(vnResultCode !=(long)enumErrorCode. RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdGetDeviceInfo.Enabled = true;
				return;
			}

			vnInfoIndex = cmbSatus.SelectedIndex + 1;
            if (vnInfoIndex == 11)
                vnInfoIndex = (int)enumGetDeviceInfo.DI_VERIFY_KIND;
            else if (vnInfoIndex == 12)
                vnInfoIndex = (int)enumGetDeviceInfo.DI_MULTIUSERS;
            else if( vnInfoIndex == 13)
                vnInfoIndex = (int)enumGetDeviceInfo.DI_NETENABLE;
            else if (vnInfoIndex == 14 )
                vnInfoIndex = (int)enumGetDeviceInfo.DI_ALARMDELAY;
            else if (vnInfoIndex == 15 )
                vnInfoIndex = (int)enumGetDeviceInfo.DI_BELLCOUNT;
            else if (vnInfoIndex == 16)
                vnInfoIndex = (int)enumGetDeviceInfo.DI_VERIFYFUNC;
        
			vnResultCode = frmMain.FK_GetDeviceInfo(frmMain.gnCommHandleIndex, vnInfoIndex, ref vnValue);
			if (vnResultCode == (long)enumErrorCode.RUN_SUCCESS)
			{   
				switch( vnInfoIndex)
				{
					case (int)enumGetDeviceInfo.DI_MANAGERS : lblMessage.Text = "ManagerCount = " + vnValue;break;
					case (int)enumGetDeviceInfo.DI_MACHINENUM : lblMessage.Text = "Machine Num = " + vnValue;break;
					case (int)enumGetDeviceInfo.DI_LANGAUGE : lblMessage.Text = "Language = " + vnValue;break;
					case (int)enumGetDeviceInfo.DI_POWEROFF_TIME : lblMessage.Text = "PowerOffTime = " + vnValue;break;
					case (int)enumGetDeviceInfo.DI_LOCK_CTRL : lblMessage.Text = "LockOperate = " + vnValue;break;
					case (int)enumGetDeviceInfo.DI_GLOG_WARNING : lblMessage.Text = "GLogWarning = " + vnValue;break;
					case (int)enumGetDeviceInfo.DI_SLOG_WARNING : lblMessage.Text = "SLogWarning = " + vnValue;break;

                    case (int)enumGetDeviceInfo.DI_BELLCOUNT: lblMessage.Text = "Bell Count = " + vnValue; break;

					case (int)enumGetDeviceInfo.DI_VERIFY_INTERVALS : lblMessage.Text = "ReVerifyTime = " + vnValue;break;
					case (int)enumGetDeviceInfo.DI_RSCOM_BPS : lblMessage.Text = "Baudrate(" +  vnValue +  ") : ";
						if(vnValue == (int)enumBaudrate.BPS_9600)
							lblMessage.Text = lblMessage.Text + "9600";
						else if(vnValue == (int)enumBaudrate.BPS_19200)
							lblMessage.Text = lblMessage.Text + "19200";
						else if(vnValue == (int)enumBaudrate.BPS_38400)
							lblMessage.Text = lblMessage.Text + "38400";
						else if(vnValue == (int)enumBaudrate.BPS_57600)
							lblMessage.Text = lblMessage.Text + "57600";
						else if(vnValue == (int)enumBaudrate.BPS_115200)
							lblMessage.Text = lblMessage.Text + "115200";
						else
							lblMessage.Text = lblMessage.Text + "--";
						break;
					case (int)enumGetDeviceInfo.DI_VERIFY_KIND : lblMessage.Text = "VerifyKind = ";
						if(vnValue == 0)
							lblMessage.Text = lblMessage.Text +"F / P / C";
						else if(vnValue == 1)
							lblMessage.Text = lblMessage.Text +"F + P";
						else if(vnValue == 2)
							lblMessage.Text = lblMessage.Text +"F + C";
						else if(vnValue == 3)
							lblMessage.Text = lblMessage.Text +"C";
						break;
					case (int)enumGetDeviceInfo.DI_DATE_SEPARATE : lblMessage.Text = "DateSeperate = " + vnValue;break;

                    case (int)enumGetDeviceInfo.DI_MULTIUSERS: lblMessage.Text = "MultiUsers = " + vnValue;break;
                    case (int)enumGetDeviceInfo.DI_NETENABLE:
                        if( vnValue == 1) 
                            lblMessage.Text = "Network Enabled.";
                         else
                            lblMessage.Text = "Network Disabled.";
                        break;
                
                    case  (int)enumGetDeviceInfo.DI_ALARMDELAY: lblMessage.Text = "Alarm Delay = " + vnValue;break;
                    case  (int)enumGetDeviceInfo.DI_SENSORDELAY: lblMessage.Text = "Sensor Delay = " + vnValue;break;
                    case  (int)enumGetDeviceInfo.DI_VERIFYFUNC:lblMessage.Text = "VerifyFunc = ";
                        if( vnValue ==0)
                            lblMessage.Text = lblMessage.Text + "All";
                        else if (vnValue == 1)
                            lblMessage.Text = lblMessage.Text + "1:N";
                        else if (vnValue == 2)
                            lblMessage.Text = lblMessage.Text + "1:1";
                        break;
            		default : lblMessage.Text = "--";break;
				}
			}
			else
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdGetDeviceInfo.Enabled = true;	
		}

		private void cmdSetDeviceInfo_Click(object sender, System.EventArgs e)
		{
			int vnInfoIndex;
			int vnValue = 0;
			int vnResultCode;
            
			cmdSetDeviceInfo.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();
            
			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if(vnResultCode != (long)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdSetDeviceInfo.Enabled = true;
				return;
			}
            
			vnInfoIndex = cmbSatus.SelectedIndex + 1;

			if(frmMain.IsNumeric(txtSetDevInfo.Text))
				vnValue = Convert.ToInt32(txtSetDevInfo.Text);
            if (vnInfoIndex == 11)
                vnInfoIndex = (int)enumGetDeviceInfo.DI_VERIFY_KIND;
            else if (vnInfoIndex == 12)
                vnInfoIndex = (int)enumGetDeviceInfo.DI_MULTIUSERS;
            else if (vnInfoIndex == 13)
                vnInfoIndex = (int)enumGetDeviceInfo.DI_NETENABLE;
            else if (vnInfoIndex == 14)
                vnInfoIndex = (int)enumGetDeviceInfo.DI_ALARMDELAY;
            else if (vnInfoIndex == 15)
                vnInfoIndex = (int)enumGetDeviceInfo.DI_BELLCOUNT;
            else if (vnInfoIndex == 16)
                vnInfoIndex = (int)enumGetDeviceInfo.DI_VERIFYFUNC;

			vnResultCode = frmMain.FK_SetDeviceInfo(frmMain.gnCommHandleIndex, vnInfoIndex, vnValue);
			if(vnInfoIndex == (int)enumGetDeviceInfo.DI_MACHINENUM && vnResultCode == (long)enumErrorCode.RUN_SUCCESS)
			{
				frmMain.gfrmMain.txtMachineNumber.Text = vnValue.ToString();
			}
			lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
            
			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdSetDeviceInfo.Enabled = true;
		}
		private void cmdGetDeviceStaus_Click(object sender, System.EventArgs e)
		{
			int vnStatusIndex;
			int vnValue = 0;
			int vnResultCode;
        
			cmdGetDeviceStaus.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if(vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdGetDeviceStaus.Enabled = true;
				return;
			}

			vnStatusIndex = cmbSatus.SelectedIndex + 1;

            if (vnStatusIndex == 17)
                vnStatusIndex = (int)enumGetDeviceStatus.GET_PALMVEIN;

            vnResultCode = frmMain.FK_GetDeviceStatus(frmMain.gnCommHandleIndex, vnStatusIndex, ref vnValue);
			if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
			{
				switch(vnStatusIndex)
				{
					case (int)enumGetDeviceStatus.GET_MANAGERS : lblMessage.Text = "Manager count = " + vnValue;break;
					case (int)enumGetDeviceStatus.GET_USERS : lblMessage.Text = "User count = " + vnValue;break;
					case (int)enumGetDeviceStatus.GET_FPS : lblMessage.Text = "Fp count = " + vnValue;break;
					case (int)enumGetDeviceStatus.GET_PSWS : lblMessage.Text = "Password count = " + vnValue;break;
					case (int)enumGetDeviceStatus.GET_SLOGS : lblMessage.Text = "SLog count = " + vnValue;break;
					case (int)enumGetDeviceStatus.GET_GLOGS : lblMessage.Text = "GLog count = " + vnValue;break;
					case (int)enumGetDeviceStatus.GET_ASLOGS : lblMessage.Text = "All SLog count = " + vnValue;break;
					case (int)enumGetDeviceStatus.GET_AGLOGS : lblMessage.Text = "All GLog count = " + vnValue;break;
					case (int)enumGetDeviceStatus.GET_CARDS : lblMessage.Text = "Card count = " + vnValue;break;
                    case (int)enumGetDeviceStatus.GET_FACES: lblMessage.Text = "Face count = " + vnValue; break;
                    case (int)enumGetDeviceStatus.GET_PALMVEIN: lblMessage.Text = "PV count = " + vnValue; break;
					case (int)enumGetDeviceStatus.GET_PHOTOS: lblMessage.Text = "Photo count = " + vnValue; break;//kks 2019.4.26 for ifkl202
					default : lblMessage.Text = "--";break;
				}
			}
			else
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);


			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdGetDeviceStaus.Enabled = true;	
		}

       

        private void cmdGetMacAddress_Click(object sender, EventArgs e)
        {
           int vnResultCode;
           int vnValue = 0;
           String MacAddr;
           cmdGetMacAddress.Enabled = false;
            lblMessage.Text = "Working...";
            Application.DoEvents();

            vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
            if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
            {
                lblMessage.Text = GlobalConstants.gstrNoDevice;
                cmdGetMacAddress.Enabled = true;
                return;
            }
            MacAddr = "";
            for (int nIndex = 0; nIndex < 6; nIndex++)
            {
                vnResultCode = frmMain.FK_GetDeviceInfo(frmMain.gnCommHandleIndex, nIndex + (int)enumGetDeviceInfo.DI_MACADDR0, ref vnValue);
                if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
                {
                    if (nIndex == 5)
                        MacAddr = MacAddr + String.Format("{0:x2}", vnValue);
                    else
                        MacAddr = MacAddr + String.Format("{0:x2}-", vnValue);
                }
                else
                {
                   lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
                   break;
                }
            }

            if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
            {
                
                lblMessage.Text = "Mac Address = " + MacAddr;
            }
            frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
            cmdGetMacAddress.Enabled = true;	
        }

	}
}
