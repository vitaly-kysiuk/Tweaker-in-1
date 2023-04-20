using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweaker_in_1.FunctionalForForms;
using Tweaker_in_1.Properties;
using Tweaker_in_1.Форми;

namespace Tweaker_in_1
{
    public partial class Form1 : Form
    {
        public static Form1 mainForm;
        public static Очищення очищення;
        public static Оптимізація оптимізація;
        public static Інтерфейс інтерфейс;
        public static Налаштування налаштування;
        //public static Системна_інформація системна_інформація;
        private Form active = очищення;
        internal bool need;
        private bool drag;
        private Point startPoint;

        public Form1()
        {
            InitializeComponent();
            mainForm = this;
            InitializeForms();
        }

        internal void InitializeForms()
        {
            очищення = new Очищення();
            очищення.TopLevel = false;
            panel3.Controls.Add(очищення);

            оптимізація = new Оптимізація();
            оптимізація.TopLevel = false;
            panel3.Controls.Add(оптимізація);

            інтерфейс = new Інтерфейс();
            інтерфейс.TopLevel = false;
            panel3.Controls.Add(інтерфейс);

            налаштування = new Налаштування();
            налаштування.TopLevel = false;
            panel3.Controls.Add(налаштування);

            //системна_інформація = new Системна_інформація();
            //системна_інформація.TopLevel = false;
            //panel3.Controls.Add(системна_інформація);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            #region Перевірка Settings
            if (Settings.Default.SystemNotification == true)
                налаштування.checkBox1.Checked = true;
            else
                налаштування.checkBox1.Checked = false;

            if (Settings.Default.ProgramSounds == true)
                налаштування.checkBox2.Checked = true;
            else
                налаштування.checkBox2.Checked = false;

            if (Settings.Default.DarkTheme)
            {
                FormTheme.DarkTheme();
                налаштування.checkBox4.Checked = true;
                button1.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                FormTheme.LightTheme();
                налаштування.checkBox4.Checked = false;
                button1.ForeColor = Color.FromArgb(0, 0, 0);
            }
            #endregion

            #region Перевірка Очищення
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Temp") && File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp"))
            {
                if (Cleaner.FolderSize(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Temp") <= 1 && Cleaner.FolderSize(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp") <= 50000000)
                {
                    очищення.checkBox2.AutoCheck = false;
                    if (Settings.Default.DarkTheme)
                        очищення.checkBox2.ForeColor = Color.FromName("ControlDarkDark");
                    else
                        очищення.checkBox2.ForeColor = Color.FromName("Control");
                }
            }
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\SoftwareDistribution\DataStore"))
            {
                if (Cleaner.FolderSize(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\SoftwareDistribution\DataStore") <= 1)
                {
                    очищення.checkBox3.AutoCheck = false;
                    if (Settings.Default.DarkTheme)
                        очищення.checkBox3.ForeColor = Color.FromName("ControlDarkDark");
                    else
                        очищення.checkBox3.ForeColor = Color.FromName("Control");
                }
            }

            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\SoftwareDistribution\Download"))
            {
                if (Cleaner.FolderSize(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\SoftwareDistribution\Download") <= 1)
                {
                    очищення.checkBox4.AutoCheck = false;
                    if (Settings.Default.DarkTheme)
                        очищення.checkBox4.ForeColor = Color.FromName("ControlDarkDark");
                    else
                        очищення.checkBox4.ForeColor = Color.FromName("Control");
                }
            }

            string[] Drives = Environment.GetLogicalDrives();
            string path = "";
            foreach (string s in Drives)
            {
                path = $@"{s}$RECYCLE.BIN";
                try
                {
                    if (Directory.Exists(path) && Cleaner.FolderSize(path) > 129)
                    {
                        очищення.checkBox5.AutoCheck = true;
                        if (Settings.Default.DarkTheme)
                            очищення.checkBox5.ForeColor = Color.FromName("Control");
                        else
                            очищення.checkBox5.ForeColor = Color.FromName("ControlDarkDark");
                        break;
                    }
                }
                catch (Exception){ }
                
            }

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Telegram Desktop"))
            {
                очищення.checkBox6.AutoCheck = false;
                if (Settings.Default.DarkTheme)
                    очищення.checkBox6.ForeColor = Color.FromName("ControlDarkDark");
                else
                    очищення.checkBox6.ForeColor = Color.FromName("Control");
            }
            if (Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\CentBrowser\User Data\Default\Cache\Cache_Data"))
            {
                очищення.checkBox7.AutoCheck = true;
                if (Settings.Default.DarkTheme)
                    очищення.checkBox7.ForeColor = Color.FromName("Control");
                else
                    очищення.checkBox7.ForeColor = Color.FromName("ControlDarkDark");
            }

            #endregion

            PanelFormNoDispose(очищення);
            await Task.Delay(500);
            mainForm.Location = new Point(mainForm.Location.X, mainForm.Location.Y + 490);

            await Task.Delay(500);
            AnimationFormUo();
            await Task.Delay(8000);
            #region Встановлення Microsoft Visual C++
            string regNamesForCheckvcredit = "";
            foreach (var item in Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall").GetSubKeyNames())
            {
                if (Registry.LocalMachine.OpenSubKey($@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{item}").GetValue("DisplayName") != null && Registry.LocalMachine.OpenSubKey($@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{item}").GetValue("DisplayName").ToString().Contains("Microsoft Visual C++"))
                {
                    regNamesForCheckvcredit += Registry.LocalMachine.OpenSubKey($@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{item}").GetValue("DisplayName").ToString();
                }
            }
            if (!regNamesForCheckvcredit.Contains("Microsoft Visual C++"))
            {
                DialogResult dialogResult = MessageBox.Show("На вашем ПК отсуствует библиотеки Microsoft Visual C++ был установлен. Желаете установить?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    new Thread(() =>
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadFile("https://drive.google.com/uc?export=download&confirm=no_antivirus&id=17EZxdm2Ge2KZ_6SMnzjqkRAsdsYeSW1q", $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Temp\vcredit.exe");
                            Process.Start(new ProcessStartInfo { FileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Temp\vcredit.exe", Arguments = "/S" }).WaitForExit();
                            Thread.Sleep(3000);
                            File.Delete($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Temp\Красівий.exe");
                            MessageBox.Show("Microsoft Visual C++ был установлен", Text);
                        }
                    })
                    .Start();
                }
            }
            else
            {
                regNamesForCheckvcredit = null;
            }
            #endregion
        }

        private async void PanelFormNoDispose(Form fm)
        {
            await Task.Delay(300);
            if (fm != null && fm != active)
            {
                if (active != null)
                    active.Visible = false;
                active = fm;
                fm.Visible = true;
            }
            else
            {
                MessageBox.Show("Окно короче наїбнулось бо null");
            }
        }

        private async void AnimationFormUo()
        {
            while (mainForm.Opacity < 0.98)
            {
                mainForm.Opacity += 0.02;
                mainForm.Location = new Point(mainForm.Location.X, mainForm.Location.Y - 10);
                await Task.Delay(1);
            }
        }

        private async void AnimationFormDown()
        {
            while (mainForm.Opacity > 0)
            {
                mainForm.Opacity -= 0.02;
                mainForm.Location = new Point(mainForm.Location.X, mainForm.Location.Y + 10);
                await Task.Delay(1);
            }
        }

        internal static void Cmd(string line)
        {
            Process.Start(new ProcessStartInfo { FileName = "cmd.exe", Arguments = $@"/c {line}", Verb = "runas", WindowStyle = ProcessWindowStyle.Hidden }).WaitForExit();
        }

        internal async void Print()
        {
            while (need)
            {
                button10.Text = "Застосовую";
                await Task.Delay(200);
                button10.Text += ".";
                await Task.Delay(200);
                button10.Text += ".";
                await Task.Delay(200);
                button10.Text += ".";
                await Task.Delay(500);
            }
            button10.Text = "Застосувати";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
            if (button1.ForeColor != Color.FromArgb(255, 255, 255))
            {
                if (Settings.Default.DarkTheme)
                {
                    foreach (Button item in panel2.Controls.OfType<Button>())
                        item.ForeColor = Color.FromName("ControlDarkDark");
                    button1.ForeColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    foreach (Button item in panel2.Controls.OfType<Button>())
                    {
                        item.ForeColor = Color.FromName("ControlLightLight");
                    }
                    button1.ForeColor = Color.FromArgb(0, 0, 0);
                }
                PanelFormNoDispose(очищення);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
            if (button2.ForeColor != Color.FromArgb(255, 255, 255))
            {
                if (Settings.Default.DarkTheme)
                {
                    foreach (Button item in panel2.Controls.OfType<Button>())
                        item.ForeColor = Color.FromName("ControlDarkDark");
                    button2.ForeColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    foreach (Button item in panel2.Controls.OfType<Button>())
                    {
                        item.ForeColor = Color.FromName("ControlLightLight");
                    }
                    button2.ForeColor = Color.FromArgb(0, 0, 0);
                }
                PanelFormNoDispose(оптимізація);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
            if (button3.ForeColor != Color.FromArgb(255, 255, 255))
            {
                if (Settings.Default.DarkTheme)
                {
                    foreach (Button item in panel2.Controls.OfType<Button>())
                    {
                        item.ForeColor = Color.FromName("ControlDarkDark");
                    }
                    button3.ForeColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    foreach (Button item in panel2.Controls.OfType<Button>())
                    {
                        item.ForeColor = Color.FromName("ControlLightLight");
                    }
                    button3.ForeColor = Color.FromArgb(0, 0, 0);
                }
                PanelFormNoDispose(інтерфейс);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
            if (button4.ForeColor != Color.FromArgb(255, 255, 255))
                if (Settings.Default.DarkTheme)
                    foreach (Button item in panel2.Controls.OfType<Button>())
                    {
                        item.ForeColor = Color.FromName("ControlDarkDark");
                        button4.ForeColor = Color.FromArgb(255, 255, 255);
                    }
                else
                {
                    button4.ForeColor = Color.FromArgb(255, 255, 255);
                    foreach (Button item in panel2.Controls.OfType<Button>())
                    {
                        item.ForeColor = Color.FromName("ControlLightLight");
                        button4.ForeColor = Color.FromArgb(0, 0, 0);
                    }
                }
            PanelFormNoDispose(налаштування);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Sounds.PlaySound3();
            //if (button5.ForeColor != Color.FromArgb(255, 255, 255))
            //    if (Settings.Default.DarkTheme)
            //        foreach (Button item in panel2.Controls.OfType<Button>())
            //        {
            //            item.ForeColor = Color.FromName("ControlDarkDark");
            //            button5.ForeColor = Color.FromArgb(255, 255, 255);
            //        }
            //    else
            //        foreach (Button item in panel2.Controls.OfType<Button>())
            //        {
            //            item.ForeColor = Color.FromName("ControlLightLight");
            //            button5.ForeColor = Color.FromArgb(0, 0, 0);
            //        }
            //PanelFormNoDispose(системна_інформація);
            //системна_інформація.Run();
            //bool yes = false;
            //Process[] listprosecc = Process.GetProcesses();
            //foreach (var item in listprosecc)
            //    if (item.ProcessName == ("WmiPrvSE"))
            //        yes = true;

            //if (File.Exists(@"C:\Windows\System32\wbem\WmiPrvSE.exe") && yes)
            //{
            try
            {
                string processor = "", coreCounts = "", friquencyProc = "", videoAdapters = "", motherboard = "";
                ulong memory = 0;

                #region Проц
                foreach (var item in new ManagementObjectSearcher("root\\cimv2", "select * from win32_processor").Get())
                {
                    processor = item.GetPropertyValue("Name").ToString();
                    coreCounts = item.GetPropertyValue("NumberOfCores").ToString();
                    friquencyProc = item.GetPropertyValue("MaxClockSpeed").ToString();
                }
                #endregion

                #region Мать
                foreach (var item in new ManagementObjectSearcher("root\\cimv2", "select * from win32_baseboard").Get())
                    motherboard += item.GetPropertyValue("Manufacturer").ToString() + " " + item.GetPropertyValue("Product").ToString();
                #endregion

                #region ОЗУ
                foreach (var item in new ManagementObjectSearcher("root\\cimv2", "select * from win32_physicalmemory").Get())
                    memory += (Convert.ToUInt64(item.GetPropertyValue("Capacity")) / 1024 / 1024);
                #endregion

                #region Видюха
                foreach (var item in new ManagementObjectSearcher("root\\cimv2", "select * from win32_videocontroller").Get())
                    if (videoAdapters.Length == 0 && item.GetPropertyValue("Name").ToString().Remove(5) == "Intel")
                        videoAdapters += item.GetPropertyValue("Name").ToString();

                foreach (var item in new ManagementObjectSearcher("root\\cimv2", "select * from win32_videocontroller").Get())
                    if (item.GetPropertyValue("Name").ToString().Remove(5) != "Intel")
                        if (videoAdapters.Length == 0)
                            videoAdapters += item.GetPropertyValue("Name").ToString();
                        else
                            videoAdapters += "\n" + item.GetPropertyValue("Name").ToString();

                #endregion

                string OSBitDepth = "";
                if (Environment.Is64BitOperatingSystem)
                    OSBitDepth = "64-х разрядная";
                else
                    OSBitDepth = "32-х разрядная";
                MessageBox.Show("ОС: " + Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName").ToString() + " " +
                                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("DisplayVersion").ToString() + " " + OSBitDepth + Environment.NewLine +
                                "Имя компьютера: " + Environment.MachineName + Environment.NewLine +
                                $"Процессор: {processor}" + Environment.NewLine +
                                "Частота процессора: " + Convert.ToInt32(friquencyProc) / 1000 + ".00GHz" + Environment.NewLine +
                                "Количество ядер: " + coreCounts + Environment.NewLine +
                                "Количество поток процессора: " + Environment.ProcessorCount + Environment.NewLine +
                                $"Материнская плата: {motherboard}" + Environment.NewLine +
                                "ОЗУ: " + memory + " MB" + Environment.NewLine +
                                $"Видеокарта: {videoAdapters}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                MessageBox.Show("WMI відсутній на ПК");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В розробці...", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
            AnimationFormDown();
            await Task.Delay(1000);
            notifyIcon1.Visible = true;
            if (налаштування.checkBox1.Checked)
                notifyIcon1.ShowBalloonTip(1000);
            Hide();
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
            AnimationFormDown();
            await Task.Delay(1000);
            Application.Exit();
        }

        private async void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            AnimationFormUo();
            await Task.Delay(1000);
            notifyIcon1.Visible = false;
        }

        private async void закритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnimationFormDown();
            await Task.Delay(1000);
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            AnimationFormUo();
            notifyIcon1.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (active.Text == "Очищення")
                очищення.Run();
            else if (active.Text == "Оптимізація")
                оптимізація.Run();
            //else if (active.Text == "Інтерфейс")
            //    інтерфейс.Run();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1_MouseDown(sender, e);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1_MouseMove(sender, e);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версія програми: " + Application.ProductVersion + " [beta]" + Environment.NewLine +
                "Розробник: sulky" + Environment.NewLine +
                "Програма розроблена на .NET Framework 4.6.2 та підтримується розробником", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}