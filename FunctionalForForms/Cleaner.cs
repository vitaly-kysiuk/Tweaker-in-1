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

        public static double FolderSize(string folder)
        {
            double size = 0;
            DirectoryInfo dir = new DirectoryInfo(folder);

            foreach (var file in dir.GetFiles("*.*", SearchOption.AllDirectories))
            {
                size += file.Length;
                Task.Delay(10);
            }
            return size;
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

            foreach (FileInfo fi in dir.GetFiles("*.*", SearchOption.AllDirectories))
            {
                try
                {
                    realsize = fi.Length;
                    fi.Delete();
                    size += realsize;
                    Task.Delay(10);
                }
                catch (Exception) { }
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
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