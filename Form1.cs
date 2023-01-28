using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;
using System.Security.Principal;


namespace Auto_Backup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Icon stoppedIcon, runningIcon;
        private void Form1_Load(object sender, EventArgs e)
        {
            //int n = System.Diagnostics.Process.GetProcessesByName("Auto_Backup").ToList().Count;
            if (System.Diagnostics.Process.GetProcessesByName("Auto_Backup").ToList().Count > 1)
            {
                MessageBox.Show("程序已经打开过了，请查看右下角的托盘栏，双击打开程序界面。");
                System.Environment.Exit(0);
            }

            //获得用户名
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            //SecurityIdentifier sid = wi.User;
            string userName = wi.Name;
            int ind=userName.LastIndexOf('\\')+1;
            lblUserName.Text = userName.Substring(ind);

            //创建自启动快捷方式
            string dirPath = @"C:\Users\" + lblUserName.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup";
            if (!System.IO.File.Exists(dirPath + @"\" + Application.ProductName + @".lnk"))
            {
                CreateShortcut(dirPath, "Auto_Backup", Application.StartupPath + @"\" + Application.ProductName + @".exe");
            }

            //注册窗体关闭事件
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
            
            //图标赋值
            Image img = Properties.Resources.restore_green;
            stoppedIcon = notifyIcon1.Icon;
            runningIcon = ConvertToIcon(img);

            //读取 Setting.txt 并初始化
            if (!System.IO.File.Exists(Application.StartupPath + "/Setting.txt"))
            {
                dateTimePicker1.Text = "23:00";
                Save_Setting();
            }else{
                this.WindowState = FormWindowState.Minimized;
                //this.Hide();
            }
            string[] settingInfo = System.IO.File.ReadAllLines(Application.StartupPath + "/Setting.txt");
            if (settingInfo.Length < 4)
            {
                Save_Setting();
                settingInfo = System.IO.File.ReadAllLines(Application.StartupPath + "/Setting.txt");
            }
            int index = settingInfo[0].IndexOf(':')+1;
            lblSourceFolderPath.Text = index==1 ? "" : settingInfo[0].Substring(index).Trim();
            index = settingInfo[1].IndexOf(':')+1;
            lblTargetFolderPath.Text = index == 1 ? "" : settingInfo[1].Substring(index).Trim();
            index = settingInfo[2].IndexOf(':')+1;
            dateTimePicker1.Text = index == 1 ? "23:00" : settingInfo[2].Substring(index).Trim()==""?"23:00": settingInfo[2].Substring(index).Trim();
            index = settingInfo[3].IndexOf(':') + 1;
            string status = settingInfo[3].Substring(index).Trim();
            if (status == "running...")
            {
                btnStartStop.Text = "Stop";
                lblStatus.Text = status;
                lblStatus.ForeColor = Color.Green;
                notifyIcon1.Icon = runningIcon;
                timer1.Enabled = true;
            }
            else
            {
                btnStartStop.Text = "Start";
                lblStatus.Text = "stopped";
                lblStatus.ForeColor = Color.Red;
                notifyIcon1.Icon = stoppedIcon;
                timer1.Enabled = false;
                if (lblSourceFolderPath.Text!="" && lblTargetFolderPath.Text != "")
                {
                    this.notifyIcon1.ShowBalloonTip(30, "Warning", "Auto_Backup status: Stopped", ToolTipIcon.Warning);
                }                
            }
        }

        //窗体关闭事件
        private void Form_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel=true;      //阻止窗体关闭
            this.WindowState = FormWindowState.Minimized;      //最小化
        }

        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog foldDialog = new FolderBrowserDialog();
            foldDialog.Description = "请选择需要备份的文件夹";
            foldDialog.ShowNewFolderButton = true;
            DialogResult result = foldDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblSourceFolderPath.Text = foldDialog.SelectedPath;
                Save_Setting();
            }
            
        }

        private void btnSelectTargetFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog foldDialog = new FolderBrowserDialog();
            foldDialog.Description = "请选择备份文件存放的位置";
            foldDialog.ShowNewFolderButton = true;
            DialogResult result = foldDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblTargetFolderPath.Text = foldDialog.SelectedPath;
                Save_Setting();
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Start")
            {
                if(!System.IO.Directory.Exists(Application.StartupPath + @"/logs"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"/logs");
                }
                if (lblSourceFolderPath.Text == "")
                {
                    MessageBox.Show("请先选择要备份的文件夹");
                    return;
                }
                if (lblTargetFolderPath.Text == "")
                {
                    MessageBox.Show("请先选择备份文件存放的位置");
                    return;
                }
                if (lblSourceFolderPath.Text == lblTargetFolderPath.Text)
                {
                    MessageBox.Show("要备份的文件夹路径不能与存放路径相同");
                    return;
                }
                btnStartStop.Text = "Stop";
                lblStatus.Text = "running...";
                lblStatus.ForeColor = Color.Green;                
                notifyIcon1.Icon = runningIcon;
                timer1.Enabled = true;
            }
            else
            {
                btnStartStop.Text = "Start";
                lblStatus.Text = "stopped";
                lblStatus.ForeColor = Color.Red;
                notifyIcon1.Icon = stoppedIcon;
                timer1.Enabled = false;
            }
            Save_Setting();
        }

        private Icon ConvertToIcon(Image img)
        {
            //Graphics g = Graphics.FromImage(img);
            //g.DrawImage(img, 0, 0, img.Width, img.Height);
            //Font f = new Font("verdana", 32);
            //Brush b = new SolidBrush(Color.Green);
            //g.DrawString("!!!", f, b, 0, 0);
            Icon icon = Icon.FromHandle(((Bitmap)img).GetHicon());
            return icon;
            //g.Dispose();
        }

        private void Save_Setting()
        {
            string settingInfo = "SourceFolder: " + lblSourceFolderPath.Text;
            settingInfo += "\r\nTargetFolder: " + lblTargetFolderPath.Text;
            settingInfo += "\r\nTimePoint: " + dateTimePicker1.Text;
            settingInfo += "\r\nStatus: " + lblStatus.Text;
            System.IO.File.WriteAllText(Application.StartupPath + "/Setting.txt", settingInfo);
        }                
        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
               // this.notifyIcon1.ShowBalloonTip(30, "Warning", "Auto_Backup status: Stopped", ToolTipIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Visible == true && this.WindowState ==FormWindowState.Minimized)
            {
                this.Hide();
            }
            if (DateTime.Now.ToString("HH:mm") == dateTimePicker1.Text)
            {
                CopyDirectory(lblSourceFolderPath.Text, lblTargetFolderPath.Text);
                //MessageBox.Show("update file");
            }
            //若为关闭状态，每天8：10提醒自动备份未开启
            if (lblStatus.Text=="stopped" && DateTime.Now.ToString("HH:mm") == "08:10")
            {
                this.notifyIcon1.ShowBalloonTip(30, "Warning", "Auto_Backup status: Stopped", ToolTipIcon.Warning);
            }
        }

        private bool CopyDirectory(string sourcePath, string destPath)
        {
            string floderName = Path.GetFileName(sourcePath);
            DirectoryInfo di = Directory.CreateDirectory(Path.Combine(destPath, floderName));
            string[] files = Directory.GetFileSystemEntries(sourcePath);

            foreach (string file in files)
            {
                if (Directory.Exists(file))
                {
                    CopyDirectory(file, di.FullName);
                }
                else
                {
                    //Console.WriteLine(file);
                    string targetFilePath = Path.Combine(di.FullName, Path.GetFileName(file));
                    bool hasExisted = System.IO.File.Exists(targetFilePath); 
                    if (!hasExisted || new FileInfo(file).LastWriteTime.ToString("yyyy/MM/dd") == System.DateTime.Now.ToString("yyyy/MM/dd"))
                    {
                        System.IO.File.Copy(file, Path.Combine(di.FullName, Path.GetFileName(file)), true);
                        FileInfo newFi = new FileInfo(Path.Combine(di.FullName, Path.GetFileName(file)));
                        string logPath = Application.StartupPath + @"/logs/" + System.DateTime.Now.ToString("yyyyMM") + ".txt";
                        int diff = DateTime.Compare(System.DateTime.Now, newFi.LastWriteTime);
                        if (diff<3)
                        {
                            System.IO.File.AppendAllText(logPath,DateTime.Now.ToString() + " updated " + Path.GetFileName(file) + " successfully\r\n");
                        }
                        else
                        {
                            System.IO.File.AppendAllText(logPath, DateTime.Now.ToString() + "Error! updated " + Path.GetFileName(file) + " failed\r\n");
                        }
                    }                    
                }
            }
            return true;
        }


        //需要引入IWshRuntimeLibrary，搜索Windows Script Host Object Model

        /// <summary>
        /// 创建快捷方式
        /// </summary>
        /// <param name="directory">快捷方式所处的文件夹</param>
        /// <param name="shortcutName">快捷方式名称</param>
        /// <param name="targetPath">目标路径</param>
        /// <param name="description">描述</param>
        /// <param name="iconLocation">图标路径，格式为"可执行文件或DLL路径, 图标编号"，
        /// 例如System.Environment.SystemDirectory + "\\" + "shell32.dll, 165"</param>
        /// <remarks></remarks>
        private void CreateShortcut(string directory, string shortcutName, string targetPath,
             string description = null, string iconLocation = null)
         {
            if (!System.IO.Directory.Exists(directory))
             {
                 System.IO.Directory.CreateDirectory(directory);
             }

             string shortcutPath = Path.Combine(directory, string.Format("{0}.lnk", shortcutName));
             WshShell shell = new WshShell();
             IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);//创建快捷方式对象
             shortcut.TargetPath = targetPath;//指定目标路径
             shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);//设置起始位置
             shortcut.WindowStyle = 1;//设置运行方式，默认为常规窗口
             shortcut.Description = description;//设置备注
             shortcut.IconLocation = string.IsNullOrWhiteSpace(iconLocation) ? targetPath : iconLocation;//设置图标路径
             shortcut.Save();//保存快捷方式
         }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                //this.Hide();
                //notifyIcon1.Icon = new Icon("C:\\Users\\yhuang9\\Documents\\Visual Studio 2019\\Project\\ICO\\upload.ico");
            }
        }

        private void mnuShow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible=true;
        }

        private void mnuExist_Click(object sender, EventArgs e)
        {
            Save_Setting();
            System.Environment.Exit(0);
        }

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            string dirPath = @"C:\Users\" + lblUserName.Text + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup";
            if (chkAutoStart.Checked == true)
            {
                if (!System.IO.File.Exists(dirPath + @"\" + Application.ProductName + @".lnk"))
                {
                    CreateShortcut(dirPath, "Auto_Backup", Application.StartupPath + @"\" + Application.ProductName + @".exe");
                }
            }
            else
            {
                System.IO.File.Delete(dirPath + @"\" + Application.ProductName + @".lnk");
            }
        }

        private void lblClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要清除所有设置？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lblSourceFolderPath.Text = "";
                lblTargetFolderPath.Text = "";
                dateTimePicker1.Text = "23:00";
                btnStartStop.Text = "Start";
                lblStatus.Text = "Stopped";
                lblStatus.ForeColor = Color.Red;
                timer1.Enabled = false;
                Save_Setting();
            }            
        }

        private void lblShowHideLog_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.InitialDirectory = Application.StartupPath + @"/logs/";
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(ofDialog.FileName);
            }
        }
    }
}
