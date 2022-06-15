using System;
using System.IO;

namespace Task3
{
    class Program
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
                    Console.WriteLine($"Исходный размер папки :{SizeFolder(path)} байт ");                   
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
            long originalSize = SizeFolder(path);
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            foreach (string dir in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if ((DateTime.Now - di.LastWriteTime) > TimeSpan.FromMinutes(30))
                {
                    di.Delete(true);
                    
                }
            }
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if ((DateTime.Now - fi.LastWriteTime) > TimeSpan.FromMinutes(30))
                {
                    fi.Delete();
                  
                }
            }
           long temp = SizeFolder(path);
            long size = originalSize - temp;
            Console.WriteLine($"Освобождено: {size} байт\nТекущий размер: {temp} байт ");
        }
        public static long SizeFolder(string folderpath)
        {

            long size = 0;
            if (Directory.Exists(folderpath))
            {
                try
                {
                    foreach (string file in Directory.GetFiles(folderpath))
                    {
                        if (File.Exists(file))
                        {
                            FileInfo fi = new FileInfo(file);
                            size += fi.Length;
                        }
                    }
                    foreach (string dirs in Directory.GetDirectories(folderpath))
                    {
                        size += SizeFolder(dirs);
                    }
                }
                catch (Exception ex)
                { Console.WriteLine($"Не удалось посчитать размер папки, ошибка {ex.Message}"); }
            }
            else
            {
                size = 0;
                Console.WriteLine("Нет доступа!");
            }
            return size;
        }
    }
}