using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FKAttendDllCSSample
{
	/// <summary>
	/// Form6 ��ժҪ˵����
	/// </summary>
	public class frmUserInfo : System.Windows.Forms.Form
    {
		public System.Windows.Forms.TextBox txtEnrollNumber;
		public System.Windows.Forms.TextBox txtName;
		public System.Windows.Forms.Button cmdGetUserName;
        public System.Windows.Forms.Button cmdSetUserName;
		public System.Windows.Forms.Label lblMessage;
		public System.Windows.Forms.Label lblEnrollNum;
		public System.Windows.Forms.Label Label3;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUserInfo()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.txtEnrollNumber = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmdGetUserName = new System.Windows.Forms.Button();
            this.cmdSetUserName = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblEnrollNum = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEnrollNumber
            // 
            this.txtEnrollNumber.AcceptsReturn = true;
            this.txtEnrollNumber.BackColor = System.Drawing.SystemColors.Window;
            this.txtEnrollNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEnrollNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEnrollNumber.Location = new System.Drawing.Point(119, 102);
            this.txtEnrollNumber.MaxLength = 8;
            this.txtEnrollNumber.Name = "txtEnrollNumber";
            this.txtEnrollNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEnrollNumber.Size = new System.Drawing.Size(96, 26);
            this.txtEnrollNumber.TabIndex = 21;
            // 
            // txtName
            // 
            this.txtName.AcceptsReturn = true;
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(119, 62);
            this.txtName.MaxLength = 10;
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.Size = new System.Drawing.Size(97, 26);
            this.txtName.TabIndex = 33;
            // 
            // cmdGetUserName
            // 
            this.cmdGetUserName.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetUserName.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetUserName.Location = new System.Drawing.Point(287, 94);
            this.cmdGetUserName.Name = "cmdGetUserName";
            this.cmdGetUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetUserName.Size = new System.Drawing.Size(137, 25);
            this.cmdGetUserName.TabIndex = 18;
            this.cmdGetUserName.Text = "Get User Name";
            this.cmdGetUserName.UseVisualStyleBackColor = false;
            this.cmdGetUserName.Click += new System.EventHandler(this.cmdGetUserName_Click);
            // 
            // cmdSetUserName
            // 
            this.cmdSetUserName.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetUserName.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSetUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetUserName.Location = new System.Drawing.Point(287, 62);
            this.cmdSetUserName.Name = "cmdSetUserName";
            this.cmdSetUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSetUserName.Size = new System.Drawing.Size(137, 25);
            this.cmdSetUserName.TabIndex = 17;
            this.cmdSetUserName.Text = "Set User Name";
            this.cmdSetUserName.UseVisualStyleBackColor = false;
            this.cmdSetUserName.Click += new System.EventHandler(this.cmdSetUserName_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMessage.Location = new System.Drawing.Point(15, 14);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMessage.Size = new System.Drawing.Size(426, 33);
            this.lblMessage.TabIndex = 27;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnrollNum
            // 
            this.lblEnrollNum.AutoSize = true;
            this.lblEnrollNum.BackColor = System.Drawing.SystemColors.Control;
            this.lblEnrollNum.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblEnrollNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEnrollNum.Location = new System.Drawing.Point(9, 106);
            this.lblEnrollNum.Name = "lblEnrollNum";
            this.lblEnrollNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblEnrollNum.Size = new System.Drawing.Size(105, 19);
            this.lblEnrollNum.TabIndex = 24;
            this.lblEnrollNum.Text = "Enroll Number :";
            this.lblEnrollNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(9, 70);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(53, 19);
            this.Label3.TabIndex = 23;
            this.Label3.Text = "Name :";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUserInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
            this.ClientSize = new System.Drawing.Size(444, 142);
            this.Controls.Add(this.txtEnrollNumber);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmdGetUserName);
            this.Controls.Add(this.cmdSetUserName);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblEnrollNum);
            this.Controls.Add(this.Label3);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(2, 28);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.frmUserInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		const short NAMESIZE = 400;
		private int[] glngUserName = new int[NAMESIZE];

		private void frmUserInfo_Load(object sender, System.EventArgs e)
		{
			txtEnrollNumber.Text = "1";
			
		}

		private void cmdGetUserName_Click(object sender, System.EventArgs e)
		{
	        int vEnrollNumber;
			string vName;
			int vnResultCode;

			cmdGetUserName.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if(vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdGetUserName.Enabled = true;
				return;
			}

			vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
			vName = new string((char)0x20, 256);
			vnResultCode = frmMain.FK_GetUserName(frmMain.gnCommHandleIndex, vEnrollNumber, ref vName);
			if(vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
			{
				txtName.Text = vName;
				lblMessage.Text = "GetUserName OK";
			}
			else
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
	
			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdGetUserName.Enabled = true;	
		}

			private void cmdSetUserName_Click(object sender, System.EventArgs e)
		{
			int vEnrollNumber;
			int vnResultCode;

			cmdSetUserName.Enabled = false;
			lblMessage.Text = "Working...";
			Application.DoEvents();

			vnResultCode = frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 0);
			if(vnResultCode != (int)enumErrorCode.RUN_SUCCESS)
			{
				lblMessage.Text = GlobalConstants.gstrNoDevice;
				cmdSetUserName.Enabled = true;
				return;
			}

			vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
			vnResultCode = frmMain.FK_SetUserName(frmMain.gnCommHandleIndex, vEnrollNumber, (txtName.Text).Trim());
		  
			if(vnResultCode == (int)enumErrorCode.RUN_SUCCESS)
				lblMessage.Text = "SetUserName OK";
			else
				lblMessage.Text = frmMain.ReturnResultPrint(vnResultCode);
			frmMain.FK_EnableDevice(frmMain.gnCommHandleIndex, 1);
			cmdSetUserName.Enabled = true;	
		}
	}
}
