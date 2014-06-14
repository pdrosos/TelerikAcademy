namespace ReverseWordsInSentence
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ReverseWordsInSentence
    {
        /// <summary>
        /// Write a program that reverses the words in given sentence.
	    /// Example: "C# is not C++, not PHP and not Delphi!" -> "Delphi not and PHP, not C++ not is C#!".
        /// </summary>
        public static void Main(string[] args)
        {
            string sentence = "C# is not C++, not PHP and not Delphi!";

            List<string> words = new List<string>();
            List<string> separators = new List<string>();

            string expression = @"\s+|,\s*|\.\s*|!\s*|\?\s*|:\s*|;\s*";
            
            foreach (string word in Regex.Split(sentence, expression))
            {
                words.Add(word);
            }

            foreach (Match separator in Regex.Matches(sentence, expression))
            {
                separators.Add(separator.Value);
            }

            for (int i = 0; i < separators.Count; i++)
            {
                Console.Write(words[words.Count - i - 2] + separators[i]);
            }

            Console.WriteLine();
        }
    }
}
