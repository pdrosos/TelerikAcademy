using System;

class BinarySearch
{
    static void Main()
    {
        //Write a program that finds the index of given element in a sorted array of integers by using the 
        //binary search algorithm (find it in Wikipedia).

        Console.WriteLine("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}]: ", i);
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine();
        Console.WriteLine("Enter the elemnt of which index you want to find: ");
        int target = Convert.ToInt32(Console.ReadLine());

        Array.Sort(array);
        Console.WriteLine("The index of the element is {0}", Array.BinarySearch(array, target));
    }
}
