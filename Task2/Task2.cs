using System;

using System.IO;

namespace task2
{

    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Укажите каталог:");
            string path = Console.ReadLine();
            Console.WriteLine("Размер директории: {0} байт", SizeFolder(path));
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
