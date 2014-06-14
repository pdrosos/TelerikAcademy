/*02.Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
 * If an invalid number or non-number text is entered, the method should throw an exception.
 * Using this method write a program that enters 10 numbers:
			a1, a2, … a10, such that 1 < a1 < … < a10 < 100*/


using System;


class readNumberMethod
{
    static int ReadNumber(int start, int end)
    {
        try
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException();
            }

            return number;
        }
        catch (OverflowException oe)
        {
            throw new OverflowException("Too big number!");
        }
        catch (FormatException fe)
        {
            throw new FormatException("The number was not in a correct format!");
        }
    }
    static void Main(string[] args)
    {
        int count = 0;
        int start = 2;
        int end = 99;
        int currentNumber = 0;

        while (count < 10)
        {
            try
            {
                currentNumber = ReadNumber(start, end);
                count++;
                start = currentNumber + 1;
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ArgumentOutOfRangeException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

