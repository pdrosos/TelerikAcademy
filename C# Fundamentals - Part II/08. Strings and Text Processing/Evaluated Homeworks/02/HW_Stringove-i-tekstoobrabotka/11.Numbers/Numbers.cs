using System;

class Numbers
{
    static void Main()
    {
        Console.WriteLine("Enter a number: ");
        int input = int.Parse(Console.ReadLine());
        Console.WriteLine("{0,15:D2}", input);
        Console.WriteLine("{0,15:X}", input);
        Console.WriteLine("{0,15:P}", input); 
        Console.WriteLine("{0,15:E}", input);
    }
}

