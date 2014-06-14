using System;

class ReversedString
{
    static void Main()
    {
        Console.WriteLine("Enter a string: ");
        string input = Console.ReadLine();
        char[] reversed = input.ToCharArray();
        Array.Reverse(reversed);
        string output = new string(reversed);
        Console.WriteLine("Your reversed string: " + output);
    }
}

