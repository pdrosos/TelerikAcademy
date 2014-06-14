using System;

/* Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.*/

class IsYearLeap
{
    static void Main()
    {
        Console.WriteLine("Enter year: ");
        int year = int.Parse(Console.ReadLine());

        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("The year {0} is leap.", year);
        }
        else
        {
            Console.WriteLine("The year {0} is not leap.", year);
        }
    }
}

