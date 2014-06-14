namespace BinaryToDecimal
{
    using System;

    public class BinaryToDecimal
    {
        /// <summary>
        /// Write a program to convert binary numbers to their decimal representation.
        /// </summary>
        public static void Main(string[] args)
        {
            string binaryNumberOne = "110011";
            string binaryNumberTwo = "0011010101";
            string binaryNumberThree = "101010110011100001";

            // two ways of conversion - custom method and with Convert
            Console.WriteLine(binaryNumberOne + ": " + BinaryToInt(binaryNumberOne) + " " + Convert.ToInt32(binaryNumberOne, 2));
            Console.WriteLine(binaryNumberTwo + ": " + BinaryToInt(binaryNumberTwo) + " " + Convert.ToInt32(binaryNumberTwo, 2));
            Console.WriteLine(binaryNumberThree + ": " + BinaryToInt(binaryNumberThree) + " " + Convert.ToInt32(binaryNumberThree, 2));
        }

        public static int BinaryToInt(string binaryNumber)
        {
            int decimalNumber = 0;
            int powerOfTwo = 1;

            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                decimalNumber += BinaryDigitToDecimalDigit(binaryNumber[i]) * powerOfTwo;
                powerOfTwo *= 2;
            }

            return decimalNumber;
        }

        public static int BinaryDigitToDecimalDigit(char digit)
        {
            return digit - '0';
        }
    }
}
