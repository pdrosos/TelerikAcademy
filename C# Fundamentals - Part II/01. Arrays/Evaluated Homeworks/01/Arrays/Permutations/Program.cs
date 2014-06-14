using System;
using System.Collections.Generic;
using System.Text;
//Write a program that reads a number N and generates and prints all the permutations
//of the numbers [1 … N]. Example:
//n = 3 => {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
class Program
{
    static List<string> list = new List<string>();
    static StringBuilder builder = new StringBuilder();

    static void Main()
    {
        Console.Write("Enter number [1...N]: ");
        int num = int.Parse(Console.ReadLine());

        int[] myArray = new int[num];

        for (int i = 0; i < num; i++)
        {
            myArray[i] = i + 1;
        }

        Permutation(myArray, 0);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    private static void Permutation(int[] myArray, int position)
    {
        if (position == myArray.Length - 1)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                builder.Append(myArray[i]).Append(" ");
            }
            list.Add(builder.ToString());
            builder.Clear();
        }
        else
        {
            for (int i = position; i < myArray.Length; i++)
            {
                Swap(ref myArray[i], ref myArray[position]);
                Permutation(myArray, position + 1);
                Swap(ref myArray[i], ref myArray[position]);
            }
        }
    }

    private static void Swap(ref int a, ref int b)
    {
        if (a == b) 
        {
            return;
        }
        a ^= b;
        b ^= a;
        a ^= b;
    }
}
