using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FelixTheCat.BlackHole;
using TestYourReflexes;
using Felix_Ivan;
using KittysGame;
using ActionGame;
using System.IO;

namespace MainMenu
{

    public class Menu
    {
        public const int windowHeight = 40;
        public const int windowWidth = 106;
        public const int width = 70;
        public const int height = windowHeight - 3;
        public static int counter = 0;
        public static string actionGameScore, blackHoleScore, mathScore, reflexesScore, kittysScore = "";
        //Side Bar
        public static void SideBar()
        {
            for (int i = 0; i < windowHeight; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("█");
            }
            ReadScoresFile();
            int infoRow = 2;
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("High Scores");
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Black Hole: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(blackHoleScore);
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Test Your Reflexes: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(reflexesScore);
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Test Your English: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(kittysScore);
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Mathematics: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(mathScore);
            Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Action Game: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(actionGameScore);
            Console.SetCursorPosition(width + 1, infoRow++); infoRow++;

            // Felix picture
            FelixPicture();
        }
        //
        public static void ReadScoresFile()
        {
            StreamReader readScores = new StreamReader("../../../../../textFiles/HighScores.txt");
            using (readScores)
            {
                blackHoleScore = readScores.ReadLine();
                reflexesScore = readScores.ReadLine();
                mathScore = readScores.ReadLine();
                kittysScore = readScores.ReadLine();
                actionGameScore = readScores.ReadLine();
            }
        }
        //Story
        public static void GameStory()
        {
            Console.SetCursorPosition(20, 1);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Welcome to Felix the Cat Game");
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(new string('█', width));
            Console.SetCursorPosition(17, 5);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Little Felix wants to become a ninja,");
            Console.SetCursorPosition(14, 6);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("but first, he has to go through some trials!");
            Console.SetCursorPosition(25, 7);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Help him make it!");
            Console.SetCursorPosition(23, 10);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Choose your destiny:");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(0, windowHeight - 4);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(new string('█', width));
        }
        //

        // Game Selection
        public static void SelectedGame()
        {
            Console.SetCursorPosition(26, 12);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("1. Black Hole");
            Console.SetCursorPosition(26, 14);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("2. Test Your Reflexes");
            Console.SetCursorPosition(26, 16);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("3. Matemathics");
            Console.SetCursorPosition(26, 18);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("4. English Test");
            Console.SetCursorPosition(26, 20);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("5. Action Game");
            Console.SetCursorPosition(33, 23);

            byte selectedGame = 0;
            byte.TryParse(Console.ReadLine(), out selectedGame);
            while (selectedGame > 5 || selectedGame <= 0)
            {
                Console.SetCursorPosition(18, 23);
                Console.WriteLine("We have only five ;)! Try again!");               
                PrintAtPosition(0, 26, new string(' ', width - 1), ConsoleColor.Magenta);
                Console.SetCursorPosition(33, 26);
                byte.TryParse(Console.ReadLine(), out selectedGame);
            }
            

            if (selectedGame == 1)
            {
                Game blackHoleGame = new Game();
                Console.Clear();
                blackHoleGame.Play();

            }
            else if (selectedGame == 2)
            {
                Console.Clear();
                ReflexesGame.Play();
            }
            else if (selectedGame == 3)
            {
                Console.Clear();
                Mathematics.Play();
            }
            else if (selectedGame == 4)
            {
                Console.Clear();
                EnglishTest.Play();
            }
            else if (selectedGame == 5)
            {
                Console.Clear();
                ActionGame.ActionGame.Play();
            }

        }
        //

        /// <summary>
        /// Prints the Felix Picture
        /// </summary>
        public static void FelixPicture()
        {
            string[,] felixPicture = 
            {
                {"███████████████████▓▓██████████████"},
                {"███████████████████  ██████████████"},
                {"███▒ ▒████████████░   ▒████████████"},
                {"███▓   ▒██████▒░░░     ░▓▒▒▒███████"},
                {"███▓     ▒▓░             ░  ▓██████"},
                {"███▓        ▒█████▓░    ████▓▒▓████"},
                {"███▓       ██████████▒  ██████▒▒███"},
                {"███▓      ████████████▓ ███████▓░▓█"},
                {"███▒     ░██████████████░████████░█"},
                {"███░     ░██████████████▓▒█  ▒███▓▒"},
                {"███░      ████░ ░████████ ▒░  ▒███▒"},
                {"███   ░   ▒███    ███████▒░▒░ ▓███▓"},
                {"██▓        ▓██░   ▒██████▒▓█▓██▒▒▓▓"},
                {"██░         ▓██░  ▓██████ ███      "},
                {"██    ░▒▒▒░   ▓█████████▒░██       "},
                {"▓   ░████████▒░░▒████▓▓▒▒████░ ░▒█▓"},
                {"▓▒   ██▓  ▓██████▓▓▓▓▓▓██████████▓█"},
                {"███▓ ░███    ▒▓███████████▓░▒███▒▒█"},
                {"████░  ██▓                  ███▒▒██"},
                {"██████▓░░██░░░░           ░██▓░▓███"},
                {"████████▓░▒▓▒▒░░░░░     ░██▓░▒█████"},
                {"███████████▓▓▓▓▓▓▒▓▒▒▓▓███▓████████"},
            };

            int currentRow = 0;
            for (int row = windowHeight - felixPicture.GetLength(0) - 1; row < windowHeight - 1; row++)
            {
                  PrintAtPosition(width + 1, row, felixPicture[currentRow, 0], ConsoleColor.White);
                  currentRow++;
            }
        }

        /// <summary>
        /// Prints a string at specific position with specific color
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void PrintAtPosition(int column, int row, string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(column, row);
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        static void PrepareConsole()
        {
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = windowWidth;
            Console.BufferHeight = Console.WindowHeight = windowHeight;
            Console.Title = "Felix the Cat Game";
            Console.Clear();
        }

        static void Main()
        {
            while (true)
            {
                PrepareConsole();
                GameStory();
                SideBar();
                SelectedGame();                
            }            
        }
    }
}