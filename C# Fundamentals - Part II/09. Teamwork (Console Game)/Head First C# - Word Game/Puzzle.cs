using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder
{
     /// <summary>
     /// The Puzzle class keeps track of the puzzle grid. The Game uses it to draw
     /// the initial grid to the screen, and the WordFinder class uses it to check if the
     /// player's input contains only letters from the grid.
     /// </summary>
     class Puzzle
     {
          /// <summary>
          /// Randomizer
          /// </summary>
          private Random random = new Random();
  
          /// <summary>
          /// Consonants (including Y)
          /// </summary>
          public static readonly char[] Consonants = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 
               'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };
  
          /// <summary>
          /// Vowels (including Y)
          /// </summary>
          public static readonly char[] Vowels = { 'A', 'E', 'I', 'O', 'U', 'Y' };
  
          /// <summary>
          /// Backing field for Letters property
          /// </summary>
          char[] letters;
  
          /// <summary>
          /// Get the letters in the puzzle
          /// </summary>
          public IEnumerable<char> Letters
          {
               get { return letters; }
           }
  
          /// <summary>
          /// The number of letters in the puzzle
          /// </summary>
          private int puzzleLength;
  
          /// <summary>
          /// Puzzle Constructor
          /// </summary>
          /// <param name="puzzleLength">The number of letters in the puzzle</param>
          /// <param name="vowelEvery">Every nth letter is a vowel</param>
          public Puzzle(int puzzleLength, int vowelEvery)
          {
               this.puzzleLength = puzzleLength;
   
               letters = new char[puzzleLength];
   
               for (int i = 0; i < puzzleLength; i++)
               {
                    if (i % vowelEvery == 0)
                        letters[i] = Vowels[random.Next(Vowels.Length)];
                    else
                        letters[i] = Consonants[random.Next(Consonants.Length)];
                }
           }
  
          /// <summary>
          /// Draw the puzzle at a specific point on the screen
          /// </summary>
          /// <param name="left">The column position of the cursor</param>
          /// <param name="top">The row position of the cursor</param>
          public void Draw(int left, int top)
          {
               int oldTop = Console.CursorTop;
               int oldLeft = Console.CursorLeft;
   
               Console.BackgroundColor = ConsoleColor.Gray;
   
               // Create the random puzzle using random letters and print them
               for (int i = 0; i < puzzleLength; i++)
               {
                    // Use cursor movement to draw the rows of the square puzzle grid
                    if (i % Math.Floor(Math.Sqrt(puzzleLength)) == 0)
                    {
                         Console.CursorTop = top++;
                         Console.CursorLeft = left;
                     }
    
                    if (Vowels.Contains(letters[i]))
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
    
                    Console.Write(" {0} ", letters[i]);
                }
   
               Console.ResetColor();
   
               Console.CursorTop = oldTop;
               Console.CursorLeft = oldLeft;
           }
      }
}