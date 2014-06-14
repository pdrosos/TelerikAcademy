using System;

class SquareRoot
{
    public static double Sqrt(string input)
    {
        double number = double.Parse(input);
        if (number < 0)
        {
            throw new System.ArgumentOutOfRangeException("Invalid number");
        }
        return Math.Sqrt(number);
    }

    static void Main()
    {
        Console.Write("Please enter a number: ");
        string resultStr = (Console.ReadLine());
        try
        {
            double result = Sqrt(resultStr);
            Console.WriteLine("The square root of the number is: {0:0.00}", Math.Sqrt(result));
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}

