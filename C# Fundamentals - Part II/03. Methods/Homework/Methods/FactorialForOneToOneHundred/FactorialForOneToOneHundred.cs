namespace FactorialForOneToOneHundred
{
    using System;
    using System.Collections.Generic;

    public class FactorialForOneToOneHundred
    {
        /// <summary>
        /// Write a program to calculate n! for each n in the range [1..100].
        /// </summary>
        public static void Main(string[] args)
        {
            int maxNumber = 100;
            int[][] array = new int[maxNumber][];
            int[] factorial = { 1 };

            for (int i = 1; i <= maxNumber; i++)
            {
                array[i - 1] = MultiplyNumberArray(factorial, i);
                factorial = array[i - 1];

                for (int j = 0; j < array[i - 1].Length; j++)
                {
                    Console.Write(array[i - 1][j]);
                }

                Console.WriteLine();
            }
        }

        static int[] MultiplyNumberArray(int[] array, int number)
        {
            List<int> result = new List<int>(array);

            int add = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int multDigit = array[i] * number + add;
                result[i] = multDigit % 10;
                add = multDigit / 10;
            }
            if (add > 0) result.InsertRange(0, NumberToArray(add));

            return result.ToArray();
        }

        static int[] NumberToArray(int number)
        {
            List<int> numberAsList = new List<int>();

            do
            {
                numberAsList.Insert(0, (number % 10));
                number = number / 10;
            } while (number != 0);

            return numberAsList.ToArray();
        }
    }
}
