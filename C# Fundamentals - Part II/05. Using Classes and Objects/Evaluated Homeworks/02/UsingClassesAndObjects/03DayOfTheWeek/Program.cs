using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//3. Write a program that prints to the console which day of the week is today. Use System.DateTime.

namespace _03DayOfTheWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            Console.WriteLine("Today is {0}.", today.DayOfWeek); //print to the console which day of the week is today
        }
    }
}
