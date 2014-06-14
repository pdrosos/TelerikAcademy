using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise9
{
    /* 9. Write a method that return the maximal element in a portion 
     *    of array of integers starting at given index. Using it write
     *    another method that sorts an array in ascending / descending order.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int index_search;
            int [] array = new int [20];
            Console.WriteLine("Please enter numbers in array: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            do
            {
                Console.WriteLine("Please enter index for search < 20 : ");
                index_search = Convert.ToInt32(Console.ReadLine());
                index_search--;
            } while (index_search < 0 && index_search > 20);
            Console.WriteLine("Greater number in next 10 numbers in array is : " + Partial_search(array, index_search));

            Console.WriteLine("\n\n Sorting... \n");
            Sort(array);
        }
        static int Partial_search(int[] array, int index)
        {
            int temp;
            int count_index = 5;
            int[] partial_array = new int[5];
            for (int i = 0; i < count_index && i + index < array.Length -1; i++)
            {
                partial_array[i] = array[i + index];
            }
            for (int i = 1; i < partial_array.Length; i++)
            {
                for (int j = 0; j < partial_array.Length - i; j++)
                {
                    if (partial_array[j] < partial_array[j + 1])
                    { 
                        temp = partial_array[j];
                        partial_array[j] = partial_array[j + 1];
                        partial_array[j + 1] = temp;
                    }
                }
            }
            return partial_array[0];
        }
        static int [] Sort(int[] array)
        {
            int member;
            int[] temp_array = new int[20];
            int [] sort_array = new int [20];
            for (int i = 0; i < temp_array.Length; i++)
            {
                temp_array[i] = array[i];
            }
            for (int i = 0; i < temp_array.Length; i++)
            {
                member = Partial_search(temp_array, i);
                sort_array[i] = member;
                for (int j = 0; j <  5 && j + i < temp_array.Length; j++)
                {
                    if (temp_array[j + i] == member)
                    {
                        temp_array[j] = -10;
                        break;
                    }
                }
            }
            for (int i = 0; i < sort_array.Length; i++)
            {
                Console.Write("{0} ", sort_array[i]);
            }
            return sort_array;
        }
    }
}
