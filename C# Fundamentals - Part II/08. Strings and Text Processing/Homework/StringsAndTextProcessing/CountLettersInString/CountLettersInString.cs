namespace CountLettersInString
{
    using System;
    using System.Collections.Generic;

    public class CountLettersInString
    {
        /// <summary>
        /// Write a program that reads a string from the console and prints all different letters in the string 
        /// along with information how many times each letter is found. 
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter some text:");
            string text = Console.ReadLine();

            Dictionary<string, int> alphabet = EnglishAlphabet();

            foreach (char symbol in text)
            {
                if ((symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z'))
                {
                    alphabet[symbol.ToString()]++;
                }
            }

            foreach (KeyValuePair<string, int> letter in alphabet)
            {
                if (letter.Value > 0)
                {
                    Console.WriteLine(letter.Key + ": " + letter.Value);
                }
            }
        }

        public static Dictionary<string, int> EnglishAlphabet(bool withCapitalLetters = true)
        {
            Dictionary<string, int> alplabet = new Dictionary<string, int>();

            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                alplabet.Add(letter.ToString(), 0);
            }

            if (withCapitalLetters == true)
            {
                for (char letter = 'A'; letter <= 'Z'; letter++)
                {
                    alplabet.Add(letter.ToString(), 0);
                }
            }

            return alplabet;
        }
    }
}
