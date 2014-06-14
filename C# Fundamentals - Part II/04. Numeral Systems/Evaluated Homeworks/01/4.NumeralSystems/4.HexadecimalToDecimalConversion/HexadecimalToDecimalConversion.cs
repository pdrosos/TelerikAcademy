// 4. Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class HexadecimalToDecimalConversion
{
    static void Main()
    {
        string hexNumber = Console.ReadLine();
        int decimalNumber = 0;
        int currentHexDigitIndex = 0;

        while (currentHexDigitIndex < hexNumber.Length)
        {
            char currentHexDigit = hexNumber[hexNumber.Length - 1 - currentHexDigitIndex];
            int currentDigitDecimal = (int)Math.Pow(16, currentHexDigitIndex);

            switch (currentHexDigit)
            {
                case 'A': decimalNumber += currentDigitDecimal * 10; break;
                case 'B': decimalNumber += currentDigitDecimal * 11; break;
                case 'C': decimalNumber += currentDigitDecimal * 12; break;
                case 'D': decimalNumber += currentDigitDecimal * 13; break;
                case 'E': decimalNumber += currentDigitDecimal * 14; break;
                case 'F': decimalNumber += currentDigitDecimal * 15; break;
                default: decimalNumber += currentDigitDecimal * int.Parse(currentHexDigit.ToString()); break;
            }

            currentHexDigitIndex++;
        }

        Console.WriteLine(decimalNumber);
    }
}