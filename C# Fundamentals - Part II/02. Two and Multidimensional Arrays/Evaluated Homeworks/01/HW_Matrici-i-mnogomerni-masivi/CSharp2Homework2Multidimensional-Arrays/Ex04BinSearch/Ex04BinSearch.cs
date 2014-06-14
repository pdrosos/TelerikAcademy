
// Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using 
// the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;

class Ex04BinSearch
{
    static void Main(string[] args)
    {
        //int[] arr = { 2, 5, 90, 56, 43, 25, 5, 10, 72, 18, 61, 15 };
        //int k = 91;
        Console.Write("Enter array's length: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());        

        Array.Sort(arr);
        if (Array.BinarySearch(arr, k) >= 0)        
            Console.WriteLine("The max number <= k is: {0}", k);
        else
        {
            do            
                k--;
            while (Array.BinarySearch(arr, k) < 0);
            Console.WriteLine("The max number <= k is: {0}", k);
        }        
    }
}

