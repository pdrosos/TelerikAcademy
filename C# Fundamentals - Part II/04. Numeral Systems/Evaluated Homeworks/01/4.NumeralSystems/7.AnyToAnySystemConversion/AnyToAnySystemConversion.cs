// 7. Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;
using System.Text;
using System.Linq;

class AnyToAnySystemConversion
{
    static void Main()
    {
        int baseToConvertFrom = 2;
        int baseToReturn = 16;
        string input = Console.ReadLine();

        int decimalNumber = AnyToDecimal(input, baseToConvertFrom);
        string result = DecimalToAny(decimalNumber, baseToReturn);
        
        Console.WriteLine(result);
    }

    static int AnyToDecimal(string number, int baseToConvertFrom)
    {
        int decimalNumber = 0;
        int currentHexDigitIndex = 0;

        while (currentHexDigitIndex < number.Length)
        {
            char currentHexDigit = number[number.Length - 1 - currentHexDigitIndex];
            int currentDigitDecimal = (int)Math.Pow(baseToConvertFrom, currentHexDigitIndex);

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

        return decimalNumber;
    }

    static string DecimalToAny(int decimalNumber, int baseToReturn)
    {
        StringBuilder builder = new StringBuilder();

        while (decimalNumber > 0)
        {
            int currentHexDigit = decimalNumber % baseToReturn;

            switch (currentHexDigit)
            {
                case 10: builder.Append("A"); break;
                case 11: builder.Append("B"); break;
                case 12: builder.Append("C"); break;
                case 13: builder.Append("D"); break;
                case 14: builder.Append("E"); break;
                case 15: builder.Append("F"); break;
                default: builder.Append(currentHexDigit); break;
            }

            decimalNumber /= baseToReturn;
        }

        string result = builder.ToString();
        builder.Clear();

        for (int i = 0; i < result.Length; i++)
        {
            builder.Append(result[result.Length - 1 - i]);
        }

        return builder.ToString();
    }
}