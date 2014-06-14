namespace AlphabetArrayAndStringAsArray
{
    using System;

    public class AlphabetArrayAndStringAsArray
    {
        /// <summary>
        /// Write a program that creates an array containing all letters from the alphabet (A-Z). 
        /// Read a word from the console and print the index of each of its letters in the array.
        /// </summary>
        public static void Main(string[] args)
        {
            char[] alphabetArray = GetEnglishAlphabetCapitalLetters(true);
            Console.WriteLine("Please, enter a word (A-Za-z):");
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i] + " - " + Array.IndexOf(alphabetArray, text[i]));
            }
        }

        public static char[] GetEnglishAlphabetCapitalLetters(bool withSmallLetters = true)
        {
            int arrayLength = 26;

            if (withSmallLetters == true)
            {
                arrayLength = 52;
            }

            char[] array = new char[arrayLength];

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                array[letter - 65] = letter; 
            }

            if (withSmallLetters == true)
            {
                for (char letter = 'a'; letter <= 'z'; letter++)
                {
                    array[letter - 97 + 26] = letter; 
                }
            }

            return array;
        }
    }
}
