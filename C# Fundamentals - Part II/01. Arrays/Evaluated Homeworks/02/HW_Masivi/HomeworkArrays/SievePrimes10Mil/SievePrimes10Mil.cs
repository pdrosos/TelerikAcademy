/*Write a program that finds all prime numbers in the range [1...10 000 000]. 
 * Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
 */
using System;

class SievePrimes10Mil
{
    static void Main()
    {
        bool[] Sequence = new bool[10000000];
        for (int i = 2; i < Math.Sqrt(Sequence.Length); i++)
        {
            if (Sequence[i] == false)
            {
                for (int j = i * i; j < Sequence.Length; j = j + i)
                {
                    Sequence[j] = true;
                }
            }
        }
        for (int i = 2; i < Sequence.Length; i++)
        {
            if (Sequence[i] == false)
            {
                Console.Write(i + " ");
            }
        }
    }
}