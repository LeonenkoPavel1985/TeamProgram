using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace TeamProgram
{
    class Program
    {
        static string path = AppDomain.CurrentDomain.BaseDirectory;
        static void ShowMenu()
        {
            Console.WriteLine("Выберите ваше действие:");
            Console.WriteLine("1. Создание текстового файла.");
            Console.WriteLine("2. Вывод на экран консоли/терминала содержимого текстового файла.");
            Console.WriteLine("3. Вывод полного пути, где сейчас находитесь в структуре каталогов.");
            Console.WriteLine("4. Переход в указанный каталог 4 пробел 'путь каталога или папка в текущем'");
            Console.WriteLine("5. Копирование в указанное место. 5 пробел 'путь к каталогу'");
            Console.WriteLine("6. Удаление файла.");
        }
        static void СreateFile() // создание текстового файла (1).
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();

            path = !path.EndsWith(@"\") ? $"{path}\\" : path;
            File.WriteAllText($"{path}Test.txt", text);
        }
        static void OutputFile() // вывод содержимого файла на экран (2).
        {
            Console.WriteLine("Текст находящийся в файле:");
            path = !path.EndsWith(@"\") ? $"{path}\\" : path;

            if(!File.Exists($"{path}Test.txt"))
            {
                Console.WriteLine("Файл не найден");
                return;
            }

            var a = File.ReadAllText($"{path}Test.txt");
            Console.WriteLine(a);
        }
        static void PathOutput() // вывод полного пути к файлу (3).
        {
            Console.WriteLine(path);
        }
        static void Transition(string newPath) // переход в указанный каталог (4).
        {
            if(!Directory.Exists(newPath))
            {
                if(Directory.Exists($"{path}{newPath}"))
                {
                    path = $"{path}{newPath}";
                    return;
                }

                Console.WriteLine("Каталог не найден!");
            }
            else
            {
                path = newPath;
            }
        }
        static void Copy(string newPath) //  копирование в указанное место (5).
        {
            if(!Directory.Exists(newPath))
            {
                Console.WriteLine("Каталог не найден");
            }

            path = !path.EndsWith(@"\") ? $"{path}\\" : path;
            string filePath = $"{path}Test.txt";
            string filePathTo = $"{newPath}Test.txt";

            FileInfo fileInf = new FileInfo(filePath);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(filePathTo);
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }
        static void Delete() //  удаление файла (6).
        {
            path = !path.EndsWith(@"\") ? $"{path}\\" : path;
            string filePath = $"{path}Test.txt";

            FileInfo fileInf = new FileInfo(filePath);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }
        static void Main(string[] args)
        {
            string select = "";
            ShowMenu();

            while (select.ToLower() != "y")
            {
                Console.Write("Введите команду ");
                select = Convert.ToString(Console.ReadLine());
                var l = select.Split(' ');

                switch (l[0])
                {
                    case "1":
                        СreateFile();
                        break;

                    case "2":
                        OutputFile();
                        break;

                    case "3":
                        PathOutput();
                        break;

                    case "4":
                        Transition(l[1]);
                        break;

                    case "5":
                        Copy(l[1]);
                        break;

                    case "6":
                        Delete();
                        break;
                }
            } 

            Console.WriteLine("До свидания...");
        }
    }
}
        
    

