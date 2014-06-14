using System;
using System.IO;
using System.Threading;

namespace WordFinderGame
{
    /// <summary>
    /// Program class contains the main loop, ending the game,
    /// and handling it when the user presses ^C to quit.
    /// All of the gameplay and drawing is handled in the game class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Length of puzzle in letters
        /// </summary>
        const int PUZZLE_LENGTH = 49;

        /// <summary>
        /// Every nth letter must be a vowel
        /// </summary>
        const int VOWEL_EVERY = 5;

        /// <summary>
        /// Time limit for the puzzle
        /// </summary>
        const int TIME_LIMIT_SECONDS = 60;

        /// <summary>
        /// The word list. 
        /// </summary>
        static string[] words = File.ReadAllLines("words.txt");

        /// <summary>
        /// Game object to track the game.
        /// </summary>
        static Game game;

        /// <summary>
        /// set to true to quit the game
        /// </summary>
        static bool quit = false;

        /// <summary>
        /// players current input
        /// </summary>
        static string word = string.Empty;

        /// <summary>
        /// Entry point. Sets up the screen, inits the game and starts 
        /// the main loop
        /// </summary>
        static void Main(string[] args)
        {
            //Make sure the game quits if the user hits ^C
            //Set Console.TreatControlCAsInput to true if you want to
            //use ^C as valid input value
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            Console.CursorVisible = false;

            game = new Game(PUZZLE_LENGTH, VOWEL_EVERY, words);
            game.DrawInitialScreen();
            MainLoop();
        }

        /// <summary>
        /// Event handler for ^C keypress
        /// </summary>
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            // Unfortunately, due to a bug in .NET Framework v4.0.30319 you can't debug this 
            // because Visual Studio 2010 gives a "No Source Available" error. 
            // http://connect.microsoft.com/VisualStudio/feedback/details/524889/debugging-c-console-application-that-handles-console-cancelkeypress-is-broken-in-net-4-0
            Console.SetCursorPosition(0, 19);
            Console.WriteLine("{0} hit, quitting... ", e.SpecialKey);
            quit = true;
            e.Cancel = true; // Set this to true to keep the process from quitting immediately
        }

        /// <summary>
        /// Main gameloop
        /// </summary>
        static void MainLoop()
        {
            int elapsedMiliseconds = 0;
            int totalMiliseconds = TIME_LIMIT_SECONDS * 1000;
            const int INTERVAL = 100;
            bool foundWord = false;

            while (elapsedMiliseconds < totalMiliseconds && !quit)
            {
                Thread.Sleep(INTERVAL);
                elapsedMiliseconds += INTERVAL;

                HandleInput(ref elapsedMiliseconds, ref foundWord);
                PrintRemainingTime(elapsedMiliseconds, totalMiliseconds);
            }
            Console.SetCursorPosition(0, 20);
            Console.WriteLine(Environment.NewLine + Environment.NewLine
                + "Game over! You found {0} words. ", game.NumberFound);
        }

        /// <summary>
        /// Write the remaining time at the top right corner of the screen
        /// </summary>
        /// <param name="elapsedMiliseconds">Time elapsed since the start of the game</param>
        /// <param name="totalMiliseconds">Total miliseconds allowed for the game</param>
        private static void PrintRemainingTime(int elapsedMiliseconds, int totalMiliseconds)
        {
            int miliSecondsLeft = totalMiliseconds - elapsedMiliseconds;
            double secondsLeft = (double)miliSecondsLeft / 1000;
            string timeString = string.Format("{0:00.0} seconds left", secondsLeft);

            //save the current cursor position
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            //Draw the time in the upper right-hand corner
            Console.SetCursorPosition(Console.WindowWidth - timeString.Length, 0);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(timeString);

            //restore the console text color and put the cursor back where we found it
            Console.ResetColor();
            Console.SetCursorPosition(left, top);
        }

        /// <summary>
        /// Handle any waiting user keystrokes
        /// </summary>
        static void HandleInput(ref int elapsedMiliseconds, ref bool foundWord)
        {
            Thread.Sleep(50);
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (word.Length > 0)
                        word = word.Substring(0, word.Length - 1);
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    word = string.Empty;
                }
                else
                {
                    string key = keyInfo.KeyChar.ToString().ToUpper();
                    if (game.IsValidLetter(key))
                    {
                        word = word + key;
                    }
                }

                
                game.CurrentInput = word;
                game.ProcessInput(ref elapsedMiliseconds, ref foundWord );
                game.UpdateScreen();
            }
            if (foundWord == true)
            {
                Thread.Sleep(100);
                
                game.CurrentInput = string.Empty;
                word = string.Empty;
                foundWord = false;
                game.UpdateScreen();
                
                
            }

               
        }
    }
}