using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace FelixTheCat.BlackHole
{
    /// <summary>
    /// Game controller
    /// </summary>
    public class Game
    {
        private static int score = 0;
        private static int bonus = 0;
        private const int scorePoints = 10;        
        private const int bonusPoints = 30;
        private const int consequtiveCorrectAnswersBonus = 3;
        private const int consequtiveWrongAnswersDecreaseFigures = 3;
        private static int consequtiveCorrectAnswers = 0;
        private static int consequtiveWrongAnswers = 0;

        private const int minFiguresCount = 2;
        private const int maxFiguresCount = 5;
        private static int figuresCount = minFiguresCount;

        private const int gameOverMilliseconds = 60000;
        private static long previousRemainingSeconds = gameOverMilliseconds / 1000;

        private const int moveFiguresMilliseconds = 110;

        private static Stopwatch moveFiguresStopwatch = new Stopwatch();
        private static Stopwatch gameOverStopwatch = new Stopwatch();

        private static List<Figure> figures;
        private static Figure missingFigure;
        private static List<Figure> resultFigures;

        // game states
        private static bool moveToHole = true;
        private static bool moveToBottom = false;
        private static bool timeToPlay = false;
        private static bool areResultFiguresPrinted = false;

        /// <summary>
        /// Game main logic
        /// </summary>
        /// <returns></returns>
        public int Play()
        {
            // welcome screen
            Window.WelcomeScreen();
            
            // initialize all game variables
            InitializeGame();

            // start game
            BlackHole blackHole = BlackHoleGenerator.GenerateBlackHole(Window.PlayfieldHeight, Window.PlayfieldWidth);
            PrepareWindow(blackHole);
            
            moveFiguresStopwatch.Restart();
            gameOverStopwatch.Restart();

            while (true)
            {
                if (IsGameOver(gameOverStopwatch))
                {
                    int totalScore = score + bonus;

                    // save high scorer
                    SaveHighScore(totalScore);
 
                    Window.PrintGameOverScreen(totalScore);

                    return totalScore;
                }

                // print remaining time
                PrintRemainingTime(gameOverStopwatch);

                if (moveFiguresStopwatch.ElapsedMilliseconds >= moveFiguresMilliseconds)
                {
                    // determine game state
                    DetermineGameState(figures, blackHole);

                    // if in the hole - remove one figure
                    if (figures[0].StartY - 1 == blackHole.StartY)
                    {
                        missingFigure = FiguresGenerator.RemoveRandomFigureFromList(ref figures, Window.PlayfieldWidth);
                    }

                    // move figures
                    MoveFigures(figures, blackHole);

                    moveFiguresStopwatch.Restart();
                }

                if (timeToPlay == true && areResultFiguresPrinted == false)
                {
                    // print result figures
                    resultFigures = FiguresGenerator.GetResultList(figures, missingFigure, Window.PlayfieldWidth);
                    Window.PrintResultFigures(resultFigures);

                    areResultFiguresPrinted = true;
                }

                // user input
                if (timeToPlay == true)
                {
                    int userInput = GetUserInput(resultFigures);
                    if (userInput > 0)
                    {
                        UpdateScore(userInput, resultFigures, missingFigure);

                        figures = FiguresGenerator.GetRandomList(figuresCount, Window.PlayfieldWidth);

                        // clear bottom bar
                        Window.ClearBottomBar();
                        Window.ClearBottomPlayfield(blackHole.EndY);
                    }
                }
            }
        }

        /// <summary>
        /// Initialize all game variables
        /// </summary>
        private static void InitializeGame()
        {
            score = 0;
            bonus = 0;
            consequtiveCorrectAnswers = 0;
            consequtiveWrongAnswers = 0;
            figuresCount = minFiguresCount;
            previousRemainingSeconds = gameOverMilliseconds / 60;

            figures = FiguresGenerator.GetRandomList(figuresCount, Window.PlayfieldWidth);
            missingFigure = new Figure(new string[0, 0], ConsoleColor.White, 0, 0);
            resultFigures = new List<Figure>();

            moveToHole = true;
            moveToBottom = false;
            timeToPlay = false;
            areResultFiguresPrinted = false;
        }

        /// <summary>
        /// Prepare game window
        /// </summary>
        /// <param name="blackHole"></param>
        private static void PrepareWindow(BlackHole blackHole)
        {
            Window.PrepareWindow();
            Window.PrintBlackHole(blackHole);
            Window.PrintBottomBar();
            Window.SideBar();
            Window.PrintScore(score);
        }

        /// <summary>
        /// Print remaining time
        /// </summary>
        /// <param name="gameOverStopwatch"></param>
        private static void PrintRemainingTime(Stopwatch stopwatch)
        {
            long remainingSeconds = (Game.gameOverMilliseconds - stopwatch.ElapsedMilliseconds) / 1000;

            if (remainingSeconds < previousRemainingSeconds)
            {
                Window.PrintRemainingTime(remainingSeconds);
                previousRemainingSeconds = remainingSeconds;
            }
        }

        /// <summary>
        /// Determine the current state of the game
        /// moveToHole: when the figures appear and start moving to the black hole
        /// moveToBottom: result figures are out of the black hole and start moving to the bottom
        /// timeToPlay: result figures are already at the bottom of the screen and it's time for user to choose the missing one
        /// </summary>
        /// <param name="figures"></param>
        /// <param name="blackHole"></param>
        private static void DetermineGameState(List<Figure> figures, BlackHole blackHole)
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
        }

        /// <summary>
        /// Move figures down
        /// </summary>
        /// <param name="figures"></param>
        /// <param name="blackHole"></param>
        private static void MoveFigures(List<Figure> figures, BlackHole blackHole)
        {
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
        }

        /// <summary>
        /// Get user input
        /// </summary>
        /// <param name="resultFigures"></param>
        /// <returns></returns>
        private static int GetUserInput(List<Figure> resultFigures)
        {
            int userInput = 0;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                int.TryParse(pressedKey.KeyChar.ToString(), out userInput);

                if (userInput >= 1 && userInput <= resultFigures.Count)
                {
                    moveToHole = true;
                    moveToBottom = false;
                    timeToPlay = false;
                    areResultFiguresPrinted = false;

                    return userInput;
                }
            }

            return userInput;
        }

        /// <summary>
        /// Update score
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="resultFigures"></param>
        /// <param name="missingFigure"></param>
        private static void UpdateScore(int userInput, List<Figure> resultFigures, Figure missingFigure)
        {
            Figure userChoice = resultFigures[userInput - 1];
            // correct answer
            if (userChoice == missingFigure)
            {
                // update score
                score += scorePoints;
                Window.PrintScore(score);

                consequtiveWrongAnswers = 0;
                consequtiveCorrectAnswers++;

                if (consequtiveCorrectAnswers % consequtiveCorrectAnswersBonus == 0)
                {
                    bonus += bonusPoints;
                    Window.PrintBonus(bonus);

                    figuresCount++;
                    if (figuresCount > maxFiguresCount)
                    {
                        figuresCount = maxFiguresCount;
                    }
                }

                Window.PrintTotal(score + bonus);
            }
            else
            {
                consequtiveCorrectAnswers = 0;
                consequtiveWrongAnswers++;

                if (consequtiveWrongAnswers % consequtiveWrongAnswersDecreaseFigures == 0)
                {
                    figuresCount--;
                    if (figuresCount < minFiguresCount)
                    {
                        figuresCount = minFiguresCount;
                    }
                }
            }
        }

        /// <summary>
        /// Check if time is up and game is over
        /// </summary>
        /// <param name="gameOverStopwatch"></param>
        /// <returns></returns>
        private static bool IsGameOver(Stopwatch gameOverStopwatch)
        {
            if (gameOverStopwatch.ElapsedMilliseconds >= gameOverMilliseconds)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Save high score in file
        /// </summary>
        /// <param name="totalScore"></param>
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

            if (Convert.ToInt32(highScore[0]) < totalScore)
            {
                highScore[0] = totalScore.ToString();
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
    }
}