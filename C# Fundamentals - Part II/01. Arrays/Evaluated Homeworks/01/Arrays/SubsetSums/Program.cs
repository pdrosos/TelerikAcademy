using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter the length of the array: ");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int setLength = int.Parse(Console.ReadLine());
        int[] arr = new int[arrayLength];
        Console.WriteLine("Enter the array members:");
        for (int i = 0; i < arrayLength; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int currentSum = 0;
        int maxSum = 0;
        for (int i = 0; i < arrayLength; i++) 
        {
            if (i + setLength > arr.Length - 1) 
            {
                break;
            }
            for (int j = i; j < i + setLength; j++) 
            {
                currentSum += arr[j];
            }
            if (currentSum > maxSum) 
            {
                maxSum = currentSum;
            }

            i = i + setLength - 1;
            currentSum = 0;
        }
        Console.WriteLine("The max subset sum is: {0}",maxSum);
    }
}

