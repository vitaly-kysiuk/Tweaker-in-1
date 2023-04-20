using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweaker_in_1.Properties;

namespace Tweaker_in_1
{
    public partial class Оптимізація : Form
    {
        public Оптимізація()
        {
            InitializeComponent();
        }

        private void Оптимізація_Load(object sender, EventArgs e)
        {
            checkBox1.AutoCheck = false;
            if (Settings.Default.DarkTheme)
                checkBox1.ForeColor = Color.FromName("ControlDarkDark");
            else
                checkBox1.ForeColor = Color.FromName("Control");

            checkBox2.AutoCheck = false;
            if (Settings.Default.DarkTheme)
                checkBox2.ForeColor = Color.FromName("ControlDarkDark");
            else
                checkBox2.ForeColor = Color.FromName("Control");

            if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Dsh").GetValue("AllowNewsAndInterests") == null)
            {
                checkBox3.AutoCheck = true;
                button4.Visible = false;
                if (Settings.Default.DarkTheme)
                    checkBox3.ForeColor = Color.FromName("Control");
                else
                    checkBox3.ForeColor = Color.FromName("ControlDarkDark");
            }
            else
            {
                checkBox3.AutoCheck = false;
                button4.Visible = true;
                if (Settings.Default.DarkTheme)
                    checkBox3.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox3.ForeColor = Color.FromName("Control");
            }

            if (Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications").GetValue("GlobalUserDisabled") == null || Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Search").GetValue("BackgroundAppGlobalToggle") == null)
            {
                checkBox4.AutoCheck = true;
                button5.Visible = false;
                if (Settings.Default.DarkTheme)
                    checkBox4.ForeColor = Color.FromName("Control");
                else
                    checkBox4.ForeColor = Color.FromName("ControlDarkDark");
            }
            else
            {
                checkBox4.AutoCheck = false;
                button5.Visible = true;
                if (Settings.Default.DarkTheme)
                    checkBox4.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox4.ForeColor = Color.FromName("Control");
            }
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

        internal void Run()
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
            //if (checkBox1.Checked)
            //if (checkBox2.Checked)
            if (checkBox3.Checked)
            {
                Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Dsh").SetValue("AllowNewsAndInterests", 0, RegistryValueKind.DWord);
                checkBox3.Checked = false;
                checkBox3.AutoCheck = false;
                button4.Visible = true;
                if (Settings.Default.DarkTheme)
                    checkBox3.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox3.ForeColor = Color.FromName("Control");
            }
            if (checkBox4.Checked)
            {
                Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications").SetValue("GlobalUserDisabled", 1, RegistryValueKind.DWord);
                Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Search").SetValue("BackgroundAppGlobalToggle", 0, RegistryValueKind.DWord);
                checkBox4.Checked = false;
                checkBox4.AutoCheck = false;
                button5.Visible = true;
                if (Settings.Default.DarkTheme)
                    checkBox4.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox4.ForeColor = Color.FromName("Control");
                //                [HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications]
                //                "GlobalUserDisabled" = dword:00000001

                //                [HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search]
                //                "BackgroundAppGlobalToggle" = dword:00000000

            }
            if (checkBox5.Checked)
            {
                string path = Application.StartupPath + "/WinDefend.exe";
                //if (!File.Exists(path))
                //    File.WriteAllBytes(Application.StartupPath + "/WinDefend.exe", Resources.WinDefend);
                try
                {
                    FunctionalForForms.TrustedInstaller.Run("cmd");
                    //File.Delete(path);
                }
                catch (Exception)
                {
                    File.Delete(path);
                }
                Task.Delay(1000);
                checkBox5.Checked = false;
                checkBox5.AutoCheck = false;
                if (Settings.Default.DarkTheme)
                    checkBox5.ForeColor = Color.FromName("ControlDarkDark");
                else
                    checkBox5.ForeColor = Color.FromName("Control");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in Controls.OfType<CheckBox>())
                if (!item.Checked && item.AutoCheck)
                    item.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Dsh", true).DeleteValue("AllowNewsAndInterests");
            button4.Visible = false;
            checkBox3.AutoCheck = true;
            if (Settings.Default.DarkTheme)
                checkBox3.ForeColor = Color.FromName("Control");
            else
                checkBox3.ForeColor = Color.FromName("ControlDarkDark");
            Sounds.PlaySound1();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications", true).DeleteValue("GlobalUserDisabled");
            Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Search", true).DeleteValue("BackgroundAppGlobalToggle");
            button5.Visible = false;
            checkBox4.AutoCheck = true;
            if (Settings.Default.DarkTheme)
                checkBox4.ForeColor = Color.FromName("Control");
            else
                checkBox4.ForeColor = Color.FromName("ControlDarkDark");
            Sounds.PlaySound1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
            button5_Click(sender, e);
        }
    }
}