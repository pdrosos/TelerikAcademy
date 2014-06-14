namespace CompareCharArraysElements
{
    using System;

    public class CompareCharArraysElements
    {
        /// <summary>
        /// Write a program that compares two char arrays lexicographically (letter by letter)
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter arrays length:");
            int arrayLength = int.Parse(Console.ReadLine());

            char[] arrayOne = new char[arrayLength];
            char[] arrayTwo = new char[arrayLength];

            Console.WriteLine("Please, enter array One elements (characters):");
            for (int i = 0; i < arrayLength; i++)
            {
                arrayOne[i] = Console.ReadLine()[0];
            }

            Console.WriteLine("Please, enter array Two elements (characters):");
            for (int i = 0; i < arrayLength; i++)
            {
                arrayTwo[i] = Console.ReadLine()[0];
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
