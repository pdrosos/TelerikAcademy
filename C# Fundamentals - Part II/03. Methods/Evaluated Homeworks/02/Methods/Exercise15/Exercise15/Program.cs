using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise15
{
    /* 15. Modify your last program and try to make it work for any number type, 
     *     not just integer (e.g. decimal, float, byte, etc.). Use generic method 
     *     (read in Internet about generic methods in C#).
     */
    class Program
    {
        static void Main(string[] args)
        {
            byte choise;
            int[] NumArray = new int[10];
            Console.WriteLine("Please enter numbers in array :");
            for (int i = 0; i < NumArray.Length; i++)
            {
                NumArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            do
            {
                Console.WriteLine("Select operation :");
                Console.WriteLine();
                Console.WriteLine(" 1 - minimum value in array");
                Console.WriteLine(" 2 - maximum value in array");
                Console.WriteLine(" 3 - average value of the array");
                Console.WriteLine(" 4 - sum value of the array");

                choise = byte.Parse(Console.ReadLine());
            } while (choise < 1 && choise > 4);

            switch (choise)
            {
                case 1:
                    Max_value(NumArray);
                    break;
                case 2:
                    Min_value(NumArray);
                    break;
                case 3:
                    Avarage(NumArray);
                    break;
                case 4:
                    Sum(NumArray);
                    break;
                default:
                    break;
            }
        }
        static void Max_value(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        Swap<int>(Ref array[j], Ref array[j + 1]);
                    }
                }
            }
            Console.WriteLine("Max value is : " + array[0]);
        }

        static void Min_value(int[] array)
        {	
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap<int>(Ref array[j], Ref array[j + 1]);
                    }
                }
            }
            Console.WriteLine("Min value is : " + array[0]);
        }
        static void Avarage(int[] array)
        {
            int Sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Sum += array[i];
            }
            Sum /= array.Length;
            Console.WriteLine("Average value is : " + Sum);
        }
        static void Sum(int[] array)
        {
            int Sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Sum += array[i];
            }
            Console.WriteLine("Sum value is : " + Sum);
        }
    }
}
