/*01.Write a program that reads an integer number and calculates and prints its square root. 
 * If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". 
 * Use try-catch-finally.*/


using System;


class CalculateSquareRoot
{
    static double SquareRoot(string input)
    {
        int number = int.Parse(input);

        if(number < 0)
        {
            throw new ArgumentOutOfRangeException("Negative number!");
        }

        return Math.Sqrt(number);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        string number = Console.ReadLine();
        try
        {
            double result = SquareRoot(number);
            Console.WriteLine("Result: {0}", result);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Too big number!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Negative number!");
        }
        catch (FormatException)
        {
            Console.WriteLine("The number {0} was not in a correct format!", number);
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}

