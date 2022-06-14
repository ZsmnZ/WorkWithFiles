using System;
using System.IO;

namespace ReadMeFile
{
    public class Program
    {
       public DateTime time = new DateTime();
        
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
;
            for (int i = 0; i < dirs.Length; i++)
            {
                if(TimeSpan.FromMinutes(30))
                {
                    folders.Delete(true);
                }

              
            }

        }
        
    }
}