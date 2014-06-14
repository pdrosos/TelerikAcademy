namespace ArrayOfIntDivisibleBySevenAndThree
{
    using System;
    using System.Linq;

    /// <summary>
    /// Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
    /// Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
    /// </summary>
    class Test
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 3, 21, 7, 13, 42, -21, 15, -42, 15 };

            // with extension methods
            Console.WriteLine("With extension methods:");
            var result = numbers.Where(number => number % 7 == 0 && number % 3 == 0);
            foreach (int number in result)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            // with LINQ
            Console.WriteLine("With LINQ:");
            result = from number in numbers
                     where number % 7 == 0 && number % 3 == 0
                     select number;
            foreach (int number in result)
            {
                Console.WriteLine(number);
            }
        }
    }
}
