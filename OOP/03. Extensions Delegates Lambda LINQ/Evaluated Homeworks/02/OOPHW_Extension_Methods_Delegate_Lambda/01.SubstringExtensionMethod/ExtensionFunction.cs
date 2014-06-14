///02.Implement a set of extension methods for IEnumerable<T>
///that implement the following group functions: sum, product, min, max, average.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringExtensionMethod
{
    public static class ExtensionFunction
    {
        //Min extensin method for T type
        public static T Min<T>(this T first, T second)
        where T : IComparable
        {
            T result;
            if (first.CompareTo(second) == 1)
            {
                result = second;
            }
            else
            {
                result = first;
            }
            return result;
        }
        //Min extensin method for T type
        public static T Max<T>(this T first, T second)
        where T : IComparable
        {
            T result;
            if (first.CompareTo(second) == -1)
            {
                result = second;
            }
            else
            {
                result = first;
            }
            return result;
        }
        //SUM
        public static T Sum<T>(this IEnumerable<T> arr)
        {
            dynamic sum = 0;
            foreach (var item in arr)
            {
                sum += (dynamic)item;
            }
            return sum;
        }
        //Product
        public static T Product<T>(this IEnumerable<T> arr)
        {
            dynamic product = 1;
            foreach (var item in arr)
            {
                product *= (dynamic)item;
            }
            return product;
        }
        //Average
        public static T Average<T>(this IEnumerable<T> arr)
        {
            dynamic product = 1;
            int count = arr.Count();

            foreach (var item in arr)
            {
                product *= (dynamic)item;
            }
            return product / count;
        }
        //Print the element into array
        public static void Print<T>( IEnumerable<T> arr)
        {
            Console.Write("Array is [");
            foreach (var item in arr)
            {
                Console.Write(" {0}",item);
            }
            Console.WriteLine("]");
        }

    }
}
