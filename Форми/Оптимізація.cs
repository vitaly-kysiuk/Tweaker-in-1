using Microsoft.Win32;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tweaker_in_1.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tweaker_in_1
{
    public partial class Оптимізація : Form
    {
        public Оптимізація()
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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in Controls.OfType<CheckBox>())
                if (!item.Checked && item.AutoCheck)
                    item.Checked = true;
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
            Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications",true).DeleteValue("GlobalUserDisabled");
            Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Search", true).DeleteValue("BackgroundAppGlobalToggle");
            button5.Visible = false;
            checkBox4.AutoCheck = true;
            if (Settings.Default.DarkTheme)
                checkBox4.ForeColor = Color.FromName("Control");
            else
                checkBox4.ForeColor = Color.FromName("ControlDarkDark");
            Sounds.PlaySound1();
        }
    }
}
