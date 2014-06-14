/*Write a program that creates an array containing all letters from the alphabet (A-Z). 
 * Read a word from the console and print the index of each of its letters in the array.
 */
using System;

class ArrayOfLetters
{
    static void Main()
    {
        int[] SequenceOfAllLetters = new int[53];
        for (int i = 1; i < SequenceOfAllLetters.Length / 2 + 1; i++)
        {
            SequenceOfAllLetters[i] = ('a' - 1) + i;
        }
        for (int i = SequenceOfAllLetters.Length / 2 + 1, k = 0; i < SequenceOfAllLetters.Length; i++, k++)
        {
            SequenceOfAllLetters[i] = 'A' + k;
        }
        Console.Write("Please enter word: ");
        string WordToValue = Console.ReadLine();
        for (int i = 0; i < WordToValue.Length; i++)
        {
            for (int j = 0; j < SequenceOfAllLetters.Length; j++)
            {
                if (WordToValue[i] == SequenceOfAllLetters[j])
                {
                    Console.WriteLine("Leter {0} has index: {1}", WordToValue[i], j);
                    break;
                }
            }
        }
    }
}
