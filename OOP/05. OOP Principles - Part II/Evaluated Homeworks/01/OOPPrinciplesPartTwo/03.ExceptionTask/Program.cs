/*Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. It 
 * should hold error message and a range definition [start … end]. Write a sample application that demonstrates the 
 * InvalidRangeException<int> and InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates 
 * in the range [1.1.1980 … 31.12.2013].*/

using System;

class Program
{
    static int ReadNumber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());
        if (number < start || number > end)
        {
            throw new InvalidRangeException<int>("This number is out of range", start, end);
        }
        else
        {
            return number;
        }
    }

    static DateTime ReadDate(DateTime start, DateTime end)
    {
        DateTime date = DateTime.Parse(Console.ReadLine());
        if (date < start || date > end)
        {
            throw new InvalidRangeException<DateTime>("This date is out of range", start, end);
        }
        else
        {
            return date;
        }
    }

    static void Main()
    {
        try
        {
            Console.WriteLine("Enter numbers between [1..100]: ");
            for (int i = 0; i < 5; i++)
            {
                int number = ReadNumber(1, 100);
                Console.WriteLine("Your number is correct!");
            }
        }
        catch (InvalidRangeException<int> ex)
        {
            Console.WriteLine("{0} [{1}..{2}]!", ex.Message, ex.Start, ex.End);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            Console.WriteLine("\nEnter date (day/month/year) between [1.1.1980..31.12.2013]");
            for (int i = 0; i < 5; i++)
            {
                DateTime date = ReadDate(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                Console.WriteLine("Your date is correct!");
            }
        }
        catch (InvalidRangeException<DateTime> ex)
        {
            Console.WriteLine("{0} [{1}..{2}]!", ex.Message, ex.Start.ToShortDateString(), ex.End.ToShortDateString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}