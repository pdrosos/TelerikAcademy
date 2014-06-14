using System;

class RangeNumbers
{
    /// <summary>
    /// Задачата може да се тества по два начина:
    /// 1. Само с натискане на enter - след всяко натискане се генерита число докато не завърши или не хвърли съответна грешка.
    /// 2. Може и да се въдежда текст/число - тогава генерираното число е въведеното число/тект. */
    /// </summary>
    public static int start = 2;

    static bool TenNumbersExceptionCheck(int end, int endFirst)
    {
        // if we hit enter (an empty string) the generator will generate numbers 1< a1 < a2 < ... < a10 < 100
        // if we enter a value the program will use the entered value, not the random number
        // If the number is more than 100 - we will have ArgumentOutOfRangeException

        int counter = 10;
        int temp = 0;
        int random = 1;
        while (counter > 0)
        {
            Console.Write("Please enter a input or hit enter (automatic generation): ");
            string s = Console.ReadLine();
            Random rnd = new Random();
            counter--;
            try
            {
                if (s == String.Empty)
                {
                    random = rnd.Next(start, endFirst);
                    random = random + temp;
                    Console.WriteLine("The current number is {0}", random);
                }
                else
                {
                    random = int.Parse(s);
                    Console.WriteLine("The current number is {0}", random);
                }
                if (random + counter > 100 && random + counter < 109)
                {
                    Console.WriteLine("The generation of ten numbers is not possible, please try again");
                    return false;
                }
                if (temp >= random)
                {
                    throw new System.ArgumentOutOfRangeException("The current number is smaller than the previous. Its not allowed");
                }
                if (end < random)
                {
                    throw new System.ArgumentOutOfRangeException("The number is out of the range (2,99)");
                }
                temp = random;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
            catch (OverflowException)
            {
                throw;
            }
            catch (FormatException)
            {
                throw new System.FormatException("The entered input can not be parsed to int");
            }
        }
        return true;
    }

    static void Main()
    {
        int endFirstNumber = 20;
        int end = 99;
        bool randomGeneration = false;

        randomGeneration = TenNumbersExceptionCheck(end, endFirstNumber);
        while (randomGeneration == false)
        {
            randomGeneration = TenNumbersExceptionCheck(end, endFirstNumber);
        }
        if (randomGeneration == true)
        {
            Console.WriteLine("The program finished with no exceptions");
        }
    }
}

