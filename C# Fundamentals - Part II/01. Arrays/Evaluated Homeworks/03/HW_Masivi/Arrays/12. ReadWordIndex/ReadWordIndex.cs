using System;

class ReadWordIndex
{
    static void Main()
    {
        char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        Console.WriteLine("Enter word: ");
        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            int index = Array.BinarySearch(alphabet, word[i]);
            Console.WriteLine("{0} has an index {1}", word[i], index);
        }
    }
}
