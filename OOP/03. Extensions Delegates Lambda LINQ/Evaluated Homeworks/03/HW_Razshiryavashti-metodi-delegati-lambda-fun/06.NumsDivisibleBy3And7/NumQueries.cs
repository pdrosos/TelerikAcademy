using System;
using System.Linq;

namespace _06.NumsDivisibleBy3And7
{
    class NumQueries
    {
        //06.Write a program that prints from given array of integers all numbers that are 
        //divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
        //lambda
        public static void PrintAllDivisibleBy3And7(int[] arr)
        {
            var selected = arr.Where(num => num % 21 == 0);
            foreach (var num in selected)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
        }
        //LINQ
        public static void PrintAllDivisibleBy3And7_LINQ(int[] arr)
        {
            var selected =
                from num in arr
                where num % 21 == 0
                select num;

            foreach (var num in selected)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
        }

    }
}
