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
     public class Mathematics
    {
        public static bool GameOver = false;
        public const int width = 60;
        public const int height = 23;
        public static int counter = 0;
        public static int incorrect = 0;
        public static int score = 0;
        public static System.Timers.Timer gameTime;
       // public static Stopwatch stopwatch = new Stopwatch();

        static void SideBar(int counter, int incorect)
        {
            for (int i = 0; i <= height + 1; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("█");
            }
            int infoRow = 2;

            Console.SetCursorPosition(width + 7, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Math Test");
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(width + 2, infoRow++);
            Console.Write(counter);
            Console.SetCursorPosition(width + 2, infoRow+=2); infoRow++;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Incorrect:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(width + 2, infoRow+=2);
            Console.Write(incorect);
            Console.SetCursorPosition(width + 2, infoRow += 7); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        static void GameRules()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(new string('█', width));
            Console.SetCursorPosition(22, 5);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Give me the answer!");
            Console.SetCursorPosition(22, 7);
            Console.Write("Rise your score!");
            Console.SetCursorPosition(22, 9);
            Console.Write("Become a ninja!");
            Console.SetCursorPosition(18, 11);
            Console.Write("Press any key to start playing.");
            Console.SetCursorPosition(0, 22);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(new string('█', width));

            SideBar(counter, incorrect);

            Console.ReadKey();
            return;
        }
        public static void TimeIsUp(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            SideBar(score, incorrect);            
            Console.ForegroundColor = ConsoleColor.Red;           
            Console.SetCursorPosition((100 - width) / 2, 10);
            Console.WriteLine("Your Score is {0}", score);
            Console.SetCursorPosition((100 - width) / 2, 11);
            Console.WriteLine("Your incorrect answers {0}", incorrect);

            SaveHighScore(score);

            GameOver = true;
            gameTime.Stop();
        }

        private static void SaveHighScore(int totalScore)
        {
            string[] highScore = new string[5];
            StreamReader readScore = new StreamReader("../../../../../textFiles/HighScores.txt");

            using (readScore)
            {
                int i = 0;
                for (string line; (line = readScore.ReadLine()) != null; i++)
                {
                    highScore[i] = line;
                }
            }

            if (Convert.ToInt32(highScore[2]) < totalScore)
            {
                highScore[2] = totalScore.ToString();
                StreamWriter newscore = new StreamWriter("../../../../../textFiles/HighScores.txt");
                using (newscore)
                {
                    for (int i = 0; i < highScore.Length; i++)
                    {
                        newscore.WriteLine(highScore[i]);
                    }
                }
            }
        }

        public static void Play()
        {
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = 100;
            Console.BufferHeight = Console.WindowHeight = 25;

            GameRules();
            Console.Clear();
            score = 0;
            incorrect = 0;
            gameTime = new System.Timers.Timer(60000);
            gameTime.Elapsed += new ElapsedEventHandler(TimeIsUp);
            gameTime.Enabled = true;

            Console.BufferWidth = Console.WindowWidth = 100;
            Console.BufferHeight = Console.WindowHeight = 25;

            string example = @"../../../../../textFiles/example.txt";
            string answers = @"../../../../../textFiles/answers.txt";
            string answer = "";


            using (StreamReader firstFile = new StreamReader(example))
            {
                using (StreamReader secondSecond = new StreamReader(answers))
                {
                    
                    //string firstLine = firstFile.ReadLine();
                    //string secondLine = secondSecond.ReadLine();
                    List<string> firstLine = new List<string>();

                    for (string line; (line = firstFile.ReadLine()) != null; )
                    {
                        firstLine.Add(line);
                    }

                    List<string> secondLine = new List<string>();

                    for (string line; (line = secondSecond.ReadLine()) != null; )
                    {
                        secondLine.Add(line);
                    }

                    Random r = new Random();

                    //stopwatch.Start();

                    while (true)
                    {
                        
                        SideBar(score, incorrect);
                        Console.SetCursorPosition((100 - width) / 2 - 6, 10);
                        int count = firstLine.Count();
                        int index = r.Next(count);
                        Console.Write(firstLine[index] + " ");

                        answer = Console.ReadLine();
                        if (GameOver == true)
                        {
                            GameOver = false;                       
                            return;
                        }
                        string suggestion = secondLine[index];

                        if (suggestion.Equals(answer))
                        {
                            score++;
                            Console.SetCursorPosition((100 - width) / 2 - 6, 11);
                            Console.WriteLine("Correct! :)");
                        }
                        else
                        {
                            incorrect++;
                            Console.SetCursorPosition((100 - width) / 2 - 6, 11);
                            Console.WriteLine("Incorrect :(");

                        }
                        Thread.Sleep(1000);
                        Console.Clear();
                        firstLine.RemoveAt(index);
                        secondLine.RemoveAt(index);
                    }                   
                }
            }
        }

        static void Main()
        {
            Play();
        }
    }
}
