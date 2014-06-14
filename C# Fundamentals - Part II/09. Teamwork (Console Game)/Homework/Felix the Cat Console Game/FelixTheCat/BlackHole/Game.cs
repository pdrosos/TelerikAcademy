using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace FelixTheCat.BlackHole
{
    public class Game
    {
        private static int score = 0;

        public void Play()
        {
            bool moveToHole = true;
            bool moveToBottom = false;
            bool timeToPlay = false;
            bool isResultPrinted = false;

            int minFiguresCount = 3;
            int maxFiguresCount = 5;

            BlackHole blackHole = BlackHoleGenerator.GenerateBlackHole(Window.PlayfieldHeight, Window.PlayfieldWidth);

            PrepareGame(blackHole);

            Stopwatch moveFiguresStopwatch = new Stopwatch();
            Timer gameTimer = new Timer(60000);
            
            List<Figure> figures = FiguresGenerator.GetRandomList(minFiguresCount, Window.PlayfieldWidth);
            Figure missingFigure = new Figure(new string[0,0], ConsoleColor.White, 0, 0);
            List<Figure> resultFigures = new List<Figure>();
            
            moveFiguresStopwatch.Start();
            gameTimer.Elapsed += new ElapsedEventHandler(TimeIsUp);
            gameTimer.Enabled = true;

            while (true)
            {
                // print timer
                Window.PrintTimer(gameTimer);

                // move figures
                if (moveFiguresStopwatch.ElapsedMilliseconds >= 120)
                {
                    // determine states of game
                    if (figures[0].StartY <= blackHole.StartY)
                    {
                        moveToHole = true;
                        moveToBottom = false;
                        timeToPlay = false;
                    }
                    else if (figures[0].StartY > blackHole.StartY && figures[0].EndY < Window.PlayfieldHeight - 1)
                    {
                        moveToHole = false;
                        moveToBottom = true;
                        timeToPlay = false;
                    }
                    else
                    {
                        moveToHole = false;
                        moveToBottom = false;
                        timeToPlay = true;
                    }

                    // if in the hole - remove one figure
                    if (figures[0].StartY - 1 == blackHole.StartY)
                    {
                        missingFigure = FiguresGenerator.RemoveRandomFigureFromList(ref figures, Window.PlayfieldWidth);
                    }
                    
                    // move to hole
                    if (moveToHole == true)
                    {
                        for (int i = 0; i < figures.Count; i++)
                        {
                            Window.PrintFigure(figures[i], 0, blackHole.StartY - 1);
                            figures[i].MoveDown();
                        }
                    }
                    else if (moveToBottom == true)
                    {
                        // move to bottom
                        for (int i = 0; i < figures.Count; i++)
                        {
                            Window.PrintFigure(figures[i], blackHole.EndY + 1, Window.PlayfieldHeight - 1);
                            figures[i].MoveDown();
                        }
                    }

                    moveFiguresStopwatch.Restart();
                }

                if (timeToPlay == true && isResultPrinted == false)
                {
                    // print result figures
                    resultFigures = FiguresGenerator.GetResultList(figures, missingFigure, Window.PlayfieldWidth);
                    Window.PrintResultFigures(resultFigures);

                    isResultPrinted = true;
                }

                // user input
                if (timeToPlay == true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        int userInput = 0;
                        int.TryParse(pressedKey.KeyChar.ToString(), out userInput);

                        if (userInput >= 1 && userInput <= resultFigures.Count)
                        {
                            Figure userChoice = resultFigures[userInput - 1];
                            // update score
                            if (userChoice == missingFigure)
                            {
                                score += 10;
                                Window.PrintScore(score);
                            }

                            moveToHole = true;
                            moveToBottom = false;
                            timeToPlay = false;
                            isResultPrinted = false;

                            // generate new figures, update score
                            figures = FiguresGenerator.GetRandomList(minFiguresCount, Window.PlayfieldWidth);

                            // clear bottom bar
                            Window.ClearBottomBar();
                            Window.ClearBottomPlayfield(blackHole.EndY);
                        }
                    }
                }
            }
        }

        private static void TimeIsUp(Object source, ElapsedEventArgs e)
        {
            Environment.Exit(7);
        }

        private static void PrepareGame(BlackHole blackHole)
        {
            Window.PrepareWindow();
            Window.PrintBlackHole(blackHole);
            Window.PrintBottomBar();
            Window.PrintSidebar();
            Window.PrintScore(score);
        }
    }
}