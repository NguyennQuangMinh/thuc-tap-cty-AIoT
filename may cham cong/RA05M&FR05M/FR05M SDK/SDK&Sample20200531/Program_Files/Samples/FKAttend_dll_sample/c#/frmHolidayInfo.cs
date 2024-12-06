using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
namespace FKAttendDllCSSample
{
	/// <summary>
	/// Form5 的摘要说明。
	/// </summary>
	public class frmHolidayInfo : System.Windows.Forms.Form
    {
        internal System.Windows.Forms.OpenFileDialog dlgOpen;
		public System.Windows.Forms.Label lblEnrollData;
        public System.Windows.Forms.Label lblTotal;
        private TabControl tabControl1;
        private TabPage tabPage1;
        public CheckBox chkSave;
        public Button cmdUsbGlog;
        internal ListView gridLogView;
        public CheckBox chkReadMark;
        public Button cmdEmptyGLogData;
        public Button cmdGlogData;
        public Label lblMessage;
        private TabPage tabPage2;
        private DataGridView HolidayInfoGridView;
        public Button cmdWriteHolidayInfo;
        public Button cmdReadHolidayInfo;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn HolidayName;
        private DataGridViewTextBoxColumn HolidayDate;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewCheckBoxColumn Column2;
        public Label lblHolidayMessage;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHolidayInfo()
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
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.lblEnrollData = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.cmdUsbGlog = new System.Windows.Forms.Button();
            this.gridLogView = new System.Windows.Forms.ListView();
            this.chkReadMark = new System.Windows.Forms.CheckBox();
            this.cmdEmptyGLogData = new System.Windows.Forms.Button();
            this.cmdGlogData = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblHolidayMessage = new System.Windows.Forms.Label();
            this.cmdWriteHolidayInfo = new System.Windows.Forms.Button();
            this.cmdReadHolidayInfo = new System.Windows.Forms.Button();
            this.HolidayInfoGridView = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HolidayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HolidayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HolidayInfoGridView)).BeginInit();
            this.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 495);
            this.tabControl1.TabIndex = 34;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.chkSave);
            this.tabPage1.Controls.Add(this.cmdUsbGlog);
            this.tabPage1.Controls.Add(this.gridLogView);
            this.tabPage1.Controls.Add(this.chkReadMark);
            this.tabPage1.Controls.Add(this.cmdEmptyGLogData);
            this.tabPage1.Controls.Add(this.cmdGlogData);
            this.tabPage1.Controls.Add(this.lblMessage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(872, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Holiday Logs";
            // 
            // chkSave
            // 
            this.chkSave.BackColor = System.Drawing.SystemColors.Control;
            this.chkSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSave.Location = new System.Drawing.Point(483, 51);
            this.chkSave.Name = "chkSave";
            this.chkSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSave.Size = new System.Drawing.Size(104, 20);
            this.chkSave.TabIndex = 43;
            this.chkSave.Text = "Save to file";
            this.chkSave.UseVisualStyleBackColor = false;
            // 
            // cmdUsbGlog
            // 
            this.cmdUsbGlog.BackColor = System.Drawing.SystemColors.Control;
            this.cmdUsbGlog.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdUsbGlog.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUsbGlog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdUsbGlog.Location = new System.Drawing.Point(693, 413);
            this.cmdUsbGlog.Name = "cmdUsbGlog";
            this.cmdUsbGlog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdUsbGlog.Size = new System.Drawing.Size(172, 56);
            this.cmdUsbGlog.TabIndex = 39;
            this.cmdUsbGlog.Text = "Read USB Holiday Logs";
            this.cmdUsbGlog.UseVisualStyleBackColor = false;
            this.cmdUsbGlog.Visible = false;
            this.cmdUsbGlog.Click += new System.EventHandler(this.cmdUsbGlog_Click);
            // 
            // gridLogView
            // 
            this.gridLogView.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridLogView.FullRowSelect = true;
            this.gridLogView.GridLines = true;
            this.gridLogView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem10,
            listViewItem11,
            listViewItem12});
            this.gridLogView.Location = new System.Drawing.Point(9, 76);
            this.gridLogView.MultiSelect = false;
            this.gridLogView.Name = "gridLogView";
            this.gridLogView.Size = new System.Drawing.Size(856, 328);
            this.gridLogView.TabIndex = 42;
            this.gridLogView.UseCompatibleStateImageBehavior = false;
            this.gridLogView.View = System.Windows.Forms.View.Details;
            // 
            // chkReadMark
            // 
            this.chkReadMark.BackColor = System.Drawing.SystemColors.Control;
            this.chkReadMark.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkReadMark.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReadMark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkReadMark.Location = new System.Drawing.Point(602, 51);
            this.chkReadMark.Name = "chkReadMark";
            this.chkReadMark.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkReadMark.Size = new System.Drawing.Size(96, 20);
            this.chkReadMark.TabIndex = 40;
            this.chkReadMark.Text = "ReadMark";
            this.chkReadMark.UseVisualStyleBackColor = false;
            // 
            // cmdEmptyGLogData
            // 
            this.cmdEmptyGLogData.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.cmdEmptyGLogData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEmptyGLogData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdEmptyGLogData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEmptyGLogData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEmptyGLogData.Location = new System.Drawing.Point(693, 413);
            this.cmdEmptyGLogData.Name = "cmdEmptyGLogData";
            this.cmdEmptyGLogData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdEmptyGLogData.Size = new System.Drawing.Size(172, 56);
            this.cmdEmptyGLogData.TabIndex = 38;
            this.cmdEmptyGLogData.Text = "Empty Holiday Logs";
            this.cmdEmptyGLogData.UseVisualStyleBackColor = false;
            this.cmdEmptyGLogData.Click += new System.EventHandler(this.cmdEmptyGLogData_Click);
            // 
            // cmdGlogData
            // 
            this.cmdGlogData.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.cmdGlogData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGlogData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGlogData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGlogData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGlogData.Location = new System.Drawing.Point(9, 410);
            this.cmdGlogData.Name = "cmdGlogData";
            this.cmdGlogData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGlogData.Size = new System.Drawing.Size(172, 56);
            this.cmdGlogData.TabIndex = 37;
            this.cmdGlogData.Text = "Read Holiday Logs";
            this.cmdGlogData.UseVisualStyleBackColor = false;
            this.cmdGlogData.Click += new System.EventHandler(this.cmdGlogData_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMessage.Location = new System.Drawing.Point(146, 3);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMessage.Size = new System.Drawing.Size(644, 28);
            this.lblMessage.TabIndex = 41;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lblHolidayMessage);
            this.tabPage2.Controls.Add(this.cmdWriteHolidayInfo);
            this.tabPage2.Controls.Add(this.cmdReadHolidayInfo);
            this.tabPage2.Controls.Add(this.HolidayInfoGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(872, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Holiday Info";
            // 
            // lblHolidayMessage
            // 
            this.lblHolidayMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblHolidayMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHolidayMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblHolidayMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHolidayMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHolidayMessage.Location = new System.Drawing.Point(119, 3);
            this.lblHolidayMessage.Name = "lblHolidayMessage";
            this.lblHolidayMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblHolidayMessage.Size = new System.Drawing.Size(644, 28);
            this.lblHolidayMessage.TabIndex = 42;
            this.lblHolidayMessage.Text = "Message";
            this.lblHolidayMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdWriteHolidayInfo
            // 
            this.cmdWriteHolidayInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.cmdWriteHolidayInfo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdWriteHolidayInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdWriteHolidayInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdWriteHolidayInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdWriteHolidayInfo.Location = new System.Drawing.Point(517, 409);
            this.cmdWriteHolidayInfo.Name = "cmdWriteHolidayInfo";
            this.cmdWriteHolidayInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdWriteHolidayInfo.Size = new System.Drawing.Size(172, 56);
            this.cmdWriteHolidayInfo.TabIndex = 40;
            this.cmdWriteHolidayInfo.Text = "Write Holiday Info";
            this.cmdWriteHolidayInfo.UseVisualStyleBackColor = false;
            this.cmdWriteHolidayInfo.Click += new System.EventHandler(this.cmdWriteHolidayInfo_Click);
            // 
            // cmdReadHolidayInfo
            // 
            this.cmdReadHolidayInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.cmdReadHolidayInfo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdReadHolidayInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdReadHolidayInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReadHolidayInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdReadHolidayInfo.Location = new System.Drawing.Point(175, 407);
            this.cmdReadHolidayInfo.Name = "cmdReadHolidayInfo";
            this.cmdReadHolidayInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdReadHolidayInfo.Size = new System.Drawing.Size(172, 56);
            this.cmdReadHolidayInfo.TabIndex = 39;
            this.cmdReadHolidayInfo.Text = "Read Holiday Info";
            this.cmdReadHolidayInfo.UseVisualStyleBackColor = false;
            this.cmdReadHolidayInfo.Click += new System.EventHandler(this.cmdReadHolidayInfo_Click);
            // 
            // HolidayInfoGridView
            // 
            this.HolidayInfoGridView.AllowUserToAddRows = false;
            this.HolidayInfoGridView.AllowUserToDeleteRows = false;
            this.HolidayInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HolidayInfoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.HolidayName,
            this.HolidayDate,
            this.Column1,
            this.Column2});
            this.HolidayInfoGridView.Location = new System.Drawing.Point(17, 41);
            this.HolidayInfoGridView.MultiSelect = false;
            this.HolidayInfoGridView.Name = "HolidayInfoGridView";
            this.HolidayInfoGridView.Size = new System.Drawing.Size(832, 362);
            this.HolidayInfoGridView.TabIndex = 0;
            this.HolidayInfoGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.HolidayInfoGridView_CellMouseClick);
            this.HolidayInfoGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.HolidayInfoGridView_CellValueChanged);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // HolidayName
            // 
            this.HolidayName.HeaderText = "Holiday Name";
            this.HolidayName.Name = "HolidayName";
            this.HolidayName.Width = 200;
            // 
            // HolidayDate
            // 
            this.HolidayDate.HeaderText = "Holiday Date";
            this.HolidayDate.Name = "HolidayDate";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Door Open Status";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Valid";
            this.Column2.Name = "Column2";
            // 
            // frmHolidayInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(888, 514);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblEnrollData);
            this.Controls.Add(this.lblTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHolidayInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Holidays";
            this.Closed += new System.EventHandler(this.frmHolidayInfo_Closed);
            this.Load += new System.EventHandler(this.frmHolidayInfo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HolidayInfoGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public const short HOLIDAY_INFO_SIZE = 68 * GlobalConstants.MAX_HOLIDAY_COUNT;
        private HOLIDAYINFO mHolidayInfo;
		private void frmHolidayInfo_Load(object sender, System.EventArgs e)
		{
			int vnii;
			long vngrdNumber;

			chkReadMark.CheckState = CheckState.Checked;
			chkSave.CheckState = CheckState.Unchecked;
			fnGridHeight = gridLogView.Height;
			vngrdNumber = DEF_MAX_LOGCOUNT / DEF_MAX_DISPCOUNT;
			if (vngrdNumber * DEF_MAX_DISPCOUNT < DEF_MAX_LOGCOUNT) vngrdNumber = vngrdNumber + 1;
			if (vngrdNumber < 0) vngrdNumber = 0;

			frmHolidayInfo_Closed(sender, e);
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

		private void frmHolidayInfo_Closed(object sender, System.EventArgs e)
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

            vnResultCode = frmMain.FK_EmptyHolidayLogData(frmMain.gnCommHandleIndex);
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
		
		private void funcGeneralLogDataGridFormat()
		{
			int vnii;
			string []  vstrLogItem;

			vstrLogItem = new string [] {"", "EnrollNo", "VerifyMode", "InOutMode", "DateTime", "Holiday Name", "DoorOpen status"};
	
			fgrdLogView[0].Height = fnGridHeight;
			fgrdLogView[0].Items.Clear();
			fgrdLogView[0].Columns.Clear();
			foreach (string vstrTmp in vstrLogItem)fgrdLogView[0].Columns.Add(vstrTmp, 80, HorizontalAlignment.Center);

			fgrdLogView[0].Columns[0].Width = 48;
			fgrdLogView[0].Columns[0].TextAlign = HorizontalAlignment.Right;
			fgrdLogView[0].Columns[2].Width = 140;
			fgrdLogView[0].Columns[4].Width = 140;
            fgrdLogView[0].Columns[5].Width = 240;
            fgrdLogView[0].Columns[6].Width = 100;
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

        private bool funcShowGeneralLogDataToGrid(int anCount, int aSEnrollNumber, int aVerifyMode, int aInOutMode, DateTime adwDate, string strHolidayName, int aDoorOpen)
		{
			int vnkk;
			int vnTop, vnAllHeight;
			string vstrTmp; 
			ListViewItem vtItem; 
			bool vRet = true;
            int vPrevDoorMode;
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
            vtItem.SubItems.Add(strHolidayName);
            if (aDoorOpen > 0)
                vtItem.SubItems.Add("Open");
            else
                vtItem.SubItems.Add("Close");
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
            string vHolidayName = "";
            int vDoorOpen = 0;
			DateTime vdwDate = DateTime.MinValue;
			int vnCount;
			int vnResultCode  = 0;
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
						+ Convert.ToChar(9) + "InOut" + Convert.ToChar(9) + "DateTime" + Convert.ToChar(9) +"HolidayName" + Convert.ToChar(9) + "DoorOpen" + Convert.ToChar(13) + Convert.ToChar(10);

					using (FileStream fs = File.Create(vstrFileName)) {};
					// Open the stream and read it back.
					using (FileStream fs = File.OpenWrite(vstrFileName))
					{
						byte[] newBytes =  new ASCIIEncoding().GetBytes(vstrFileData.ToCharArray());
						fs.Write(newBytes, 0, vstrFileData.Length);
					}
				}
                vnResultCode = frmMain.FK_LoadHolidayLogData(frmMain.gnCommHandleIndex, vnReadMark);

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
                    vnResultCode = frmMain.FK_GetHolidayLogData(frmMain.gnCommHandleIndex, ref vSEnrollNumber, ref vVerifyMode, ref vInOutMode, ref vdwDate, ref vHolidayName, ref vDoorOpen);
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
                        vstrFileData = funcMakeGeneralLogFileData(vnCount, vSEnrollNumber, vVerifyMode, vInOutMode, vdwDate, vHolidayName, vDoorOpen);
						
						using (FileStream fs = File.OpenWrite(vstrFileName))
						{
							byte[] newBytes =  new ASCIIEncoding().GetBytes(vstrFileData.ToCharArray());
							
							fs.Seek(0,SeekOrigin.End);
							fs.Write(newBytes, 0, vstrFileData.Length);
						}
					}

                    if (funcShowGeneralLogDataToGrid(vnCount, vSEnrollNumber, vVerifyMode, vInOutMode, vdwDate,vHolidayName, vDoorOpen) == false) break;
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
			cmdGlogData.Enabled = vbFrmOpenFlag && abEnableFlag;
			cmdEmptyGLogData.Enabled = vbFrmOpenFlag && abEnableFlag;
			cmdUsbGlog.Enabled = abEnableFlag;
			Application.DoEvents();
		}

		private string funcMakeGeneralLogFileData(long anCount, 
			long aSEnrollNumber,long aVerifyMode, long aInOutMode, DateTime adwDate, string strHolidayName, long aDoorOpen)
		{
			string vstrData;
			string vstrDTime;

			vstrData = anCount.ToString() +  Convert.ToChar(9) + aSEnrollNumber.ToString() 
				+  Convert.ToChar(9) + aVerifyMode.ToString() +  Convert.ToChar(9) +  aInOutMode.ToString() +  Convert.ToChar(9);

			vstrDTime = adwDate.Year + adwDate.Month.ToString("/0#") + adwDate.Day.ToString("/0#") + 
				adwDate.Hour.ToString(" 0#") + adwDate.Minute.ToString(":0#") + adwDate.Second.ToString(":0#");

            return (vstrData + vstrDTime + Convert.ToChar(9) + strHolidayName + Convert.ToChar(9) + aDoorOpen.ToString() + Convert.ToChar(13) + Convert.ToChar(10) );
		}

        private void cmdReadHolidayInfo_Click(object sender, EventArgs e)
        {
            int vnResultCode;
            byte[] vbytHolidayInfo = new byte[HOLIDAY_INFO_SIZE];

            cmdReadHolidayInfo.Enabled = false;
            lblHolidayMessage.Text = "Working...";
            Application.DoEvents();

            vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
            if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
            {
                lblHolidayMessage.Text = GlobalConstants.gstrNoDevice;
                cmdReadHolidayInfo.Enabled = true;
                return;
            }

            vnResultCode = frmMain.FK_GetHolidayInfo(frmMain.gnCommHandleIndex, vbytHolidayInfo, HOLIDAY_INFO_SIZE);
            lblHolidayMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
            if (vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
            {
                object vobj = frmMain.ConvertByteArrayToStructure(vbytHolidayInfo, typeof(HOLIDAYINFO));
                if (vobj == null)
                    return;
                mHolidayInfo = (HOLIDAYINFO)vobj;
                ShowValue();
            }

            frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
            cmdReadHolidayInfo.Enabled = true;	
        }
        private bool isModify = false;
        private void ShowValue()
        {
          	int vnii;
            HolidayInfoGridView.Rows.Clear();
            isModify = false;
            for (vnii = 0; vnii < GlobalConstants.MAX_HOLIDAY_COUNT; vnii++)
            {
                HolidayInfoGridView.Rows.Add();
                HolidayInfoGridView.Rows[vnii].Cells[0].Value = vnii + 1;
                HolidayInfoGridView.Rows[vnii].Cells[1].Value = mHolidayInfo.mHolidayName[vnii].Value;
                if (mHolidayInfo.mMonth[vnii] > 0 && mHolidayInfo.mDay[vnii] > 0)
                    HolidayInfoGridView.Rows[vnii].Cells[2].Value = mHolidayInfo.mMonth[vnii].ToString("d2") + "-" + mHolidayInfo.mDay[vnii].ToString("d2");
                else
                    HolidayInfoGridView.Rows[vnii].Cells[2].Value = "";
                HolidayInfoGridView.Rows[vnii].Cells[3].Value = (mHolidayInfo.mOpenDoor[vnii] > 0)? true:false;
                HolidayInfoGridView.Rows[vnii].Cells[4].Value = (mHolidayInfo.mValid[vnii] > 0)? true:false;
                
            }
            isModify = true;
        }

        private void HolidayInfoGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string str = e.ToString();
            int vRowIndex = e.RowIndex;
            if (vRowIndex < 0) return;
            if (isModify == false) return;
            int vColIndex = e.ColumnIndex;
            if (vColIndex == 2)
            {
                string vStr = HolidayInfoGridView.Rows[vRowIndex].Cells[2].Value.ToString();
                string[] words = vStr.Split('-');
                if (words.Length != 2)
                {
                    isModify = false;
                    if (mHolidayInfo.mMonth[vRowIndex] > 0 && mHolidayInfo.mDay[vRowIndex] > 0)
                        HolidayInfoGridView.Rows[vRowIndex].Cells[2].Value = mHolidayInfo.mMonth[vRowIndex].ToString("d2") + "-" + mHolidayInfo.mDay[vRowIndex].ToString("d2");
                    else
                        HolidayInfoGridView.Rows[vRowIndex].Cells[2].Value = "";
                    MessageBox.Show("wrong date, input mm-dd");
                    isModify = true;
                    return;
                }
                int vMonth = frmMain.ConvertNumer(words[0]);
                int vDay = frmMain.ConvertNumer(words[1]);
                if (vMonth < 1 || vMonth > 12 || vDay < 1 || vDay > 31)
                {
                    isModify = false;
                    if (mHolidayInfo.mMonth[vRowIndex] > 0 && mHolidayInfo.mDay[vRowIndex] > 0)
                        HolidayInfoGridView.Rows[vRowIndex].Cells[2].Value = mHolidayInfo.mMonth[vRowIndex].ToString("d2") + "-" + mHolidayInfo.mDay[vRowIndex].ToString("d2");
                    else
                        HolidayInfoGridView.Rows[vRowIndex].Cells[2].Value = "";

                    MessageBox.Show("wrong date, input mm-dd");
                    isModify = true;
                    return;
                }
                mHolidayInfo.mMonth[vRowIndex] = (byte)vMonth;
                mHolidayInfo.mDay[vRowIndex] = (byte)vDay;

            }else if(vColIndex == 1){
                
                mHolidayInfo.mHolidayName[vRowIndex].Value = HolidayInfoGridView.Rows[vRowIndex].Cells[1].Value.ToString();
            }
            else if (vColIndex == 3)
            {
                if ((bool)HolidayInfoGridView.Rows[vRowIndex].Cells[3].Value == true)
                    mHolidayInfo.mOpenDoor[vRowIndex] = 1;// (byte)HolidayInfoGridView.Rows[vRowIndex].Cells[3].Value;
                else
                    mHolidayInfo.mOpenDoor[vRowIndex] = 0;

            }
            else if (vColIndex == 4)
            {
                if ((bool)HolidayInfoGridView.Rows[vRowIndex].Cells[4].Value == true)
                {
                    if (mHolidayInfo.mMonth[vRowIndex] == 0 || mHolidayInfo.mDay[vRowIndex] == 0 || HolidayInfoGridView.Rows[vRowIndex].Cells[1].Value.ToString().Length == 0)
                    {
                        isModify = false;
                        HolidayInfoGridView.Rows[vRowIndex].Cells[4].Value = false;
                        MessageBox.Show("input holiday name and date at first!");
                        isModify = true;
                        return;
                    }
                    mHolidayInfo.mValid[vRowIndex] = 1;// (byte)HolidayInfoGridView.Rows[vRowIndex].Cells[3].Value;
                }
                else
                    mHolidayInfo.mValid[vRowIndex] = 0;
           }
        }

        private void cmdWriteHolidayInfo_Click(object sender, EventArgs e)
        {
            int vnResultCode;
            byte[] bytHolidayInfo = new byte[HOLIDAY_INFO_SIZE];

            cmdWriteHolidayInfo.Enabled = false;
            lblHolidayMessage.Text = "Working...";
            Application.DoEvents();

            //GetValue();

            frmMain.ConvertStructureToByteArray((object)mHolidayInfo, bytHolidayInfo);
            vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
            if (vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
            {
                lblHolidayMessage.Text = GlobalConstants.gstrNoDevice;
                cmdWriteHolidayInfo.Enabled = true;
                return;
            }

            vnResultCode = frmMain.FK_SetHolidayInfo(frmMain.gnCommHandleIndex, bytHolidayInfo, HOLIDAY_INFO_SIZE);
            lblHolidayMessage.Text = frmMain.ReturnResultPrint(vnResultCode);

            frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
            cmdWriteHolidayInfo.Enabled = true;
        }

        private void HolidayInfoGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int vRowIndex = e.RowIndex;
            if (vRowIndex < 0) return;
            if (isModify == false) return;
            int vColIndex = e.ColumnIndex;

            if (vColIndex == 4)
            {
                if ((bool)HolidayInfoGridView.Rows[vRowIndex].Cells[4].Value == true)
                {
                    if (mHolidayInfo.mMonth[vRowIndex] == 0 || mHolidayInfo.mDay[vRowIndex] == 0 || HolidayInfoGridView.Rows[vRowIndex].Cells[1].Value.ToString().Length == 0)
                    {
                        isModify = false;
                        HolidayInfoGridView.Rows[vRowIndex].Cells[4].Value = false;
                        MessageBox.Show("input holiday name and date at first!");
                        isModify = true;
                        return;
                    }
                    mHolidayInfo.mValid[vRowIndex] = 1;// (byte)HolidayInfoGridView.Rows[vRowIndex].Cells[3].Value;
                }
                else
                    mHolidayInfo.mValid[vRowIndex] = 0;
            }
            else if (vColIndex == 3)
            {
                if ((bool)HolidayInfoGridView.Rows[vRowIndex].Cells[3].Value == true)
                    mHolidayInfo.mOpenDoor[vRowIndex] = 1;// (byte)HolidayInfoGridView.Rows[vRowIndex].Cells[3].Value;
                else
                    mHolidayInfo.mOpenDoor[vRowIndex] = 0;

            }
        }
       
	}
}
