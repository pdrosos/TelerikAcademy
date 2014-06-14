namespace NumberOfDaysBetweenDates
{
    using System;
    using System.Globalization;
    
    public class NumberOfDaysBetweenDates
    {
        /// <summary>
        /// Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
        /// </summary>
        public static void Main(string[] args)
        {
            DateTime dateOne = DateTime.ParseExact("27.02.2006", "d.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime dateTwo = DateTime.ParseExact("3.03.2006", "d.MM.yyyy", CultureInfo.InvariantCulture);

            // the time interval between two dates is represented with TimeSpan struct
            TimeSpan timeSpan = dateTwo - dateOne;
            Console.WriteLine(timeSpan.TotalDays);
        }
    }
}
