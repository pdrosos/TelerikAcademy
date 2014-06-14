namespace CompareArraysElements
{
    using System;
    
    public class CompareArraysElements
    {
        /// <summary>
        /// Write a program that reads two arrays from the console and compares them element by element.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter arrays length:");
            int arrayLength = int.Parse(Console.ReadLine());

            int[] arrayOne = new int[arrayLength];
            int[] arrayTwo = new int[arrayLength];

            Console.WriteLine("Please, enter array One elements (integers):");
            for (int i = 0; i < arrayLength; i++)
            {
                arrayOne[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Please, enter array Two elements (integers):");
            for (int i = 0; i < arrayLength; i++)
            {
                arrayTwo[i] = int.Parse(Console.ReadLine());
            }

            string sign = string.Empty;
            for (int i = 0; i < arrayLength; i++)
            {
                if (arrayOne[i] == arrayTwo[i])
                {
                    sign = " = ";
                }
                else
                {
                    sign = " != ";
                }

                Console.WriteLine(arrayOne[i] + sign + arrayTwo[i]);
            }
        }
    }
}
