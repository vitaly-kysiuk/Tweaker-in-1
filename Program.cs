using System;
using System.Threading;
using System.Windows.Forms;

namespace Tweaker_in_1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Exception);
            Application.Run(new Form1());
        }

        private static void Exception(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), e.Exception.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}