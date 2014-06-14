using System;

namespace _2.GetMax
{
    class GetMax
    {
        static int MaxOfTwo(int number1, int number2)
        {
            if (number1 > number2)
            {
                return number1;
            }
            else
            {
                return number2;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter three numbers: ");
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            number2 = MaxOfTwo(number1,number2);
            number2 = MaxOfTwo(number2, number3);

            Console.WriteLine("Max number is " + number2);
        }
    }
}
