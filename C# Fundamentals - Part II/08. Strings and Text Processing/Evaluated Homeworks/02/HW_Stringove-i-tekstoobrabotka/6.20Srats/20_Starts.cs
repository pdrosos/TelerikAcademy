using System;

class Stars
{
    static void Main()
    {
        Console.WriteLine("Enter a string (Max 20 characters): ");
        string input = Console.ReadLine();
        //string output = "";
        if (input.Length < 20)
        {
            while (input.Length < 20)
            {
                input = string.Concat(input, "*");
            }
        }
        Console.WriteLine(input);
    }
}

