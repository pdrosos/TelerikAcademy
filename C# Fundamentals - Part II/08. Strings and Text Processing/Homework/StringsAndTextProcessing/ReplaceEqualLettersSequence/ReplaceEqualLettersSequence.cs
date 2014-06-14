namespace ReplaceEqualLettersSequence
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ReplaceEqualLettersSequence
    {
        /// <summary>
        /// Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. 
        /// Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".
        /// </summary>
        public static void Main(string[] args)
        {
            string text = "aaaaabbbbbcdddeeeedssaa1122333";
            Console.WriteLine(Regex.Replace(text, @"(\w)\1+", "$1"));
            Console.WriteLine(RemoveRepeatingLetters(text));
        }

        public static string RemoveRepeatingLetters(string text)
        {
            StringBuilder result = new StringBuilder();
            result.Append(text);

            for (int i = 1; i < result.Length; i++)
            {
                // check if the character is a letter or digit
                if (char.IsLetterOrDigit(result[i]) && (result[i] == result[i - 1]))
                {
                    result.Remove(i, 1);
                    i--;
                }
            }

            return result.ToString();
        }
    }
}
