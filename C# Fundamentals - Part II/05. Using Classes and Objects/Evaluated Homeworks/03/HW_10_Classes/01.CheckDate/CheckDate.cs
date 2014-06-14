//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;


class CheckDate
    {
        static void Main()
        {
            Console.WriteLine("Please, enter a year: ");
            int year = int.Parse(Console.ReadLine());

            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine("The year {0} is Leap!", year);
            }
            else
            {
                Console.WriteLine("The year {0} is NOT Leap!", year);
            }
        }
    }
