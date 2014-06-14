namespace ReplaceForbiddenWords
{
    using System;
    using System.Text.RegularExpressions;

    public class ReplaceForbiddenWords
    {
        /// <summary>
        /// We are given a string containing a list of forbidden words and a text containing some of these words. 
        /// Write a program that replaces the forbidden words with asterisks.
        /// </summary>
        public static void Main(string[] args)
        {
            string forbiddenWords = "PHP, CLR, Microsoft";
            string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

            string processedText = Regex.Replace(text, @"\b" + forbiddenWords.Replace(", ", "|") + @"\b", 
                match => new String('*', match.Length));
            Console.WriteLine(processedText);
        }
    }
}
