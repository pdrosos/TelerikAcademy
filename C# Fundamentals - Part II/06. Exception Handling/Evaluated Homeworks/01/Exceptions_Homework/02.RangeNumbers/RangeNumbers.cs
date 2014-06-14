
// Condition: Write a method ReadNumber(int start, int end) that enters an integer number in given range
//            [ start...end]. If an invalid number or non-number text is entered, the method should trow
//            an exception. Using this method write a program that enters 10 numbers:
//            1<a1<......<a10<100.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class RangeNumbers
{
    static void ReadNumber(int start, int end)
    {
        // loop to enter 10 numbers
        for (int i = 0; i < 10; i++)
        {
            // enter number in string format
            Console.Write("Enter integer number: ");
            string strNum = Console.ReadLine();

            // convert to integer and check if the number belong to given range
            // if not appropriate exception is executed
            try
            {
                int num = int.Parse(strNum);

                if (num <= start || num >= end)
                {
                    ArgumentOutOfRangeException aor = new ArgumentOutOfRangeException();
                    Console.Error.WriteLine(aor.Message + "\nThe range of numbers should be between 1 and 100.");
                }
            }
            catch (FormatException fe)
            {
                Console.Error.WriteLine(fe.Message + "\nYou have to enter valid number.");
            }
        }

    }

    static void Main(string[] args)
    {
        // call method and specified its range
        ReadNumber(1, 100);
    }
}

