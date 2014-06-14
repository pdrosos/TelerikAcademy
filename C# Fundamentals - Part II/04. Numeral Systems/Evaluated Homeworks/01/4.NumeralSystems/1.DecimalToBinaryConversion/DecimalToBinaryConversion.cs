// 1. Write a program to convert decimal numbers to their binary representation.

using System;
using System.Collections.Generic;

class DecimalToBinaryConversion
{
    static void Main()
    {
        int decimalNumber = int.Parse(Console.ReadLine());
        List<string> binaryNumber = new List<string>();       

        while (decimalNumber > 0)
        {
            int currentBinaryDigit = decimalNumber % 2;
            binaryNumber.Add(currentBinaryDigit.ToString());
            decimalNumber /= 2;
        }

        binaryNumber.Reverse();

        Console.WriteLine(string.Join("", binaryNumber));
    }
}