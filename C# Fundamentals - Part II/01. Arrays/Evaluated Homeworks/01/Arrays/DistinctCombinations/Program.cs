using System;
using System.Collections.Generic;
using System.Text;
//Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
//Example: N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
class Program
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        int[] num = new int[k];
        Generate(num, 1, k-1, n);
    }

    private static void Generate(int[] num, int iteration, int index, int n)
    {
       
        if (index == -1) // bottom of recursion 
        {
            foreach (var item in num)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }        
        else
        {
            for (int i = iteration; i <= n; i++)
            {
                num[index] = i;
                Generate(num, i + 1, index - 1, n); //recursion
            }
        }
    }
}
