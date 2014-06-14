using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise10
{
    /* 10. Write a program to calculate n! for each n in the range [1..100]. 
     * Hint: Implement first a method that multiplies a number represented 
     * as array of digits by given integer number. 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            bool null_digit = false;
            int[] calculated_array = new int[10];
            do {
                Console.WriteLine("Please enter num in range [0 - 100]");
                num = Convert.ToInt32(Console.ReadLine());
            } while (num < 0 || num > 100);
            calculated_array = Facotorial(num);
            for (int i = calculated_array.Length - 1; i >= 0; i--)
            {
                if (calculated_array[i] != 0)
                {
                    null_digit = true;
                }
                if (null_digit == true )
                {
                    Console.Write("{0}", calculated_array[i]);  
                }
                
            }
            Console.WriteLine();
        }
        static int[] Facotorial(int number)
        {
            int[] array = new int[10];
            int carrage;
            int temp;
            temp = number;
            array[0] = temp % 10;
            temp -= array[0];
            temp /= 10;
            array[1] = temp % 10;
            temp -= array[1];
            temp /= 10;
            array[2] = temp % 10;
            for (int i = 1; i < number; i++)
            {
                carrage = 0;
                array[0] *= i;
                if (array[0] > 9)
                { 
                    carrage = array[0];
                    array[0] = carrage % 10;
                    carrage -= array[0];
                    carrage /= 10;
                }
                array[1] *= i;
                array[1] += carrage;
                carrage = 0;
                if (array[1] > 9)
                {
                    carrage = array[1];
                    array[1] = carrage % 10;
                    carrage -= array[1];
                    carrage /= 10;
                }
                array[2] *= i;
                array[2] += carrage;
                carrage = 0;
                if (array[2] > 9)
                {
                    carrage = array[2];
                    array[2] = carrage % 10;
                    carrage -= array[2];
                    carrage /= 10;
                }
                array[3] *= i;
                array[3] += carrage;
                carrage = 0;
                if (array[3] > 9)
                {
                    carrage = array[3];
                    array[3] = carrage % 10;
                    carrage -= array[3];
                    carrage /= 10;
                }
                array[4] *= i;
                array[4] += carrage;
                carrage = 0;
                if (array[4] > 9)
                {
                    carrage = array[4];
                    array[4] = carrage % 10;
                    carrage -= array[4];
                    carrage /= 10;
                }
                array[5] *= i;
                array[5] += carrage;
                carrage = 0;
                if (array[5] > 9)
                {
                    carrage = array[5];
                    array[5] = carrage % 10;
                    carrage -= array[5];
                    carrage /= 10;
                }
                array[6] *= i;
                array[6] += carrage;
                carrage = 0;
                if (array[6] > 9)
                {
                    carrage = array[6];
                    array[6] = carrage % 10;
                    carrage -= array[6];
                    carrage /= 10;
                }
                array[7] *= i;
                array[7] += carrage;
                carrage = 0;
                if (array[7] > 9)
                {
                    carrage = array[7];
                    array[7] = carrage % 10;
                    carrage -= array[7];
                    carrage /= 10;
                }
                array[8] *= i;
                array[8] += carrage;
                carrage = 0;
                if (array[8] > 9)
                {
                    carrage = array[8];
                    array[8] = carrage % 10;
                    carrage -= array[8];
                    carrage /= 10;
                }
                array[9] *= i;
                array[9] += carrage;
                carrage = 0;
                if (array[9] > 9)
                {
                    carrage = array[9];
                    array[9] = carrage % 10;
                    carrage -= array[9];
                    carrage /= 10;
                }
            }
            return array;
        }
    }
}
