/*Write a program that reads two numbers N and K 
 * and generates all the variations of K elements from the set [1..N]. Example:
 * 	N = 3, K = 2 > {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
 */
using System;

class AllVariations
{
    static int[] Result;
    static int K;
    static int N;

    static void Main()
    {
        Console.Write("Enter number of elements for variations: ");
        N = int.Parse(Console.ReadLine());
        Console.Write("Enter lenght of variation: ");
        K = int.Parse(Console.ReadLine());
        Result = new int[K];
        Variation(0);
    }

    static void Variation(int index)
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
        for (int i = 0; i < N; i++)
        {
            Result[index] = i + 1;
            Variation(index + 1);
        }
    }
}