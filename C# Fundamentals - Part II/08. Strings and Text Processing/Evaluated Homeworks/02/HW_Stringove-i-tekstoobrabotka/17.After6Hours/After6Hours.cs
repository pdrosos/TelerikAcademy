//Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
//and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class After6Hours
{
    static void Main()
    {
        //Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        Console.Write("Enter a date(day.month.year hour:minute:second ): ");
        DateTime date = Convert.ToDateTime(Console.ReadLine());
        DateTime span = date.AddMinutes(390);
        CultureInfo bulgarian = new CultureInfo("bg-BG");
        string dayName = span.ToString("dddd", bulgarian);
        Console.Write(span + " ");
        Console.WriteLine(dayName);
    }
}

