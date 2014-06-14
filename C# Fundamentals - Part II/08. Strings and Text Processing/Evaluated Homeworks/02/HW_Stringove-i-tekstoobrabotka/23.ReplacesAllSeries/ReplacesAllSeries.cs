//Write a program that reads a string from the console and replaces all series of consecutive identical 
//letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

using System;
using System.Text;

namespace ReplacesAllSeries
{
    internal class Program
    {
        private static void Main()
        {
            string input = "aaaaabbbbbcdddeeeedssaa";
            string output = RemoveConsecutiveLetters(input);
            Console.WriteLine(output);

        }

        private static string RemoveConsecutiveLetters(string content)
        {
            var result = new StringBuilder();
            result.Append(content[0]);
            for (int i = 1; i < content.Length; i++)
            {
                if (content[i] != result[result.Length - 1])
                {
                    result.Append(content[i]);
                }
            }

            return result.ToString();
        }
    }
}
