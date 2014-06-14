using System;

class Unicode
{
    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();
        Console.WriteLine("Output: ");
        for (int i = 0; i < input.Length; i++)
        {
            Console.Write("\\u{0:X4}", (int)input[i]);
        }
        Console.WriteLine();      
    }
}

