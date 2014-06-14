using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise7
{
    /* 7. Write a method that reverses the digits of given decimal number. Example: 256 -> 652
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a big integer number : ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Once rotated your number is : "+Rotate_digit(num));
        }
        static int Rotate_digit(int num)
        {
            int [] array_digit = new int[10];
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
                if(array_digit[i] != 0)
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
    }
}
