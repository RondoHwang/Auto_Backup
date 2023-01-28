
namespace Auto_Backup
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.lblSourceFolderPath = new System.Windows.Forms.Label();
            this.lblTargetFolderPath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblUserName = new System.Windows.Forms.Label();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.lblClearAll = new System.Windows.Forms.Label();
            this.lblShowHideLog = new System.Windows.Forms.Label();
            this.btnSelectTargetFolder = new System.Windows.Forms.Button();
            this.btnSelectSourceFolder = new System.Windows.Forms.Button();
            this.notifyIconMnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(49, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. 选择要备份的文件夹";
            // 
            // lblSourceFolderPath
            // 
            this.lblSourceFolderPath.AutoSize = true;
            this.lblSourceFolderPath.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSourceFolderPath.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblSourceFolderPath.Location = new System.Drawing.Point(151, 80);
            this.lblSourceFolderPath.Name = "lblSourceFolderPath";
            this.lblSourceFolderPath.Size = new System.Drawing.Size(0, 20);
            this.lblSourceFolderPath.TabIndex = 2;
            // 
            // lblTargetFolderPath
            // 
            this.lblTargetFolderPath.AutoSize = true;
            this.lblTargetFolderPath.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTargetFolderPath.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTargetFolderPath.Location = new System.Drawing.Point(151, 192);
            this.lblTargetFolderPath.Name = "lblTargetFolderPath";
            this.lblTargetFolderPath.Size = new System.Drawing.Size(0, 20);
            this.lblTargetFolderPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(49, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "2. 选择备份文件存放的位置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(49, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "3. 选择每天备份的时间点";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(79, 296);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(110, 30);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartStop.Location = new System.Drawing.Point(358, 285);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(129, 52);
            this.btnStartStop.TabIndex = 8;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(515, 299);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(101, 24);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "stopped";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyIconMnu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Auto_Backup";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // notifyIconMnu
            // 
            this.notifyIconMnu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.notifyIconMnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShow,
            this.mnuExit});
            this.notifyIconMnu.Name = "existMnu";
            this.notifyIconMnu.Size = new System.Drawing.Size(129, 68);
            this.notifyIconMnu.Text = "Mnu";
            // 
            // mnuShow
            // 
            this.mnuShow.Name = "mnuShow";
            this.mnuShow.Size = new System.Drawing.Size(128, 32);
            this.mnuShow.Text = "Show";
            this.mnuShow.Click += new System.EventHandler(this.mnuShow_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(128, 32);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExist_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(702, 35);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 18);
            this.lblUserName.TabIndex = 11;
            this.lblUserName.Visible = false;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Checked = true;
            this.chkAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoStart.Location = new System.Drawing.Point(53, 358);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(124, 22);
            this.chkAutoStart.TabIndex = 12;
            this.chkAutoStart.Text = "开机自启动";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // lblClearAll
            // 
            this.lblClearAll.AutoSize = true;
            this.lblClearAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblClearAll.Location = new System.Drawing.Point(632, 359);
            this.lblClearAll.Name = "lblClearAll";
            this.lblClearAll.Size = new System.Drawing.Size(116, 18);
            this.lblClearAll.TabIndex = 13;
            this.lblClearAll.Text = "清除所有设置";
            this.lblClearAll.Click += new System.EventHandler(this.lblClearAll_Click);
            // 
            // lblShowHideLog
            // 
            this.lblShowHideLog.AutoSize = true;
            this.lblShowHideLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblShowHideLog.Location = new System.Drawing.Point(482, 359);
            this.lblShowHideLog.Name = "lblShowHideLog";
            this.lblShowHideLog.Size = new System.Drawing.Size(116, 18);
            this.lblShowHideLog.TabIndex = 14;
            this.lblShowHideLog.Text = "查看备份记录";
            this.lblShowHideLog.Click += new System.EventHandler(this.lblShowHideLog_Click);
            // 
            // btnSelectTargetFolder
            // 
            this.btnSelectTargetFolder.BackgroundImage = global::Auto_Backup.Properties.Resources.folder;
            this.btnSelectTargetFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectTargetFolder.FlatAppearance.BorderSize = 0;
            this.btnSelectTargetFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectTargetFolder.Location = new System.Drawing.Point(71, 182);
            this.btnSelectTargetFolder.Name = "btnSelectTargetFolder";
            this.btnSelectTargetFolder.Size = new System.Drawing.Size(54, 42);
            this.btnSelectTargetFolder.TabIndex = 4;
            this.btnSelectTargetFolder.UseVisualStyleBackColor = true;
            this.btnSelectTargetFolder.Click += new System.EventHandler(this.btnSelectTargetFolder_Click);
            // 
            // btnSelectSourceFolder
            // 
            this.btnSelectSourceFolder.BackgroundImage = global::Auto_Backup.Properties.Resources.folder;
            this.btnSelectSourceFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectSourceFolder.FlatAppearance.BorderSize = 0;
            this.btnSelectSourceFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectSourceFolder.Location = new System.Drawing.Point(71, 70);
            this.btnSelectSourceFolder.Name = "btnSelectSourceFolder";
            this.btnSelectSourceFolder.Size = new System.Drawing.Size(54, 42);
            this.btnSelectSourceFolder.TabIndex = 1;
            this.btnSelectSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectSourceFolder.Click += new System.EventHandler(this.btnSelectSourceFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.lblShowHideLog);
            this.Controls.Add(this.lblClearAll);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTargetFolderPath);
            this.Controls.Add(this.btnSelectTargetFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSourceFolderPath);
            this.Controls.Add(this.btnSelectSourceFolder);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto_Backup";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.notifyIconMnu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectSourceFolder;
        private System.Windows.Forms.Label lblSourceFolderPath;
        private System.Windows.Forms.Label lblTargetFolderPath;
        private System.Windows.Forms.Button btnSelectTargetFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ContextMenuStrip notifyIconMnu;
        private System.Windows.Forms.ToolStripMenuItem mnuShow;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Label lblClearAll;
        private System.Windows.Forms.Label lblShowHideLog;
    }
}

