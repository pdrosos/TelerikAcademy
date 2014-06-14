using System;

class MultitaskProgram
{
    static void ReverseNumbers(int number)
    {
        int devidedNumber = number;
        int remainder = 0;
        while (devidedNumber != 0)
        {
            remainder = devidedNumber % 10;
            devidedNumber = devidedNumber / 10;
            Console.Write(remainder);
        }
    }
    static double AverageOfIntegers()
    {
        Console.WriteLine("Enter the numbers count:");
        double result;
        int count = int.Parse(Console.ReadLine());
        double sum = 0;
        double number;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Enter number:");
            number = double.Parse(Console.ReadLine());
            sum = sum + number;
        }
        result = sum/count;

        return result;
    }
    static void EquationAxPlusB()
    {
        Console.WriteLine("Enter A:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter B:");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("x={0}",(-b)/a);
    }

    static void Main()
    {
        Console.WriteLine("Please choose task:");
        Console.WriteLine("1.Reverse digits of number.");
        Console.WriteLine("2.Calculate average of sequence of integers.");
        Console.WriteLine("3.Solves a linear equation a * x + b = 0");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter number");
                int number = int.Parse(Console.ReadLine());
                ReverseNumbers(number);
                break;
            case 2:
                Console.WriteLine( AverageOfIntegers() );
                break;
            case 3:
                EquationAxPlusB();
                break;
            default:
                break;
        }

    }
}
