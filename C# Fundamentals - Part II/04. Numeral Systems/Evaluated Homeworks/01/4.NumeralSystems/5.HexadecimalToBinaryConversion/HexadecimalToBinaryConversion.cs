// 5. Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;
using System.Collections.Generic;

class HexadecimalToBinaryConversion
{
    static void Main()
    {
        string hexNumber = "FAC1";
        List<string> binaryDigitBuilder = new List<string>();
        int currentHexDigitIndex = 0;

        while (currentHexDigitIndex < hexNumber.Length)
        {
            char currentHexDigit = hexNumber[currentHexDigitIndex];
            string currentBinaryDigit = string.Empty;

            switch (currentHexDigit)
            {
                case '0': currentBinaryDigit = "0000"; break;
                case '1': currentBinaryDigit = "0001"; break;
                case '2': currentBinaryDigit = "0010"; break;
                case '3': currentBinaryDigit = "0011"; break;
                case '4': currentBinaryDigit = "0100"; break;
                case '5': currentBinaryDigit = "0101"; break;
                case '6': currentBinaryDigit = "0110"; break;
                case '7': currentBinaryDigit = "0111"; break;
                case '8': currentBinaryDigit = "1000"; break;
                case '9': currentBinaryDigit = "1001"; break;
                case 'A': currentBinaryDigit = "1010"; break;
                case 'B': currentBinaryDigit = "1011"; break;
                case 'C': currentBinaryDigit = "1100"; break;
                case 'D': currentBinaryDigit = "1101"; break;
                case 'E': currentBinaryDigit = "1110"; break;
                case 'F': currentBinaryDigit = "1111"; break;
                default: break;
            }

            binaryDigitBuilder.Add(currentBinaryDigit);            
            currentHexDigitIndex++;
        }

        Console.WriteLine(string.Join("", binaryDigitBuilder));
    }
}