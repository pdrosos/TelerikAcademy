using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    class Testing
    {
        static void Main(string[] args)
        {
            //Test with int.
            InvalidRangeException<int> testIntExeption =
                new InvalidRangeException<int>("Your number is out of range!", 1, 100);

            Console.WriteLine("Enter number  in the range [1..100]");
            int number = int.Parse(Console.ReadLine());
            if (number < testIntExeption.Start || number > testIntExeption.End)
            {
                throw testIntExeption;
            }
            else
            {
                Console.WriteLine("Number validated");
            }

            //Test with DateTime.
            InvalidRangeException<DateTime> testDateTimeExeption = new InvalidRangeException<DateTime>
                ("Your number is out of range!", DateTime.Parse("1/1/1980"), DateTime.Parse("1/1/2013"));

            Console.WriteLine("Enter date between 1.1.1980 and 1.1.2013 :");
            DateTime date = DateTime.Parse(Console.ReadLine());
            if (date.CompareTo(testDateTimeExeption.Start) == -1 || date.CompareTo(testDateTimeExeption.End) == 1)
            {
                throw testDateTimeExeption;
            }
            else
            {
                Console.WriteLine("Date validated");
            }
        }
    }
}
