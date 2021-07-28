using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificatorsLoader
{
    class Program
    {
        static void PrintMenu(string[] menuItems, int choice, string info)
        {
            Console.Clear();
            Console.WriteLine(info);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == choice) Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static int MenuChoice(string[] menuItems, string info = "")
        {
            Console.CursorVisible = false;
            int choice = 0;
            while (true)
            {
                PrintMenu(menuItems, choice, info);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (choice != 0) choice--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (choice != menuItems.Length - 1) choice++;
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return choice;
                }
            }
        }

        static void Main(string[] args)
        {
            string[] menu = new string[] { "Загрузить ОКПД 2", "Загрузить ОКЕИ", "Загрузить список должностей", "Загрузить все", "Выйти" };

            while (true)
            {
                int userChoice = MenuChoice(menu, "Выберите необходимое действие") + 1;
                Console.Clear();
                if (userChoice == menu.Length) break;

                switch (userChoice)
                {
                    case 1:
                        OKPD.Load();
                        break;

                    case 2:
                        OKEI.Load();
                        break;

                    case 3:
                        PositionList.Load();
                        break;

                    case 4:
                        OKPD.Load();
                        OKEI.Load();
                        PositionList.Load();
                        break;
                }

                Console.ReadLine();
            }
        }
    }
}
