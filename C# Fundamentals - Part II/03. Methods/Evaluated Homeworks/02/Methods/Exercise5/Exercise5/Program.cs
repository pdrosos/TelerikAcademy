using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise5
{
    /* 5. Write a method that checks if the element at given position in 
     *    given array of integers is bigger than its two neighbors (when such exist).
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            int index_array = 0;
            Console.WriteLine("Enter numbers in array : ");
            for (int i = 0; i < array.Length; i++ )
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Please enter a index of element for test : ");
            index_array = Convert.ToInt32(Console.ReadLine());
            if (Check_element(--index_array, array))
            {
                Console.WriteLine("Your num is greater then nums before and after it.");
            }
            else
            {
                Console.WriteLine("Your num is NOT greater then nums before and after it.");
            }

        }
        static bool Check_element(int index, int[] array)
        {
            bool result = true;
            if (index > 0 && array[index] <= array[--index])
            {
                result = false;
            }
            
            if(index < array.Length && array[index]<=array[++index])
            {
                result = false;
            }
            return result;
        }
    }
}
