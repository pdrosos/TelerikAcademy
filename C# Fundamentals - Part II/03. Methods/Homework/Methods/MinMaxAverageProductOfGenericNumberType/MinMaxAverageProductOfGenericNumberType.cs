namespace MinMaxAverageProductOfGenericNumberType
{
    using System;

    public class MinMaxAverageProductOfGenericNumberType
    {
        /// <summary>
        /// Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). 
        /// Use generic methods.
        /// </summary>
        public static void Main(string[] args)
        {
            int[] intNumbers = { -1, 3, -5, 4, 16, 8, -7, 2 };

            Console.WriteLine("{ " + string.Join(", ", intNumbers) + " }");
            Console.WriteLine("Min = " + Min(intNumbers));
            Console.WriteLine("Max = " + Max(intNumbers));
            Console.WriteLine("Avg = " + Avg(intNumbers));
            Console.WriteLine("Sum = " + Sum(intNumbers));
            Console.WriteLine("Product = " + Product(intNumbers));

            Console.WriteLine();

            double[] doubleNumbers = { -2.3, 4.5, 6, -7.8, 9.2, 1.2345, -3.456 };
            Console.WriteLine("{ " + string.Join(", ", doubleNumbers) + " }");
            Console.WriteLine("Min = " + Min(doubleNumbers));
            Console.WriteLine("Max = " + Max(doubleNumbers));
            Console.WriteLine("Avg = " + Avg(doubleNumbers));
            Console.WriteLine("Sum = " + Sum(doubleNumbers));
            Console.WriteLine("Product = " + Product(doubleNumbers));
        }

        public static T Min<T>(T[] numbers) where T : IComparable<T>
        {
            if (numbers.Length == 0)
            {
                throw new Exception("Cannot have empty array parameter.");
            }

            int minIndex = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i].CompareTo(numbers[minIndex]) < 0)
                
                {
                    minIndex = i;
                }
            }

            return numbers[minIndex];
        }

        public static T Max<T>(T[] numbers) where T : IComparable<T>
        {
            if (numbers.Length == 0)
            {
                throw new Exception("Cannot have empty array parameter.");
            }

            int maxIndex = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i].CompareTo(numbers[maxIndex]) > 0)
                {
                    maxIndex = i;
                }
            }

            return numbers[maxIndex];
        }

        public static double Avg<T>(T[] numbers)
        {
            return Convert.ToDouble(Sum(numbers)) / numbers.Length;
        }

        public static T Sum<T>(T[] numbers)
        {
            dynamic sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        public static T Product<T>(T[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new Exception("Cannot have empty array parameter.");
            }

            dynamic product = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }

            return product;
        }
    }
}
