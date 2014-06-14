using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise4
{
    /* 4. Write a method that counts how many times given number appears in given array. 
     * Write a test program to check if the method is working correctly.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];
            Console.WriteLine("Please enter number in array : ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Please enter number fo search in array : ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Number {0} is found in array", Count(num, array));
        }
        static int Count(int num, int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (num == array[i])
                {
                    count++;
                }
            }
            return count;
        }

    }
}
