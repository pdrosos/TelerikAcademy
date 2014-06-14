///07.Using delegates write a class Timer that has can execute certain method at each t seconds.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringExtensionMethod
{
    //Delegete
    public delegate void TimerDelegate();

    
    public class Time
    {
        //Print the current time
        public static void ShowTime()
        {
            Console.WriteLine("Hello, the time is {0}",DateTime.Now.ToLongTimeString());
           
        }
        //Print day of week
        public static void ShowDayOfWeek()
        {
            Console.WriteLine("Today is {0} !", DateTime.Now.DayOfWeek);

        }
    }
}
