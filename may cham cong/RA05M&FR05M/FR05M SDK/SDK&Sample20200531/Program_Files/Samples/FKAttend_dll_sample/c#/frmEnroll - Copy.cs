using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace FKAttendDllCSSample
{
	/// <summary>
	/// Form3 µÄÕªÒªËµÃ÷¡£
	/// </summary>
	public class frmEnroll : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Button cmdBenumbManager;
		internal System.Windows.Forms.OpenFileDialog dlgOpen;
		internal System.Windows.Forms.SaveFileDialog dlgSave;
		public System.Windows.Forms.Button cmdUSBSetAllData;
        public System.Windows.Forms.Button cmdUSBGetAllData;
		public System.Windows.Forms.TextBox txtEnrollNumber;
		public System.Windows.Forms.Button cmdGetEnrollData;
		public System.Windows.Forms.Button cmdEmptyEnrollData;
		public System.Windows.Forms.Button cmdDisableUser;
		public System.Windows.Forms.ComboBox cmbBackupNumber;
        public System.Windows.Forms.ComboBox cmbPrivilege;
		public System.Windows.Forms.Button cmdClearData;
		public System.Windows.Forms.Button cmdSetEnrollData;
		public System.Windows.Forms.Button cmdDeleteEnrollData;
		public System.Windows.Forms.Button cmdModifyPrivilege;
		public System.Windows.Forms.Button cmdEnableUser;
		public System.Windows.Forms.Button cmdSetAllEnrollData;
		public System.Windows.Forms.Button cmdGetAllEnrollData;
		public System.Windows.Forms.Button cmdGetEnrollInfo;
		public System.Windows.Forms.ListBox lstEnrollData;
		public System.Windows.Forms.Label lblEnrollNum;
		public System.Windows.Forms.Label lblTotal;
		public System.Windows.Forms.Label lblPrivilege;
		public System.Windows.Forms.Label lblEnrollData;
		public System.Windows.Forms.Label lblBackupNumber;
        public System.Windows.Forms.Label lblMessage;
        internal Label lblDBCount;
        public Button cmdDel;
        internal HScrollBar scbAdoScroll;
        private TextBox textValue;
        private Label label1;
        private CheckBox UseChk;
		/// <summary>
		/// ±ØÐèµÄÉè¼ÆÆ÷±äÁ¿¡£
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmEnroll()
		{
			//
			// Windows ´°ÌåÉè¼ÆÆ÷Ö§³ÖËù±ØÐèµÄ
			//
			InitializeComponent();

			//
			// TODO: ÔÚ InitializeComponent µ÷ÓÃºóÌí¼ÓÈÎºÎ¹¹Ôìº¯Êý´úÂë
			//
		}

		/// <summary>
		/// ÇåÀíËùÓÐÕýÔÚÊ¹ÓÃµÄ×ÊÔ´¡£
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

		#region Windows ´°ÌåÉè¼ÆÆ÷Éú³ÉµÄ´úÂë
		/// <summary>
		/// Éè¼ÆÆ÷Ö§³ÖËùÐèµÄ·½·¨ - ²»ÒªÊ¹ÓÃ´úÂë±à¼­Æ÷ÐÞ¸Ä
		/// ´Ë·½·¨µÄÄÚÈÝ¡£
		/// </summary>
		private void InitializeComponent()
		{
this.cmdBenumbManager = new System.Windows.Forms.Button();
this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
this.dlgSave = new System.Windows.Forms.SaveFileDialog();
this.cmdUSBSetAllData = new System.Windows.Forms.Button();
this.cmdUSBGetAllData = new System.Windows.Forms.Button();
this.txtEnrollNumber = new System.Windows.Forms.TextBox();
this.cmdGetEnrollData = new System.Windows.Forms.Button();
this.cmdEmptyEnrollData = new System.Windows.Forms.Button();
this.cmdDisableUser = new System.Windows.Forms.Button();
this.cmbBackupNumber = new System.Windows.Forms.ComboBox();
this.cmbPrivilege = new System.Windows.Forms.ComboBox();
this.cmdClearData = new System.Windows.Forms.Button();
this.cmdSetEnrollData = new System.Windows.Forms.Button();
this.cmdDeleteEnrollData = new System.Windows.Forms.Button();
this.cmdModifyPrivilege = new System.Windows.Forms.Button();
this.cmdEnableUser = new System.Windows.Forms.Button();
this.cmdSetAllEnrollData = new System.Windows.Forms.Button();
this.cmdGetAllEnrollData = new System.Windows.Forms.Button();
this.cmdGetEnrollInfo = new System.Windows.Forms.Button();
this.lstEnrollData = new System.Windows.Forms.ListBox();
this.lblEnrollNum = new System.Windows.Forms.Label();
this.lblTotal = new System.Windows.Forms.Label();
this.lblPrivilege = new System.Windows.Forms.Label();
this.lblEnrollData = new System.Windows.Forms.Label();
this.lblBackupNumber = new System.Windows.Forms.Label();
this.lblMessage = new System.Windows.Forms.Label();
this.lblDBCount = new System.Windows.Forms.Label();
this.cmdDel = new System.Windows.Forms.Button();
this.scbAdoScroll = new System.Windows.Forms.HScrollBar();
this.textValue = new System.Windows.Forms.TextBox();
this.label1 = new System.Windows.Forms.Label();
this.UseChk = new System.Windows.Forms.CheckBox();
this.SuspendLayout();
// 
// cmdBenumbManager
// 
this.cmdBenumbManager.BackColor = System.Drawing.SystemColors.Control;
this.cmdBenumbManager.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdBenumbManager.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdBenumbManager.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdBenumbManager.Location = new System.Drawing.Point(255, 469);
this.cmdBenumbManager.Name = "cmdBenumbManager";
this.cmdBenumbManager.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdBenumbManager.Size = new System.Drawing.Size(216, 35);
this.cmdBenumbManager.TabIndex = 83;
this.cmdBenumbManager.Text = "Benumb All Managers";
this.cmdBenumbManager.UseVisualStyleBackColor = false;
this.cmdBenumbManager.Click += new System.EventHandler(this.cmdBenumbManager_Click);
// 
// cmdUSBSetAllData
// 
this.cmdUSBSetAllData.BackColor = System.Drawing.SystemColors.Control;
this.cmdUSBSetAllData.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdUSBSetAllData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdUSBSetAllData.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdUSBSetAllData.Location = new System.Drawing.Point(255, 312);
this.cmdUSBSetAllData.Name = "cmdUSBSetAllData";
this.cmdUSBSetAllData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdUSBSetAllData.Size = new System.Drawing.Size(216, 36);
this.cmdUSBSetAllData.TabIndex = 64;
this.cmdUSBSetAllData.Text = "Set All Enroll Data(USB)";
this.cmdUSBSetAllData.UseVisualStyleBackColor = false;
this.cmdUSBSetAllData.Click += new System.EventHandler(this.cmdUSBSetAllData_Click);
// 
// cmdUSBGetAllData
// 
this.cmdUSBGetAllData.BackColor = System.Drawing.SystemColors.Control;
this.cmdUSBGetAllData.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdUSBGetAllData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdUSBGetAllData.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdUSBGetAllData.Location = new System.Drawing.Point(255, 282);
this.cmdUSBGetAllData.Name = "cmdUSBGetAllData";
this.cmdUSBGetAllData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdUSBGetAllData.Size = new System.Drawing.Size(216, 36);
this.cmdUSBGetAllData.TabIndex = 63;
this.cmdUSBGetAllData.Text = "Get All Enroll Data(USB)";
this.cmdUSBGetAllData.UseVisualStyleBackColor = false;
this.cmdUSBGetAllData.Click += new System.EventHandler(this.cmdUSBGetAllData_Click);
// 
// txtEnrollNumber
// 
this.txtEnrollNumber.AcceptsReturn = true;
this.txtEnrollNumber.BackColor = System.Drawing.SystemColors.Window;
this.txtEnrollNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
this.txtEnrollNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtEnrollNumber.ForeColor = System.Drawing.SystemColors.WindowText;
this.txtEnrollNumber.Location = new System.Drawing.Point(151, 79);
this.txtEnrollNumber.MaxLength = 8;
this.txtEnrollNumber.Name = "txtEnrollNumber";
this.txtEnrollNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.txtEnrollNumber.Size = new System.Drawing.Size(81, 26);
this.txtEnrollNumber.TabIndex = 71;
// 
// cmdGetEnrollData
// 
this.cmdGetEnrollData.BackColor = System.Drawing.SystemColors.Control;
this.cmdGetEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdGetEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdGetEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdGetEnrollData.Location = new System.Drawing.Point(255, 79);
this.cmdGetEnrollData.Name = "cmdGetEnrollData";
this.cmdGetEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdGetEnrollData.Size = new System.Drawing.Size(216, 36);
this.cmdGetEnrollData.TabIndex = 58;
this.cmdGetEnrollData.Text = "Get Enroll Data";
this.cmdGetEnrollData.UseVisualStyleBackColor = false;
this.cmdGetEnrollData.Click += new System.EventHandler(this.cmdGetEnrollData_Click);
// 
// cmdEmptyEnrollData
// 
this.cmdEmptyEnrollData.BackColor = System.Drawing.SystemColors.Control;
this.cmdEmptyEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdEmptyEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdEmptyEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdEmptyEnrollData.Location = new System.Drawing.Point(255, 506);
this.cmdEmptyEnrollData.Name = "cmdEmptyEnrollData";
this.cmdEmptyEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdEmptyEnrollData.Size = new System.Drawing.Size(216, 36);
this.cmdEmptyEnrollData.TabIndex = 69;
this.cmdEmptyEnrollData.Text = "Empty Enroll Data";
this.cmdEmptyEnrollData.UseVisualStyleBackColor = false;
this.cmdEmptyEnrollData.Click += new System.EventHandler(this.cmdEmptyEnrollData_Click);
// 
// cmdDisableUser
// 
this.cmdDisableUser.BackColor = System.Drawing.SystemColors.Control;
this.cmdDisableUser.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdDisableUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdDisableUser.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdDisableUser.Location = new System.Drawing.Point(363, 394);
this.cmdDisableUser.Name = "cmdDisableUser";
this.cmdDisableUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdDisableUser.Size = new System.Drawing.Size(108, 37);
this.cmdDisableUser.TabIndex = 67;
this.cmdDisableUser.Text = "Disable User";
this.cmdDisableUser.UseVisualStyleBackColor = false;
this.cmdDisableUser.Click += new System.EventHandler(this.cmdDisableUser_Click);
// 
// cmbBackupNumber
// 
this.cmbBackupNumber.BackColor = System.Drawing.SystemColors.Window;
this.cmbBackupNumber.Cursor = System.Windows.Forms.Cursors.Default;
this.cmbBackupNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cmbBackupNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmbBackupNumber.ForeColor = System.Drawing.SystemColors.WindowText;
this.cmbBackupNumber.Location = new System.Drawing.Point(151, 119);
this.cmbBackupNumber.Name = "cmbBackupNumber";
this.cmbBackupNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmbBackupNumber.Size = new System.Drawing.Size(81, 27);
this.cmbBackupNumber.TabIndex = 79;
// 
// cmbPrivilege
// 
this.cmbPrivilege.BackColor = System.Drawing.SystemColors.Window;
this.cmbPrivilege.Cursor = System.Windows.Forms.Cursors.Default;
this.cmbPrivilege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cmbPrivilege.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmbPrivilege.ForeColor = System.Drawing.SystemColors.WindowText;
this.cmbPrivilege.Location = new System.Drawing.Point(151, 151);
this.cmbPrivilege.Name = "cmbPrivilege";
this.cmbPrivilege.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmbPrivilege.Size = new System.Drawing.Size(81, 27);
this.cmbPrivilege.TabIndex = 78;
// 
// cmdClearData
// 
this.cmdClearData.BackColor = System.Drawing.SystemColors.Control;
this.cmdClearData.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdClearData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdClearData.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdClearData.Location = new System.Drawing.Point(255, 543);
this.cmdClearData.Name = "cmdClearData";
this.cmdClearData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdClearData.Size = new System.Drawing.Size(216, 36);
this.cmdClearData.TabIndex = 70;
this.cmdClearData.Text = "Clear All Data(E,GL,SL) ";
this.cmdClearData.UseVisualStyleBackColor = false;
this.cmdClearData.Click += new System.EventHandler(this.cmdClearData_Click);
// 
// cmdSetEnrollData
// 
this.cmdSetEnrollData.BackColor = System.Drawing.SystemColors.Control;
this.cmdSetEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdSetEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdSetEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdSetEnrollData.Location = new System.Drawing.Point(255, 115);
this.cmdSetEnrollData.Name = "cmdSetEnrollData";
this.cmdSetEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdSetEnrollData.Size = new System.Drawing.Size(216, 36);
this.cmdSetEnrollData.TabIndex = 59;
this.cmdSetEnrollData.Text = "Set Enroll Data";
this.cmdSetEnrollData.UseVisualStyleBackColor = false;
this.cmdSetEnrollData.Click += new System.EventHandler(this.cmdSetEnrollData_Click);
// 
// cmdDeleteEnrollData
// 
this.cmdDeleteEnrollData.BackColor = System.Drawing.SystemColors.Control;
this.cmdDeleteEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdDeleteEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdDeleteEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdDeleteEnrollData.Location = new System.Drawing.Point(255, 151);
this.cmdDeleteEnrollData.Name = "cmdDeleteEnrollData";
this.cmdDeleteEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdDeleteEnrollData.Size = new System.Drawing.Size(216, 36);
this.cmdDeleteEnrollData.TabIndex = 60;
this.cmdDeleteEnrollData.Text = "Delete Enroll Data";
this.cmdDeleteEnrollData.UseVisualStyleBackColor = false;
this.cmdDeleteEnrollData.Click += new System.EventHandler(this.cmdDeleteEnrollData_Click);
// 
// cmdModifyPrivilege
// 
this.cmdModifyPrivilege.BackColor = System.Drawing.SystemColors.Control;
this.cmdModifyPrivilege.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdModifyPrivilege.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdModifyPrivilege.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdModifyPrivilege.Location = new System.Drawing.Point(255, 432);
this.cmdModifyPrivilege.Name = "cmdModifyPrivilege";
this.cmdModifyPrivilege.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdModifyPrivilege.Size = new System.Drawing.Size(216, 36);
this.cmdModifyPrivilege.TabIndex = 68;
this.cmdModifyPrivilege.Text = "ModifyPrivilege";
this.cmdModifyPrivilege.UseVisualStyleBackColor = false;
this.cmdModifyPrivilege.Click += new System.EventHandler(this.cmdModifyPrivilege_Click);
// 
// cmdEnableUser
// 
this.cmdEnableUser.BackColor = System.Drawing.SystemColors.Control;
this.cmdEnableUser.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdEnableUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdEnableUser.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdEnableUser.Location = new System.Drawing.Point(255, 394);
this.cmdEnableUser.Name = "cmdEnableUser";
this.cmdEnableUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdEnableUser.Size = new System.Drawing.Size(108, 37);
this.cmdEnableUser.TabIndex = 66;
this.cmdEnableUser.Text = "Enable User";
this.cmdEnableUser.UseVisualStyleBackColor = false;
this.cmdEnableUser.Click += new System.EventHandler(this.cmdEnableUser_Click);
// 
// cmdSetAllEnrollData
// 
this.cmdSetAllEnrollData.BackColor = System.Drawing.SystemColors.Control;
this.cmdSetAllEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdSetAllEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdSetAllEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdSetAllEnrollData.Location = new System.Drawing.Point(255, 235);
this.cmdSetAllEnrollData.Name = "cmdSetAllEnrollData";
this.cmdSetAllEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdSetAllEnrollData.Size = new System.Drawing.Size(216, 36);
this.cmdSetAllEnrollData.TabIndex = 62;
this.cmdSetAllEnrollData.Text = "Set All Enroll Data";
this.cmdSetAllEnrollData.UseVisualStyleBackColor = false;
this.cmdSetAllEnrollData.Click += new System.EventHandler(this.cmdSetAllEnrollData_Click);
// 
// cmdGetAllEnrollData
// 
this.cmdGetAllEnrollData.BackColor = System.Drawing.SystemColors.Control;
this.cmdGetAllEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdGetAllEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdGetAllEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdGetAllEnrollData.Location = new System.Drawing.Point(255, 199);
this.cmdGetAllEnrollData.Name = "cmdGetAllEnrollData";
this.cmdGetAllEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdGetAllEnrollData.Size = new System.Drawing.Size(216, 36);
this.cmdGetAllEnrollData.TabIndex = 61;
this.cmdGetAllEnrollData.Text = "Get All Enroll Data";
this.cmdGetAllEnrollData.UseVisualStyleBackColor = false;
this.cmdGetAllEnrollData.Click += new System.EventHandler(this.cmdGetAllEnrollData_Click);
// 
// cmdGetEnrollInfo
// 
this.cmdGetEnrollInfo.BackColor = System.Drawing.SystemColors.Control;
this.cmdGetEnrollInfo.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdGetEnrollInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdGetEnrollInfo.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdGetEnrollInfo.Location = new System.Drawing.Point(255, 357);
this.cmdGetEnrollInfo.Name = "cmdGetEnrollInfo";
this.cmdGetEnrollInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdGetEnrollInfo.Size = new System.Drawing.Size(216, 36);
this.cmdGetEnrollInfo.TabIndex = 65;
this.cmdGetEnrollInfo.Text = "Get Enroll Info";
this.cmdGetEnrollInfo.UseVisualStyleBackColor = false;
this.cmdGetEnrollInfo.Click += new System.EventHandler(this.cmdGetEnrollInfo_Click);
// 
// lstEnrollData
// 
this.lstEnrollData.BackColor = System.Drawing.SystemColors.Window;
this.lstEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
this.lstEnrollData.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lstEnrollData.ForeColor = System.Drawing.SystemColors.WindowText;
this.lstEnrollData.ItemHeight = 15;
this.lstEnrollData.Location = new System.Drawing.Point(15, 225);
this.lstEnrollData.Name = "lstEnrollData";
this.lstEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.lstEnrollData.Size = new System.Drawing.Size(220, 424);
this.lstEnrollData.TabIndex = 73;
// 
// lblEnrollNum
// 
this.lblEnrollNum.AutoSize = true;
this.lblEnrollNum.BackColor = System.Drawing.SystemColors.Control;
this.lblEnrollNum.Cursor = System.Windows.Forms.Cursors.Default;
this.lblEnrollNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblEnrollNum.ForeColor = System.Drawing.SystemColors.ControlText;
this.lblEnrollNum.Location = new System.Drawing.Point(15, 87);
this.lblEnrollNum.Name = "lblEnrollNum";
this.lblEnrollNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.lblEnrollNum.Size = new System.Drawing.Size(105, 19);
this.lblEnrollNum.TabIndex = 80;
this.lblEnrollNum.Text = "Enroll Number :";
// 
// lblTotal
// 
this.lblTotal.AutoSize = true;
this.lblTotal.BackColor = System.Drawing.SystemColors.Control;
this.lblTotal.Cursor = System.Windows.Forms.Cursors.Default;
this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
this.lblTotal.Location = new System.Drawing.Point(143, 197);
this.lblTotal.Name = "lblTotal";
this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.lblTotal.Size = new System.Drawing.Size(50, 19);
this.lblTotal.TabIndex = 77;
this.lblTotal.Text = "Total : ";
// 
// lblPrivilege
// 
this.lblPrivilege.AutoSize = true;
this.lblPrivilege.BackColor = System.Drawing.SystemColors.Control;
this.lblPrivilege.Cursor = System.Windows.Forms.Cursors.Default;
this.lblPrivilege.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblPrivilege.ForeColor = System.Drawing.SystemColors.ControlText;
this.lblPrivilege.Location = new System.Drawing.Point(15, 159);
this.lblPrivilege.Name = "lblPrivilege";
this.lblPrivilege.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.lblPrivilege.Size = new System.Drawing.Size(67, 19);
this.lblPrivilege.TabIndex = 76;
this.lblPrivilege.Text = "Privilege :";
// 
// lblEnrollData
// 
this.lblEnrollData.AutoSize = true;
this.lblEnrollData.BackColor = System.Drawing.SystemColors.Control;
this.lblEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
this.lblEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
this.lblEnrollData.Location = new System.Drawing.Point(15, 197);
this.lblEnrollData.Name = "lblEnrollData";
this.lblEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.lblEnrollData.Size = new System.Drawing.Size(99, 19);
this.lblEnrollData.TabIndex = 74;
this.lblEnrollData.Text = "Enrolled Data :";
// 
// lblBackupNumber
// 
this.lblBackupNumber.AutoSize = true;
this.lblBackupNumber.BackColor = System.Drawing.SystemColors.Control;
this.lblBackupNumber.Cursor = System.Windows.Forms.Cursors.Default;
this.lblBackupNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblBackupNumber.ForeColor = System.Drawing.SystemColors.ControlText;
this.lblBackupNumber.Location = new System.Drawing.Point(15, 119);
this.lblBackupNumber.Name = "lblBackupNumber";
this.lblBackupNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.lblBackupNumber.Size = new System.Drawing.Size(117, 19);
this.lblBackupNumber.TabIndex = 72;
this.lblBackupNumber.Text = "Backup Number :";
// 
// lblMessage
// 
this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
this.lblMessage.Location = new System.Drawing.Point(15, 15);
this.lblMessage.Name = "lblMessage";
this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.lblMessage.Size = new System.Drawing.Size(456, 29);
this.lblMessage.TabIndex = 75;
this.lblMessage.Text = "Message";
this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
// 
// lblDBCount
// 
this.lblDBCount.BackColor = System.Drawing.Color.White;
this.lblDBCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.lblDBCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblDBCount.ForeColor = System.Drawing.Color.Blue;
this.lblDBCount.Location = new System.Drawing.Point(31, 653);
this.lblDBCount.Name = "lblDBCount";
this.lblDBCount.Size = new System.Drawing.Size(85, 28);
this.lblDBCount.TabIndex = 87;
this.lblDBCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
// 
// cmdDel
// 
this.cmdDel.BackColor = System.Drawing.SystemColors.Control;
this.cmdDel.Cursor = System.Windows.Forms.Cursors.Default;
this.cmdDel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
this.cmdDel.Location = new System.Drawing.Point(135, 652);
this.cmdDel.Name = "cmdDel";
this.cmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
this.cmdDel.Size = new System.Drawing.Size(96, 30);
this.cmdDel.TabIndex = 86;
this.cmdDel.Text = "Delete DB";
this.cmdDel.UseVisualStyleBackColor = false;
this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
// 
// scbAdoScroll
// 
this.scbAdoScroll.LargeChange = 2;
this.scbAdoScroll.Location = new System.Drawing.Point(15, 652);
this.scbAdoScroll.Maximum = 1;
this.scbAdoScroll.Name = "scbAdoScroll";
this.scbAdoScroll.Size = new System.Drawing.Size(120, 30);
this.scbAdoScroll.TabIndex = 88;
this.scbAdoScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scbAdoScroll_Scroll);
// 
// textValue
// 
this.textValue.Location = new System.Drawing.Point(337, 618);
this.textValue.Name = "textValue";
this.textValue.Size = new System.Drawing.Size(134, 20);
this.textValue.TabIndex = 89;
// 
// label1
// 
this.label1.AutoSize = true;
this.label1.Location = new System.Drawing.Point(261, 621);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(70, 13);
this.label1.TabIndex = 90;
this.label1.Text = "Card or PWD";
// 
// UseChk
// 
this.UseChk.AutoSize = true;
this.UseChk.Location = new System.Drawing.Point(264, 595);
this.UseChk.Name = "UseChk";
this.UseChk.Size = new System.Drawing.Size(162, 17);
this.UseChk.TabIndex = 91;
this.UseChk.Text = "Check Using Pwd or CardNo";
this.UseChk.UseVisualStyleBackColor = true;
// 
// frmEnroll
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.ClientSize = new System.Drawing.Size(494, 688);
this.Controls.Add(this.UseChk);
this.Controls.Add(this.label1);
this.Controls.Add(this.textValue);
this.Controls.Add(this.lblDBCount);
this.Controls.Add(this.cmdDel);
this.Controls.Add(this.scbAdoScroll);
this.Controls.Add(this.cmdUSBGetAllData);
this.Controls.Add(this.txtEnrollNumber);
this.Controls.Add(this.lblEnrollNum);
this.Controls.Add(this.lblTotal);
this.Controls.Add(this.lblPrivilege);
this.Controls.Add(this.lblEnrollData);
this.Controls.Add(this.lblBackupNumber);
this.Controls.Add(this.cmdGetEnrollData);
this.Controls.Add(this.cmdEmptyEnrollData);
this.Controls.Add(this.cmdDisableUser);
this.Controls.Add(this.cmbBackupNumber);
this.Controls.Add(this.cmbPrivilege);
this.Controls.Add(this.cmdClearData);
this.Controls.Add(this.cmdSetEnrollData);
this.Controls.Add(this.cmdDeleteEnrollData);
this.Controls.Add(this.cmdModifyPrivilege);
this.Controls.Add(this.cmdEnableUser);
this.Controls.Add(this.cmdSetAllEnrollData);
this.Controls.Add(this.cmdGetAllEnrollData);
this.Controls.Add(this.cmdGetEnrollInfo);
this.Controls.Add(this.lstEnrollData);
this.Controls.Add(this.lblMessage);
this.Controls.Add(this.cmdBenumbManager);
this.Controls.Add(this.cmdUSBSetAllData);
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
this.MaximizeBox = false;
this.MinimizeBox = false;
this.Name = "frmEnroll";
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.Text = "Manage Enroll Data";
this.Closed += new System.EventHandler(this.frmEnroll_Closed);
this.Load += new System.EventHandler(this.frmEnroll_Load);
this.ResumeLayout(false);
this.PerformLayout();

		}
		#endregion
		
        private bool mbGetState;
        private const int FP_DATA_SIZE = 1680;
        private const int FACE_DATA_SIZE = 20080;
        private const int PWD_DATA_SIZE = 40;
        private const int PALMVEIN_DATA_SIZE = 20080;
        private byte[] mbytCurEnrollData = new byte[FACE_DATA_SIZE];
        private int mnCurPassword = 0;
        
        private const string mcstrAdoConn = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=false;Data Source=";
        private ADODB.Connection mAdoConnEnroll = new ADODB.Connection();
		private ADODB.Recordset mAdoRstEnroll = new ADODB.Recordset();
		private ADODB.Recordset mAdoRstTmp = new ADODB.Recordset();		
        private object[] mListBoxItemBackupNumber;		

		private void frmEnroll_Load(object sender, System.EventArgs e)
		{
			string vstrDBPath;
			int vnii;
            
			mbGetState = false;
			mListBoxItemBackupNumber = new object[] {
                enumBackupNumberType.BACKUP_FP_0, "Fp-0",
                enumBackupNumberType.BACKUP_FP_1, "Fp-1", 
				enumBackupNumberType.BACKUP_FP_2, "Fp-2",
                enumBackupNumberType.BACKUP_FP_3, "Fp-3", 
				enumBackupNumberType.BACKUP_FP_4, "Fp-4",
                enumBackupNumberType.BACKUP_FP_5, "Fp-5",
				enumBackupNumberType.BACKUP_FP_6, "Fp-6",
                enumBackupNumberType.BACKUP_FP_7, "Fp-7", 
				enumBackupNumberType.BACKUP_FP_8, "Fp-8",
                enumBackupNumberType.BACKUP_FP_9, "Fp-9", 
				enumBackupNumberType.BACKUP_PSW, "Pass",
                enumBackupNumberType.BACKUP_CARD, "Card",
                enumBackupNumberType.BACKUP_FACE, "Face",
                enumBackupNumberType.BACKUP_PALMVEIN_0, "PmVein-0", 
                enumBackupNumberType.BACKUP_PALMVEIN_1, "PmVein-1", 
                enumBackupNumberType.BACKUP_PALMVEIN_2, "PmVein-2", 
                enumBackupNumberType.BACKUP_PALMVEIN_3, "PmVein-3",
            };
            
			lblMessage.Text = "";
			txtEnrollNumber.Text = "1";
			
            cmbBackupNumber.Items.Clear();
            for (vnii = 1; vnii <= mListBoxItemBackupNumber.GetUpperBound(0); vnii += 2)
                cmbBackupNumber.Items.Add(mListBoxItemBackupNumber[vnii]);

			cmbBackupNumber.SelectedIndex = 0;

            cmbPrivilege.Items.Clear();
			cmbPrivilege.Items.Add("User");
			cmbPrivilege.Items.Add("Manager");
			cmbPrivilege.SelectedIndex = 0;
			
            lstEnrollData.Items.Clear();

			DBWithItemEnable(false);

            vstrDBPath = System.Windows.Forms.Application.StartupPath + "\\datEnrollDat.mdb";
			if (!File.Exists(vstrDBPath))
            {
                dlgOpen.InitialDirectory = System.Windows.Forms.Application.StartupPath;
				dlgOpen.Filter = "DB Files (*.mdb)|*.mdb|All Files (*.*)|*.*";
				dlgOpen.FilterIndex = 1;
				if (dlgOpen.ShowDialog() != DialogResult.OK) goto lbl_end;
				vstrDBPath = dlgOpen.FileName;
				dlgOpen.FileName = "";               

			}
        
			frmEnroll_Closed(sender, e);            

			mAdoConnEnroll.CommandTimeout = 300;
			mAdoConnEnroll.ConnectionTimeout = 300;                           // Set the time out.
			mAdoConnEnroll.ConnectionString = mcstrAdoConn + vstrDBPath;
			mAdoConnEnroll.Open("","","",-1);
            if (mAdoConnEnroll.State != (int)ADODB.ObjectStateEnum.adStateOpen) 
                goto lbl_end;
			mAdoRstEnroll.CacheSize = 1000;

			mAdoRstEnroll.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			mAdoRstEnroll.Open("select * from tblEnroll", mAdoConnEnroll, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockPessimistic,-1);
			if(mAdoRstEnroll.State == (int)ADODB.ObjectStateEnum.adStateOpen)
				if (!mAdoRstEnroll.BOF) mAdoRstEnroll.MoveFirst();
			AdoEnroll_MoveComplete();
								
			mAdoRstTmp.CacheSize = 1000;
			mAdoRstTmp.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			DBWithItemEnable(true);
lbl_end:
			if (frmMain.gfrmMain.gbOpenFlag == false)
				disableButtons();
			return;
		}

		private void frmEnroll_Closed(object sender, System.EventArgs e)
		{
			if(mAdoRstEnroll.State == (int)ADODB.ObjectStateEnum.adStateOpen)
				mAdoRstEnroll.Close();
			if (mAdoConnEnroll.State == (int)ADODB.ObjectStateEnum.adStateOpen)
				mAdoConnEnroll.Close();
		}

		private void scbAdoScroll_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			if (mAdoRstEnroll.RecordCount > 0 ){
				switch(e.Type)
				{
					case ScrollEventType.SmallDecrement:
						if(!mAdoRstEnroll.BOF)
						{
							mAdoRstEnroll.MovePrevious();
							if (mAdoRstEnroll.BOF) mAdoRstEnroll.MoveFirst();
						}
						break;
					case ScrollEventType.SmallIncrement:
						if(!mAdoRstEnroll.EOF)
						{
							mAdoRstEnroll.MoveNext();
							if (mAdoRstEnroll.EOF) mAdoRstEnroll.MoveLast();
						}
						break;
					default:
						return;
				}
			}
			
			AdoEnroll_MoveComplete();			
		}

		private void AdoEnroll_MoveComplete()
		{
			int vnPos;
			int vEnrollNumber = 0;
			string vEnrollName = "";
			int vBackupNumber = 0;
			int vPrivilege = (int)enumMachinePrivilege.MP_NONE;

			if (mbGetState == true) return;
			vnPos = Convert.ToInt32(mAdoRstEnroll.AbsolutePosition);
			if (vnPos < 0) vnPos = 0;
			lblDBCount.Text = "  " + vnPos + "/" + mAdoRstEnroll.RecordCount;
			if (mAdoRstEnroll.RecordCount > 0)
				readEnrollDataFromDB(ref vEnrollNumber, ref vBackupNumber, ref vPrivilege, ref vEnrollName,true);
		}

		private void cmdDel_Click(object sender, System.EventArgs e)
		{
			cmdDel.Enabled = false;
			Application.DoEvents();
			if (mAdoRstTmp.State == (int)ADODB.ObjectStateEnum.adStateOpen) mAdoRstTmp.Close();
			mAdoRstTmp.Open("Delete From tblEnroll", mAdoConnEnroll, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockPessimistic,-1);
	        mAdoRstEnroll.Requery(-1);
			AdoEnroll_MoveComplete();
			cmdDel.Enabled = true;		
		}

		private void zeroArray(byte [] aArray)
        {
            int i;
            for (i = 0; i < aArray.Length; i++)
                aArray[i] = 0;
        }

        private void cmdGetEnrollData_Click(object sender, System.EventArgs e)
		{
			int vnResultCode;
            int vEnrollNumber;
			int vBackupNumber;
			int vPrivilege = (int)enumMachinePrivilege.MP_ALL;

			cmdGetEnrollData.Enabled = false;
			lstEnrollData.Items.Clear();
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdGetEnrollData.Enabled = true;
				return;
			}

			vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
			vBackupNumber = getCurSelBackupNumberFromCombo();

            Array.Clear(mbytCurEnrollData, 0, mbytCurEnrollData.Length);
            vnResultCode = frmMain.FK_GetEnrollData(
                frmMain.gnCommHandleIndex, 
                vEnrollNumber, 
                vBackupNumber, 
                ref vPrivilege,
                mbytCurEnrollData,
                ref mnCurPassword);

			if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
			{
				if (vPrivilege == (int)enumMachinePrivilege.MP_ALL)
					cmbPrivilege.SelectedIndex = 1;
				else
					cmbPrivilege.SelectedIndex = 0;

                showEnrollDataToListbox(vBackupNumber, mbytCurEnrollData);
				lblMessage.Text = "GetEnrollData OK";
			}
			else
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
			
			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdGetEnrollData.Enabled = true;			
		}

		private void cmdSetEnrollData_Click(object sender, System.EventArgs e)
		{
			int vEnrollNumber;
			int vBackupNumber;
			int vPrivilege;
			int vnResultCode;

			cmdSetEnrollData.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

            vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
			vBackupNumber = getCurSelBackupNumberFromCombo();
			if (cmbPrivilege.SelectedIndex == 1)
				vPrivilege = (int)enumMachinePrivilege.MP_ALL;
			else
				vPrivilege = (int)enumMachinePrivilege.MP_NONE;

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdSetEnrollData.Enabled = true;
				return;
			}

               if(UseChk.Checked){
                    if(vBackupNumber == (int)enumBackupNumberType.BACKUP_PSW ||  vBackupNumber == (int)enumBackupNumberType.BACKUP_CARD)
                    {
                        if(textValue.Text.Equals("")){
                            lblMessage.Text  = "Please input value for backupnumber =" + vBackupNumber.ToString();
                            vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
                            textValue.Focus();
                            cmdSetEnrollData.Enabled = true;
                            return;
                        }
                        int vnEncryptFlag = 1;
                    int vnValue = Convert.ToInt32(textValue.Text);
                    vnResultCode = frmMain.FK_GetEncrptEnrolledData(frmMain.gnCommHandleIndex, vBackupNumber, mbytCurEnrollData, vnValue, vnEncryptFlag);
                                          
                    }
               }
            //vBackupNumber = 11;

            //frmMain.FK_GetEncrptEnrolledData(frmMain.gnCommHandleIndex, vBackupNumber, mbytCurEnrollData, 3786694070, 1);

			vnResultCode = frmMain.FK_PutEnrollData(
                frmMain.gnCommHandleIndex, 
                vEnrollNumber, 
                vBackupNumber, 
                vPrivilege, 
                mbytCurEnrollData,
                mnCurPassword);

            if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = "Saving...";
				Application.DoEvents();
				vnResultCode = frmMain.FK_SaveEnrollData(frmMain.gnCommHandleIndex);
				if(vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
					lblMessage.Text = "SetEnrollData OK";
			}

			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdSetEnrollData.Enabled = true;
		}

		private void cmdDeleteEnrollData_Click(object sender, System.EventArgs e)
		{
			int vEnrollNumber;
			int vBackupNumber;
			int vnResultCode;

			cmdDeleteEnrollData.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdDeleteEnrollData.Enabled = true;
				return;
			}

			vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
			vBackupNumber = getCurSelBackupNumberFromCombo();
			vnResultCode = frmMain.FK_DeleteEnrollData(frmMain.gnCommHandleIndex, vEnrollNumber, vBackupNumber);
			if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
				lblMessage.Text = "DeleteEnrollData OK";
			else
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdDeleteEnrollData.Enabled = true;				
		}

		private void cmdGetAllEnrollData_Click(object sender, System.EventArgs e)
		{
            int vnResultCode;
            int vEnrollNumber = 0;
            int vBackupNumber = 0;
			string vEnrollName;			
			int vPrivilege = (int)enumMachinePrivilege.MP_NONE;
			int vnEnableFlag  = 0;
			DialogResult vnMessRet;
			string vTitle;			

			cmdGetAllEnrollData.Enabled = false;
			lstEnrollData.Items.Clear();
			vTitle = this.Text;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode !=(int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdGetAllEnrollData.Enabled = true;;
				return;
			}

			vnResultCode = frmMain.FK_ReadAllUserID(frmMain.gnCommHandleIndex);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
				frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
				cmdGetAllEnrollData.Enabled = true;
				return;
			}

			//---- Get Enroll data and save into database -------------
			Cursor = Cursors.WaitCursor;
			mbGetState = true;
			do {
				vEnrollName = new string((char)0x20, 256);
lbl_GetNext:
				vnResultCode = frmMain.FK_GetAllUserID(
                    frmMain.gnCommHandleIndex, 
                    ref vEnrollNumber, 
                    ref vBackupNumber, 
                    ref vPrivilege, 
                    ref vnEnableFlag);
				if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
				{
					if (vnResultCode == (int)enumErrorCode.RUNERR_DATAARRAY_END)
						vnResultCode = (int)enumErrorCode.RUN_SUCCESS;
					break;
				}
lbl_Retry:
				vnResultCode = frmMain.FK_GetEnrollData(
                    frmMain.gnCommHandleIndex, 
                    vEnrollNumber, 
                    vBackupNumber, 
                    ref vPrivilege, 
                    mbytCurEnrollData,
                    ref mnCurPassword);
				
                if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
				{
					vnMessRet = MessageBox.Show(
                        frmMain.ReturnResultPrint(vnResultCode) + ": Retry (y) / Get Next (n) ?", 
                        "GetEnrollData", 
                        MessageBoxButtons.YesNoCancel);
					if (vnMessRet == DialogResult.Yes)
                        goto lbl_Retry;
                    else if (vnMessRet == DialogResult.No)
                        goto lbl_GetNext;
					else if (vnMessRet == DialogResult.Cancel)
						break;
					
				}

				saveEnrollDataToDB(
                    vEnrollNumber, 
                    vBackupNumber, 
                    vPrivilege, 
                    vEnrollName);
				this.Text = vEnrollNumber.ToString("0000#");
				Application.DoEvents();
			}
			while(true);
			mbGetState = false;
			Application.DoEvents();

			if (mAdoRstEnroll.RecordCount > 1)
			{
				mAdoRstEnroll.MoveFirst();
				mAdoRstEnroll.MoveLast();
			}

			this.Text = vTitle;
			Cursor = Cursors.Default;

			if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
				lblMessage.Text = "GetAllEnrollData OK";
			else
				lblMessage.Text = "GetAllEnrollData Error : " + frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdGetAllEnrollData.Enabled = true;			
		}

		private void cmdSetAllEnrollData_Click(object sender, System.EventArgs e)
		{
            int vnResultCode;
            int vEnrollNumber = 0;
			string vEnrollName = "";
			int vBackupNumber = 0;
			int vPrivilege = (int)enumMachinePrivilege.MP_NONE;
			DialogResult vnMessRet;
			string vStr = "";
			string vTitle;			
			bool vbRet;

			cmdSetAllEnrollData.Enabled = false;
			lstEnrollData.Items.Clear();
			vTitle = this.Text;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdSetAllEnrollData.Enabled = true;
				return;
			}

			mbGetState = true;
			Cursor = Cursors.WaitCursor;

			if (mAdoRstEnroll.RecordCount > 0)
			{
				mAdoRstEnroll.MoveLast();
				mAdoRstEnroll.MoveFirst();
				do
				{
lbl_Retry:
					vbRet = readEnrollDataFromDB(
                        ref vEnrollNumber, 
                        ref vBackupNumber, 
                        ref vPrivilege, 
                        ref vEnrollName, 
                        false);
					if (vbRet != true)
					{
						vStr = "SetAllEnrollData Error";
						break;
					}

					vnResultCode = frmMain.FK_PutEnrollData(
                        frmMain.gnCommHandleIndex,
                        vEnrollNumber, 
                        vBackupNumber, 
                        vPrivilege, 
                        mbytCurEnrollData,
                        mnCurPassword);					
                    if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
					{
						vStr = "SetAllEnrollData Error";
						vnMessRet = MessageBox.Show(
                            frmMain.ReturnResultPrint(vnResultCode) + ": Retry (y) / Move Next (n) ?", 
                            "SetEnrollData", 
                            MessageBoxButtons.YesNoCancel);
						if (vnMessRet == DialogResult.Yes) 
                            goto lbl_Retry;
						if (vnMessRet == DialogResult.Cancel) 
                            break;
					}
					lblMessage.Text = "ID = " + vEnrollNumber.ToString("000#") + ", FpNo = " + vBackupNumber + ", Count = " + mAdoRstEnroll.AbsolutePosition;

					this.Text = mAdoRstEnroll.AbsolutePosition.ToString().Trim();
					Application.DoEvents();
					mAdoRstEnroll.MoveNext();
				} 
                while(mAdoRstEnroll.EOF == false);

			}

			this.Text = vTitle;
			Cursor = Cursors.Default;
            mbGetState = false;
			
            if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = "Saving...";
				Application.DoEvents();
				vnResultCode = frmMain.FK_SaveEnrollData(frmMain.gnCommHandleIndex);
				if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
					lblMessage.Text = "SetAllEnrollData OK";
				else
					lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
			}
			else
				lblMessage.Text = vStr + " : " + frmMain.ReturnResultPrint(vnResultCode);
			
			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdSetAllEnrollData.Enabled = true;		
		}

		private void cmdUSBGetAllData_Click(object sender, System.EventArgs e)
		{
            int vnResultCode = 0;
            int vEnrollNumber = 0;
			string vEnrollName;
			int vBackupNumber = 0;
			int vPrivilege = (int)enumMachinePrivilege.MP_NONE;
			int vnEnableFlag = 0;
			string vTitle;
			string vstrFileName;
			
            dlgOpen.InitialDirectory = Directory.GetCurrentDirectory();
			dlgOpen.Filter = "DAT Files (*.dat)|*.dat|All Files (*.*)|*.*";
			dlgOpen.FilterIndex = 1;
			if (dlgOpen.ShowDialog() != DialogResult.OK)
				return;

			vstrFileName = dlgOpen.FileName;
			dlgOpen.FileName = "";

			cmdUSBGetAllData.Enabled = false;
			lstEnrollData.Items.Clear();
			vTitle = this.Text;
			lblMessage.Text = "Working...";
			Application.DoEvents();

            frmSelectFKFirmwareVer vFrmSelectFKFirmwareVer = new frmSelectFKFirmwareVer();
            vFrmSelectFKFirmwareVer.ShowDialog();
            vnResultCode = frmMain.FK_SetUDiskFileFKModel(frmMain.gnCommHandleIndex, vFrmSelectFKFirmwareVer.FKFirmware);
            if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
            {
                lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
                cmdUSBGetAllData.Enabled = true;
                return;
            } 
            
            vnResultCode = frmMain.FK_USBReadAllEnrollDataFromFile(
                frmMain.gnCommHandleIndex, vstrFileName);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
				cmdUSBGetAllData.Enabled = true;
				return;
			}

			//---- Get Enroll data and save into database -------------
			Cursor = Cursors.WaitCursor;

			mbGetState = true;
			do
			{
				vEnrollName = new string((char)0x20, 256);

				vnResultCode = frmMain.FK_USBGetOneEnrollData(
                    frmMain.gnCommHandleIndex, 
                    ref vEnrollNumber, 
					ref vBackupNumber, 
                    ref vPrivilege, 
                    mbytCurEnrollData,
                    ref mnCurPassword, 
                    ref vnEnableFlag, 
                    ref vEnrollName);
				if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
				{
					if (vnResultCode == (int)enumErrorCode.RUNERR_DATAARRAY_END)
						vnResultCode = (int)enumErrorCode.RUN_SUCCESS;
					break;
				}

				saveEnrollDataToDB(
                    vEnrollNumber, 
                    vBackupNumber, 
                    vPrivilege,
                    vEnrollName);

				this.Text = vEnrollNumber.ToString("0000#");
				Application.DoEvents();
			}
            while(true);

			mbGetState = false;
			Application.DoEvents();
			if (mAdoRstEnroll.RecordCount > 1)
			{
				mAdoRstEnroll.MoveFirst();
				mAdoRstEnroll.MoveLast();
			}

			this.Text = vTitle;
			Cursor = Cursors.Default;

			if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
				lblMessage.Text = "GetAllEnrollData(USB) OK";
			else
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
			cmdUSBGetAllData.Enabled = true	;		
		}

		private void cmdUSBSetAllData_Click(object sender, System.EventArgs e)
		{
			int vEnrollNumber = 0;
			string vEnrollName = "";
			int vBackupNumber = 0;
			int vPrivilege = (int)enumMachinePrivilege.MP_NONE;
			DialogResult vnMessRet;
			string vstrMess;
			string vTitle;
			string vstrFileName;
			int vnEnableFlag;
			int vnResultCode = 0;
			bool vbRet;

			lstEnrollData.Items.Clear();

			vstrMess = "";
			dlgSave.InitialDirectory = Directory.GetCurrentDirectory();
			dlgSave.Filter = "DAT Files (*.dat)|*.dat|All Files (*.*)|*.*";
			dlgSave.FilterIndex = 1;
			if (dlgSave.ShowDialog() != DialogResult.OK)
				return;

			vstrFileName = dlgSave.FileName;
			dlgSave.FileName = "";

			cmdUSBSetAllData.Enabled = false;
			vTitle = this.Text;
			lblMessage.Text = "Working...";
			Application.DoEvents();

            frmSelectFKFirmwareVer vFrmSelectFKFirmwareVer = new frmSelectFKFirmwareVer();
            vFrmSelectFKFirmwareVer.ShowDialog();
            vnResultCode = frmMain.FK_SetUDiskFileFKModel(frmMain.gnCommHandleIndex, vFrmSelectFKFirmwareVer.FKFirmware);
            if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
            {
                lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
                cmdUSBSetAllData.Enabled = true;
                return;
            } 
            
            mbGetState = true;
			Cursor = Cursors.WaitCursor;

			if (mAdoRstEnroll.RecordCount > 0)
			{
				mAdoRstEnroll.MoveLast();
				mAdoRstEnroll.MoveFirst();
				do
				{ 
					vEnrollName = new string((char)0x20, 256);
lbl_Retry:
					vbRet = readEnrollDataFromDB(
                        ref vEnrollNumber, 
                        ref vBackupNumber, 
                        ref vPrivilege, 
                        ref vEnrollName, 
                        false);
					if (vbRet != true)
					{
						vstrMess = "SetAllEnrollData(USB) Error";
						break;
					}
                    vEnrollName = textValue.Text;
					vnEnableFlag = 1;
                    vnResultCode = frmMain.FK_USBSetOneEnrollData(
                        frmMain.gnCommHandleIndex, 
                        vEnrollNumber, 
                        vBackupNumber, 
                        vPrivilege, 
                        mbytCurEnrollData, 
                        mnCurPassword,
                        vnEnableFlag,
                       vEnrollName); //白云峰
					if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
					{
						vstrMess = "USBSetOneEnrollData Error";
						vnMessRet = MessageBox.Show(
                            frmMain.ReturnResultPrint(vnResultCode) + ": Retry (y) / Move Next (n) ?", 
                            vstrMess, 
                            MessageBoxButtons.YesNoCancel);
						if (vnMessRet == DialogResult.Yes) 
                            goto lbl_Retry;
						if (vnMessRet == DialogResult.Cancel) 
                            break;
					}

					lblMessage.Text = "ID = " + vEnrollNumber.ToString("000#") + ", FpNo = " +
						vBackupNumber + ", Count = " + mAdoRstEnroll.AbsolutePosition;

					this.Text = mAdoRstEnroll.AbsolutePosition.ToString().Trim();
					Application.DoEvents();
					mAdoRstEnroll.MoveNext();
				}while (mAdoRstEnroll.EOF == false);
			}

			this.Text = vTitle;
			Cursor = Cursors.Default;
			mbGetState = false;
            /*frmMain.FK_GetEncrptEnrolledData(frmMain.gnCommHandleIndex, 10, mbytCurEnrollData, 111111, 1);

            vnResultCode = frmMain.FK_USBSetOneEnrollData(
                       frmMain.gnCommHandleIndex,
                       133,
                       10,
                       0,
                       mbytCurEnrollData,
                       mnCurPassword,
                       1,
                       vEnrollName);

            frmMain.FK_GetEncrptEnrolledData(frmMain.gnCommHandleIndex, 11, mbytCurEnrollData, 5200, 1);

            vnResultCode = frmMain.FK_USBSetOneEnrollData(
                       frmMain.gnCommHandleIndex,
                       19,
                       11,
                       0,
                       mbytCurEnrollData,
                       mnCurPassword,
                       1,
                       vEnrollName);
            */
			if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
			{
				vnResultCode = frmMain.FK_USBWriteAllEnrollDataToFile(frmMain.gnCommHandleIndex, vstrFileName);
				if(vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
					lblMessage.Text = "USBWriteAllEnrollDataToFile OK";
				else
					lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
			}	
			else
				lblMessage.Text = vstrMess;

			cmdUSBSetAllData.Enabled = true;			
		}


		private void cmdGetEnrollInfo_Click(object sender, System.EventArgs e)
		{
			int vEnrollNumber = 0;
			int vBackupNumber = 0;
			string vstrBackupNumber;
			int vPrivilege = (int)enumMachinePrivilege.MP_NONE;
			string vstrPrivilege;
			int vnEnableFlag = 0;
			string vstrEnableFlag;
			int vnii;
			int vnResultCode;

			cmdGetEnrollInfo.Enabled = false;
			lblEnrollData.Text = "User IDs";
			lstEnrollData.Items.Clear();
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdGetEnrollInfo.Enabled = true;
				return;
			}

			vnResultCode = frmMain.FK_ReadAllUserID(frmMain.gnCommHandleIndex);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
				frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
				cmdGetEnrollInfo.Enabled = true;
				return;
			}

			//------ Show all enroll information ----------
			vnii = 0;
			lstEnrollData.Items.Add(" No.  EnNo    Fp   Priv   Enable");
			do
			{
				vnResultCode = frmMain.FK_GetAllUserID(frmMain.gnCommHandleIndex, ref vEnrollNumber,ref vBackupNumber, ref vPrivilege, ref vnEnableFlag);
				if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
				{
					if (vnResultCode == (int)enumErrorCode.RUNERR_DATAARRAY_END)
						vnResultCode = (int)enumErrorCode.RUN_SUCCESS;
					break;
				}

				if (vPrivilege ==(int)enumMachinePrivilege.MP_ALL)
					vstrPrivilege = "Man";
				else
					vstrPrivilege = "User";
				vstrBackupNumber = FuncStringFromBackupNumber(vBackupNumber);

				if (vnEnableFlag == 1)
					vstrEnableFlag = "E";
				else
					vstrEnableFlag = "D";
				
				lstEnrollData.Items.Add(vnii.ToString("000#") + " " + vEnrollNumber.ToString("0000000#") + " " +
					vstrBackupNumber + " " + vstrPrivilege + "     " + vstrEnableFlag);

				vnii = vnii + 1;
				lblTotal.Text = "Total : " + vnii;
				Application.DoEvents();
			}
			while(true);

			if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
				lblMessage.Text = "GetEnrollInfo OK";
			else
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdGetEnrollInfo.Enabled = true;		
		}
				
		private void FuncSetUserEnableStatus(int abEnableFlag)
        {
			int vEnrollNumber;
			int vBackupNumber;
			int vnResultCode;

			lblMessage.Text = "Working...";
			Application.DoEvents();

			vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
			vBackupNumber = getCurSelBackupNumberFromCombo();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				return;
			}

			vnResultCode = frmMain.FK_EnableUser(frmMain.gnCommHandleIndex, vEnrollNumber, vBackupNumber, abEnableFlag);
			lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
		}
		private void cmdEnableUser_Click(object sender, System.EventArgs e)
		{
			cmdEnableUser.Enabled = false;
			FuncSetUserEnableStatus(1);
			cmdEnableUser.Enabled = true;			
		}

		private void cmdDisableUser_Click(object sender, System.EventArgs e)
		{
			cmdDisableUser.Enabled = false;
			FuncSetUserEnableStatus(0);
			cmdDisableUser.Enabled = true;		
		}

		private void cmdModifyPrivilege_Click(object sender, System.EventArgs e)
		{
			int vEnrollNumber;
			int vBackupNumber;
			int vPrivilege;
			int vnResultCode;

			cmdModifyPrivilege.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
			vBackupNumber = getCurSelBackupNumberFromCombo();
			if (cmbPrivilege.SelectedIndex == 1)
				vPrivilege = (int)enumMachinePrivilege.MP_ALL;
			else
				vPrivilege = (int)enumMachinePrivilege.MP_NONE;
			
			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS){
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdModifyPrivilege.Enabled = true;
				return;
			}	

			vnResultCode = frmMain.FK_ModifyPrivilege(frmMain.gnCommHandleIndex, vEnrollNumber, vBackupNumber, vPrivilege);
			lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdModifyPrivilege.Enabled = true;			
		}

		private void cmdBenumbManager_Click(object sender, System.EventArgs e)
		{
			long vnResultCode;

			cmdBenumbManager.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdBenumbManager.Enabled = true;
				return;
			}

			vnResultCode = frmMain.FK_BenumbAllManager(frmMain.gnCommHandleIndex);
			lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdBenumbManager.Enabled = true;		
		}

		private void cmdEmptyEnrollData_Click(object sender, System.EventArgs e)
		{
			int vnResultCode;

			cmdEmptyEnrollData.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdEmptyEnrollData.Enabled = true;
				return;
			}

			vnResultCode = frmMain.FK_EmptyEnrollData(frmMain.gnCommHandleIndex);
			lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdEmptyEnrollData.Enabled = true;			
		}

		private void cmdClearData_Click(object sender, System.EventArgs e)
		{
			int vnResultCode;

			cmdClearData.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdClearData.Enabled = true;
				return;
			}

			vnResultCode = frmMain.FK_ClearKeeperData(frmMain.gnCommHandleIndex);
			if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
				lblMessage.Text = "ClearKeeperData OK";
			else
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdClearData.Enabled = true;			
		}

		private void DBWithItemEnable(bool abEnableFlag)
		{
			scbAdoScroll.Enabled = abEnableFlag;
			lblDBCount.Enabled = abEnableFlag;
			cmdDel.Enabled = abEnableFlag;
			cmdGetAllEnrollData.Enabled = abEnableFlag;
			cmdSetAllEnrollData.Enabled = abEnableFlag;
			//cmdUSBGetAllData.Enabled = abEnableFlag;
			//cmdUSBSetAllData.Enabled = abEnableFlag;
		}

		private void disableButtons()
		{
			cmdGetEnrollData.Enabled = false;
			cmdSetEnrollData.Enabled =false;
			cmdDeleteEnrollData.Enabled = false;
			cmdGetAllEnrollData.Enabled = false;
			cmdSetAllEnrollData.Enabled = false;
			cmdGetEnrollInfo.Enabled = false;
			cmdEnableUser.Enabled = false;
			cmdDisableUser.Enabled = false;
			cmdModifyPrivilege.Enabled = false;
			cmdBenumbManager.Enabled = false;
			cmdClearData.Enabled = false;
			cmdEmptyEnrollData.Enabled = false;
		}

        private void showByteArrayToListbox(ref ListBox aListBox, byte[] abytArray, uint aLenToShow)
        {
            int i, k;
            int len;
            string strItem;

            aListBox.Items.Clear();

            len = (int)aLenToShow;
            if (len > abytArray.Length)
                len = abytArray.Length;
            for (k = 0; k < len / 8; k++)
            {
                strItem = "";
                for (i = 0; i < 8; i++)
                {
                    strItem += abytArray[k * 8 + i].ToString("X2");
                    strItem += " ";
                }
                lstEnrollData.Items.Add(strItem);
            }
            strItem = "";
            for (i = k * 8; i < len; i++)
                strItem += abytArray[i].ToString("X2") + " ";

            lstEnrollData.Items.Add(strItem);
        }

        private void showEnrollDataToListbox(int anBackupNumber, byte [] abytEnrollData)
        {
            lstEnrollData.Items.Clear();
            lblEnrollData.Text = "Enrolled Data :";
            lblTotal.Text = "";

            if ((anBackupNumber == (int)enumBackupNumberType.BACKUP_PSW) ||
                (anBackupNumber == (int)enumBackupNumberType.BACKUP_CARD))
            {
                showByteArrayToListbox(ref lstEnrollData, abytEnrollData, PWD_DATA_SIZE);
            }            
            else if (anBackupNumber >= (int)enumBackupNumberType.BACKUP_FP_0 &&
                anBackupNumber <= (int)enumBackupNumberType.BACKUP_FP_9)
            {
                showByteArrayToListbox(ref lstEnrollData, abytEnrollData, FP_DATA_SIZE);
            }
            else if (anBackupNumber == (int)enumBackupNumberType.BACKUP_FACE)
            {
                showByteArrayToListbox(ref lstEnrollData, abytEnrollData, FACE_DATA_SIZE);
            }
            else if (anBackupNumber >= (int)enumBackupNumberType.BACKUP_PALMVEIN_0 && anBackupNumber <= (int)enumBackupNumberType.BACKUP_PALMVEIN_3)
            {
                showByteArrayToListbox(ref lstEnrollData, abytEnrollData, PALMVEIN_DATA_SIZE);
            }   
        }
		
        private void convFpDataToSaveInDbForCompatibility(byte [] abytSrc, ref byte [] abytDest)
        {
            int nTempLen = abytSrc.Length/4;
            int lenConvFpData = nTempLen*5;
            byte [] byteConvFpData = new byte[lenConvFpData];
            byte[] byteTemp = new byte [4];
            int k, m1;
                                    
            for (k = 0; k < nTempLen; k++)
            {
                byteTemp[0] = abytSrc[k * 4];
                byteTemp[1] = abytSrc[k * 4 + 1];
                byteTemp[2] = abytSrc[k * 4 + 2];
                byteTemp[3] = abytSrc[k * 4 + 3];
                m1 = BitConverter.ToInt32(byteTemp, 0);
                
                byteConvFpData[k*5] = 1;
                if (m1 < 0)
                {
                    if (m1 == -2147483648)
                    {
                        byteConvFpData[k * 5] = 2;
                        m1 = 2147483647;
                    }
                    else
                    {
                        byteConvFpData[k * 5] = 0;
                        m1 = -m1;
                    }                    
                }
                byteTemp = BitConverter.GetBytes(m1);
                byteConvFpData[k * 5 + 1] = byteTemp[3];
                byteConvFpData[k * 5 + 2] = byteTemp[2];
                byteConvFpData[k * 5 + 3] = byteTemp[1];
                byteConvFpData[k * 5 + 4] = byteTemp[0];
            }
            abytDest = byteConvFpData;
        }

        private void saveEnrollDataToDB(
            int anEnrollNumber, 
            int anBackupNumber, 
            int anPrivilege,
            string astrEnrollName)
		{  
			string vstrFind;
			long vnCount;
            byte[] bytEnrollData;

			vstrFind = "select count(*) from tblEnroll where EnrollNumber=" 
				+ anEnrollNumber.ToString() + " and FingerNumber=" + anBackupNumber.ToString();

            if (mAdoRstTmp.State == (int)ADODB.ObjectStateEnum.adStateOpen) mAdoRstTmp.Close();
            mAdoRstTmp.Open(vstrFind, mAdoConnEnroll, ADODB.CursorTypeEnum.adOpenStatic, 
				ADODB.LockTypeEnum.adLockPessimistic, -1);
			
            vnCount = Convert.ToInt32(mAdoRstTmp.Fields[0].Value);
            mAdoRstTmp.Close();
            if (vnCount > 0)
            {
				lblMessage.Text = "Double ID : " + anEnrollNumber.ToString("0000#") + "-" +anBackupNumber;
                lstEnrollData.Items.Add(lblMessage.Text);
                return;
            }
        	object oMissing = System.Reflection.Missing.Value;	
            mAdoRstEnroll.AddNew(oMissing,oMissing);
            mAdoRstEnroll.Fields["EnrollNumber"].Value = anEnrollNumber;
            mAdoRstEnroll.Fields["FingerNumber"].Value = anBackupNumber;
            mAdoRstEnroll.Fields["Privilige"].Value = anPrivilege;
            mAdoRstEnroll.Fields["EnrollName"].Value = (astrEnrollName).Trim();

            if ((anBackupNumber == (int)enumBackupNumberType.BACKUP_PSW) ||
                (anBackupNumber == (int)enumBackupNumberType.BACKUP_CARD))
            {
                bytEnrollData = new byte[PWD_DATA_SIZE];
                Array.Copy(mbytCurEnrollData, bytEnrollData, PWD_DATA_SIZE);
                mAdoRstEnroll.Fields["FPdata"].Value = bytEnrollData;
            }
            else if ((anBackupNumber >= (int)enumBackupNumberType.BACKUP_FP_0) &&
                (anBackupNumber <= (int)enumBackupNumberType.BACKUP_FP_9))
            {
                bytEnrollData = new byte[FP_DATA_SIZE];
                Array.Copy(mbytCurEnrollData, bytEnrollData, FP_DATA_SIZE);
                //{ convert fpdata for compatibility with old version database
                byte [] vbytConvFpData = new byte[1];
                convFpDataToSaveInDbForCompatibility(bytEnrollData, ref vbytConvFpData);
                //}
                mAdoRstEnroll.Fields["FPdata"].Value = vbytConvFpData;
            }
            else if (anBackupNumber == (int)enumBackupNumberType.BACKUP_FACE)
            {
                bytEnrollData = new byte[FACE_DATA_SIZE];
                Array.Copy(mbytCurEnrollData, bytEnrollData, FACE_DATA_SIZE);
                mAdoRstEnroll.Fields["FPdata"].Value = bytEnrollData;
            }
            else if (anBackupNumber >= (int)enumBackupNumberType.BACKUP_PALMVEIN_0 && anBackupNumber <= (int)enumBackupNumberType.BACKUP_PALMVEIN_3)
            {
                bytEnrollData = new byte[PALMVEIN_DATA_SIZE];
                Array.Copy(mbytCurEnrollData, bytEnrollData, PALMVEIN_DATA_SIZE);
                mAdoRstEnroll.Fields["FPdata"].Value = bytEnrollData;
            
            }
            
            mAdoRstEnroll.Update(oMissing,oMissing);
            mAdoRstEnroll.UpdateBatch(ADODB.AffectEnum.adAffectAll);
            AdoEnroll_MoveComplete();
            
            lblMessage.Text = anEnrollNumber.ToString("0000#") +"-" + anBackupNumber;
            txtEnrollNumber.Text = anEnrollNumber.ToString().Trim();
            cmbBackupNumber.SelectedIndex = getComboItemIndexFromBackupNumber(anBackupNumber);
            if (anPrivilege == (int)enumMachinePrivilege.MP_ALL)
                cmbPrivilege.SelectedIndex = 1;
            else
                cmbPrivilege.SelectedIndex = 0;
            
            Application.DoEvents();
		}

        private void convFpDataAfterReadFromDbForCompatibility(byte[] abytSrc, ref byte[] abytDest)
        {
            int nTempLen = abytSrc.Length / 5;
            int lenConvFpData = nTempLen * 4;
            
            if (lenConvFpData < FP_DATA_SIZE)
                lenConvFpData = FP_DATA_SIZE;

            byte[] byteConvFpData = new byte[lenConvFpData];
            byte[] byteTemp = new byte[4];
            int k, m;

            for (k = 0; k < nTempLen; k++)
            {
                byteTemp[0] = abytSrc[k * 5 + 4];
                byteTemp[1] = abytSrc[k * 5 + 3];
                byteTemp[2] = abytSrc[k * 5 + 2];
                byteTemp[3] = abytSrc[k * 5 + 1];
                m = BitConverter.ToInt32(byteTemp, 0);
                if (abytSrc[k*5] == 0)
                {
                    m = -m;
                }
                else if (abytSrc[k * 5] == 2)
                {
                    m = -2147483648;
                }
                byteTemp = BitConverter.GetBytes(m);

                byteConvFpData[k * 4 + 3] = byteTemp[3];
                byteConvFpData[k * 4 + 2] = byteTemp[2];
                byteConvFpData[k * 4 + 1] = byteTemp[1];
                byteConvFpData[k * 4 + 0] = byteTemp[0];
            }
            abytDest = byteConvFpData;
        }

        private bool readEnrollDataFromDB(
            ref int anEnrollNumber, 
            ref int anBackupNumber, 
            ref int anPrivilege,
            ref string astrEnrollName, 
            bool abdispFlag)
		{   
			if (mAdoRstEnroll.RecordCount <= 0 )
                return false;
            if(mAdoRstEnroll.AbsolutePosition <= 0)
                return false;
            if ((int)mAdoRstEnroll.Fields["EnrollNumber"].Value <= 0)
                return false;

            anEnrollNumber = (int)mAdoRstEnroll.Fields["EnrollNumber"].Value;
            txtEnrollNumber.Text =anEnrollNumber.ToString().Trim();
            anBackupNumber =(int)mAdoRstEnroll .Fields["FingerNumber"].Value;
            cmbBackupNumber.SelectedIndex = getComboItemIndexFromBackupNumber(anBackupNumber);
            anPrivilege = (int)mAdoRstEnroll.Fields["Privilige"].Value;
            if (anPrivilege == (int)enumMachinePrivilege.MP_ALL)
                cmbPrivilege.SelectedIndex = 1;
            else
                cmbPrivilege.SelectedIndex = 0;

            if ((anBackupNumber >= (int)enumBackupNumberType.BACKUP_FP_0) &&
                (anBackupNumber <= (int)enumBackupNumberType.BACKUP_FP_9))
            {
                byte[] bytConvFpData = (byte[])mAdoRstEnroll.Fields["FPdata"].Value;
                byte[] bytFpData = new byte [FP_DATA_SIZE];
                if (bytConvFpData.Length < FP_DATA_SIZE)
                {
                    Array.Clear(mbytCurEnrollData, 0, mbytCurEnrollData.Length);
                }
                else
                {
                    convFpDataAfterReadFromDbForCompatibility(bytConvFpData, ref bytFpData); // convert fpdata for compatibility with old version database
                    Array.Copy(bytFpData, mbytCurEnrollData, FP_DATA_SIZE);                    
                }
            }
            else if ((anBackupNumber == (int)enumBackupNumberType.BACKUP_PSW) ||
                (anBackupNumber == (int)enumBackupNumberType.BACKUP_CARD))
            {
                byte[] bytPwdData = (byte[])mAdoRstEnroll.Fields["FPdata"].Value;
                if (bytPwdData.Length < PWD_DATA_SIZE)
                    Array.Clear(mbytCurEnrollData, 0, mbytCurEnrollData.Length);
                else
                    Array.Copy(bytPwdData, mbytCurEnrollData, PWD_DATA_SIZE);
            }
            else if (anBackupNumber == (int)enumBackupNumberType.BACKUP_FACE)
            {
                byte[] bytFaceData = (byte[])mAdoRstEnroll.Fields["FPdata"].Value;
                if (bytFaceData.Length < FACE_DATA_SIZE)
                    Array.Clear(mbytCurEnrollData, 0, mbytCurEnrollData.Length);
                else
                    Array.Copy(bytFaceData, mbytCurEnrollData, FACE_DATA_SIZE);
            }

            else if (anBackupNumber >= (int)enumBackupNumberType.BACKUP_PALMVEIN_0 && anBackupNumber <= (int)enumBackupNumberType.BACKUP_PALMVEIN_3)
            {
                byte[] bytFaceData = (byte[])mAdoRstEnroll.Fields["FPdata"].Value;
                if (bytFaceData.Length < PALMVEIN_DATA_SIZE)
                    Array.Clear(mbytCurEnrollData, 0, mbytCurEnrollData.Length);
                else
                    Array.Copy(bytFaceData, mbytCurEnrollData, PALMVEIN_DATA_SIZE);
            
            }
            try
            {
                astrEnrollName = (string)mAdoRstEnroll.Fields["EnrollName"].Value;
            }
            catch (Exception e)
            {
                astrEnrollName = "";
            }

            if (abdispFlag == true)
                showEnrollDataToListbox(anBackupNumber, mbytCurEnrollData);
            
            return true;
		}

		private int getCurSelBackupNumberFromCombo()
		{     
			int vnIndex;

			vnIndex = cmbBackupNumber.SelectedIndex;
			if (vnIndex < 0) vnIndex = 0;
			return (int)mListBoxItemBackupNumber[vnIndex * 2];
		}

		private int getComboItemIndexFromBackupNumber(int anBackupNumber)
		{ 
			int vnii;

			for (vnii = 0;vnii<mListBoxItemBackupNumber.GetUpperBound(0);vnii+=2)
			{ 
				if ((int)mListBoxItemBackupNumber[vnii] == anBackupNumber)
				{
					return vnii / 2;
				}
	           
			}
			return -1;
		}

		private string FuncStringFromBackupNumber(int anBackupNumber)
		{    
			int vnii;
			string vRet = "        ";
					
			for (vnii = 0;vnii<mListBoxItemBackupNumber.GetUpperBound(0);vnii+=2)
			{ 
				if ((int)mListBoxItemBackupNumber[vnii] == anBackupNumber)
				{
					vRet = (string)mListBoxItemBackupNumber[vnii + 1];
					if (anBackupNumber != (int)enumBackupNumberType.BACKUP_PSW && anBackupNumber != (int)enumBackupNumberType.BACKUP_CARD)
						vRet = vRet + " ";
					return vRet;
				}
			}
			return vRet;
		}

       

       

	}
}
