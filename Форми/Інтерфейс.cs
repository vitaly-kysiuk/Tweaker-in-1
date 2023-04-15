using System;
using System.Linq;
using System.Windows.Forms;

namespace Tweaker_in_1.Форми
{
    public partial class Інтерфейс : Form
    {
        public Інтерфейс()
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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in Controls.OfType<CheckBox>())
                if (!item.Checked && item.AutoCheck)
                    item.Checked = true;
        }
    }
}
