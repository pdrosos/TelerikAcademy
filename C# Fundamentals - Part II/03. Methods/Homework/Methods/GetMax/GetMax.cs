namespace GetMax
{
    using System;

    public class GetMax
    {
        /// <summary>
        /// Write a method GetMax() with two parameters that returns the bigger of two integers. 
        /// Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter three integer numbers:");
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            int maxNumber = Max(numberOne, Max(numberTwo, numberThree));

            Console.WriteLine("The maximal number of {0}, {1} and {2} is {3}.", numberOne, numberTwo, numberThree, maxNumber);
        }

        public static int Max(int numberOne, int numberTwo)
        {
            return Math.Max(numberOne, numberTwo);
        }
    }
}
