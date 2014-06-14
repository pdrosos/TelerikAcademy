namespace ConvertBetweenNumeralSystems
{
    using System;
    using System.Text;

    class ConvertBetweenNumeralSystems
    {
        /// <summary>
        /// Write a program to convert from any numeral system of given base s to any other numeral system of base d 
        /// (2 ≤ s, d ≤  16).
        /// </summary>
        public static void Main(string[] args)
        {
            int sourceNumeralSystemBase = 8;
            int destinationNumeralSystemBase = 16;

            int sourceNumeralSystemNumber = 125037;
            string destinationNumeralSystemNumber = NumeralSystemToNumeralSystem(
                sourceNumeralSystemNumber,
                sourceNumeralSystemBase, 
                destinationNumeralSystemBase);

            Console.WriteLine(sourceNumeralSystemNumber + " of base " + sourceNumeralSystemBase +
                " = " + destinationNumeralSystemNumber + " of base " + destinationNumeralSystemBase);
        }

        public static int NumeralSystemToDecimal(int number, int numeralSystemBase)
        {
            int convertedNumber = 0;
            int powerOfNumeralSystemBase = 1;

            string numeralSystemOneString = number.ToString(); //number as array of chars

            for (int i = numeralSystemOneString.Length - 1; i >= 0; i--)
            {
                convertedNumber += BinaryDigitToDecimalDigit(numeralSystemOneString[i]) * powerOfNumeralSystemBase;
                powerOfNumeralSystemBase *= numeralSystemBase;
            }

            return convertedNumber;
        }

        public static string DecimalToNumeralSystem(int number, int numeralSystemBase)
        {
            StringBuilder convertedNumber = new StringBuilder();

            do
            {
                convertedNumber.Insert(0, DecimalDigitToHexDigit(number % numeralSystemBase));
                number /= numeralSystemBase;
            }
            while (number != 0);

            return convertedNumber.ToString();
        }

        public static char DecimalDigitToHexDigit(int number)
        {
            if (number >= 10)
            {
                return (char)('A' + number - 10);
            }
            else
            {
                return (char)('0' + number);
            }
        }

        public static int BinaryDigitToDecimalDigit(char digit)
        {
            return digit - '0';
        }
        
        public static string NumeralSystemToNumeralSystem(int number, int sourceNumeralSystemBase, int destinationNumeralSystemBase)
        {
            return DecimalToNumeralSystem(NumeralSystemToDecimal(number, sourceNumeralSystemBase), destinationNumeralSystemBase);
        }
    }
}
