using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        int k = int.Parse(Console.ReadLine());
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());

        }
        Array.Sort(arr);
        int index = Array.BinarySearch(arr, k);
        //if (arr[0] > k)
       // {
          //  Console.WriteLine("All the numbers are bigger than k.");
       // }
       // else
        //{

            if (index >= 0)
            {
                Console.WriteLine("The  number smaller or equal to k is {0} ", arr[index]);
            }
            else
            {
                Console.WriteLine("The larger number smaller or equal to k is {0} ", arr[~index]);
            }
        }
    }
//}
