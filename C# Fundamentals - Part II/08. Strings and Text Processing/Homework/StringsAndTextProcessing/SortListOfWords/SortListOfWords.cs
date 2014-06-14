namespace SortListOfWords
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class SortListOfWords
    {
        /// <summary>
        /// Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
        /// </summary>
        public static void Main(string[] args)
        {
            string text = "Lorem ipsum Dolor, Sit-amet.";

            List<string> words = new List<string>();
            foreach (Match word in Regex.Matches(text, @"\w+"))
            {
                words.Add(word.Value);
            }

            words.Sort();

            Console.WriteLine(String.Join(" ", words));
        }
    }
}
