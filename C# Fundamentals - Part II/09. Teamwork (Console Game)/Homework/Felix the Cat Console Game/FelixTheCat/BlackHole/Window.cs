using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace FelixTheCat.BlackHole
{
    public static class Window
    {
        // window properties
        public const int FieldHeight = 46;
        public const int FieldWidth = 130;
        public const int SidebarWidth = 36;
        public const int BottomBarHeight = 12;
        public const int PlayfieldWidth = FieldWidth - SidebarWidth;
        public const int PlayfieldHeight = FieldHeight - BottomBarHeight;

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

        public static void PrintBlackHole(BlackHole item)
        {
            int currentRow = item.StartY;
            for (int row = 0; row < item.Height; row++)
            {
                PrintAtPosition(item.StartX, currentRow, item.Symbols[row, 0], item.Color);
                currentRow++;
            }
        }

        public static void PrepareWindow()
        {
            Console.Title = "Black Hole";
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            Console.BufferHeight = Console.WindowHeight = FieldHeight;
            Console.BufferWidth = Console.WindowWidth = FieldWidth;
        }

        public static void PrintSidebar()
        {
            // wall
            for (int row = 0; row < FieldHeight; row++)
            {
                PrintAtPosition(PlayfieldWidth, row, "█", ConsoleColor.DarkGray);
            }

            // timer
            PrintAtPosition(PlayfieldWidth + 3, 3, "Time: ", ConsoleColor.DarkCyan);

            // score
            PrintAtPosition(PlayfieldWidth + 3, 7, "Score: ", ConsoleColor.DarkCyan);

            // Felix picture
            string[,] felixPicture = GameElements.GetFelixPicture();            
            int currentRow = 0;
            for (int row = FieldHeight - felixPicture.GetLength(0) - 1; row < FieldHeight - 1; row++)
            {
                PrintAtPosition(PlayfieldWidth + 1, row, felixPicture[currentRow, 0], ConsoleColor.White);
                currentRow++;
            }
        }

        public static void PrintTimer(Timer timer)
        {
            //PrintAtPosition(PlayfieldWidth + 9, 3, timer.ToString().PadRight(4, ' '), ConsoleColor.Yellow);
        }

        public static void PrintScore(int score)
        {
            PrintAtPosition(PlayfieldWidth + 10, 7, score.ToString().PadRight(4, ' '), ConsoleColor.Yellow);
        }

        public static void PrintBottomBar()
        {
            PrintAtPosition(0, PlayfieldHeight, new string('█', PlayfieldWidth + 1), ConsoleColor.DarkGray);
        }

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

            string text = "Please enter the missing shape's number"; 
            PrintAtPosition((PlayfieldWidth - text.Length) / 2, currentRow + 3, text, ConsoleColor.DarkCyan);
        }

        public static void ClearBottomPlayfield(int blackHoleEndY)
        {
            string clearString = new string(' ', PlayfieldWidth - 1);
            for (int row = blackHoleEndY + 1; row < PlayfieldHeight; row++)
            {
                PrintAtPosition(0, row, clearString);
            }
        }

        public static void ClearBottomBar()
        {
            string clearString = new string(' ', PlayfieldWidth - 1);
            for (int row = FieldHeight - BottomBarHeight + 1; row < FieldHeight; row++)
            {
                PrintAtPosition(0, row, clearString);
            }
        }

        public static void PrintAtPosition(int column, int row, string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(column, row);
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}
