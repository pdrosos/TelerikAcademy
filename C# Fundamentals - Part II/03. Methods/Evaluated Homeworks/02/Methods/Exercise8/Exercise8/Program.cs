using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise8
{
    /* 8. Write a method that adds two positive integer numbers represented
     *    as arrays of digits (each array element arr[i] contains a digit; 
     *    the last digit is kept in arr[0]). Each of the numbers that will 
     *    be added could have up to 10 000 digits.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int temp = 7;
            int [] number1 = new int [4];
            int [] number2 = new int [3];
            for (int i = 0; i < number1.Length; i++)
			{
                temp++;
			    number1[i] = temp;
                if (temp == 9)
	            {
            		 temp = 0;
	            }
			}
            temp = 3;
            for (int i = 0; i < number2.Length; i++)
			{
                temp++;
			    number2[i] = temp;
                if (temp == 9)
	            {
            		 temp = 0;
	            }
			}
            Console.WriteLine("Array 1 :");
            for (int i = 0; i < number1.Length; i++)
			{
                if(i % 20 == 0)
	            {
            		 Console.WriteLine();
	            }
                Console.Write("{0} ", number1[i]);
			}
            Console.WriteLine("\n\n + \n");
            Console.WriteLine("Array 2 :");
            for (int i = 0; i < number2.Length; i++)
			{
                if(i % 20 == 0)
	            {
            		 Console.WriteLine();
	            }
                Console.Write("{0} ", number2[i]);
			}
            Console.WriteLine("\n\nSum is:");
            number1 = Sum(number1, number2);
            temp = 0;
            for (int i = number1.Length - 1; i > 0; i--)
            {
                if (number1[i] != 0)
                {
                    temp = i;
                    break;
                }
            }
            for (int i = 0; i <= number1.Length - 1/*temp + 1 */; i++)
			{
                if(i % 20 == 0)
	            {
            		 Console.WriteLine();
	            }
                Console.Write("{0} ", number1[i]);
			}
            Console.WriteLine();
        }
        static int [] Sum (int [] num1 , int [] num2)
        {
            int digit1 = 0, digit2;
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
			{
                if (num1.Length - 1 >= i && num2.Length - 1 >= i)
                {
			        digit1 = num1[i] + num2[i] + digit1;
			        digit2 = digit1 % 10;
                    digit1 /= 10;
                    array[i] = digit2;
                }
                if(num1.Length - 1 < i && num2.Length - 1 < i)
                {
                    break;
                }
                if (num1.Length - 1 >= i)
                {
                    digit1 = num1[i] + digit1;
                    digit2 = digit1 % 10;
                    digit1 /= 10;
                    array[i] = digit2;
                }
                if (num2.Length - 1 >= i)
                {
                    digit1 = num2[i] + digit1;
                    digit2 = digit1 % 10;
                    digit1 /= 10;
                    array[i] = digit2;
                }
            }
            return array;
        }
    }
}
