using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace Felix_Ivan
{
    class Math
    {

        public const int width = 60;
        public const int height = 23;
        public static int counter = 0;
        public static int incorrect = 0;
        public static int score = 0;
        public static System.Timers.Timer gameTime;

        static void SideBar(int counter, int incorect)
        {
            for (int i = 0; i <= height + 1; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.Write("█");
            }
            int infoRow = 2;

            Console.SetCursorPosition(width + 7, infoRow++); infoRow++;
            Console.Write("Math Test");
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(width + 2, infoRow++);
            Console.Write(counter);
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("incorrect:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(width + 2, infoRow++);
            Console.Write(incorect);
            Console.SetCursorPosition(width + 2, infoRow += 7); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Felix снимка");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(width + 2, infoRow++);

            
        }
        public static void TimeIsUp(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            SideBar(score, incorrect);
            Console.SetCursorPosition(width - 40, height - 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Time is up!");
            Console.WriteLine("Your overall score from this game is: {0}", score);
            Environment.Exit(0);
        }

        
        static void Main()
        {
            gameTime = new System.Timers.Timer(60000);
            gameTime.Elapsed += new ElapsedEventHandler(TimeIsUp);
            gameTime.Enabled = true;

            Console.BufferWidth = Console.WindowWidth = 100;
            Console.BufferHeight = Console.WindowHeight = 25;

            string example = @"../../example.txt";
            string answers = @"../../answers.txt";
            string answer = "";
            
            
            using (StreamReader firstFile = new StreamReader(example))
            {
                using (StreamReader secondSecond = new StreamReader(answers))
                {
                    //string firstLine = firstFile.ReadLine();
                    //string secondLine = secondSecond.ReadLine();
                    List<string> firstLine = new List<string>();

                    for (string line; (line = firstFile.ReadLine()) != null;)
                    {
                        firstLine.Add(line);
                    }

                    List<string> secondLine = new List<string>();

                    for (string line; (line = secondSecond.ReadLine()) != null; )
                    {
                        secondLine.Add(line);
                    }

                    Random r = new Random();

                    while (firstLine.Count > 0)
                    {
                        
                        SideBar(score, incorrect);
                        Console.SetCursorPosition((100 - width) / 2, 10);
                        int count = firstLine.Count();
                        int index = r.Next(count);
                        Console.Write(firstLine[index] + " ");

                        answer = Console.ReadLine();

                        string suggestion = secondLine[index];

                        if (suggestion.Equals(answer))
                        {
                            score++;
                            Console.SetCursorPosition((100 - width) / 2, 11);
                            Console.WriteLine("Correct! :)");
                        }
                        else
                        {
                            incorrect++;
                            Console.SetCursorPosition((100 - width) / 2, 11);
                            Console.WriteLine("Incorrect :(");

                        }
                        Thread.Sleep(1000);
                        Console.Clear();
                        firstLine.RemoveAt(index);
                        secondLine.RemoveAt(index);
                    }

                    Console.SetCursorPosition((100 - width) / 2, 10);
                    Console.WriteLine("Your Score is {0}", score);
                    Console.SetCursorPosition((100 - width) / 2, 11);
                    Console.WriteLine("Your incorrect answers {0}", incorrect);
                }
            }
        }
    }
}
