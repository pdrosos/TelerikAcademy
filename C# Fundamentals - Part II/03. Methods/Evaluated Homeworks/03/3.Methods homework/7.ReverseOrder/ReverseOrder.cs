using System;

class ReverseOrder
{
    static void ReverseNumbers(int number)
    {
        int devidedNumber = number;
        int remainder = 0;
        while (devidedNumber != 0)
        {
            remainder = devidedNumber % 10;
            devidedNumber = devidedNumber / 10;
            Console.Write(remainder);
        }

    }
    static void Main()
    {
        ReverseNumbers(256782);
        Console.WriteLine();
    }
}
