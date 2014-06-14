namespace SumOfBigNumbers
{
    using System;
    using System.Collections.Generic;

    public class SumOfBigNumbers
    {
        /// <summary>
        /// Write a method that adds two positive integer numbers represented as arrays of digits 
        /// (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
        /// Each of the numbers that will be added could have up to 10 000 digits
        /// </summary>
        public static void Main(string[] args)
        {
            byte[] numberOne = { 2, 4, 5, 1, 6, 3, 7 };
            byte[] numberTwo = { 0, 4, 5, 2, 9 };

            //byte[] numberOne = { 9, 7, 4, 3, 6, 5 };
            //byte[] numberTwo = { 2, 1, 5, 0, 8, 7, 4, 3 };

            Console.WriteLine("{ " + string.Join(", ", numberOne) + " }");
            Console.WriteLine("{ " + string.Join(", ", numberTwo) + " }");

            List<byte> sum = Sum(numberOne, numberTwo);
            Console.Write("Sum = ");
            for (int i = sum.Count - 1; i >= 0; i--)
            {
                Console.Write(sum[i]);
            }
            Console.Write(" - { " + string.Join(", ", sum) + " }");
            Console.WriteLine();
        }

        public static List<byte> Sum(byte[] numberOne, byte[] numberTwo)
        {
            if (numberOne.Length > 10000 || numberTwo.Length > 10000)
            {
                throw new Exception("Numbers are out of range.");
            }

            List<byte> sum = new List<byte>();
            int carriedNumber = 0;
            int currentSum = 0;

            for (int i = 0; i < Math.Max(numberOne.Length, numberTwo.Length); i++)
            {
                currentSum = (i < numberOne.Length ? numberOne[i] : 0) + (i < numberTwo.Length ? numberTwo[i] : 0);
                sum.Add((byte)((currentSum + carriedNumber) % 10));
                carriedNumber = currentSum / 10;
            }

            if (carriedNumber > 0)
            {
                sum.Add((byte)carriedNumber);
            }

            return sum;
        }
    }
}
