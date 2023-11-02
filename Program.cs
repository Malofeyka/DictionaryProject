using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace DictionaryProjectC_
{
    public class MainMenu
    {
        int choice = 0;
        public string[] options = { "1. Найти перевод слова", "2. Добавить слово в словарь", "3. Заменить слово", "4. Удалить слово", "5. Создать словарь", "6. Показать все словари", "7. Выход\n(управлять стрелками)" };
        public string hello = "Добро пожаловать в словарь!";
        public int ShowMenu(string[] options, string hello)
        {
            Console.Clear();
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(hello);
                for (int i = 0; i < options.Length; i++)
                {
                    if (choice == i)
                    {
                        Console.WriteLine($">{options[i]}");
                    }
                    else
                    {
                        Console.WriteLine($" {options[i]}");
                    }
                }
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (choice != 0)
                        {
                            choice--;
                        }
                        else
                        {
                            choice = options.Length - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (choice != options.Length - 1)
                        {
                            choice++;
                        }
                        else
                        {
                            choice = 0;
                        }
                        break;
                    case ConsoleKey.Enter:

                        return choice + 1;

                }

            }


        }
    }

    public class SubMenuAddWord : MainMenu
    {
        public string[] options = { "1. Добавить русское слово", "2. Добавить английское слово", "3. Назад" };
        public string hello = "Добавление нового слова";
    }

    public class Dictionary : MainMenu
    {
        public string[] options = { "1. Создать англо-русский словарь", "2. Создать русско-английский словарь", "3. Назад" };
        public string hello = "Создание словаря";
        public string pathRtoE = "C:\\Users\\hoxy_\\Source\\Repos\\Malofeyka\\DictionaryProject\\dicts\\RusEng";
        public string pathEtoR = "C:\\Users\\hoxy_\\Source\\Repos\\Malofeyka\\DictionaryProject\\dicts\\EngRus";
        public void createFile(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите название: ");
                string title = Console.ReadLine();


                if (File.Exists(path + "\\" + title + ".txt"))
                {
                    Console.WriteLine("Файл уже существует");
                    Thread.Sleep(3000);

                }
                else
                {

                    FileStream fs = File.Create(path + "\\" + title + ".txt");
                    Console.WriteLine("Файл создан успешно");
                    Thread.Sleep(3000);
                    fs.Close();
                    break;


                }

            }

        }
    }

    public class ReadAllThat
    {
        public List<string> ReadInSet(string path)
        {
            while (true)
            {
                try
                {
                    var words = new List<string>();
                    using (StreamReader reader = new StreamReader(path, Encoding.GetEncoding("windows-1251")))
                    {
                        string line;
                        while ((line = reader.ReadLine()) is not null)
                        {
                            words.Add(line);
                        }
                    }
                    Console.Clear();
                    foreach (var e in words)
                    {
                        Console.WriteLine(e);
                    }

                    return words;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }


            }

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            SubMenuAddWord menuAddWord = new SubMenuAddWord();
            Dictionary dictionary = new Dictionary();
            ReadAllThat read1 = new ReadAllThat();
            int choice = 0;
            while (true)
            {
                if (choice == 0)
                {
                    choice = menu.ShowMenu(menu.options, menu.hello);
                }
                else if (choice == 1)
                {
                    read1.ReadInSet(dictionary.pathEtoR + "\\test1.txt");
                    choice = 0;
                    Console.ReadKey();
                }
                else if (choice == 2)
                {
                    choice = menuAddWord.ShowMenu(menuAddWord.options, menuAddWord.hello);

                }
                else if (choice == 3)
                {
                    Console.ReadKey();
                }
                else if (choice == 4)
                {
                    Console.ReadKey();
                }
                else if (choice == 5)
                {
                    choice = dictionary.ShowMenu(dictionary.options, dictionary.hello);
                    if (choice == 1)
                    {
                        dictionary.createFile(dictionary.pathEtoR);
                        choice = 0;
                    }
                    else if (choice == 2)
                    {
                        dictionary.createFile(dictionary.pathRtoE);
                        choice = 0;
                    }

                }
                else if (choice == 6)
                {
                    Console.Clear();
                    Console.WriteLine("Англо-русские словари");
                    DirectoryInfo di = new DirectoryInfo(dictionary.pathEtoR);
                    foreach (var fi in di.GetFiles())
                    {
                        Console.WriteLine("\t- " + fi.Name);
                    }
                    Console.WriteLine("Русско-английские словари");
                    DirectoryInfo di1 = new DirectoryInfo(dictionary.pathRtoE);
                    foreach (var fi in di1.GetFiles())
                    {
                        Console.WriteLine("\t- " + fi.Name);
                    }
                    Console.ReadKey();
                    choice = 0;
                }
                else if (choice == 7)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
