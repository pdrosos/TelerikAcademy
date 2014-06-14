namespace IsLeapYear
{
    using System;

    public class IsLeapYear
    {
        /// <summary>
        /// Write a program that reads a year from the console and checks whether it is a leap. 
        /// Use DateTime.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter year:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}: {1}", year, DateTime.IsLeapYear(year) ? "leap" : "not leap");
        }
    }
}
