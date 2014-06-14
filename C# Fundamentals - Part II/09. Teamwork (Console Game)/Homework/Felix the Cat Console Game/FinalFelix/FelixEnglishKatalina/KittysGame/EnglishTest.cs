using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace KittysGame
{
    public class EnglishTest
    {
        const int width = 60;
        const int height = 23;
        public static int counter = 0;

        //Game time
        public static System.Timers.Timer gameTime;
        public static bool gameOver = false;

        public static void TimeIsUp(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            SideBar(0);
            Console.SetCursorPosition(width - 40, height - 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game over!");
            Console.SetCursorPosition(width - 40, height - 12);
            Console.WriteLine("Your score is " + counter);
            gameTime.Stop();
            gameOver = true;
            SaveHighScore(counter);           
        }

        public static List<Tuple<string, int>> ReadQuestions()
        {
            StreamReader reader = new StreamReader(@"../../../../../textFiles/Questions.txt");

            using (reader)
            {
                string row = reader.ReadLine(); // + "\n"
                List<Tuple<string, int>> questions = new List<Tuple<string, int>>(1);
                string currentRow = reader.ReadLine();
                int rightAnswer = 0;

                while (currentRow != null)
                {
                    int.TryParse(currentRow, out rightAnswer);

                    if (rightAnswer != 0)
                    {
                        questions.Add(new Tuple<string, int>(row, rightAnswer));
                        row = "";
                        rightAnswer = 0;
                    }

                    else
                    {
                        row = row + currentRow + "\n";
                    }

                    currentRow = reader.ReadLine();
                }
                return questions;
            }
        }

        public static void TrueOrFalse()
        {
            gameTime = new System.Timers.Timer(60000);
            gameTime.Elapsed += new ElapsedEventHandler(TimeIsUp);
            gameTime.Enabled = true;

            List<Tuple<string, int>> questions = ReadQuestions();

            int choosenAnswer = 0;
            bool isFirstTime = true;
            string rightOrWrong = "";
            List<int> previousQuestions = new List<int>(1);
            bool firstTime = true;
            int questionCount = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while (true)
            {
                if (gameOver == true)
                {
                    return;
                }

                //TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(stopWatch.Elapsed.TotalSeconds));
                //if (timeSpan.Seconds >= 60)
                //{
                //    Console.Clear();
                //    Console.WriteLine("Game over!");
                //    Console.WriteLine("Your score is " + counter);
                //    SaveHighScore(counter);
                //    Console.ReadLine();
                //    break;
                //}

                Random randomQuestion = new Random();
                int index = randomQuestion.Next(0, questions.Count);
                
                bool isQuestionChoosenBefore = false;

                if (questionCount == 12)
                {
                    Console.Clear();
                    SideBar(0);
                    Console.SetCursorPosition(width - 40, height - 13);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game over!");
                    Console.SetCursorPosition(width - 40, height - 12);
                    Console.WriteLine("Your score is " + counter);
                    SaveHighScore(counter);
                    Console.ReadLine();
                    break;
                }
                for (int i = 0; i < previousQuestions.Count; i++)
                {
                    if (index == previousQuestions[i])
                    {
                        isQuestionChoosenBefore = true;
                        break;
                    }
                }


                if (isQuestionChoosenBefore)
                {
                    continue;
                }
                else
                {
                    previousQuestions.Add(index);
                    questionCount++;
                }

                SideBar(counter);

                //if (isFirstTime)
                //{
                //    Console.SetCursorPosition(0, 0);
                   
                //    Console.WriteLine(timeSpan);
                //}
                //else
                //{
                //    Console.SetCursorPosition(0, 1);
                   
                //    Console.WriteLine(timeSpan);
                //}
                Console.SetCursorPosition(0, 0);
                if (rightOrWrong == "Wrong...")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(rightOrWrong);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (rightOrWrong == "Correct!!!")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(rightOrWrong);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                #region english
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string('-', 60));
                Console.WriteLine("");
                Console.WriteLine(new string('-', 60));
                // TODO: clear question and answer with regex
                #endregion

                int questionIndex = questions[index].Item1.IndexOf("question:");
                int answerIndex = questions[index].Item1.IndexOf("1)");

                if (questionIndex == -1)
                {
                    int j = 0;
                    for (int i = 0; i < questions[index].Item1.Length; i++)
                    {
                        Console.Write(questions[index].Item1[i]);
                    }
                }
                else
                {
                    int j = 0;
                    for (int i = 9; i < questions[index].Item1.Length; i++)
                    {
                        j++;
                        if (i >= answerIndex)
                        {
                            j = 0;
                           // Console.Write(questions[index].Item1[i]);
                        }
                        else if (j == 55)
                        {

                            Console.WriteLine();
                            j = 0;
                        }
                        Console.Write(questions[index].Item1[i]);
                    }
                }
                try
                {
                    choosenAnswer = int.Parse(Console.ReadLine());

                    // TODO: exception handler
                    if (choosenAnswer == questions[index].Item2)
                    {
                        rightOrWrong = "Correct!!!";
                        counter++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(rightOrWrong);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        rightOrWrong = "Wrong...";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(rightOrWrong);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                
                Console.Clear();
            }
        }
        static void SideBar(int counter)
        {
            for (int i = 0; i <= height + 1; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("█");
            }
            int infoRow = 2;

            Console.SetCursorPosition(width + 7, infoRow++); infoRow++;
            Console.Write("Master English Test");
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(width + 2, infoRow++);
            Console.Write(counter);        
        }
        public static void Play()
        {
            Console.Title = "Felix the Ninja Cat";
            Console.BufferWidth = Console.WindowWidth = 92;
            Console.BufferHeight = Console.WindowHeight = 25;

            GameRules();
            Console.Clear();

            SideBar(0);
            TrueOrFalse();
        }

        static void GameRules()
        {
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(new string('█', width));
            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("This game tests Felix's english skills.");
            Console.SetCursorPosition(16, 6);
            Console.Write("Help him get more points.");
            Console.SetCursorPosition(10, 7);
            Console.Write("Answer the questions with 1, 2, 3 or 4.");
            Console.SetCursorPosition(22, 8);
            Console.Write("Good luck!");
            Console.SetCursorPosition(12, 10);
            Console.Write("Press any key to start playing.");
            Console.SetCursorPosition(0, 22);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(new string('█', width));

            SideBar(0);

            Console.ReadKey();
            return;
        }

        static void SaveHighScore(int totalScore)
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

            if (Convert.ToInt32(highScore[3]) < totalScore)
            {
                highScore[3] = totalScore.ToString();
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

        static void Main()
        {
            Play();
        }
    }
}