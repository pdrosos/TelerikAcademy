using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicWords
{
    class MagicWords
    {
        static void Main(string[] args)
        {
            List<string> words = ReadWords();

            if (words.Count == 1)
            {
                Console.WriteLine(words.First());
            }
            else
            {
                string magicWord = CalculateMagicWord(words);
                Console.WriteLine(magicWord);
            }
        }
  
        private static string CalculateMagicWord(List<string> words)
        {
            StringBuilder magicWord = new StringBuilder();

            // move words
            int currentWordNewPosition = 0;
            for (int i = 0; i < words.Count; i++)
            {
                currentWordNewPosition = words[i].Length % (words.Count + 1);
                MoveWord(words, i, currentWordNewPosition);
            }

            bool hasRemainingLetters = false;
            int currentIndex = 0;
            while (true)
            {
                hasRemainingLetters = false;

                for (int i = 0; i < words.Count; i++)
                {
                    if (currentIndex < words[i].Length)
                    {
                        hasRemainingLetters = true;
                        magicWord.Append(words[i][currentIndex]);
                    }
                }

                if (hasRemainingLetters == false)
                {
                    break;
                }

                currentIndex++;
            }

            return magicWord.ToString();
        }

        private static void MoveWord(List<string> words, int fromIndex, int toIndex)
        {
            string word = words[fromIndex];
            
            if (fromIndex < toIndex)
            {
                words.Insert(toIndex, word);
                words.RemoveAt(fromIndex);                
            }
            else if (fromIndex > toIndex)
            {
                words.RemoveAt(fromIndex);
                words.Insert(toIndex, word);
            }
        }

        static List<string> ReadWords()
        {
            int wordsCount = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();

            for (int i = 0; i < wordsCount; i++)
			{
			    words.Add(Console.ReadLine());
			}

            return words;
        }
    }
}
