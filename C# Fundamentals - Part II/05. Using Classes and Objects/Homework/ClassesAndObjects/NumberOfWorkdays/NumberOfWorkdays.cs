namespace NumberOfWorkdays
{
    using System;

    public class NumberOfWorkdays
    {
        protected static DateTime[] holidays =
        {
            new DateTime(2013,1,1), new DateTime(2013,3,3), new DateTime(2013,5,1), 
            new DateTime(2013,5,3), new DateTime(2013,5,4), new DateTime(2013,5,5), 
            new DateTime(2013,5,6), new DateTime(2013,9,6), new DateTime(2013,9,22), 
            new DateTime(2013,12,24), new DateTime(2013,12,25), new DateTime(2013,12,26)
        };

        /// <summary>
        /// Write a method that calculates the number of workdays between today and given date, passed as parameter. 
        /// Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
        /// </summary>
        public static void Main(string[] args)
        {
            DateTime day = new DateTime(2013, 5, 24);

            Console.WriteLine("Today: " + DateTime.Today.ToString("dd.MM.yyyy"));
            Console.WriteLine("Date: " + day.ToString("dd.MM.yyyy"));
            Console.WriteLine("Workdays in the period: " + GetWorkdays(day));
        }

        public static int GetWorkdays(DateTime day)
        {
            int days = (day - DateTime.Today.Date).Days;
            int differenceInDays = day.DayOfWeek - DateTime.Today.DayOfWeek;
            int clearWorkdays = 5 * (days - differenceInDays) / 7;
            int extraWeekends = 0;
            int holidaysDuringPeriod = 0;

            for (DayOfWeek i = DateTime.Today.DayOfWeek; i <= day.DayOfWeek; i++)
            {
                if ((i == DayOfWeek.Saturday) || (i == DayOfWeek.Sunday)) extraWeekends++;
            }

            foreach (DateTime item in holidays)
            {
                if ((item > DateTime.Today) && (item < day)) holidaysDuringPeriod++;
            }

            int workdays = clearWorkdays + differenceInDays - extraWeekends - holidaysDuringPeriod;

            return workdays;
        }
    }
}
