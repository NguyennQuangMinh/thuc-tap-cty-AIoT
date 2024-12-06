using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace FKAttendDllCSSample
{
	/// <summary>
	/// Form5 的摘要说明。
	/// </summary>
	public class frmLog : System.Windows.Forms.Form
	{
		public System.Windows.Forms.CheckBox chkSave;
		public System.Windows.Forms.Button cmdUsbGlog;
		public System.Windows.Forms.Button cmdUsbSLog;
		internal System.Windows.Forms.ListView gridLogView;
		internal System.Windows.Forms.OpenFileDialog dlgOpen;
		public System.Windows.Forms.CheckBox chkReadMark;
		public System.Windows.Forms.Button cmdEmptyGLogData;
		public System.Windows.Forms.Button cmdEmptySLogData;
		public System.Windows.Forms.Button cmdGlogData;
		public System.Windows.Forms.Button cmdSLogData;
		public System.Windows.Forms.Label lblEnrollData;
		public System.Windows.Forms.Label lblTotal;
		public System.Windows.Forms.Label lblMessage;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLog()
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


		const long DEF_MAX_LOGCOUNT = 200000;    // max log data count to support by device.
		const long DEF_MAX_DISPCOUNT = 30000;     // max count to show on a grid.
		const short DEF_MUL_TWIPS = 15;

		private int fnGridHeight;
		private int fngrdIndex;
		private ListView[] fgrdLogView;
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.cmdUsbGlog = new System.Windows.Forms.Button();
            this.cmdUsbSLog = new System.Windows.Forms.Button();
            this.gridLogView = new System.Windows.Forms.ListView();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.chkReadMark = new System.Windows.Forms.CheckBox();
            this.cmdEmptyGLogData = new System.Windows.Forms.Button();
            this.cmdEmptySLogData = new System.Windows.Forms.Button();
            this.cmdGlogData = new System.Windows.Forms.Button();
            this.cmdSLogData = new System.Windows.Forms.Button();
            this.lblEnrollData = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkSave
            // 
            this.chkSave.BackColor = System.Drawing.SystemColors.Control;
            this.chkSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSave.Location = new System.Drawing.Point(438, 69);
            this.chkSave.Name = "chkSave";
            this.chkSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSave.Size = new System.Drawing.Size(104, 20);
            this.chkSave.TabIndex = 33;
            this.chkSave.Text = "Save to file";
            this.chkSave.UseVisualStyleBackColor = false;
            // 
            // cmdUsbGlog
            // 
            this.cmdUsbGlog.BackColor = System.Drawing.SystemColors.Control;
            this.cmdUsbGlog.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdUsbGlog.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUsbGlog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdUsbGlog.Location = new System.Drawing.Point(549, 430);
            this.cmdUsbGlog.Name = "cmdUsbGlog";
            this.cmdUsbGlog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdUsbGlog.Size = new System.Drawing.Size(106, 56);
            this.cmdUsbGlog.TabIndex = 27;
            this.cmdUsbGlog.Text = "Read USB GLogData";
            this.cmdUsbGlog.UseVisualStyleBackColor = false;
            this.cmdUsbGlog.Click += new System.EventHandler(this.cmdUsbGlog_Click);
            // 
            // cmdUsbSLog
            // 
            this.cmdUsbSLog.BackColor = System.Drawing.SystemColors.Control;
            this.cmdUsbSLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdUsbSLog.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUsbSLog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdUsbSLog.Location = new System.Drawing.Point(229, 430);
            this.cmdUsbSLog.Name = "cmdUsbSLog";
            this.cmdUsbSLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdUsbSLog.Size = new System.Drawing.Size(105, 56);
            this.cmdUsbSLog.TabIndex = 24;
            this.cmdUsbSLog.Text = "Read USB SLogData";
            this.cmdUsbSLog.UseVisualStyleBackColor = false;
            this.cmdUsbSLog.Click += new System.EventHandler(this.cmdUsbSLog_Click);
            // 
            // gridLogView
            // 
            this.gridLogView.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridLogView.FullRowSelect = true;
            this.gridLogView.GridLines = true;
            this.gridLogView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.gridLogView.Location = new System.Drawing.Point(14, 94);
            this.gridLogView.MultiSelect = false;
            this.gridLogView.Name = "gridLogView";
            this.gridLogView.Size = new System.Drawing.Size(644, 328);
            this.gridLogView.TabIndex = 32;
            this.gridLogView.UseCompatibleStateImageBehavior = false;
            this.gridLogView.View = System.Windows.Forms.View.Details;
            // 
            // chkReadMark
            // 
            this.chkReadMark.BackColor = System.Drawing.SystemColors.Control;
            this.chkReadMark.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkReadMark.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReadMark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkReadMark.Location = new System.Drawing.Point(557, 69);
            this.chkReadMark.Name = "chkReadMark";
            this.chkReadMark.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkReadMark.Size = new System.Drawing.Size(96, 20);
            this.chkReadMark.TabIndex = 28;
            this.chkReadMark.Text = "ReadMark";
            this.chkReadMark.UseVisualStyleBackColor = false;
            // 
            // cmdEmptyGLogData
            // 
            this.cmdEmptyGLogData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEmptyGLogData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdEmptyGLogData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEmptyGLogData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEmptyGLogData.Location = new System.Drawing.Point(442, 430);
            this.cmdEmptyGLogData.Name = "cmdEmptyGLogData";
            this.cmdEmptyGLogData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdEmptyGLogData.Size = new System.Drawing.Size(106, 56);
            this.cmdEmptyGLogData.TabIndex = 26;
            this.cmdEmptyGLogData.Text = "Empty GLogData";
            this.cmdEmptyGLogData.UseVisualStyleBackColor = false;
            this.cmdEmptyGLogData.Click += new System.EventHandler(this.cmdEmptyGLogData_Click);
            // 
            // cmdEmptySLogData
            // 
            this.cmdEmptySLogData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEmptySLogData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdEmptySLogData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEmptySLogData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEmptySLogData.Location = new System.Drawing.Point(121, 430);
            this.cmdEmptySLogData.Name = "cmdEmptySLogData";
            this.cmdEmptySLogData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdEmptySLogData.Size = new System.Drawing.Size(107, 56);
            this.cmdEmptySLogData.TabIndex = 23;
            this.cmdEmptySLogData.Text = "Empty SLogData";
            this.cmdEmptySLogData.UseVisualStyleBackColor = false;
            this.cmdEmptySLogData.Click += new System.EventHandler(this.cmdEmptySLogData_Click);
            // 
            // cmdGlogData
            // 
            this.cmdGlogData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGlogData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGlogData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGlogData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGlogData.Location = new System.Drawing.Point(335, 430);
            this.cmdGlogData.Name = "cmdGlogData";
            this.cmdGlogData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGlogData.Size = new System.Drawing.Size(106, 56);
            this.cmdGlogData.TabIndex = 25;
            this.cmdGlogData.Text = "Read GLogData";
            this.cmdGlogData.UseVisualStyleBackColor = false;
            this.cmdGlogData.Click += new System.EventHandler(this.cmdGlogData_Click);
            // 
            // cmdSLogData
            // 
            this.cmdSLogData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSLogData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSLogData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSLogData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSLogData.Location = new System.Drawing.Point(14, 430);
            this.cmdSLogData.Name = "cmdSLogData";
            this.cmdSLogData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSLogData.Size = new System.Drawing.Size(106, 56);
            this.cmdSLogData.TabIndex = 22;
            this.cmdSLogData.Text = "Read SLogData";
            this.cmdSLogData.UseVisualStyleBackColor = false;
            this.cmdSLogData.Click += new System.EventHandler(this.cmdSLogData_Click);
            // 
            // lblEnrollData
            // 
            this.lblEnrollData.AutoSize = true;
            this.lblEnrollData.BackColor = System.Drawing.SystemColors.Control;
            this.lblEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEnrollData.Location = new System.Drawing.Point(14, 70);
            this.lblEnrollData.Name = "lblEnrollData";
            this.lblEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblEnrollData.Size = new System.Drawing.Size(73, 19);
            this.lblEnrollData.TabIndex = 31;
            this.lblEnrollData.Text = "Log Data :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(124, 70);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotal.Size = new System.Drawing.Size(46, 19);
            this.lblTotal.TabIndex = 30;
            this.lblTotal.Text = "Total :";
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMessage.Location = new System.Drawing.Point(14, 21);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMessage.Size = new System.Drawing.Size(644, 28);
            this.lblMessage.TabIndex = 29;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmLog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(675, 514);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.cmdUsbGlog);
            this.Controls.Add(this.cmdUsbSLog);
            this.Controls.Add(this.gridLogView);
            this.Controls.Add(this.chkReadMark);
            this.Controls.Add(this.cmdEmptyGLogData);
            this.Controls.Add(this.cmdEmptySLogData);
            this.Controls.Add(this.cmdGlogData);
            this.Controls.Add(this.cmdSLogData);
            this.Controls.Add(this.lblEnrollData);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empty GLogData";
            this.Closed += new System.EventHandler(this.frmLog_Closed);
            this.Load += new System.EventHandler(this.frmLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmLog_Load(object sender, System.EventArgs e)
		{
			int vnii;
			long vngrdNumber;

			chkReadMark.CheckState = CheckState.Checked;
			chkSave.CheckState = CheckState.Unchecked;
			fnGridHeight = gridLogView.Height;
			vngrdNumber = DEF_MAX_LOGCOUNT / DEF_MAX_DISPCOUNT;
			if (vngrdNumber * DEF_MAX_DISPCOUNT < DEF_MAX_LOGCOUNT) vngrdNumber = vngrdNumber + 1;
			if (vngrdNumber < 0) vngrdNumber = 0;

			frmLog_Closed(sender, e);
			fgrdLogView = new ListView[vngrdNumber];
			fgrdLogView[0] = gridLogView;
			if(vngrdNumber > 0)
			{
				for (vnii = 1;vnii< vngrdNumber;vnii++)
				{
					fgrdLogView[vnii] = new ListView();
					fgrdLogView[vnii].Name = "gridListView" + vnii;
					fgrdLogView[vnii].Left = gridLogView.Left;
					fgrdLogView[vnii].Top = gridLogView.Top;
					fgrdLogView[vnii].Width = gridLogView.Width;
					fgrdLogView[vnii].Height = 0;
					fgrdLogView[vnii].HeaderStyle = ColumnHeaderStyle.None;
					fgrdLogView[vnii].View = gridLogView.View;
					fgrdLogView[vnii].GridLines = gridLogView.GridLines;
					fgrdLogView[vnii].Visible = false;
					Controls.Add(fgrdLogView[vnii]);
				}
			}
			OwnerEnableButtons(true);
		}

		private void frmLog_Closed(object sender, System.EventArgs e)
		{
			if (fgrdLogView == null) return;
			if (fgrdLogView.GetUpperBound(0) <= 0) return;
			foreach(ListView vtObject in fgrdLogView)
			{
				if (vtObject != null)
				{
					if (vtObject.Name != gridLogView.Name)
					{	
						Controls.Remove(vtObject);
						vtObject.Dispose();
					}
				}
			}	
		}
		private void cmdSLogData_Click(object sender, System.EventArgs e)
		{
			OwnerEnableButtons(false);
			funcGetSuperLogData(false);
			OwnerEnableButtons(true);	
		}

		private void cmdEmptySLogData_Click(object sender, System.EventArgs e)
		{
			int vnResultCode;
            
			cmdEmptySLogData.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();
            
			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdEmptySLogData.Enabled = true;
				return;
			}
			vnResultCode = frmMain.FK_EmptySuperLogData(frmMain.gnCommHandleIndex);
			lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
            
			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdEmptySLogData.Enabled = true;	
		}

		private void cmdUsbSLog_Click(object sender, System.EventArgs e)
		{
			OwnerEnableButtons(false);
			funcGetSuperLogData(true);
			OwnerEnableButtons(true);	
		}

		private void cmdGlogData_Click(object sender, System.EventArgs e)
		{
			OwnerEnableButtons(false);
			funcGetGeneralLogData(false);
			OwnerEnableButtons(true);		
		}

		private void cmdEmptyGLogData_Click(object sender, System.EventArgs e)
		{
			int vnResultCode;
			cmdEmptyGLogData.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();
            
			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex,0);
			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdEmptyGLogData.Enabled = true;
				return;
			}

			vnResultCode = frmMain.FK_EmptyGeneralLogData(frmMain.gnCommHandleIndex);
			lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex,1);
			cmdEmptyGLogData.Enabled = true;
		}

		private void cmdUsbGlog_Click(object sender, System.EventArgs e)
		{
			OwnerEnableButtons(false);
			funcGetGeneralLogData(true);
			OwnerEnableButtons(true);
	
		}
		private void funcGetSuperLogData(bool abUSBFlag)
		{
			int vSEnrollNumber = 0;
			int vGEnrollNumber = 0;
			int vManipulation = 0;
			int vBackupNumber = 0;
			DateTime vdwDate = DateTime.Now;
			int vnii;

			string []vstrLogItem;
			string vstrFileName;
			int vnReadMark;
			int vnResultCode;
			string vstrTmp;
			ListViewItem vtItem;
            
			vstrFileName = "";
			vstrTmp = "";
			lblMessage.Text = "Waiting...";
			lblTotal.Text = "Total : 0";
			Application.DoEvents();

			vstrLogItem = new string[] {"", "SEnrollNo", "GEnrollNo", "Manipulation", "BackupNo", "DateTime"};
			
			fgrdLogView[0].Height = fnGridHeight;
			fgrdLogView[0].Items.Clear();
			fgrdLogView[0].Columns.Clear();
			
			foreach(string vstrTmp2 in vstrLogItem)
			{
				fgrdLogView[0].Columns.Add(vstrTmp2, 80, HorizontalAlignment.Center);
			}
			fgrdLogView[0].Columns[0].Width = 48;
			fgrdLogView[0].Columns[0].TextAlign = HorizontalAlignment.Right;
			fgrdLogView[0].Columns[3].Width = 140;
			fgrdLogView[0].Columns[3].TextAlign = HorizontalAlignment.Left;
			fgrdLogView[0].Columns[5].Width = 140;
			Application.DoEvents();
		

			for (vnii = 1 ;vnii< fgrdLogView.GetUpperBound(0);vnii++)
			{
				if (fgrdLogView[vnii]!=null)
				{
					fgrdLogView[vnii].Visible = false;
					fgrdLogView[vnii].Height = 0;
					fgrdLogView[vnii].Items.Clear();
					fgrdLogView[vnii].Columns.Clear();
					foreach(ColumnHeader vtColumnHeader in fgrdLogView[0].Columns)
					{
						fgrdLogView[vnii].Columns.Add("", vtColumnHeader.Width, vtColumnHeader.TextAlign);
					}
				}
			}

			if (abUSBFlag == true)
			{
				dlgOpen.InitialDirectory = Directory.GetCurrentDirectory();
				dlgOpen.Filter = "SLog Files (*.txt)|*.txt|All Files (*.*)|*.*";
				dlgOpen.FilterIndex = 1;
				if (dlgOpen.ShowDialog() != DialogResult.OK)
					return;
				vstrFileName = dlgOpen.FileName;
				dlgOpen.FileName = "";
				if (vstrFileName == "") return;
			}
			else
			{
				vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
				if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
				{
					lblMessage.Text = GlobalConstants.gstrNoDevice;
					return;
				}
			}

			Cursor = Cursors.WaitCursor;
			Application.DoEvents();
			if (abUSBFlag == true)
				vnResultCode = frmMain.FK_USBLoadSuperLogDataFromFile(frmMain.gnCommHandleIndex, vstrFileName);
			else
			{
				if (chkReadMark.CheckState == CheckState.Checked)
					vnReadMark = 1;
				else
					vnReadMark = 0;
				
				vnResultCode = frmMain.FK_LoadSuperLogData(frmMain.gnCommHandleIndex, vnReadMark);
			}

			if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
			else
			{
				lblMessage.Text = "Getting...";
				Application.DoEvents();
				vnii = 1;
				do
				{
					vnResultCode = frmMain.FK_GetSuperLogData(frmMain.gnCommHandleIndex, ref vSEnrollNumber, 
						ref vGEnrollNumber, ref vManipulation, ref vBackupNumber, ref vdwDate);
					if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
					{
						if (vnResultCode == (int)enumErrorCode.RUNERR_DATAARRAY_END)
							vnResultCode = (int)enumErrorCode.RUN_SUCCESS;
						break;
					}
					vtItem = new ListViewItem();
					vtItem.Text = (Convert.ToString(vnii)).Trim();
					vtItem.SubItems.Add(vSEnrollNumber.ToString().Trim());
					vtItem.SubItems.Add(vGEnrollNumber.ToString().Trim());
					switch(vManipulation)
					{
						case (int)enumSuperLogInfo.LOG_ENROLL_USER:
							vstrTmp = "Enroll User";break;
						case (int)enumSuperLogInfo.LOG_ENROLL_MANAGER:
							vstrTmp = "Enroll Manager";break;
						case (int)enumSuperLogInfo.LOG_ENROLL_DELFP:
							vstrTmp = "Delete Fp Data";break;
						case (int)enumSuperLogInfo.LOG_ENROLL_DELPASS:
							vstrTmp = "Delete Password";break;
						case (int)enumSuperLogInfo.LOG_ENROLL_DELCARD:
							vstrTmp = "Delete Card Data";break;
						case (int)enumSuperLogInfo.LOG_LOG_ALLDEL:
							vstrTmp = "Delete All LogData";break;
						case (int)enumSuperLogInfo.LOG_SETUP_SYS:
							vstrTmp = "Modify System Info";break;
						case (int)enumSuperLogInfo.LOG_SETUP_TIME:
							vstrTmp = "Modify System Time";break;
						case (int)enumSuperLogInfo.LOG_SETUP_LOG:
							vstrTmp = "Modify Log Setting";break;
						case (int)enumSuperLogInfo.LOG_SETUP_COMM:
							vstrTmp = "Modify Comm Setting";break;
						case (int)enumSuperLogInfo.LOG_PASSTIME:
							vstrTmp = "Pass Time Set";break;
						case (int)enumSuperLogInfo.LOG_SETUP_DOOR:
							vstrTmp = "Door Set Log";break;
						default:
							vstrTmp = "--";break;
					}
					vtItem.SubItems.Add(vstrTmp);

					if (vBackupNumber == (int)enumBackupNumberType.BACKUP_PSW)
						vstrTmp = "Password";
					else if (vBackupNumber == (int)enumBackupNumberType.BACKUP_CARD)
						vstrTmp = "Card";
					else if (vBackupNumber < (int)enumBackupNumberType.BACKUP_PSW)
						vstrTmp = "Fp-" + vBackupNumber.ToString().Trim();
					else
						vstrTmp = "--";
		
					vtItem.SubItems.Add(vstrTmp);

					vstrTmp = vdwDate.Year + vdwDate.Month.ToString("/0#") + vdwDate.Day.ToString("/0#") + 
						vdwDate.Hour.ToString(" 0#") + vdwDate.Minute.ToString(":0#") + vdwDate.Second.ToString(":0#");

					vtItem.SubItems.Add(vstrTmp);
					fgrdLogView[0].Items.Add(vtItem);
					vtItem = null;
					lblTotal.Text = "Total : " + vnii;
					Application.DoEvents();
					vnii = vnii + 1;
				}while(true);

				if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
				{
					if (abUSBFlag == true)
						lblMessage.Text = "USBReadSuperLogDataFromFile OK";
					else
						lblMessage.Text = "ReadAllSuperLogData OK";
				}	
				else
					lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
			}

			Cursor = Cursors.Default;
			if (abUSBFlag == false)
				frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
		
		}

		private void funcGeneralLogDataGridFormat()
		{
			int vnii;
			string []  vstrLogItem;

			vstrLogItem = new string [] {"", "EnrollNo", "VerifyMode", "InOutMode", "DateTime", "Temperature"};
	
			fgrdLogView[0].Height = fnGridHeight;
			fgrdLogView[0].Items.Clear();
			fgrdLogView[0].Columns.Clear();
			foreach (string vstrTmp in vstrLogItem)fgrdLogView[0].Columns.Add(vstrTmp, 80, HorizontalAlignment.Center);

			fgrdLogView[0].Columns[0].Width = 48;
			fgrdLogView[0].Columns[0].TextAlign = HorizontalAlignment.Right;
			fgrdLogView[0].Columns[2].Width = 140;
			fgrdLogView[0].Columns[4].Width = 140;
			Application.DoEvents();


			for(vnii = 1;vnii<fgrdLogView.GetUpperBound(0);vnii++)
			{
				if (fgrdLogView[vnii] != null)
				{
					fgrdLogView[vnii].Visible = false;
					fgrdLogView[vnii].Left = fgrdLogView[0].Left;
					fgrdLogView[vnii].Top = fgrdLogView[0].Top;
					fgrdLogView[vnii].Width = fgrdLogView[0].Width;
					fgrdLogView[vnii].Height = 0;
					fgrdLogView[vnii].Items.Clear();
					fgrdLogView[vnii].Columns.Clear();
					foreach(ColumnHeader vtColumnHeader in fgrdLogView[0].Columns)
					{
						fgrdLogView[vnii].Columns.Add("", vtColumnHeader.Width, vtColumnHeader.TextAlign);
					}
					
				}
			}
			Application.DoEvents();

		}

        private string getVerifymodeToString(UInt32 anVerifyMode,ref int anGetDoorMode)
        {
            string vstrTmp = "";
            UInt32 vVerifyMode;
            anGetDoorMode = 0;
            if (anVerifyMode < 256)
            {
                vVerifyMode = anVerifyMode % (UInt32)enumGLogVerifyMode.LOG_OPEN_DOOR;

                switch (vVerifyMode)
                {
                    case (int)enumGLogVerifyMode.LOG_FPVERIFY:          //1
                        vstrTmp = "Fp"; break;
                    case (int)enumGLogVerifyMode.LOG_PASSVERIFY:        //2
                        vstrTmp = "Password"; break;
                    case (int)enumGLogVerifyMode.LOG_CARDVERIFY:        //3
                        vstrTmp = "Card"; break;
                    case (int)enumGLogVerifyMode.LOG_FPPASS_VERIFY:     //4
                        vstrTmp = "Fp+Password"; break;
                    case (int)enumGLogVerifyMode.LOG_FPCARD_VERIFY:     //5
                        vstrTmp = "Fp+Card"; break;
                    case (int)enumGLogVerifyMode.LOG_PASSFP_VERIFY:     //6
                        vstrTmp = "Password+Fp"; break;
                    case (int)enumGLogVerifyMode.LOG_CARDFP_VERIFY:     //7
                        vstrTmp = "Card+Fp"; break;
                    case (int)enumGLogVerifyMode.LOG_FACEVERIFY:        //20
                        vstrTmp = "Face"; break;
                    case (int)enumGLogVerifyMode.LOG_FACECARDVERIFY:    //21
                        vstrTmp = "Face+Card"; break;
                    case (int)enumGLogVerifyMode.LOG_FACEPASSVERIFY:    //22
                        vstrTmp = "Face+Pass"; break;
                    case (int)enumGLogVerifyMode.LOG_PASSFACEVERIFY:    //23
                        vstrTmp = "Pass+Face"; break;
                    case (int)enumGLogVerifyMode.LOG_CARDFACEVERIFY:    //24
                        vstrTmp = "Card+Face"; break;
                    case (int)enumGLogVerifyMode.LOG_FACEFPVERIFY:    //25
                        vstrTmp = "Face+Fp"; break;

                    case (int)enumGLogVerifyMode.LOG_CLOSE_DOOR:    //10
                        anGetDoorMode = (int)enumGLogDoorMode.LOG_CLOSE_DOOR;
                        break;
                    case (int)enumGLogVerifyMode.LOG_OPEN_HAND:    //11
                        anGetDoorMode = (int)enumGLogDoorMode.LOG_OPEN_HAND;
                        break;
                    case (int)enumGLogVerifyMode.LOG_PROG_OPEN:    //12
                        anGetDoorMode = (int)enumGLogDoorMode.LOG_PROG_OPEN;
                        break;
                    case (int)enumGLogVerifyMode.LOG_PROG_CLOSE:    //13
                        anGetDoorMode = (int)enumGLogDoorMode.LOG_PROG_CLOSE;
                        break;
                    case (int)enumGLogVerifyMode.LOG_OPEN_IREGAL:    //14
                        anGetDoorMode = (int)enumGLogDoorMode.LOG_OPEN_IREGAL;
                        break;
                    case (int)enumGLogVerifyMode.LOG_CLOSE_IREGAL:    //15
                        anGetDoorMode = (int)enumGLogDoorMode.LOG_CLOSE_IREGAL;
                        break;
                    case (int)enumGLogVerifyMode.LOG_OPEN_COVER:    //16
                        anGetDoorMode = (int)enumGLogDoorMode.LOG_OPEN_COVER;
                        break;
                    case (int)enumGLogVerifyMode.LOG_CLOSE_COVER:    //17
                        anGetDoorMode = (int)enumGLogDoorMode.LOG_CLOSE_COVER;
                        break;

                    default:
                        break;

                }

                anVerifyMode = anVerifyMode - vVerifyMode;
                if (anVerifyMode / (int)enumGLogVerifyMode.LOG_OPEN_THREAT == 1)
                    anGetDoorMode = (int)enumGLogDoorMode.LOG_OPEN_DOOR_THREAT;
                else if (anVerifyMode / (int)enumGLogVerifyMode.LOG_OPEN_DOOR == 1)
                    anGetDoorMode = (int)enumGLogDoorMode.LOG_OPEN_DOOR;
            }
            else
            {
                vstrTmp = frmMain.GetStringVerifyMode(anVerifyMode);
            }
            
            return vstrTmp;
        }

        private string getIOmodeToString(int anInOutMode, int anPrevDoorMode)
        {
            string vstrTmp;
            int vIoMode = 0;
            int vDoorMode = 0;
            frmMain.GetIoModeAndDoorMode(anInOutMode, ref vIoMode, ref vDoorMode);
            if (vDoorMode == 0)
            {
                vDoorMode = anPrevDoorMode;
            }
            if (vDoorMode == 0)
                vstrTmp = "( " + vIoMode + " )";
            else
                vstrTmp = "( " + vIoMode + " ) &    ";
            switch (vDoorMode)
            {
                case (int)enumGLogDoorMode.LOG_CLOSE_DOOR:
                    vstrTmp += "Close Door"; break;
                case (int)enumGLogDoorMode.LOG_OPEN_HAND:
                    vstrTmp += "Hand Open"; break;
                case (int)enumGLogDoorMode.LOG_PROG_OPEN:
                    vstrTmp += "Prog Open"; break;
                case (int)enumGLogDoorMode.LOG_PROG_CLOSE:
                    vstrTmp += "Prog Close"; break;
                case (int)enumGLogDoorMode.LOG_OPEN_IREGAL:
                    vstrTmp += "Illegal Open"; break;
                case (int)enumGLogDoorMode.LOG_CLOSE_IREGAL:
                    vstrTmp += "Illegal Close"; break;
                case (int)enumGLogDoorMode.LOG_OPEN_COVER:
                    vstrTmp += "Cover Open"; break;
                case (int)enumGLogDoorMode.LOG_CLOSE_COVER:
                    vstrTmp += "Cover Close"; break;
                case (int)enumGLogDoorMode.LOG_OPEN_DOOR:
                    vstrTmp += "Open door"; break;
                case (int)enumGLogDoorMode.LOG_OPEN_DOOR_THREAT:
                    vstrTmp += "Open Door as Threat"; break;
                case (int)enumGLogDoorMode.LOG_FORCE_OPEN_DOOR:
                    vstrTmp += "Force Open"; break;
                case (int)enumGLogDoorMode.LOG_FORCE_CLOSE_DOOR_:
                    vstrTmp += "Force Close"; break;

                //vstrTmp = "--"; break;
            }
            if (vstrTmp == "") vstrTmp = "--";
            return vstrTmp;
        }

        private bool funcShowGeneralLogDataToGrid(int anCount, int aSEnrollNumber, int aVerifyMode, int aInOutMode, DateTime adwDate, int aTemperature)
		{
			int vnkk;
			int vnTop, vnAllHeight;
			string vstrTmp; 
			ListViewItem vtItem; 
			bool vRet = true;
            int vPrevDoorMode;
            float vTemperature;
			if(anCount <= 1)
				fngrdIndex = 0;
			else
			{
				if ((fngrdIndex+1) * DEF_MAX_DISPCOUNT < anCount)
				{
					fngrdIndex = fngrdIndex + 1;
					if (fngrdIndex > fgrdLogView.GetUpperBound(0))
					{
						vRet = false;
						return vRet;
					}
                    vnAllHeight = fnGridHeight;
					vnTop = fgrdLogView[0].Top;
					for (vnkk = 0;vnkk<fngrdIndex;vnkk++)
					{
						fgrdLogView[vnkk].Top = vnTop + (vnkk - 1) * (vnAllHeight / fngrdIndex);
						fgrdLogView[vnkk].Height = vnAllHeight / fngrdIndex;
					}
					fgrdLogView[fngrdIndex].Visible = true;
				}
			}

			vtItem = new ListViewItem();
			vtItem.Text = anCount.ToString().Trim();

            vtItem.SubItems.Add(aSEnrollNumber.ToString().Trim());



            vPrevDoorMode = 0;
            vtItem.SubItems.Add(getVerifymodeToString((UInt32)aVerifyMode, ref vPrevDoorMode));
            vtItem.SubItems.Add(getIOmodeToString(aInOutMode, vPrevDoorMode));
            
			vstrTmp = adwDate.Year + adwDate.Month.ToString("/0#") + adwDate.Day.ToString("/0#") + 
				adwDate.Hour.ToString(" 0#") + adwDate.Minute.ToString(":0#") + adwDate.Second.ToString(":0#");	
	
			vtItem.SubItems.Add(vstrTmp);

            vTemperature = ((float)aTemperature / 10);
            if (vTemperature > 0)
                vtItem.SubItems.Add(vTemperature.ToString().Trim());
            else
                vtItem.SubItems.Add(" -- ");
			fgrdLogView[fngrdIndex].Items.Add(vtItem);
			vtItem = null;
			lblTotal.Text = "Total : " +  anCount;
			
			Application.DoEvents();
			return vRet;
		}


		private void funcGetGeneralLogData(bool abUSBFlag)
		{
			int vSEnrollNumber = 0;
			int vVerifyMode = 0;
			int vInOutMode = 0 ;
			DateTime vdwDate = DateTime.MinValue;
			int vnCount;
			int vnResultCode  = 0;
            int vTemperature = 0;
			string vstrFileName;
			string vstrFileData;
			int vnReadMark;
 
			vstrFileName = "";
			lblMessage.Text = "Waiting...";
			lblTotal.Text = "Total : 0";
			Application.DoEvents();
			funcGeneralLogDataGridFormat();

			if( abUSBFlag == true)
			{
				dlgOpen.InitialDirectory = Directory.GetCurrentDirectory();
				dlgOpen.Filter = "GLog Files (*.txt)|*.txt|All Files (*.*)|*.*";
				dlgOpen.FilterIndex = 1;
				if( dlgOpen.ShowDialog() != DialogResult.OK)
					return;
				vstrFileName = dlgOpen.FileName;
				dlgOpen.FileName = "";
			}
			else
			{
				vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex,0);
				if( vnResultCode == 0)
				{
					lblMessage.Text = GlobalConstants.gstrNoDevice;
					return;
				}
			}

			Cursor = Cursors.WaitCursor;
			Application.DoEvents();
			if( abUSBFlag == true)
				vnResultCode = frmMain.FK_USBLoadGeneralLogDataFromFile(frmMain.gnCommHandleIndex,vstrFileName);
			else
			{
				if( chkReadMark.CheckState == CheckState.Checked)
					vnReadMark = 1;
				else
					vnReadMark = 0;

				//open file for save
				if( chkSave.CheckState == CheckState.Checked)
				{
					if( vnReadMark == 0)
						vstrFileName = Directory.GetCurrentDirectory() + "\\AllLog.txt";
					else
						vstrFileName = Directory.GetCurrentDirectory() + "\\Log.txt";

					if( Directory.Exists(vstrFileName)== true) File.Delete(vstrFileName);
					vstrFileData = "No." + Convert.ToChar(9) + "EnrNo" + Convert.ToChar(9) + "Verify" 
						+ Convert.ToChar(9) + "InOut" + Convert.ToChar(9) + "DateTime" + Convert.ToChar(13)+Convert.ToChar(10);

					using (FileStream fs = File.Create(vstrFileName)) {};
					// Open the stream and read it back.
					using (FileStream fs = File.OpenWrite(vstrFileName))
					{
						byte[] newBytes =  new ASCIIEncoding().GetBytes(vstrFileData.ToCharArray());
						fs.Write(newBytes, 0, vstrFileData.Length);
					}
				}
				vnResultCode = frmMain.FK_LoadGeneralLogData(frmMain.gnCommHandleIndex,vnReadMark);

			}
			if( vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
			else
			{
				lblMessage.Text = "Getting...";
				Application.DoEvents();

				vnCount = 1;
				do
				{
                    vnResultCode = frmMain.FK_GetTemperatureLogData(frmMain.gnCommHandleIndex, ref vSEnrollNumber, ref vVerifyMode, ref vInOutMode, ref vdwDate, ref vTemperature);
                    if (vnResultCode == (int)enumErrorCode.RUNERR_NOSUPPORT)
                    {
                        vnResultCode = frmMain.FK_GetGeneralLogData(frmMain.gnCommHandleIndex, ref vSEnrollNumber, ref vVerifyMode, ref vInOutMode, ref vdwDate);
                    }
					if( vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
					{
						if( vnResultCode == (int)enumErrorCode.RUNERR_DATAARRAY_END)
						{
							vnResultCode = (int)enumErrorCode.RUN_SUCCESS;
						}
						break;
					}
					if( abUSBFlag == false && chkSave.CheckState == CheckState.Checked)
					{
						vstrFileData = funcMakeGeneralLogFileData(vnCount, vSEnrollNumber, vVerifyMode, vInOutMode, vdwDate);
						
						using (FileStream fs = File.OpenWrite(vstrFileName))
						{
							byte[] newBytes =  new ASCIIEncoding().GetBytes(vstrFileData.ToCharArray());
							
							fs.Seek(0,SeekOrigin.End);
							fs.Write(newBytes, 0, vstrFileData.Length);
						}
					}

                    if (funcShowGeneralLogDataToGrid(vnCount, vSEnrollNumber, vVerifyMode, vInOutMode, vdwDate, vTemperature) == false) break;
					vnCount = vnCount + 1;
				}while(true);

				if( vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
				{
					if( abUSBFlag == true)
						lblMessage.Text = "USBReadGeneralLogDataFromFile OK";
					else
						lblMessage.Text = "ReadGeneralLogData OK";
				}
				else
					lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
				
			}

			Cursor = Cursors.Default;
			if( abUSBFlag == false)
				frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex,1);
	
		}
		private void OwnerEnableButtons(bool abEnableFlag)
		{
			bool vbFrmOpenFlag;

			vbFrmOpenFlag = frmMain.gfrmMain.gbOpenFlag;
			cmdSLogData.Enabled = vbFrmOpenFlag && abEnableFlag;
			cmdEmptySLogData.Enabled = vbFrmOpenFlag && abEnableFlag;
			cmdUsbSLog.Enabled = abEnableFlag;
			cmdGlogData.Enabled = vbFrmOpenFlag && abEnableFlag;
			cmdEmptyGLogData.Enabled = vbFrmOpenFlag && abEnableFlag;
			cmdUsbGlog.Enabled = abEnableFlag;
			Application.DoEvents();
		}

		private string funcMakeGeneralLogFileData(long anCount, 
			long aSEnrollNumber,long aVerifyMode, long aInOutMode, DateTime adwDate)
		{
			string vstrData;
			string vstrDTime;

			vstrData = anCount.ToString() +  Convert.ToChar(9) + aSEnrollNumber.ToString() 
				+  Convert.ToChar(9) + aVerifyMode.ToString() +  Convert.ToChar(9) +  aInOutMode.ToString() +  Convert.ToChar(9);

			vstrDTime = adwDate.Year + adwDate.Month.ToString("/0#") + adwDate.Day.ToString("/0#") + 
				adwDate.Hour.ToString(" 0#") + adwDate.Minute.ToString(":0#") + adwDate.Second.ToString(":0#");	

			return (vstrData + vstrDTime + Convert.ToChar(13) + Convert.ToChar(10));
		}
	}
}
