using System;
using System.IO;
using System.Threading.Tasks;

namespace Tweaker_in_1.FunctionalForForms
{
    internal class Cleaner
    {
        public static void CleanerFolders()
        {

        }

        public static bool PresenceOfFoldersInRecycleBin(string folder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            int count = 0;
            // Add subdirectory sizes.
            DirectoryInfo[] dis = directoryInfo.GetDirectories();
            foreach (DirectoryInfo di in dis)
                count++;
            if (count > 2)
                return true;
            return false;
        }

        public static double FolderSize(string folder)
        {
            double Size = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);

            // Add file sizes.
            FileInfo[] fis = directoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
                //MessageBox.Show(fi.FullName);
            }

            // Add subdirectory sizes.
            DirectoryInfo[] dis = directoryInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            foreach (DirectoryInfo di in dis)
                Size += FolderSize(di.FullName);

            return Size;
            //double size = 0;
            //DirectoryInfo dir = new DirectoryInfo(folder);

            //foreach (FileInfo fi in dir.GetFiles("*.*"))
            //{
            //    size += fi.Length;
            //    Task.Delay(10);
            //}

            //foreach (DirectoryInfo di in dir.GetDirectories("*.*"))
            //{
            //    FolderSize(di.FullName);
            //}
            //return size;
        }

        public static double DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                double size = 0;
                FileInfo info = new FileInfo(path);
                size += info.Length;
                info.Delete();
                return size;
            }
            return 0;
        }
        public static double CleanerInFoldersTheFiles(string folder)
        {
            double size = 0;
            double realsize = 0;
            DirectoryInfo dir = new DirectoryInfo(folder);

            foreach (FileInfo fi in dir.GetFiles("*.*", SearchOption.TopDirectoryOnly))
            {
                //try
                //{
                realsize = fi.Length;
                fi.Delete();
                size += realsize;
                Task.Delay(10);
                //}
                //catch (Exception) { }
            }

            foreach (DirectoryInfo di in dir.GetDirectories("*.*"))
            {
                try
                {
                    CleanerInFoldersTheFiles(di.FullName);
                    di.Delete();
                }
                catch (Exception) { }
            }
            return size;
        }
    }
}