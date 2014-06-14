namespace ShortToBinary
{
    using System;

    class ShortToBinary
    {
        /// <summary>
        /// Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
        /// </summary>
        static void Main(string[] args)
        {
            short numberOne = 123;
            short numberTwo = 897;
            short numberThree = 2090;

            // two ways of conversion - custom method and with convert
            Console.WriteLine(numberOne + ": " + Int16ToBinary(numberOne) + " " + Convert.ToString(numberOne, 2));
            Console.WriteLine(numberTwo + ": " + Int16ToBinary(numberTwo) + " " + Convert.ToString(numberTwo, 2));
            Console.WriteLine(numberThree + ": " + Int16ToBinary(numberThree) + " " + Convert.ToString(numberThree, 2));
        }

        // with leading zeroes
        public static string Int16ToBinary(short number)
        {
            char[] binary = new char[16];
            int currentPosition = 15;
            int i = 0;

            while (i < 16)
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
