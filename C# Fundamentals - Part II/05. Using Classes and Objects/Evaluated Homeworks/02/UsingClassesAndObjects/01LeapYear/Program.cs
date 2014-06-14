using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//1. Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.


namespace _01LeapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter year that you want  to check if it is leap: ");
            int year =int.Parse(Console.ReadLine());

            if (DateTime.IsLeapYear(year)) //check if the year is leap the write on the console if it is or if it is not
            {
                Console.WriteLine("The year you entered is leap."); 
            }
            else
            {
                Console.WriteLine("The year you entered is not leap.");
            }
        }
    }
}
