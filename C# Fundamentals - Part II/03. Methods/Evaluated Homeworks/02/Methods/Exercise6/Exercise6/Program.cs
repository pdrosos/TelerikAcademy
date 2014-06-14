using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise6
{
    /* 6. Write a method that returns the index of the first element in array
     *    that is bigger than its neighbors, or -1, if there’s no such element.
     *    Use the method from the previous exercise.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int [] array = new int [10];
            Console.WriteLine("Please enter numbers in array : ");
            for (i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            for (i = 0; i < array.Length; i++)
            {
                if (Check_element(i, array))
                {
                    Console.WriteLine("First element in the array greater then its neighbors is "+ array[i]);
                    break;
                }
            }
            if (i == 10)
            {
                Console.WriteLine("First element in the array greater then its neighbors is -1 ");
            }
        }
        static bool Check_element(int index, int[] array)
        {
            bool result = true;
            if (index > 0 && array[index] <= array[index - 1])
            {
                result = false;
            }
            if (index < array.Length && array[index] <= array[index + 1])
            {
                result = false;
            }
            return result;
        }
    }
}
