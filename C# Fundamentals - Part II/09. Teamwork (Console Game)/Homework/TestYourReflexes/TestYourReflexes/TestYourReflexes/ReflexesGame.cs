using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Timers;

namespace TestYourReflexes
{
    class ReflexesGame
    {
        //Game time
        public static System.Timers.Timer gameTime;

        public static void TimeIsUp(Object source, ElapsedEventArgs e)
        {
            Console.SetCursorPosition(width - 40, height - 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Time is up!");
            Console.WriteLine("Your overall score from this game is: {0}", overallResult);
            Console.WriteLine("Press q for exit");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).KeyChar == 'q')
                    {
                        Environment.Exit(0);
                    }
                }
            }
            
        }
        //
        struct symbol
        {
            public int x;
            public int y;
            public char c;
            public ConsoleColor color;
        }

        static void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Green)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        public const int width = 60;
        public const int height = 23;
        public static int counter = 0;
        public static int timeBonus = 0;
        public static int overallResult;
        public static Random randomNum = new Random();
        
        //Side Bar
        static void SideBar()
        {
            for (int i = 0; i <= height + 1; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
            }
            int infoRow = 2;
            Console.SetCursorPosition(width + 1, infoRow++); infoRow++;
            Console.Write("Test Your Reflexes");
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Score:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(width + 2, infoRow++);
            Console.Write(counter);
            Console.SetCursorPosition(width + 2, infoRow++);
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Time Bonus:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(width + 2, infoRow++);
            Console.Write(timeBonus);
            Console.SetCursorPosition(width + 2, infoRow++);
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Overall result:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(width + 2, infoRow++);
            Console.Write(overallResult);
            Console.SetCursorPosition(width + 2, infoRow += 2); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Felix снимка");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(width + 2, infoRow++);
        }
        //

        static void Main()
        {
            //game timer
            gameTime = new System.Timers.Timer(10000);
            gameTime.Elapsed += new ElapsedEventHandler(TimeIsUp);
            gameTime.Enabled = true;

            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = 100;
            Console.BufferHeight = Console.WindowHeight = 25;

            //reading the symbols from a file
            StreamReader reader = new StreamReader(@"../../input_symbols.txt", System.Text.Encoding.UTF8);
            string contents = reader.ReadToEnd();
            char[] symbols = new char[contents.Length];
            reader.Close();
            int len = contents.Length;

            //create a char array with the chars in the txt file
            for (int i = 0; i < len; i++)
            {
                symbols[i] = contents[i];
            }

            SideBar();

            //game logic
            while (true)
            {
                symbol symbol = new symbol();
                symbol.color = ConsoleColor.Green;
                symbol.x = randomNum.Next(width);
                symbol.y = randomNum.Next(height);
                symbol.c = symbols[randomNum.Next(0, symbols.Length)];

                PrintOnPosition(symbol.x, symbol.y, symbol.c, symbol.color);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                if (symbol.c == Console.ReadKey(true).KeyChar)
                {
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    counter++;

                    if (ts.Milliseconds < 200)
                    {
                        timeBonus++;
                    }
                    overallResult = (counter * timeBonus) / 2;
                    Console.Clear();
                    SideBar();
                }
                else
                {
                    Console.Clear();
                    SideBar();
                }
            }
        }
    }
}