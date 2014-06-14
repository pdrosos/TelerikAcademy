/*Write a program that reads two numbers N and K 
 * and generates all the combinations of K distinct elements 
 * from the set [1..N]. Example:
 * 	N = 5, K = 2 > {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
 */
using System;

class DistinctVariation
{
    static int[] Result;
    static int K;
    static int N;

    static void Main()
    {
        Console.Write("Enter number of elements for combinations: ");
        N = int.Parse(Console.ReadLine());
        Console.Write("Enter lenght of combination: ");
        K = int.Parse(Console.ReadLine());
        Result = new int[K];
        DistinctVariations(0, 1);
    }

    static void DistinctVariations(int index, int startValue)
    {
        if (index == K)
        {
            for (int i = 0; i < K; i++)
            {
                Console.Write("{0,3}", Result[i]);
            }
            Console.WriteLine();
            return;
        }
        for (int i = startValue; i <= N; i++)
        {
            Result[index] = i;
            DistinctVariations(index + 1, i + 1);
        }
    }
}