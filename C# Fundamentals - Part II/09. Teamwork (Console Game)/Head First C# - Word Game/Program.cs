using System;
using System.IO;
using System.Threading;

namespace WordFinder
{
     /// <summary>
     /// The Program class contains the main loop, ending the game, running the timer,
     /// and handling it when the user presses ^C to quit. All of the gameplay and drawing
     /// is handled in the Game class.
     /// </summary>
     class Program
     {
          /// <summary>
          /// Length of the puzzle in letters
          /// </summary>
          const int PUZZLE_LENGTH = 49;
  
          /// <summary>
          /// Every nth letter must be a vowel
          /// </summary>
          const int VOWEL_EVERY = 5;
  
          /// <summary>
          /// The time limit for the puzzle
          /// </summary>
          const int TIME_LIMIT_SECONDS = 60;
  
          /// <summary>
          /// The word list -- I downloaded it from http://unix-tree.huihoo.org/V7/usr/dict/words.html 
          /// and pasted it into words.txt, making sure to set the Copy to Output Directory property
          /// to "Copy Always" (so it ends up in the same foler as the executable). We could also use
          /// a resource, but this makes it easy to expand the game to use any word list.
          /// </summary>
          static string[] words = File.ReadAllLines("words.txt");
  
          /// <summary>
          /// Game object to track the gameplay
          /// </summary>
          static Game game;
  
          /// <summary>
          /// Set this static field to true to quit the game
          /// </summary>
          static bool quit = false;
  
          /// <summary>
          /// The player's current input
          /// </summary>
          static string word = String.Empty;
  
          /// <summary>
          /// The entry point sets up the screen, initializes the game, and kicks off the main loop
          /// </summary>
          static void Main(string[] args)
          {
               // Make sure the game quits if the user hits ^C
               // Set Console.TreatControlCAsInput to true if you want to use ^C as a valid input value
               Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
   
               Console.CursorVisible = false;
               
               game = new Game(PUZZLE_LENGTH, VOWEL_EVERY, words);
               game.DrawInititalScreen();
               MainLoop();
           }
  
          /// <summary>
          /// Event handler for ^C key press
          /// </summary>
          static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
          {
               // Unfortunately, due to a bug in .NET Framework v4.0.30319 you can't debug this 
               // because Visual Studio 2010 gives a "No Source Available" error. 
               // http://connect.microsoft.com/VisualStudio/feedback/details/524889/debugging-c-console-application-that-handles-console-cancelkeypress-is-broken-in-net-4-0
               Console.SetCursorPosition(0, 19);
               Console.WriteLine("{0} hit, quitting...", e.SpecialKey);
               quit = true;
               e.Cancel = true; // Set this to true to keep the process from quitting immediately
           }
  
          /// <summary>
          /// The main gameloop
          /// </summary>
          static void MainLoop()
          {
               int elapsedMilliseconds = 0;
               int totalMilliseconds = TIME_LIMIT_SECONDS * 1000;
               const int INTERVAL = 100;
   
               while (elapsedMilliseconds < totalMilliseconds && !quit)
               {
                    // Sleep for a short period
                    Thread.Sleep(INTERVAL);
                    elapsedMilliseconds += INTERVAL;
    
                    HandleInput();
    
                    PrintRemainingTime(elapsedMilliseconds, totalMilliseconds);
                }
   
               Console.SetCursorPosition(0, 20);
               Console.WriteLine(Environment.NewLine + Environment.NewLine
                   + "Game over! You found {0} words.", game.NumberFound);
           }
  
          /// <summary>
          /// Write the remaining time at the top right corner of the screen
          /// </summary>
          /// <param name="elapsedMilliseconds">Time elapsed since the start of the game</param>
          /// <param name="totalMilliseconds">Total milliseconds allowed for the game</param>
          private static void PrintRemainingTime(int elapsedMilliseconds, int totalMilliseconds)
          {
               int milliSecondsLeft = totalMilliseconds - elapsedMilliseconds;
               double secondsLeft = (double)milliSecondsLeft / 1000;
               string timeString = String.Format("{0:00.0} seconds left", secondsLeft);
   
               // Save the current cursor position
               int left = Console.CursorLeft;
               int top = Console.CursorTop;
   
               // Draw the time in the upper right-hand corner
               Console.SetCursorPosition(Console.WindowWidth - timeString.Length, 0);
               Console.ForegroundColor = ConsoleColor.Magenta;
               Console.Write(timeString);
   
               // Restore the console text color and put the cursor back where we found it
               Console.ResetColor();
               Console.SetCursorPosition(left, top);
           }
  
          /// <summary>
          /// Handle any waiting user keystrokes 
          /// </summary>
          static void HandleInput()
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
                         word = String.Empty;
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
                    game.ProcessInput();
                    game.UpdateScreen();
                }
           }
      }
}