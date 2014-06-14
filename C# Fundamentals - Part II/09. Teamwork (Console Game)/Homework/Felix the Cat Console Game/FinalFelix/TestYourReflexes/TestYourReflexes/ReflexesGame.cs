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
    public class ReflexesGame
    {
        //Game time
        public static System.Timers.Timer gameTime;
        public static char[] distractorSym =  {'@', '#', '$', '%', '&', '!', '?', '+', '*', '-'};

        public static bool GameOver = false;

        public static void TimeIsUp(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            SideBar();
            Console.SetCursorPosition(width - 40, height - 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Time is up!");
            Console.SetCursorPosition(width - 40, height - 12);
            Console.WriteLine("Your overall score from this game is: {0}", overallResult);
            gameTime.Stop();
            GameOver = true;
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

            if (Convert.ToInt32(highScore[1]) < overallResult)
            {
                highScore[1] = overallResult.ToString();
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
        //
        struct symbol:IEquatable<symbol>
        {
            public int x;
            public int y;
            public char c;
            public ConsoleColor color;

            public bool Equals(symbol position)
            {
                if (x == position.x && y == position.y)
                {
                    return true;
                }
                return false;
            }
        }

        
        static void PrintAnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Green)
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("█");

                int infoRow = 2;
                Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
                Console.ForegroundColor = ConsoleColor.White;
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
            }
        }
        //

        static void GameRules()
        {
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(new string('█', width));
            Console.SetCursorPosition(3, 5);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Letters will appear on random places on the game field.");
            Console.SetCursorPosition(10, 6);
            Console.Write("Type the letters as fast as you can.");
            Console.SetCursorPosition(7, 7);
            Console.Write("You get a bonus if you do it fast enough!");
            Console.SetCursorPosition(3, 8);
            Console.Write("Be careful, there are other symbols to distract you!");
            Console.SetCursorPosition(12, 10);
            Console.Write("Press any key to start playing.");
            Console.SetCursorPosition(0, 22);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(new string('█', width));
            
            SideBar();
            
            Console.ReadKey();
            return;            
        }

        static void YouAreWrong()
        {
             Console.BackgroundColor = ConsoleColor.Red;
             Console.Clear();
             Thread.Sleep(20);
             Console.BackgroundColor = ConsoleColor.Black;
             Console.Clear();
        }

        public static void Play()
        {

            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = 100;
            Console.BufferHeight = Console.WindowHeight = 25;

            //distractor
            List<symbol> distractors = new List<symbol>();
            int iteration = 0;
            int distractorsCount = 0;

            GameRules();
            Console.Clear();

            //game timer
            gameTime = new System.Timers.Timer(60000);
            gameTime.Elapsed += new ElapsedEventHandler(TimeIsUp);
            gameTime.Enabled = true;

            //reading the symbols from a file
            StreamReader reader = new StreamReader(@"../../../../../textFiles/input_symbols.txt", System.Text.Encoding.UTF8);
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
                if (GameOver == true)
                {
                    return; 
                }
                Console.BackgroundColor = ConsoleColor.Black;

                //printing distractors
                if (iteration <= 10)
                {
                    distractorsCount = iteration;
                }
                else
                {
                    distractorsCount = 10;
                }

                distractors.Clear();

                for (int i = 0; i < distractorsCount; i++)
                {
                    symbol distractor = new symbol();
                    do
                    {
                        distractor.color = ConsoleColor.Magenta;
                        distractor.x = randomNum.Next(width);
                        distractor.y = randomNum.Next(height);
                        distractor.c = distractorSym[randomNum.Next(0, distractorSym.Length)];

                    } while (distractors.Contains(distractor) == true);

                    distractors.Add(distractor);
                }

                for (int i = 0; i < distractors.Count; i++)
                {
                    PrintAnPosition(distractors[i].x, distractors[i].y, distractors[i].c, distractors[i].color);
                }
                //

                //printing letters
                symbol symbol = new symbol();
                symbol.color = ConsoleColor.Green;
                symbol.x = randomNum.Next(width);
                symbol.y = randomNum.Next(height);
                symbol.c = symbols[randomNum.Next(0, symbols.Length)];

                PrintAnPosition(symbol.x, symbol.y, symbol.c, symbol.color);
                //

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                if (symbol.c == Console.ReadKey(true).KeyChar)
                {
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    counter++;

                    if (ts.Milliseconds < 200)
                    {
                        timeBonus+=10;
                    }
                    overallResult = counter + timeBonus;
                    Console.Clear();
                    SideBar();
                }
                else
                {
                    YouAreWrong();
                    Console.Clear();
                    SideBar();
                }

                iteration++;
            }
        
        }

        static void Main()
        {
            Play();
        }
    }
}