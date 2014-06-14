namespace VariationsOfKElementsOfArrayOfNElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VariationsOfKElementsOfArrayOfNElements
    {
        /// <summary>
        /// Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
        /// Example:	N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a number >= 1:");
            int number = int.Parse(Console.ReadLine());

            int[] numbers = new int[number];

            for (int i = 0; i < number; i++)
            {
                numbers[i] = i + 1;
            }

            Console.WriteLine("Please, enter variations length:");
            int variationsLength = int.Parse(Console.ReadLine());

            List<int[]> variations = Variations(numbers, variationsLength);

            Console.WriteLine("All possible variations of {" + string.Join(", ", numbers.Select(x => x.ToString()).ToArray()) + "} are:");
            foreach (int[] variation in variations)
            {
                Console.WriteLine("{" + string.Join(", ", variation.Select(x => x.ToString()).ToArray()) + "}");
            }
        }

        public static List<int[]> Variations(int[] array, int length)
        {
            List<int[]> variations = new List<int[]>();
            int[] variation = new int[length];

            CalculateVariations(array, variation, 0, variations);

            return variations;
        }

        protected static void CalculateVariations(int[] array, int[] variation, int length, List<int[]> variations)
        {
            if (length < variation.Length)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    variation[length] = array[i];
                    CalculateVariations(array, variation, length + 1, variations);
                }
            }
            else
            {
                variations.Add((int[])variation.Clone());
            }
        }
    }
}
