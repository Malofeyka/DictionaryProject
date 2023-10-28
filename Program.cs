using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryProjectC_
{
    class MainMenu
    {
        int choice = 0;
        public int ShowMenu()
        {            
            
            string[] options = { "1. Найти перевод слова", "2. Добавить слово в словарь", "3. Заменить слово", "4. Удалить слово", "5. Создать словарь", "6. Показать все словари\n(управлять стрелками)" };
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Добро пожаловать в словарь!");
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
                        if(choice != 0)
                        {
                            choice--;
                        }
                        else
                        {
                            choice = options.Length-1;
                        }
                        break;
                    
                    case ConsoleKey.DownArrow:
                        if (choice != options.Length-1)
                        {
                            choice++;
                        }
                        else
                        {
                            choice = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return choice+1;


                }
                
            }
            
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            int choice = menu.ShowMenu();
            
            Console.ReadKey();


        }
    }
}
