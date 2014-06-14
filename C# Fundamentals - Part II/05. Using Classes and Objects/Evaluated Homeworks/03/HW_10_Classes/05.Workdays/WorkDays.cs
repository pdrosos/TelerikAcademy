//Write a method that calculates the number of workdays between today and given date, passed as parameter. Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

using System;

    class WorkDays
    {
        public static void CalcHolidays(DateTime date, out int days, out int holidays)
        {
            DateTime dateToday = DateTime.Today;
            int currentYear = DateTime.Today.Year;
            holidays = 0;
            days = 0;

            //array with holidays
            DateTime[] hdays =
            {
                new DateTime(currentYear, 1, 1),
                new DateTime(currentYear, 3, 3),
                new DateTime(currentYear, 5, 1),
                new DateTime(currentYear, 5, 2),
                new DateTime(currentYear, 5, 6),
                new DateTime(currentYear, 5, 24),
                new DateTime(currentYear, 9, 22),
                new DateTime(currentYear, 12, 24),
                new DateTime(currentYear, 12, 25),
                new DateTime(currentYear, 12, 26),
                new DateTime(currentYear, 12, 31)
             };

            while (dateToday <= date)
            {
                if (dateToday.DayOfWeek == DayOfWeek.Saturday || dateToday.DayOfWeek == DayOfWeek.Sunday)
                {
                    holidays++;
                }
                else
                {
                    foreach (var element in hdays)
                    {
                        if (element.DayOfYear == dateToday.DayOfYear)
                        {
                            holidays++;
                        }
                    }
                }
                days++;
                dateToday = dateToday.AddDays(1);
            }
        }

        static void Main()
        {
            DateTime date2;
            int days = 0;
            int holidays = 0;

            do
            {
                Console.WriteLine("Please, enter the final date in the following format: dd mm yyyy: ");
                date2 = DateTime.Parse(Console.ReadLine());
            } while (date2 < DateTime.Today);

            CalcHolidays(date2, out days, out holidays);

            Console.WriteLine("{0} days in the time interval", days);
            Console.WriteLine("{0} holidays in the time interval", holidays);
            Console.WriteLine("{0} workdays in the time interval", days - holidays);
        }
    }
