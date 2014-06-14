namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implement a set of extension methods for IEnumerable<T> that implement the following group functions: 
    /// sum, product, min, max, average.
    /// </summary>
    class Test
    {
        static void Main(string[] args)
        {
            List<double> collection = new List<double> 
            { 3, 4, 5.6, 9.8, 123, -67, 15, 2.5, 18, -10 };

            Console.WriteLine("{ " + string.Join(", ", collection) + " }");

            Console.WriteLine("Sum: " + collection.Sum());
            Console.WriteLine("Product: " + collection.Product());
            Console.WriteLine("Average: " + collection.Average());
            Console.WriteLine("Min: " + collection.Min());
            Console.WriteLine("Max: " + collection.Max());
        }
    }
}
