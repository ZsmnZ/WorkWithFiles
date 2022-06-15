using System;
using System.IO;

namespace ReadMeFile
{
    public class Program
    {          
        public static void Main()
        {
            ClearFolders();
        }
        public static void ClearFolders()
        {
            Console.WriteLine("Укажите путь до папки:");
            string path = Console.ReadLine();
            DirectoryInfo folders = new DirectoryInfo(path);
            try
            {
                if (folders.Exists)
                {
                    Console.WriteLine($"В папке {folders.Name}: каталогов {folders.GetDirectories().Length} \n\t\t\tфайлов {folders.GetFiles().Length} ");
                }
                else
                {
                    Console.WriteLine("Передан некорректный путь!");
                    ClearFolders();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
           foreach(string dir in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if((DateTime.Now - di.LastWriteTime) > TimeSpan.FromMinutes(30))
                { 
                    di.Delete(true);
                    Console.WriteLine($"папка: {di.FullName} - удалена");
                }
            }
           foreach(string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if ((DateTime.Now - fi.LastWriteTime) > TimeSpan.FromMinutes(30))
                {
                    fi.Delete();
                    Console.WriteLine($"файл : {fi.Name} - удалён");
                }
            }
          
        }      
    }
}