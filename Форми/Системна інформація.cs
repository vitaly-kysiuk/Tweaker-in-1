using Microsoft.Win32;
using System;
using System.Management;
using System.Windows.Forms;

namespace Tweaker_in_1.Форми
{
    public partial class Системна_інформація : Form
    {
        public Системна_інформація()
        {
            InitializeComponent();
        }

        private void Системна_інформація_Load(object sender, EventArgs e)
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
            label1.Text = "ОС: " + Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName").ToString() + " " +
                            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("DisplayVersion").ToString() + " " + OSBitDepth + Environment.NewLine +
                            "Имя компьютера: " + Environment.MachineName + Environment.NewLine +
                            $"Процессор: {processor}" + Environment.NewLine +
                            "Частота процессора: " + Convert.ToInt32(friquencyProc) / 1000 + ".00GHz" + Environment.NewLine +
                            "Количество ядер: " + coreCounts + Environment.NewLine +
                            "Количество поток процессора: " + Environment.ProcessorCount + Environment.NewLine +
                            $"Материнская плата: {motherboard}" + Environment.NewLine +
                            "ОЗУ: " + memory + " MB" + Environment.NewLine +
                            $"Видеокарта: {videoAdapters}";
        }
    }
}