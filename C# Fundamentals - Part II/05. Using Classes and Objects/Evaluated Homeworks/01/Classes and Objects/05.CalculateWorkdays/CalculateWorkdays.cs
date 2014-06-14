using System;

/* Write a method that calculates the number of workdays between today and given date, passed as parameter. 
 Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified 
 preliminary as array.*/

class CalculateWorkdays
{
    static void Workdays(DateTime now, DateTime final, DateTime[] holidays)
    {
        int lengthDays = (final - now).Days;
        int length = lengthDays;
        DateTime currentDate = new DateTime();

        for (int i = 0; i <= length; i++)
        {

            currentDate = now.AddDays(i);
            
            for (int days = 0; days < holidays.Length; days++)
            {
                int comparison = currentDate.CompareTo(holidays[days]);
                if (comparison == 0)
                {
                    lengthDays--;
                }
            }

            if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                lengthDays--;
            }
        }

        PrintResult(now, final, lengthDays);

    }
    static void PrintResult(DateTime now, DateTime final, int lengthDays)
    {
        Console.WriteLine("Today is: {0}", now);
        Console.WriteLine("Final Date is: {0}", final);
        Console.WriteLine("Working days: {0}", lengthDays);
    }
    static void Main(string[] args)
    {
        int currentYear = DateTime.Now.Year;
        DateTime[] holidays = new DateTime[] 
        {
            new DateTime(currentYear, 1, 1),
            new DateTime(currentYear, 3, 3),
            new DateTime(currentYear, 5, 1),
            new DateTime(currentYear, 5, 6),
            new DateTime(currentYear, 5, 24),
            new DateTime(currentYear, 9, 22),
            new DateTime(currentYear, 12, 24),
            new DateTime(currentYear, 12, 25),
            new DateTime(currentYear, 12, 26),
            new DateTime(currentYear, 12, 31),
        };

        DateTime now = DateTime.Today;
        Console.Write("Enter final date<YYYY-MM-DD>: ");
        DateTime final = DateTime.Parse(Console.ReadLine());
        Workdays(now, final, holidays);

    }


}

