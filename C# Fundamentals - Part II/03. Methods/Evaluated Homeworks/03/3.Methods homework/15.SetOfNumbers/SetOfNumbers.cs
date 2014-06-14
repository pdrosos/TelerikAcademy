using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.SetOfNumbers
{
    class SetOfNumbers
    {
        static void Min<T>(T[] setOfNumbers) where T : IComparable<T>
        {
            if (setOfNumbers.Length > 1)
            {
                T minValue = setOfNumbers[0];

                for (int i = 0; i < setOfNumbers.Length - 1; i++)
                {
                    if (minValue.CompareTo(setOfNumbers[i + 1]) > 0)
                    {
                        minValue = setOfNumbers[i + 1];
                    }
                }
                Console.WriteLine("The minimum value of your secuence is {0}.", minValue);
            }
            else if (setOfNumbers.Length == 1)
            {
                T minValue = setOfNumbers[0];
                Console.WriteLine("The minimum value of your secuence is {0}.", minValue);
            }
            else
            {
                Console.WriteLine("You don't have any values in the array.");
            }
        }
        static void Max<T>(T[] setOfNumbers) where T : IComparable<T>
        {
            if (setOfNumbers.Length > 1)
            {
                T maxValue = setOfNumbers[0];

                for (int i = 0; i < setOfNumbers.Length - 1; i++)
                {
                    if (maxValue.CompareTo(setOfNumbers[i + 1]) < 0)
                    {
                        maxValue = setOfNumbers[i + 1];
                    }
                }
                Console.WriteLine("The max value of your secuence is {0}.", maxValue);
            }
            else if (setOfNumbers.Length == 1)
            {
                T maxValue = setOfNumbers[0];
                Console.WriteLine("The max value of your secuence is {0}.", maxValue);
            }
            else
            {
                Console.WriteLine("You don't have any values in the array.");
            }
        }
        static T Add<T>(T num1, T num2)
        {
            dynamic number1 = num1;
            dynamic number2 = num2;

            return number1 + number2;
        }
        static T Divide<T>(T num1, int num2)
        {
            dynamic number1 = num1;
            dynamic number2 = num2;

            return number1 / number2;
        }
        static void Average<T>(T[] setOfNumbers) where T : IComparable<T>
        {
            if (setOfNumbers.Length > 1)
            {
                T average = setOfNumbers[0];
                for (int i = 1; i < setOfNumbers.Length; i++)
                {
                    average = Add(average, setOfNumbers[i]);
                }
                Console.WriteLine("The average value of your secuence is {0}.", Divide(average,setOfNumbers.Length));
            }
            else if (setOfNumbers.Length == 1)
            {
                T average = setOfNumbers[0];
                Console.WriteLine("The average value of your secuence is {0}.", average);
            }
            else
            {
                Console.WriteLine("You don't have any values in the array.");
            }
        }
        static void Sum<T>(T[] setOfNumbers) where T : IComparable<T>
        {
            if (setOfNumbers.Length > 1)
            {
                T sum = setOfNumbers[0];
                for (int i = 1; i < setOfNumbers.Length; i++)
                {
                    sum = Add(sum, setOfNumbers[i]);
                }
                Console.WriteLine("The sum of your secuence is {0}.", sum);
            }
            else if (setOfNumbers.Length == 1)
            {
                T sum = setOfNumbers[0];
                Console.WriteLine("The sum of your secuence is {0}.", sum);
            }
            else
            {
                Console.WriteLine("You don't have any values in the array.");
            }
        }
        static void Main(string[] args)
        {
            decimal[] arrayOdDec = { 2.3m, 3.2m, 8.1m, 4m};
            Min(arrayOdDec);
            Max(arrayOdDec);
            Average(arrayOdDec);
            Sum(arrayOdDec);
        }
    }
}
