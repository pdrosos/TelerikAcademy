using System;
using System.IO;
using System.Linq;
using System.Threading;


namespace ApacheCombat
{
    class StartScreen
    {
        static string[] menu = new string[] { "1. Play game", "2.Exit" };

        public static void DrawAsciiHelicopter(string pathToAsciFile)
        {
            StreamReader reader = new StreamReader(pathToAsciFile);
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();


                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber < 7)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                    Thread.Sleep(20);
                }
            }            
        }

        public static void MenuChoice()
        {
            bool choice = false;
            int row = 0;

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine(menu[0]);
            Console.ResetColor();
            Console.WriteLine(menu[1]);

            while (!choice)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            choice = true;
                            if (row > 0)
                            {
                                Console.WriteLine("\nWe are sorry that you're leaving!\n");
                                Environment.Exit(0);
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (row == 1)
                            {
                                row--;
                                Console.SetCursorPosition(0, Console.CursorTop - 2);
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(menu[0]);
                                Console.ResetColor();
                                Console.WriteLine(menu[1]);
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (row == 0)
                            {
                                row++;
                                Console.SetCursorPosition(0, Console.CursorTop - 2);
                                Console.ResetColor();
                                Console.WriteLine(menu[0]);
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(menu[1]);
                                Console.ResetColor();
                            }
                            break;
                        default:
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.Write(' ');
                            Console.SetCursorPosition(0, Console.CursorTop);
                            break;
                    }
                }
            }

            Console.Clear();
        }
    }
}
