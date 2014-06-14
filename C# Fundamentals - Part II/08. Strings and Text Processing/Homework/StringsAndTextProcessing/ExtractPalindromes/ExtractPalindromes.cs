namespace ExtractPalindromes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExtractPalindromes
    {
        /// <summary>
        /// Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
        /// </summary>
        public static void Main(string[] args)
        {
            string text = @"A palindrome is a word, phrase, number, or other sequence of units that may be read the same way in either direction, 
                            with general allowances for adjustments to punctuation and word dividers.
                            Composing literature in palindromes is an example of constrained writing. aibohphobia, alula, cammac, civic, deified, 
                            deleveled, detartrated, devoved, dewed, evitative, ABBA";

            List<string> palindromes = Palindromes(text);
            Console.WriteLine(String.Join("\n", palindromes));
        }

        public static List<string> Palindromes(string text)
        {
            List<string> palindromes = new List<string>();
            StringBuilder word = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    while ((i < text.Length - 1) && (text[i + 1] != ' ') && (text[i + 1] != ',') && (text[i + 1] != '.') && (text[i + 1] != '-'))
                    {
                        i++;
                        word.Append(text[i]);
                    }

                    bool isPalindrome = true;
                    if (word.Length > 1)
                    {
                        int j = 0;
                        while (j < (word.Length - j - 1))
                        {
                            if ((word[j] == word[word.Length - j - 1])) j++;
                            else
                            {
                                isPalindrome = false;
                                break;
                            }
                        }

                        if (isPalindrome) 
                        {
                            palindromes.Add(word.ToString());
                        }
                    }
                }

                word.Clear();
            }

            return palindromes;
        }
    }
}
