
// Condition: 1. Write a program that reads an integer number and calculates and prints its square root.
//               If the numbe is invalid or negative, print "Invalid number". In all cases finally print "Good Bye".
//               Use try-catch-finally.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Sqrt_Exception
{
    static void Main(string[] args)
    {
        // input number like string
        Console.Write("Enter integer number: ");
        string num = Console.ReadLine();

        // convert into integer and go througn all possible exceptions
        // if necessary
        try
        {
            int n = Int32.Parse(num);
            if (n < 0)
            {
                ArithmeticException ae = new ArithmeticException();
                Console.Error.WriteLine("Invalid number!" + ae.Message);

            }
            else
            {
                double sqtr = Math.Sqrt((double)Int32.Parse(num));
                Console.WriteLine("The square root of {0} is: {1:n2}", num, sqtr);
            }
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("Invalid number!" + fe.Message);
        }
        catch (OverflowException)
        {
            Console.Error.WriteLine("Your number is not in the range of integers.");
        }
        finally
        {
            Console.WriteLine("Goob Bye!");
        }

    }
}
