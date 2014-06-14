using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FelixTheCat.BlackHole
{
    /// <summary>
    /// The game window. Prints all game objects.
    /// </summary>
    public static class Window
    {
        // window properties
        public const int FieldHeight = 46;
        public const int FieldWidth = 130;
        public const int SidebarWidth = 36;
        public const int BottomBarHeight = 12;
        public const int PlayfieldWidth = FieldWidth - SidebarWidth;
        public const int PlayfieldHeight = FieldHeight - BottomBarHeight;

        /// <summary>
        /// Welcome screen
        /// </summary>
        public static void WelcomeScreen()
        {
            PrepareWindow();
            SideBar();
            
            string gameTitle = "Black Hole";
            PrintAtPosition((PlayfieldWidth - gameTitle.Length) / 2, 1, gameTitle, ConsoleColor.Magenta);

            string borders = new string('█', PlayfieldWidth);
            PrintAtPosition(0, 3, borders, ConsoleColor.DarkRed);
            PrintAtPosition(0, FieldHeight - 4, borders, ConsoleColor.DarkRed);

            string gameRules = "One of the falling objects is removed. Select the missing object.";
            PrintAtPosition((PlayfieldWidth - gameRules.Length) / 2, 6, gameRules, ConsoleColor.Magenta);

            string gameTime = "You have 60 seconds.";
            PrintAtPosition((PlayfieldWidth - gameTime.Length) / 2, 8, gameTime, ConsoleColor.Magenta);
            
            string startGame = "Press any key to start playing.";
            PrintAtPosition((PlayfieldWidth - startGame.Length) / 2, 11, startGame, ConsoleColor.Magenta);

            Console.ReadKey();
        }

        /// <summary>
        /// Print falling figure
        /// </summary>
        /// <param name="item"></param>
        /// <param name="windowStartY"></param>
        /// <param name="windowEndY"></param>
        public static void PrintFigure(Figure item, int windowStartY, int windowEndY)
        {
            if (item.StartY <= windowStartY)
            {
                PrintFigureOnEntrance(item, windowStartY);
            }
            else if (item.EndY > windowEndY)
            {
                PrintFigureOnExit(item, windowEndY);
            }
            else
            {
                PrintFigureInConsoleInnerPart(item);
            }
        }

        /// <summary>
        /// Print falling figure on entering the window area
        /// </summary>
        /// <param name="item"></param>
        /// <param name="windowStartY"></param>
        private static void PrintFigureOnEntrance(Figure item, int windowStartY)
        {
            int currentRow = windowStartY;
            int firstRow = item.Height - (item.EndY - windowStartY + 1);    
            int lastRow = item.Height - 1;

            for (int row = firstRow; row <= lastRow; row++)
            {
                PrintAtPosition(item.StartX, currentRow, item.Symbols[row, 0], item.Color);
                currentRow++;
            }
        }

        /// <summary>
        /// Print falling figure on exiting the window area
        /// </summary>
        /// <param name="item"></param>
        /// <param name="windowEndY"></param>
        private static void PrintFigureOnExit(Figure item, int windowEndY)
        {
            PrintAtPosition(item.StartX, item.StartY - 1, new string(' ', item.Width));

            int currentRow = item.StartY;
            int lastRow = item.Height - (item.EndY - windowEndY);
            for (int row = 0; row < lastRow; row++)
            {
                PrintAtPosition(item.StartX, currentRow, item.Symbols[row, 0], item.Color);
                currentRow++;
            }

        }

        /// <summary>
        /// Print falling figure in the middle of the window area
        /// </summary>
        /// <param name="item"></param>
        private static void PrintFigureInConsoleInnerPart(Figure item)
        {
            PrintAtPosition(item.StartX, item.StartY - 1, new string(' ', item.Width));

            int currentRow = item.StartY;
            for (int row = 0; row < item.Height; row++)
            {
                PrintAtPosition(item.StartX, currentRow, item.Symbols[row, 0], item.Color);
                currentRow++;
            }
        }

        /// <summary>
        /// Print black hole
        /// </summary>
        /// <param name="item"></param>
        public static void PrintBlackHole(BlackHole item)
        {
            int currentRow = item.StartY;
            for (int row = 0; row < item.Height; row++)
            {
                PrintAtPosition(item.StartX, currentRow, item.Symbols[row, 0], item.Color);
                currentRow++;
            }
        }

        /// <summary>
        /// Initialize game window
        /// </summary>
        public static void PrepareWindow()
        {
            Console.Title = "Black Hole";
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            // Console.TreatControlCAsInput = true;

            Console.BufferHeight = Console.WindowHeight = FieldHeight;
            Console.BufferWidth = Console.WindowWidth = FieldWidth;
            Console.Clear();
        }

        /// <summary>
        /// Print sidebar
        /// </summary>
        public static void SideBar()
        {
            // wall
            for (int row = 0; row < FieldHeight; row++)
            {
                PrintAtPosition(PlayfieldWidth, row, "█", ConsoleColor.DarkRed);
            }

            // timer
            PrintAtPosition(PlayfieldWidth + 3, 3, "Time: ", ConsoleColor.Cyan);
            PrintAtPosition(PlayfieldWidth + 9, 3, "60", ConsoleColor.Cyan);

            // score
            PrintAtPosition(PlayfieldWidth + 3, 6, "Score: ", ConsoleColor.Green);
            PrintAtPosition(PlayfieldWidth + 10, 6, "0", ConsoleColor.Green);

            // bonus
            PrintAtPosition(PlayfieldWidth + 3, 9, "Bonus: ", ConsoleColor.Magenta);
            PrintAtPosition(PlayfieldWidth + 10, 9, "0", ConsoleColor.Magenta);

            // total
            PrintAtPosition(PlayfieldWidth + 3, 12, "Total: ", ConsoleColor.Red);
            PrintAtPosition(PlayfieldWidth + 10, 12, "0", ConsoleColor.Red);

            // Felix picture
            //string[,] felixPicture = GameElements.GetFelixPicture();            
            //int currentRow = 0;
            //for (int row = FieldHeight - felixPicture.GetLength(0) - 1; row < FieldHeight - 1; row++)
            //{
                  //PrintAtPosition(PlayfieldWidth + 1, row, felixPicture[currentRow, 0], ConsoleColor.White);
                  //currentRow++;
            //}
        }

        /// <summary>
        /// Print timer
        /// </summary>
        /// <param name="stopwatch"></param>
        public static void PrintRemainingTime(long remainingTime)
        {
            PrintAtPosition(PlayfieldWidth + 9, 3, remainingTime.ToString().PadRight(6, ' '), ConsoleColor.Cyan);
        }

        /// <summary>
        /// Print score
        /// </summary>
        /// <param name="score"></param>
        public static void PrintScore(int score)
        {
            PrintAtPosition(PlayfieldWidth + 10, 6, score.ToString().PadRight(6, ' '), ConsoleColor.Green);
        }

        /// <summary>
        /// Print bonus points
        /// </summary>
        /// <param name="bonus"></param>
        public static void PrintBonus(int bonus)
        {
            PrintAtPosition(PlayfieldWidth + 10, 9, bonus.ToString().PadRight(6, ' '), ConsoleColor.Magenta);
        }

        /// <summary>
        /// Print total points
        /// </summary>
        /// <param name="bonus"></param>
        public static void PrintTotal(int total)
        {
            PrintAtPosition(PlayfieldWidth + 10, 12, total.ToString().PadRight(6, ' '), ConsoleColor.Red);
        }

        /// <summary>
        /// Print bottom bar
        /// </summary>
        public static void PrintBottomBar()
        {
            PrintAtPosition(0, PlayfieldHeight, new string('█', PlayfieldWidth + 1), ConsoleColor.DarkRed);
        }

        /// <summary>
        /// Print the figures, containing the missing one
        /// </summary>
        /// <param name="items"></param>
        public static void PrintResultFigures(List<Figure> items)
        {
            int currentRow = 0;

            for (int i = 0; i < items.Count; i++)
            {
                currentRow = FieldHeight - BottomBarHeight + 2;
                for (int row = 0; row < items[i].Height; row++)
                {
                    PrintAtPosition(items[i].StartX, currentRow, items[i].Symbols[row, 0], items[i].Color);
                    currentRow++;
                }

                // print number
                PrintAtPosition(items[i].StartX + (items[i].Width / 2), currentRow + 1, Convert.ToString(i + 1), ConsoleColor.White);
            }

            string text = "Please enter the missing object's number"; 
            PrintAtPosition((PlayfieldWidth - text.Length) / 2, currentRow + 3, text, ConsoleColor.DarkCyan);
        }

        /// <summary>
        /// Clear the playfield
        /// </summary>
        /// <param name="blackHoleEndY"></param>
        public static void ClearPlayfield()
        {
            string clearString = new string(' ', PlayfieldWidth);
            for (int row = 0; row < PlayfieldHeight + BottomBarHeight; row++)
            {
                PrintAtPosition(0, row, clearString);
            }
        }

        /// <summary>
        /// Clear the space between the black hole and the bottom bar
        /// </summary>
        /// <param name="blackHoleEndY"></param>
        public static void ClearBottomPlayfield(int blackHoleEndY)
        {
            string clearString = new string(' ', PlayfieldWidth - 1);
            for (int row = blackHoleEndY + 1; row < PlayfieldHeight; row++)
            {
                PrintAtPosition(0, row, clearString);
            }
        }

        /// <summary>
        /// Clear bottom bar
        /// </summary>
        public static void ClearBottomBar()
        {
            string clearString = new string(' ', PlayfieldWidth - 1);
            for (int row = FieldHeight - BottomBarHeight + 1; row < FieldHeight; row++)
            {
                PrintAtPosition(0, row, clearString);
            }
        }

        /// <summary>
        /// Print text at specific position
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void PrintAtPosition(int column, int row, string text, ConsoleColor color = ConsoleColor.White, ConsoleColor bgColor = ConsoleColor.Black)
        {
            Console.SetCursorPosition(column, row);
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgColor;
            Console.Write(text);
        }

        /// <summary>
        /// Game over screen
        /// </summary>
        public static void PrintGameOverScreen(int totalScore)
        {
            ClearPlayfield();

            string gameTitle = "Black Hole";
            PrintAtPosition((PlayfieldWidth - gameTitle.Length) / 2, 1, gameTitle, ConsoleColor.Magenta);

            string borders = new string('█', PlayfieldWidth);
            PrintAtPosition(0, 3, borders, ConsoleColor.DarkRed);
            PrintAtPosition(0, FieldHeight - 4, borders, ConsoleColor.DarkRed);

            string timeUp = "Time is up!";
            PrintAtPosition((PlayfieldWidth - timeUp.Length) / 2, 6, timeUp, ConsoleColor.Red);

            string score = "Your overall score from this game is: " + totalScore;
            PrintAtPosition((PlayfieldWidth - score.Length) / 2, 8, score, ConsoleColor.Red);

            string returnToMenu = "Press any key to return to menu.";
            PrintAtPosition((PlayfieldWidth - returnToMenu.Length) / 2, 11, returnToMenu, ConsoleColor.Red);

            Console.ReadKey();
        }
    }
}
