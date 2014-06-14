using System;
using System.Collections.Generic;
using System.Text;

namespace KaspichanNumbers
{
    class KaspichanNumbers
    {
        static void Main(string[] args)
        {
            ulong decimalNumber = ulong.Parse(Console.ReadLine());            
            string kaspichanNumber = ConvertFromDecimalToKaspichanNumber(decimalNumber);
            Console.WriteLine(kaspichanNumber);
        }

        private static string ConvertFromDecimalToKaspichanNumber(ulong decimalNumber)
        {
            List<string> kaspichanDigits = GetKaspichanDigits();
            ulong kaspichanNumeralSystemBase = (ulong)kaspichanDigits.Count;
            
            StringBuilder convertedNumber = new StringBuilder();

            do
            {
                convertedNumber.Insert(0, kaspichanDigits[(int)(decimalNumber % kaspichanNumeralSystemBase)]);
                decimalNumber /= kaspichanNumeralSystemBase;
            }
            while (decimalNumber != 0);

            return convertedNumber.ToString();
        }

        static List<string> GetKaspichanDigits()
        {
            List<string> digits = new List<string>();

            for (char symbol = 'A'; symbol <= 'Z'; symbol++)
            {
                digits.Add(symbol.ToString());
            }

            for (char symbolOne = 'a'; symbolOne <= 'i'; symbolOne++)
            {
                for (char symbolTwo = 'A'; symbolTwo <= 'Z'; symbolTwo++)
                {
                    digits.Add(symbolOne.ToString() + symbolTwo.ToString());
                }
            }

            digits = digits.GetRange(0, 256);

            return digits;
        }
    }
}
