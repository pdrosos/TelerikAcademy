using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.SetOfIntegers
{
    class SetOfIntegers
    {
        static void minOfSet(int[] setOfInts)
        {
            try
            {
                var min = setOfInts[0];
                for (int i = 1; i < setOfInts.Length; i++)
                {
                    if (setOfInts[i] < min)
                    {
                        min = setOfInts[i];
                    }
                }
                Console.WriteLine(min);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void maxOfSet(int[] setOfInts)
        {
            try
            {
                var max = setOfInts[0];
                for (int i = 1; i < setOfInts.Length; i++)
                {
                    if (setOfInts[i] > max)
                    {
                        max = setOfInts[i];
                    }
                }
                Console.WriteLine(max);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void averageOfSet(int[] setOfInts)
        {
            try
            {
                int sum = 0;
                double average = 0d;
                foreach (var item in setOfInts)
                {
                    sum += item;
                }
                average = (double)sum / setOfInts.Length;
                
                Console.WriteLine(average);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void sumOfSet(int[] setOfInts)
        {
            try
            {
                int sum = 0;
                foreach (var item in setOfInts)
                {
                    sum += item;
                }
                Console.WriteLine(sum);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void productOfSet(int[] setOfInts)
        {
            try
            {
                var product = 1;
                foreach (var item in setOfInts)
                {
                    product *= item;
                }
                Console.WriteLine(product);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Main(string[] args)
        {
            int[] setOfIntegers = { 1, 3, 2, 1, 4 };
            maxOfSet(setOfIntegers);
            minOfSet(setOfIntegers);
            averageOfSet(setOfIntegers);
            productOfSet(setOfIntegers);
        }
    }
}
