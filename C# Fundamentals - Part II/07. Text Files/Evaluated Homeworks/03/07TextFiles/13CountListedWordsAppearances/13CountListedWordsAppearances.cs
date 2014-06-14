using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Write a program that reads a list of words from a file words.txt and finds how many 
// times each of the words is contained in another file test.txt. The result should 
// be written in the file result.txt and the words should be sorted by the number of 
// their occurrences in descending order. Handle all possible exceptions in your methods.

namespace _13CountListedWordsAppearances
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader words = new StreamReader(@"..\..\words.txt"))
            {
                using (StreamReader test = new StreamReader(@"..\..\test.txt"))
                {
                    string word = words.ReadLine();
                    string line = test.ReadToEnd();
                    while (word != null)
                    {
                        Console.WriteLine("The word \"{0}\" is contained {1} times.", word, CountSubstringAppearance(line, word));
                        word = words.ReadLine();
                    }

                }
            }
        }

        static int CountSubstringAppearance(string str, string word)
        {
            int result = 0;
            for (int index = 0; index < str.Length - word.Length; index++)
            {
                if (str.Substring(index, word.Length).ToLower() == word)
                {
                    result++;
                    index += word.Length - 1;
                }
            }
            return result;
        }
    }
}
