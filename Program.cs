using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryProjectC_
{
    public class MainMenu
    {
        int choice = 0;
        public string[] options = { "1. Найти перевод слова", "2. Добавить слово в словарь", "3. Заменить слово", "4. Удалить слово", "5. Создать словарь", "6. Показать все словари\n(управлять стрелками)" };
        public string hello = "Добро пожаловать в словарь!";
        public int ShowMenu(string[] options, string hello)
        {
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

    public class SubMenuFindWord:MainMenu
    {
        public string[] options = { "1. Добавить русское слово", "2. Добавить английское слово", "3. Назад" };
        public string hello = "Добавление нового слова";
        
    
    }   


    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            int choice = menu.ShowMenu(menu.options, menu.hello);                    
            Console.ReadKey();
            SubMenuFindWord menuFindWord = new SubMenuFindWord();
            menuFindWord.ShowMenu(menuFindWord.options,menuFindWord.hello);

        }
    }
}
