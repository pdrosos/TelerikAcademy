namespace PrimeNumbersSieveOfEratosthenes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PrimeNumbersSieveOfEratosthenes
    {
        /// <summary>
        /// Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm.
        /// </summary>
        public static void Main(string[] args)
        {
            uint maxNumber = 10000000;

            List<int> primeNumbers = GetPrimeNumbersSieveOfEratosthenes(maxNumber);

            foreach (int primeNumber in primeNumbers)
            {
                Console.Write(primeNumber + " ");
            }

            Console.WriteLine("Prime Numbers Count = " + primeNumbers.Count);
        }

        public static List<int> GetPrimeNumbersSieveOfEratosthenes(uint maxNumber)
        {
            BitArray primeNumbers = new BitArray((int)maxNumber, true);

            int currentNumber = 1;
            int currentNumberSquare = 1;

            while (currentNumberSquare <= maxNumber)
            {
                currentNumber++;

                while (!primeNumbers[currentNumber])
                {
                    currentNumber++;
                }

                currentNumberSquare = currentNumber * currentNumber;

                for (int i = currentNumberSquare; i < maxNumber; i += currentNumber)
                {
                    if (i > 0)
                    {
                        primeNumbers[i] = false;
                    }
                }
            }

            List<int> primeNumbersList = new List<int>();

            for (int i = 2; i < maxNumber; i++)
            {
                if (primeNumbers[i])
                {
                    primeNumbersList.Add(i);
                }
            }

            return primeNumbersList;
        }
    }
}
