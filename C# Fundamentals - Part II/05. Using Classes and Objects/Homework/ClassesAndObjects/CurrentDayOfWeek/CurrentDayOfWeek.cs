namespace CurrentDayOfWeek
{
    using System;

    class CurrentDayOfWeek
    {
        /// <summary>
        /// Write a program that prints to the console which day of the week is today. Use System.DateTime.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
        }
    }
}
