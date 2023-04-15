using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tweaker_in_1.Форми;

namespace Tweaker_in_1
{
    internal class FormTheme
    {
        public static void DarkTheme()
        {
            Form1.mainForm.panel1.BackColor = Color.FromArgb(0, 0, 0);
            Form1.mainForm.panel2.BackColor = Color.FromArgb(28, 28, 28);
            Form1.mainForm.label1.ForeColor = Color.FromArgb(255, 255, 255);
            Form1.mainForm.button10.ForeColor = Color.FromArgb(255, 255, 255);
            Form1.mainForm.BackColor = Color.FromArgb(20, 20, 20);
            Form1.mainForm.ForeColor = Color.FromArgb(20, 20, 20);

            Form1.очищення.BackColor = Color.FromArgb(28, 28, 28);
            foreach (var item in Form1.очищення.Controls.OfType<CheckBox>())
                item.ForeColor = Color.White;

            Form1.оптимізація.BackColor = Color.FromArgb(28, 28, 28);
            foreach (var item in Form1.оптимізація.Controls.OfType<CheckBox>())
                item.ForeColor = Color.White;

            Form1.інтерфейс.BackColor = Color.FromArgb(28, 28, 28);
            foreach (var item in Form1.інтерфейс.Controls.OfType<CheckBox>())
                item.ForeColor = Color.White;

            Form1.налаштування.BackColor = Color.FromArgb(28, 28, 28);
            foreach (var item in Form1.налаштування.Controls.OfType<CheckBox>())
                item.ForeColor = Color.White;
            foreach (var item in Form1.налаштування.Controls.OfType<Button>())
                item.ForeColor = Color.White;

            Form1.системна_інформація.BackColor = Color.FromArgb(28, 28, 28);
            Form1.системна_інформація.label1.ForeColor = Color.White;




            //foreach (var item in Form1.mainForm.panel2.Controls.OfType<Button>())
            //{
            //    if (item.Name == "button8")
            //        return;
            //    item.ForeColor = Color.FromArgb(255, 255, 255);
            //    item.BackColor = Color.FromArgb(227, 227, 227);
            //}
        }
        public static void LightTheme()
        {
            Form1.mainForm.panel1.BackColor = Color.FromArgb(255, 255, 255);
            Form1.mainForm.panel2.BackColor = Color.FromArgb(227, 227, 227);
            Form1.mainForm.label1.ForeColor = Color.FromArgb(0, 0, 0);
            Form1.mainForm.button10.ForeColor = Color.FromArgb(0, 0, 0);
            Form1.mainForm.BackColor = Color.FromArgb(235, 235, 235);
            Form1.mainForm.ForeColor = Color.FromArgb(20, 20, 20);

            Form1.очищення.BackColor = Color.FromArgb(227, 227, 227);
            foreach (var item in Form1.очищення.Controls.OfType<CheckBox>())
                item.ForeColor = Color.Black;
            
            Form1.оптимізація.BackColor = Color.FromArgb(227, 227, 227);
            foreach (var item in Form1.оптимізація.Controls.OfType<CheckBox>())
                item.ForeColor = Color.Black;
            
            Form1.інтерфейс.BackColor = Color.FromArgb(227, 227, 227);
            foreach (var item in Form1.інтерфейс.Controls.OfType<CheckBox>())
                item.ForeColor = Color.Black;
            
            Form1.налаштування.BackColor = Color.FromArgb(227, 227, 227);
            foreach (var item in Form1.налаштування.Controls.OfType<CheckBox>())
                item.ForeColor = Color.Black;
            foreach (var item in Form1.налаштування.Controls.OfType<Button>())
                item.ForeColor = Color.Black;
            
            Form1.системна_інформація.BackColor = Color.FromArgb(227, 227, 227);
            Form1.системна_інформація.label1.ForeColor = Color.Black;
            
            





            //foreach (var item in Form1.mainForm.panel2.Controls.OfType<Button>())
            //{
            //    if (item.Name == "button8")
            //    {
            //        return;
            //    }
            //    item.ForeColor = Color.FromArgb(0, 0, 0);
            //    item.BackColor = Color.FromArgb(28, 28, 28);
            //}
        }
    }
}