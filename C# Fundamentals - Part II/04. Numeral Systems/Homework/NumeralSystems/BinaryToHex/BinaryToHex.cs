namespace BinaryToHex
{
    using System;
    using System.Text;

    public class BinaryToHex
    {
        /// <summary>
        /// Write a program to convert binary numbers to hexadecimal numbers (directly).
        /// </summary>
        public static void Main(string[] args)
        {
            string binaryNumberOne = "110011101";
            string binaryNumberTwo = "100010110";
            string binaryNumberThree = "10101010";

            Console.WriteLine(binaryNumberOne + ": " + BinaryToHexadecimal(binaryNumberOne));
            Console.WriteLine(binaryNumberTwo + ": " + BinaryToHexadecimal(binaryNumberTwo));
            Console.WriteLine(binaryNumberThree + ": " + BinaryToHexadecimal(binaryNumberThree));
        }

        public static string BinaryToHexadecimal(string binaryNumber)
        {
            // Add leading zeroes if needed to have groups of 4 elements
            if (binaryNumber.Length % 4 != 0)
            {
                return BinaryToHexadecimal(new String('0', 4 - binaryNumber.Length % 4) + binaryNumber);
            }

            StringBuilder hexNumber = new StringBuilder();
            int digitsGroup;
            int powerOfTwo;

            // Convert each group of 4 binary digits to hex digit
            for (int i = binaryNumber.Length - 1; i >= 0; i -= 4)
            {
                digitsGroup = 0;
                powerOfTwo = 1;
                for (int j = 0; j < 4; j++)
                {
                    digitsGroup += BinaryDigitToDecimalDigit(binaryNumber[i - j]) * powerOfTwo;
                    powerOfTwo *= 2;
                }

                hexNumber.Insert(0, DecimalDigitToHexDigit(digitsGroup));
            }

            return hexNumber.ToString();
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
    }
}
