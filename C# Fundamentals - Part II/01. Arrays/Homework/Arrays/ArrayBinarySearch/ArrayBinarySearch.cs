namespace ArrayBinarySearch
{
    using System;

    public class ArrayBinarySearch
    {
        /// <summary>
        /// Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm.
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { 2, -4, 5, -8, 0, 10, 13, 26, 59, -29 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");  

            Array.Sort(array);
            Console.WriteLine("The sorted array is: { " + string.Join(", ", array) + " }");
            
            Console.WriteLine("Please, enter search element:");
            int searchElement = int.Parse(Console.ReadLine());

            int searchIndex = Array.BinarySearch(array, searchElement);

            Console.WriteLine("The index of the first occurence of {0} is {1}", searchElement, searchIndex);
        }
    }
}
