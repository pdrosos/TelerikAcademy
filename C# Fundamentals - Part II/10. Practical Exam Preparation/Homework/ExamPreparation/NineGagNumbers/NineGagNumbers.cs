using System;
using System.Collections.Generic;

namespace NineGagNumbers
{
    class NineGagNumbers
    {
        static void Main(string[] args)
        {
            string nineGagNumber = Console.ReadLine();

            List<int> nineNumberDigits = new List<int>();
            string currentNineGagDigit = string.Empty;

            for (int i = 0; i < nineGagNumber.Length; i++)
            {
                currentNineGagDigit += nineGagNumber[i];

                int currentNineDigit = NineGagDigitToNineDigit(currentNineGagDigit);
                if (currentNineDigit >= 0)
                {
                    nineNumberDigits.Add(currentNineDigit);
                    currentNineGagDigit = string.Empty;
                }
            }

            ulong decimalNumber = 0;

            for (int i = 0; i < nineNumberDigits.Count; i++)
            {
                decimalNumber += (ulong)nineNumberDigits[i] * Pow(9, nineNumberDigits.Count - i - 1);
            }

            Console.WriteLine(decimalNumber);
        }

        private static int NineGagDigitToNineDigit(string nineGagDigit)
        {
            List<string> nineGagDigits = new List<string>()
            {
                "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-"
            };
            
            if (nineGagDigits.Contains(nineGagDigit))
            {
                return nineGagDigits.IndexOf(nineGagDigit);
            }

            return -1;
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
