using System;
using System.Collections.Generic;

namespace MultiverseCommunication
{
    class MultiverseCommunication
    {
        static void Main(string[] args)
        {
            string multiverseNumber = Console.ReadLine();
            ulong decimalNumber = ConvertFromMultiverseToDecimalNumber(multiverseNumber);
            Console.WriteLine(decimalNumber);
        }

        private static ulong ConvertFromMultiverseToDecimalNumber(string multiverseNumber)
        {
            List<string> muliverseDigits = GetMultiverseDigits();

            // split Multiverse number to digits
            List<string> multiverseNumberDigits = new List<string>();
            string currentDigit = string.Empty;
            for (int i = 0; i < multiverseNumber.Length; i++)
            {
                currentDigit += multiverseNumber[i];

                if (muliverseDigits.Contains(currentDigit))
                {
                    multiverseNumberDigits.Add(currentDigit);
                    currentDigit = string.Empty;
                }
            }

            // calculate decimal number
            ulong decimalNumber = 0;
            int durankulakNumeralSystemBase = muliverseDigits.Count;

            for (int i = 0; i < multiverseNumberDigits.Count; i++)
            {
                decimalNumber += (ulong)muliverseDigits.IndexOf(multiverseNumberDigits[i]) * Pow(durankulakNumeralSystemBase, multiverseNumberDigits.Count - i - 1);
            }

            return decimalNumber;
        }

        static List<string> GetMultiverseDigits()
        {
            List<string> digits = new List<string>()
            {
                "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ",
                "ERI", "CAD", "K-A", "IIA", "YLO", "PLA"
            };

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
