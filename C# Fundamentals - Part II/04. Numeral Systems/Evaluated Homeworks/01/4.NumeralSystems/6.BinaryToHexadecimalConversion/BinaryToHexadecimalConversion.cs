// 6. Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
using System.Collections.Generic;
using System.Text;

class BinaryToHexadecimalConversion
{
    static void Main()
    {
        string binaryNumber = "11111";        
        List<string> binaryNumberDigits = new List<string>();

        if (binaryNumber.Length % 4 != 0)
        {
            int padLength = binaryNumber.Length + (4 - (binaryNumber.Length % 4));
            binaryNumber = binaryNumber.PadLeft(padLength, '0');
        }

        int currentStartIndex = 0;

        while (currentStartIndex < binaryNumber.Length - 1)
        {
            string currentBinaryDigit = binaryNumber.Substring(currentStartIndex, 4);
            binaryNumberDigits.Add(currentBinaryDigit);
            currentStartIndex += 4;
        }

        StringBuilder hexadecimalBuilder = new StringBuilder();

        for (int i = 0; i < binaryNumberDigits.Count; i++)
        {
            string currentBinaryDigit = binaryNumberDigits[i];
            switch (currentBinaryDigit)
            {
                case "0000": hexadecimalBuilder.Append("0"); break;
                case "0001": hexadecimalBuilder.Append("1"); break;
                case "0010": hexadecimalBuilder.Append("2"); break;
                case "0011": hexadecimalBuilder.Append("3"); break;
                case "0100": hexadecimalBuilder.Append("4"); break;
                case "0101": hexadecimalBuilder.Append("5"); break;
                case "0110": hexadecimalBuilder.Append("6"); break;
                case "0111": hexadecimalBuilder.Append("7"); break;
                case "1000": hexadecimalBuilder.Append("8"); break;
                case "1001": hexadecimalBuilder.Append("9"); break;
                case "1010": hexadecimalBuilder.Append("A"); break;
                case "1011": hexadecimalBuilder.Append("B"); break;
                case "1100": hexadecimalBuilder.Append("C"); break;
                case "1101": hexadecimalBuilder.Append("D"); break;
                case "1110": hexadecimalBuilder.Append("E"); break;
                case "1111": hexadecimalBuilder.Append("F"); break;
                default: break;
            }
        }

        Console.WriteLine(hexadecimalBuilder);
    }
}