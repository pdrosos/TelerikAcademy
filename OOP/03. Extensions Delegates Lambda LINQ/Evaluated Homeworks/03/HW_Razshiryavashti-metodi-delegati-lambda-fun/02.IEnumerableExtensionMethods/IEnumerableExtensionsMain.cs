using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

class IEnumerableExtensionsMain
{
    //test

    static void Main()
    {
        //min
        int[] arr = new int[5] {7,2,3,8,5};
        int min = arr.Min<int>();
        Console.WriteLine("Min: {0}", min);

        //max
        int max = arr.Max<int>();
        Console.WriteLine("Max: {0}", max);

        //average
        decimal average = arr.Average<int>();
        Console.WriteLine("Average: {0}", average);

        //sum
        decimal sum = arr.Sum<int>();
        Console.WriteLine("Sum: {0}", sum);

        //product
        decimal product = arr.Product<int>();
        Console.WriteLine("Product: {0}", product);
    }
}

