//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

using System;
using System.Collections.Generic;

class CalcTwoDates
{
    static void Main()
    {
        Console.Write("Enter the first date: ");
        string first = Console.ReadLine();
        Console.Write("Enter the second date: ");
        string second = Console.ReadLine();
        DateTime dateOne = Convert.ToDateTime(first);
        DateTime dateTwo = Convert.ToDateTime(second);
        TimeSpan span = dateTwo.Subtract(dateOne);
        Console.WriteLine("Distance: {0}", span.Days);

    }
}
