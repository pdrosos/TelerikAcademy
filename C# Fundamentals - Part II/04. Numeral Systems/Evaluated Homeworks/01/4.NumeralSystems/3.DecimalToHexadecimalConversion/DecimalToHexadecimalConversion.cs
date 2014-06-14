// 3. Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Text;

class DecimalToHexadecimalConversion
{
    static void Main()
    {
        int decimalNumber = int.Parse(Console.ReadLine());
        StringBuilder hexNumber = new StringBuilder();

        while (decimalNumber > 0)
        {
            int currentHexDigit = decimalNumber % 16;

            switch (currentHexDigit)
            {
                case 10: hexNumber.Append("A"); break;
                case 11: hexNumber.Append("B"); break;
                case 12: hexNumber.Append("C"); break;
                case 13: hexNumber.Append("D"); break;
                case 14: hexNumber.Append("E"); break;
                case 15: hexNumber.Append("F"); break;
                default: hexNumber.Append(currentHexDigit); break;
            }

            decimalNumber /= 16;
        }

        string result = hexNumber.ToString();

        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[result.Length - 1 - i]);
        }

        Console.WriteLine();
    }
}