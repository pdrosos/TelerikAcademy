namespace CountWordsInString
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class CountWordsInString
    {
        /// <summary>
        /// Write a program that reads a string from the console and lists all different words in the string 
        /// along with information how many times each word is found.
        /// </summary>
        public static void Main(string[] args)
        {
            string text = "Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found";

            Dictionary<string, int> wordsOccurences = CountWordsOccurences(text);
            foreach (KeyValuePair<string, int> word in wordsOccurences)
            {
                Console.WriteLine(word.Key + ": " + word.Value);
            }
        }

        public static Dictionary<string, int> CountWordsOccurences(string text)
        {
            MatchCollection words = Regex.Matches(text, @"\w+");
            Dictionary<string, int> wordsOccurences = new Dictionary<string, int>();

            foreach (Match word in words)
            {
                if (wordsOccurences.ContainsKey(word.Value))
                {
                    wordsOccurences[word.Value]++;
                }
                else
                {
                    wordsOccurences.Add(word.Value, 1);
                }
            }

            return wordsOccurences;
        }
    }
}
