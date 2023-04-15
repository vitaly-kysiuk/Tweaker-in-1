using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Forms;

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
            //if (checkBox3.Checked)
            //{
            //    Registry.LocalMachine.?CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Dsh").SetValue("AllowNewsAndInterests", 0, RegistryValueKind.DWord);
            //    Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall").GetSubKeyNames();
            //}
        }
    }
}
