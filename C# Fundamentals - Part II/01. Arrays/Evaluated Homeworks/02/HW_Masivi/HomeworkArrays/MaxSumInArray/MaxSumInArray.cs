/* Write a program that reads two
 * integer numbers N and K and an array
 * of N elements from the console. Find
 * in the array those K elements that have maximal sum.
 */
using System;

class MaxSumInArray
{
    static void Main()
    {
        Console.Write("Please enter N: ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Please enter K: ");
        int K = int.Parse(Console.ReadLine());
        int[] SequenceArray = new int[N];
        for (int i = 0; i < SequenceArray.Length; i++)
        {
            Console.Write("Please enter element: " + i + " : ");
            SequenceArray[i] = int.Parse(Console.ReadLine());
        }

        string BestSequence = "";
        int Sum = 0;
        int BestSum = int.MinValue;
        int ArrayLen = SequenceArray.Length;
        for (int i = 0; i < ArrayLen; i++)
        {
            string CurrentSequence = "";
            if (i + K > ArrayLen)
            {
                break;
            }
            for (int j = i; j < i + K; j++)
            {
                Sum = Sum + SequenceArray[j];
                CurrentSequence = CurrentSequence + ' ' + SequenceArray[j];
            }
            if (Sum > BestSum)
            {
                BestSequence = CurrentSequence;
                BestSum = Sum;
            }
            Sum = 0;
        }
        Console.WriteLine("The {0} elements of the array with highest sum are: {1}", K, BestSequence);
        Console.WriteLine("Their total sum is: " + BestSum);
    }
}

