using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder
{
     /// <summary>
     /// The Game class keeps track of the state of the game and draws the screen
     /// updates. It uses an instance of the Puzzle class to keep track of the letters on
     /// the puzzle grid, and an instance of WordChecker to keep track of the valid
     /// words and check the player's answers.
     /// </summary>
     class Game
     {
          /// <summary>
          /// The WordChecker object to check the words that were found
          /// </summary>
          private WordChecker wordChecker;
  
          /// <summary>
          /// Get the number of words that were found
          /// </summary>
          public int NumberFound
          {
               // The WordChecker object keeps track of this
               get { return wordChecker.NumberFound; }
           }
  
          /// <summary>
          /// The Puzzle object keeps track of the random letters and checks words
          /// </summary>
          private Puzzle puzzle;
  
          /// <summary>
          /// The player's current input
          /// </summary>
          public string CurrentInput { private get; set; }
  
          /// <summary>
          /// Game constructor
          /// </summary>
          /// <param name="puzzleLength">The number of letters in the puzzle</param>
          /// <param name="vowelEvery">Add a vowel every Nth letter</param>
          /// <param name="validWords">The sequence of valid words</param>
          public Game(int puzzleLength, int vowelEvery, IEnumerable<string> validWords)
          {
               this.wordChecker = new WordChecker(validWords);
               this.puzzle = new Puzzle(puzzleLength, vowelEvery);
               CurrentInput = String.Empty;
           }
  
          /// <summary>
          /// Draw the screen to the console when the program starts
          /// </summary>
          public void DrawInititalScreen()
          {
               Console.Clear();
               Console.Title = "Word finder";
               puzzle.Draw(25, 3);
               Console.SetCursorPosition(7, 11);
               Console.Write("┌───────────────────────────────────────────────────────╖");
               Console.SetCursorPosition(7, 12);
               Console.Write("│");
               Console.SetCursorPosition(63, 12);
               Console.Write("║");
               Console.SetCursorPosition(7, 13);
               Console.Write("╘═══════════════════════════════════════════════════════╝");
               UpdateScreen();
           }
  
          /// <summary>
          /// Update the screen when it's refreshed
          /// </summary>
          public void UpdateScreen()
          {
               // Use String.PadRight() to make sure the yellow entry box remains a constant
               // size, no matter how long the word is or the word number
               Console.SetCursorPosition(8, 12);
               Console.ForegroundColor = ConsoleColor.DarkGray;
               Console.BackgroundColor = ConsoleColor.Yellow;
               string message = String.Format("Enter word #{0}: {1}", 
                       wordChecker.NumberFound, CurrentInput);
               Console.Write(message.PadRight(54));
               Console.ResetColor();
   
               Console.SetCursorPosition(0, 17);
               Console.Write("Found words: ");
               foreach (string word in wordChecker.FoundWords)
                   Console.Write("{0} ", word);
   
               Console.SetCursorPosition(7, 14);
               Console.Write("Type in any words you find, press <ESC> to clear the line");
           }
  
          /// <summary>
          /// Process input any time the player enters a new letter
          /// </summary>
          public void ProcessInput()
          {
               wordChecker.CheckAnswer(CurrentInput, puzzle);
           }
  
          /// <summary>
          /// Return true if a key press is a valid letter
          /// </summary>
          /// <param name="key">Key that was pressed</param>
          /// <returns>True only if the key is a valid consonant or vowel in the puzzle</returns>
          public bool IsValidLetter(string key)
          {
               if (key.Length == 1)
               {
                    char c = key.ToCharArray()[0];
                    return Puzzle.Consonants.Contains(c) || Puzzle.Vowels.Contains(c);
                }
               return false;
           }
  
      }
}