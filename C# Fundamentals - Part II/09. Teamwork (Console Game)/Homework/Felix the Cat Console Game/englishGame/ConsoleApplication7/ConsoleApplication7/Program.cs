using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

namespace KittysGame
{
    class Program
    {
        const int width = 60;
        const int height = 23;
        public static int counter = 0;

        public static List<Tuple<string, int>> ReadQuestions()
        {
            StreamReader reader = new StreamReader("Questions.txt");

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
                TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(stopWatch.Elapsed.TotalSeconds));

                if (timeSpan.Seconds == 120)
                {
                    Console.Clear();
                    Console.WriteLine("Game over!");
                    Console.WriteLine("Your score is " + counter);
                    break;
                }

                Random randomQuestion = new Random();
                int index = randomQuestion.Next(0, questions.Count);

                bool isQuestionChoosenBefore = false;

                if (questionCount == 12)
                {
                    Console.Clear();
                    Console.WriteLine("Game over!");
                    Console.WriteLine("Your score is " + counter);
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

                if (isFirstTime)
                {
                    Console.SetCursorPosition(0, 0);

                    Console.WriteLine(timeSpan);
                }
                else
                {
                    Console.SetCursorPosition(0, 1);

                    Console.WriteLine(timeSpan);
                }
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
                Console.WriteLine(new string('-', 60));
                Console.WriteLine(@"     
                                 B@ @B          @@     
                                 @@             B@   
      B@B@B@   B@B@B@B  @B@B@@@O B@ @B :@B@B@@  @B@B@Br
     B@M  @B@  @B7  B@  B@   @B  @@ B@ @B@      B@  :@B
     @@@M@M@r  B@:  OB  PB@B@B7  B@ @B  i0@B@B  @@   @@
     U@B       @BY  B@  :@@.     @B B@     XB@  B@   @B
      L@B@B@.  M@,  UB  1B@B@B@  BZ @B 7@B@B@.  @8   B8
                       @@   0B@                       
                       2B@B@@0                        ");
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
                        counter--;
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

                // timer
            }
        }
        static void SideBar(int counter)
        {
            for (int i = 0; i <= height + 1; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.Write("|");
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
            Console.SetCursorPosition(width + 2, infoRow += 7); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Felix снимка");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(width + 2, infoRow++);
        }

        static void Main()
        {
            Console.Title = "Felix the Ninja Cat";
            Console.BufferWidth = Console.WindowWidth = 92;
            Console.BufferHeight = Console.WindowHeight = 25;

            SideBar(0);
            TrueOrFalse();
        }
    }
}