namespace DecimalToBinary
{
    using System;
    
    public class DecimalToBinary
    {
        /// <summary>
        /// Write a program to convert decimal numbers to their binary representation.
        /// </summary>
        public static void Main(string[] args)
        {
            int numberOne = 2;
            int numberTwo = -2;

            // two ways of conversion - custom method and with convert
            Console.WriteLine(numberOne + ": " + Int32ToBinary(numberOne) + " " + Convert.ToString(numberOne, 2));
            Console.WriteLine(numberTwo + ": " + Int32ToBinary(numberTwo) + " " + Convert.ToString(numberTwo, 2));
        }

        // with leading zeroes
        public static string Int32ToBinary(int number)
        {
            char[] binary = new char[32];
            int currentPosition = 31;
            int i = 0;

            while (i < 32)
            {
                if ((number & (1 << i)) != 0)
                {
                    binary[currentPosition] = '1';
                }
                else
                {
                    binary[currentPosition] = '0';
                }
                currentPosition--;
                i++;
            }

            return new string(binary);
        }
    }
}
