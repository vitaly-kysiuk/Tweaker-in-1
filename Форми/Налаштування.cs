using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Windows.Forms;

namespace Tweaker_in_1.Форми
{
    public partial class Налаштування : Form
    {
        public Налаштування()
        {
            InitializeComponent();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            Sounds.PlaySound3();
            if (checkBox1.Checked)
                Properties.Settings.Default.SystemNotification = true;
            else
                Properties.Settings.Default.SystemNotification = false;
            Properties.Settings.Default.Save();
        }

        private static bool Ok(string host)
        {
            try
            {
                Dns.GetHostEntry(host);
                return true;
            }
            catch { return false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string programName = Application.ProductName;
            string programPath = Application.StartupPath + "\\";
            using (WebClient client = new WebClient())
            {
                if (Ok("google.com"))
                {
                    string newVersion = client.DownloadString("https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1XIOtZaD-fiE7oRK3frMv7minQ00G0otE");
                    if (Convert.ToDouble(Application.ProductVersion, CultureInfo.InvariantCulture)  == Convert.ToDouble(newVersion, CultureInfo.InvariantCulture))
                        MessageBox.Show("Встановлена остання версія програми", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    else
                    {
                        if (MessageBox.Show("Доступна нова версія програми. Бажаєте оновити?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                        {
                            client.DownloadFile("https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1hM6tlE9CIKXcfFXFzULtRi369ztf1mUG", programPath + "temp.exe");
                            Process.Start(new ProcessStartInfo { FileName = "cmd", Arguments = $"/c taskkill /f /im \"{programName}\".exe && timeout /t 1 && del \"{programName}\".exe && ren temp.exe \"{programName}\".exe && \"{programName}\".exe", WindowStyle = ProcessWindowStyle.Hidden });
                        }
                    }
                }
                else
                    MessageBox.Show("Перевірте підключення до інтернету");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                Properties.Settings.Default.ProgramSounds = true;
            else
                Properties.Settings.Default.ProgramSounds = false;
            Properties.Settings.Default.Save();
        }
        private void checkBox3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_Click(object sender, EventArgs e)
        {

            if (checkBox4.Checked)
            {
                FormTheme.DarkTheme();
                Properties.Settings.Default.DarkTheme = true;
            }
            else
            {
                FormTheme.LightTheme();
                Properties.Settings.Default.DarkTheme = false;
            }
            Properties.Settings.Default.Save();
        }
    }
}
