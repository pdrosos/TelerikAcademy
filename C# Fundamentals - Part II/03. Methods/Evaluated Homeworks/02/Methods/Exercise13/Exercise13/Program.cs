using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise13
{
    /* 14. Write a program that can solve these tasks:
           - Reverses the digits of a number
           - Calculates the average of a sequence of integers
           - Solves a linear equation a * x + b = 0
		   Create appropriate methods.
		   Provide a simple text-based menu for the user to choose which task to solve.
		   Validate the input data:
           - The decimal number should be non-negative
           - The sequence should not be empty
           - a should not be equal to 0
     */
    class Program
    {
        static void Main(string[] args)
        {
            int Reverse;
            int Result;
            int choise;
            int[] array = new int[10];
            do
            {
                Console.WriteLine("Plase select task: ");
                Console.WriteLine();
                Console.WriteLine(" 1 - Reverse the digit ");
                Console.WriteLine(" 2 - average of a sequence of integers ");
                Console.WriteLine(" 3 - Solves a linear equation a * x + b = 0");
                choise = int.Parse(Console.ReadLine());
            } while (choise < 1 || choise > 3);
            switch (choise)
            { 
                case 1:
                    Console.WriteLine("Please enter a number for reverse : ");
                    Reverse = int.Parse(Console.ReadLine());
                    Result = Rotate_digit(Reverse);
                    Console.WriteLine("Result is : "+ Result);
                    break;
                case 2:
                    Console.WriteLine("Plase enter numbers in array :");
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = int.Parse(Console.ReadLine());
                    }
                    Avarage(array);
                    break;
                case 3:
                    Equation();
                    break;
            }
        }
        static int Rotate_digit(int num)
        {
            int[] array_digit = new int[10];
            int index = 0;
            int digit;
            int digit_size = 10;
            do
            {
                array_digit[index] = num % 10;
                num /= 10;
                index++;
            } while (num > 0);
            for (int i = 9; i >= 0; i--)
            {
                if (array_digit[i] != 0)
                {
                    index = i;
                    break;
                }
            }
            digit = array_digit[index];
            for (int i = index; i > 0; i--)
            {
                array_digit[i] = array_digit[i - 1];
            }
            array_digit[0] = digit;
            for (int i = 1; i < index + 1; i++)
            {
                digit += (array_digit[i] * digit_size);
                digit_size *= 10;
            }
            return digit;
        }
        static void Avarage(int [] array)
        {
            int Sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Sum += array[i];
            }
            Sum /= array.Length;
            Console.WriteLine("Average value is : " + Sum);
        }
        static void Equation()
        {
            int a, b;
            Console.WriteLine("Please enter coef to equation: "); 
            do{
                a = int.Parse(Console.ReadLine());
            } while(a < 0);

            do{
                b = int.Parse(Console.ReadLine());
            } while (b <= 0);
            Console.WriteLine("IN equation ax + b = 0");
            Console.WriteLine("x has a value : {0:F2}", (float)(-b)/(float)(a) );
        }
    }
}
