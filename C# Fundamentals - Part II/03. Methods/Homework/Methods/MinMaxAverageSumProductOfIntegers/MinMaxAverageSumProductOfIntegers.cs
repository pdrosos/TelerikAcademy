namespace MinMaxAverageSumProductOfIntegers
{
    using System;
    
    public class MinMaxAverageSumProductOfIntegers
    {
        /// <summary>
        /// Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
        /// Use variable number of arguments.
        /// </summary>
        public static void Main(string[] args)
        {
            int[] numbers = { -1, 3, -5, 4, 16, 8, -7, 2 };

            Console.WriteLine("{ " + string.Join(", ", numbers) + " }");
            Console.WriteLine("Min = " + Min(numbers));
            Console.WriteLine("Max = " + Max(numbers));
            Console.WriteLine("Avg = " + Avg(numbers));
            Console.WriteLine("Sum = " + Sum(numbers));
            Console.WriteLine("Product = " + Product(numbers));
        }

        public static int Min(int[] numbers)
        {
            int min = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        public static int Max(int[] numbers)
        {
            int max = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        public static double Avg(int[] numbers)
        {
            return Sum(numbers) / (double)numbers.Length;
        }

        public static int Sum(int[] numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        public static int Product(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new Exception("Cannot have empty array parameter.");
            }

            int product = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }

            return product;
        }
    }
}
