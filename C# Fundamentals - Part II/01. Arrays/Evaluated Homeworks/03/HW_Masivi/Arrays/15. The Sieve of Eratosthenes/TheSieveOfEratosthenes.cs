using System;
using System.Collections.Generic;

class TheSieveOfEratosthenes
{
    static void Main()
    {
        //Write a program that finds all prime numbers in the range [1...10 000 000]. 
        //Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

        int n = 10000;

        int[] primes = new int[n];
        for (int i = 2; i < n; i++)
        {
            primes[i] = 1;
        }

        primes[0] = 0;
        primes[1] = 0;
        for (int i = 2; i < n; i++)
        {
            if (primes[i] == 1)
            {
                for (int j = 2; i * j < n; j++)
                {
                    primes[j * i] = 0;
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (primes[i] == 1)
            {
                Console.Write("{0} ", i);
            }
        }
        Console.WriteLine();
    }
}
