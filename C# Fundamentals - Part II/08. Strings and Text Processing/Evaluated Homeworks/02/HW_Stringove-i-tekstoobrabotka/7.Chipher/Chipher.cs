using System;

class Chipher
{
    static void Main()
    {
        Console.WriteLine("Enter text to encode: ");
        string input = Console.ReadLine();
        Console.WriteLine("Enter chipher: ");
        string chipfer = Console.ReadLine();
        string output = "";

        for (int i = 0, j = 0; i < input.Length; i++,j++)
        {
            if (j==chipfer.Length)
            {
                j = 0;
            }
            output = output + (char)((int)input[i] ^ (int)chipfer[j]);
        }
        Console.WriteLine("Encodet text: "+output);
    }
}

