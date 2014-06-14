using System;
using System.Linq;

namespace _06.NumsDivisibleBy3And7
{
    class NumsMain
    {
        //06.Write a program that prints from given array of integers all numbers that are 
        //divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

        static void Main()
        {
            //initialize an array
            int[] arr = new int[100];
            for (int i = 0; i < 100; i++)
            {
                arr[i] = i;
            }

            NumQueries.PrintAllDivisibleBy3And7(arr);
            Console.WriteLine("-----------");
            NumQueries.PrintAllDivisibleBy3And7_LINQ(arr);
        }
    }
}
