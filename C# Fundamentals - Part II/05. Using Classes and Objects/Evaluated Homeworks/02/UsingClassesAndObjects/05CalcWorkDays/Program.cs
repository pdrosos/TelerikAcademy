using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//5. Write a method that calculates the number of workdays between today and given date, passed as parameter. 
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

namespace _05CalcWorkDays
{
    class Program
    {
        static void Main(string[] args)
        {
            //in my program i am not starting the counting from today but from torrow because it wasn't written exactly in the exercise
            //and that is how i think it should be

            Console.WriteLine("Enter a date for which you want to check how much work days we have till this date");
            Console.Write("Enter bigger date than today in format year/month/day, End Date:  ");

            DateTime[] holidays = { new DateTime(2013, 9, 6), new DateTime(2013, 12, 31) }; //That's just some example dates to test the program
            DateTime[] workSaturdays = { new DateTime(2013, 8, 17) }; //That's just example dates to test the program

            DateTime enteredDate = DateTime.Parse(Console.ReadLine()); //read from the console the due date

            if (enteredDate.CompareTo(DateTime.Today) > 0) //checks if the entered date is after today
            {
                Console.Write("The work days between today and {0} are: ", enteredDate.ToString("d"));
                Console.WriteLine(CalcWorkDays(holidays, workSaturdays, enteredDate.Date)); //print the counted work days on the console
            }
            else
            {   //if the entered date is today or before today print to the console messege thata there isn't any work days between these dates.
                Console.WriteLine("The day you entered is today or before today so there isn't any work days between today and this date");
            }

        }

        static int CalcWorkDays(DateTime[] holidays, DateTime[] workSaturdays, DateTime givenDate)
        {
            int countDays = 0;
            DateTime current = DateTime.Today.Date;
            while ((current.CompareTo(givenDate)) != 0) // while current date is diffrent than entered date
            {
                current = current.AddDays(1);  //increase the date with one day 
                int dayOfWeek = (int)current.DayOfWeek;  //get which day of the week is the current date
                //if it is saturday and it is working saturday or check if today is diffrent than weekend and it's not a holiday
                //current day is not in the array with dates that are national holidays
                //if one of these 2 conditions is achieved then it's work day and increase with one countDays
                if ((dayOfWeek == 6 && workSaturdays.Contains(current)) || (dayOfWeek != 6 && dayOfWeek != 0 && !(holidays.Contains(current))))
                {
                    countDays++;
                }
            }

            return countDays; //return the number of day that are working days
        }

    }
}
