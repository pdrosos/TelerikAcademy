using System;
using System.Collections.Generic;

namespace DurankulakNumbers
{
    class DurankulakNumbers
    {
        static void Main(string[] args)
        {
            string durankulakNumber = Console.ReadLine();
            ulong decimalNumber = ConvertFromDurankulakToDecimalNumber(durankulakNumber);
            Console.WriteLine(decimalNumber);
        }

        private static ulong ConvertFromDurankulakToDecimalNumber(string durankulakNumber)
        {
            List<string> durankulakDigits = GetDurankulakDigits();
            
            // split Durankulak number to digits
            List<string> durankulakNumberDigits = new List<string>();
            string currentDigit = string.Empty;
            for (int i = 0; i < durankulakNumber.Length; i++)
            {
                currentDigit += durankulakNumber[i];

                if (durankulakDigits.Contains(currentDigit))
                {
                    durankulakNumberDigits.Add(currentDigit);
                    currentDigit = string.Empty;
                }
            }

            // calculate decimal number
            ulong decimalNumber = 0;
            int durankulakNumeralSystemBase = durankulakDigits.Count;

            for (int i = 0; i < durankulakNumberDigits.Count; i++)
            {
                decimalNumber += (ulong)durankulakDigits.IndexOf(durankulakNumberDigits[i]) * Pow(durankulakNumeralSystemBase, durankulakNumberDigits.Count - i - 1);
            }

            return decimalNumber;
        }

        static List<string> GetDurankulakDigits()
        {
            List<string> digits = new List<string>();

            for (char symbol = 'A'; symbol <= 'Z'; symbol++)
            {
                digits.Add(symbol.ToString());
            }

            for (char symbolOne = 'a'; symbolOne <= 'f'; symbolOne++)
            {
                for (char symbolTwo = 'A'; symbolTwo <= 'Z'; symbolTwo++)
                {
                    digits.Add(symbolOne.ToString() + symbolTwo.ToString());
                }
            }

            digits = digits.GetRange(0, 168);

            return digits;
        }

        private static ulong Pow(int number, int power)
        {
            ulong result = 1;

            for (int i = 1; i <= power; i++)
            {
                result *= (ulong)number;
            }

            return result;
        }
    }
}
