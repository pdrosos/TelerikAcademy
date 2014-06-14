namespace DateTimeWithBgCulture
{
    using System;
    using System.Threading;

    public class DateTimeWithBgCulture
    {
        /// <summary>
        /// Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time 
        /// after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
        /// </summary>
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("bg-BG");
            
            DateTime dateTime = DateTime.Parse("12.03.2013 13:34:27");
            Console.WriteLine(dateTime.ToString("dd.MM.yyyy HH:mm:ss"));

            DateTime futureDateTime = dateTime.AddHours(6).AddMinutes(30);
            Console.WriteLine(futureDateTime.ToString("dddd dd.MM.yyyy HH:mm:ss"));
        }
    }
}
