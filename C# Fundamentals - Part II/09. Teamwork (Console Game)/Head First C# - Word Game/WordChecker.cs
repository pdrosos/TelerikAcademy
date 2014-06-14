using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder
{
     /// <summary>
     /// The WordChecker class keeps track of the list of valid words and checks 
     /// to see if a given word is valid and only made up of letters from the grid.
     /// </summary>
     class WordChecker
     {
          /// <summary>
          /// The valid words
          /// </summary>
          private List<string> words = new List<string>();
  
          /// <summary>
          /// The found words
          /// </summary>
          private List<string> foundWords = new List<string>();
  
          /// <summary>
          /// Return the number of words that were found
          /// </summary>
          public int NumberFound
          {
               get { return foundWords.Count; }
           }
  
          /// <summary>
          /// Get the set of words that were found
          /// </summary>
          public IEnumerable<string> FoundWords {
               get
               {
                    List<string> value = new List<string>();
                    foreach (string word in foundWords)
                    {
                         value.Add(word.ToUpper());
                     }
                    return value;
                }
           }
  
          /// <summary>
          /// WordChecker Constructor
          /// </summary>
          /// <param name="validWords">The set of valid words</param>
          public WordChecker(IEnumerable<string> validWords)
          {
               // Make each word uppercase and add it to the word list
               foreach(string word in validWords)
                   this.words.Add(word.ToUpper());
           }
  
          /// <summary>
          /// Check if a player's word is a valid word that's contained in the puzzle
          /// </summary>
          /// <param name="word">Word to check</param>
          /// <param name="puzzle">Reference to the Puzzle object</param>
          public void CheckAnswer(string word, Puzzle puzzle)
          {
               // Make sure the word is a non-empty, valid word that's at least 4 characters long
               if (String.IsNullOrEmpty(word) || foundWords.Contains(word) || word.Length < 4)
                   return;
   
               // Make sure the word is upper case -- and the upperCaseWord string will be destroyed
               // so we need to make a copy. We'll remove each puzzle letter from the word. If any
               // letters are left over, the word is not in the puzzle.
               string upperCaseWord = word.ToUpper();
               if (words.Contains(upperCaseWord))
               {
                    // Make sure it's made up entirely of letters in the puzzle
                    foreach (char letter in puzzle.Letters)
                    {
                         // Remove each puzzle letter from the word
                         if (upperCaseWord.Contains(letter))
                         {
                              // If the word starts with the letter, Substring(0, index - 1) will throw an exception
                              if (upperCaseWord.StartsWith(letter.ToString()))
                                  upperCaseWord = upperCaseWord.Substring(1);
                              else
                              {
                                   int index = upperCaseWord.IndexOf(letter);
                                   upperCaseWord = upperCaseWord.Substring(0, index - 1) + upperCaseWord.Substring(index + 1);
                               }
                          }
                     }
                }
   
               // If removing all the puzzle letters from upperCaseWord left us with an empty string,
               // we found a word. Beep and add it to the found words list.
               if (String.IsNullOrEmpty(upperCaseWord))
               {
                    Console.Beep();
                    foundWords.Add(word);
                }
           }
      }
}