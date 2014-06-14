namespace IntegerReverseDigits
{
    using System;

    public class IntegerReverseDigits
    {
        /// <summary>
        /// Write a method that reverses the digits of given decimal number. 
        /// Example: 256 -> 652
        /// </summary>
        public static void Main(string[] args)
        {
            int number = 1253;

            Console.WriteLine(number + ": " + Reverse(number));
        }

        public static int Reverse(int number)
        {
            int reversedNumber = 0;
            int check = number;
            int index = 0;

            do
            {
                index++;
                check = check / 10;
            } while (check != 0);

            for (int i = index - 1; i >= 0; i--)
            {
                reversedNumber = reversedNumber + number % 10 * (int)Math.Pow(10, i);
                number = number / 10;
            }

            return reversedNumber;
        }
    }
}
