using System;
using System.IO;
using System.Collections.Specialized;
namespace FileSystem
{
    class Program
    {
        static DateTime datetimeend = DateTime.Now;

        static void Main(string[] args)
        {

            string rootDir;
            //задаем папку для обхода
            if (args.Length == 0)
                rootDir = @"e:\garmin\";
            else
                rootDir = args[0].ToString();

           
                datetimeend = datetimeend - TimeSpan.FromMinutes(30);

            //вызываем рекурсивный метод
            DeleteFolder(rootDir);

        }

        static void DeleteFolder(string folder)   //
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(folder);
                DirectoryInfo[] diA = di.GetDirectories();
                FileInfo[] fi = di.GetFiles();
                foreach (FileInfo f in fi)
                {
                    if (f.LastAccessTime < datetimeend)
                        f.Delete();
                }
                foreach (DirectoryInfo df in diA)
                {
                    DeleteFolder(df.FullName);
                }
                if (di.GetDirectories().Length == 0 && di.GetFiles().Length == 0) di.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}