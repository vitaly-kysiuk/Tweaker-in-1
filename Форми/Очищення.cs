using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweaker_in_1.FunctionalForForms;
using Tweaker_in_1.Properties;
using static System.Windows.Forms.AxHost;

namespace Tweaker_in_1
{
    public partial class Очищення : Form
    {
        public Очищення()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in Controls.OfType<CheckBox>())
                if (!item.Checked && item.AutoCheck)
                    item.Checked = true;
        }

        internal async void Run()
        {
            #region Перевірка чекбоксів
            bool yes = false;
            foreach (var item in Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    yes = true;
                    break;
                }
            }
            if (!yes)
            {
                MessageBox.Show("Піздєц", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            double size = 0;
            string path;
            Form1.mainForm.need = true;
            Form1.mainForm.Print();
            await Task.Delay(1000);
            if (checkBox1.Checked)
            {
                await Task.Delay(200);
                Cleaner.CleanerFolders();
                path = Environment.GetLogicalDrives()[0] + "lalala";
                if (Directory.Exists(path))
                    size += Cleaner.CleanerInFoldersTheFiles(path);
                checkBox1.Checked = false;
                checkBox1.AutoCheck = false;
                if (Settings.Default.DarkTheme)
                    checkBox1.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox1.ForeColor = Color.FromName("Control");
            }
            if (checkBox2.Checked)
            {
                await Task.Delay(1000);
                path = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Temp";
                if (Directory.Exists(path))
                    size += Cleaner.CleanerInFoldersTheFiles(path);

                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp";
                if (Directory.Exists(path))
                    size += Cleaner.CleanerInFoldersTheFiles(path);
                checkBox2.Checked = false;
                checkBox2.AutoCheck = false;
                if (Settings.Default.DarkTheme)
                    checkBox2.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox2.ForeColor = Color.FromName("Control");
            }
            if (checkBox3.Checked)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\SoftwareDistribution\DataStore";
                if (Directory.Exists(path))
                    size += Cleaner.CleanerInFoldersTheFiles(path);
                checkBox3.Checked = false;
                checkBox3.AutoCheck = false;
                if (Settings.Default.DarkTheme)
                    checkBox3.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox3.ForeColor = Color.FromName("Control");
            }
            if (checkBox4.Checked)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\SoftwareDistribution\Download";
                if (Directory.Exists(path))
                    size += Cleaner.CleanerInFoldersTheFiles(path);
                checkBox4.Checked = false;
                checkBox4.AutoCheck = false;
                if (Settings.Default.DarkTheme)
                    checkBox4.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox4.ForeColor = Color.FromName("Control");
                await Task.Delay(500);
            }
            if (checkBox5.Checked)
            {
                string[] Drives = Environment.GetLogicalDrives();
                foreach (string s in Drives)
                {
                    path = $@"{s}$RECYCLE.BIN";
                    if (Directory.Exists(path) && Cleaner.FolderSize(path) > 129)
                        size += Cleaner.CleanerInFoldersTheFiles(path);
                }
                checkBox5.Checked = false;
                checkBox5.AutoCheck = false;
                if (Settings.Default.DarkTheme)
                    checkBox5.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox5.ForeColor = Color.FromName("Control");
                await Task.Delay(500);
                Form1.Cmd("taskkill /F /IM explorer.exe & start explorer.exe");
            }
            if (checkBox6.Checked)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Telegram Desktop";
                if (Directory.Exists(path))
                    size += Cleaner.CleanerInFoldersTheFiles(path);
                checkBox6.Checked = false;
                checkBox6.AutoCheck = false;
                if (Settings.Default.DarkTheme)
                    checkBox6.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox6.ForeColor = Color.FromName("Control");
                await Task.Delay(300);
            }
            if (checkBox7.Checked)
            {
                #region Cent Browser
                path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\CentBrowser\User Data\Default\Cache\Cache_Data";
                if (Directory.Exists(path))
                    size += Cleaner.CleanerInFoldersTheFiles(path);
                #endregion

                #region Chrome
                path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Google\Chrome\UserData\Default\Cache";
                if (Directory.Exists(path))
                    size += Cleaner.CleanerInFoldersTheFiles(path);
                #endregion

                #region Opera Gx
                path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Opera Software\Opera GX Stable\Cache\Cache_Data";
                if (Directory.Exists(path))
                    size += Cleaner.CleanerInFoldersTheFiles(path);
                path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Opera Software\Opera GX Stable\System Cache\Cache_Data";
                if (Directory.Exists(path))
                    size += Cleaner.CleanerInFoldersTheFiles(path);
                #endregion

                checkBox7.Checked = false;
                checkBox7.AutoCheck = false;
                if (Settings.Default.DarkTheme)
                    checkBox7.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox7.ForeColor = Color.FromName("Control");
            }
            size = Convert.ToDouble(string.Format("{0:f1}", size / 1024 / 1024));
            await Task.Delay(1000);
            Form1.mainForm.need = false;
            MessageBox.Show($"Було очищено: {size} MB", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            await Task.Delay(1000);
        }
    }
}