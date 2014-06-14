// 2. Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDecimalConversion
{
    static void Main()
    {
        int binaryNumber = int.Parse(Console.ReadLine());
        int decimalNumber = 0;
        int digitPosition = 0;

        while (binaryNumber > 0)
        {
            int currentDigit = binaryNumber % 10;
            decimalNumber += ((int)Math.Pow(2, digitPosition)) * currentDigit;
            digitPosition++;
            binaryNumber /= 10;
        }

        Console.WriteLine(decimalNumber);
    }
}