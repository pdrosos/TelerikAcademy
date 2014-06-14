using System;

class FindElemWithMaxSum
{
    static void Main()
    {
        //Write a program that reads two integer numbers N and K and an array of N elements from the console. 
        //Find in the array those K elements that have maximal sum.

        Console.Write("N: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("K: ");
        int k = Convert.ToInt32(Console.ReadLine());

        if (k > n || k < 1)
        {
            Console.WriteLine("Error !");
            return;
        }
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}]: ", i);
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        Array.Sort(array);
        Console.Write("The elements with maximum sum are: ");
        for (int i = array.Length - 1, count = 0; count < k ; i--, count++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}