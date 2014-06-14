//Write a program that prints to the console which day of the week is today. Use System.DateTime.


using System;

class PrintDate
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Today is: {0} {1}", DateTime.Today.DayOfWeek, DateTime.Now);
        }
    }
