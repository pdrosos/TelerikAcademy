namespace NumberOccurencesInArray
{
    using System;

    public class NumberOccurencesInArray
    {
        /// <summary>
        /// Write a method that counts how many times given number appears in given array. 
        /// Write a test program to check if the method is working correctly.
        /// </summary>
        public static void Main(string[] args)
        {
            int[] arrayOne = { 1, 2, 3, 4, 5, 6, 7 };
            int[] arrayTwo = { -1, -5, 5, 5, 4 };
            int[] arrayThree = { 0, 0, 0, 0, 0, 0, 0, 0 };

            if (OccurencesInArray(arrayOne, 3) == 1)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }

            if (OccurencesInArray(arrayTwo, 5) == 2)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }

            if (OccurencesInArray(arrayThree, 0) == 8)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }

        public static int OccurencesInArray(int[] array, int number)
        {
            int occurencesCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    occurencesCount++;
                }
            }

            return occurencesCount;
        }
    }
}
