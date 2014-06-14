using System;
using System.Collections.Generic;
using System.Text;
//Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
//    N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
class Program
{

    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        int[] num = new int[k];
        Generate(num, n, k-1);
    }

    private static void Generate(int[] num, int n, int index)
    {
        if (index == -1) // bottom of recursion 
        {
            foreach (var item in num)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                num[index] = i;
                Generate(num, n, index - 1); //recursion
            }
        }
    }
}

