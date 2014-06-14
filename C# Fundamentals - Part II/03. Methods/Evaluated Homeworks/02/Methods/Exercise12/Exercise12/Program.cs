using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise12
{
    /* 12. Extend the program to support also subtraction and multiplication of polynomials.
     */
    class Program
    {
        static void Main(string[] args)
        {
            bool null_digit = false;
            int coef;
            int carage = 0;
            int[] polinom1 = new int[10];
            int[] polinom2 = new int[10];
            int[] result = new int[10];
            Console.WriteLine("Please enter coefficient of first polinomial");
            Console.WriteLine("Start with smallest coeficient  : ");
            for (int i = 0; i < polinom1.Length; i++)
            {
                polinom1[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Please enter coefficient of first polinomial");
            Console.WriteLine("Start with smallest coeficient  : ");
            for (int i = 0; i < polinom2.Length; i++)
            {
                polinom2[i] = int.Parse(Console.ReadLine());
            }
            result = Sum(polinom1, polinom2);
            Console.WriteLine("Sum is : ");
            for (int i = 0; i < result.Length; i++)
            {
                if (false)//if (result[i] != 0)
                {
                    null_digit = true;
                }
                if (true)//if (null_digit == true)
                {
                    Console.Write("{0}", result[i]);
                }
            }
            Console.WriteLine();
            result = Multiply(polinom1, polinom2);
            Console.WriteLine("Multiply is : ");
            for (int i = 0; i < result.Length; i++)
            {
                if (false)//if (result[i] != 0)
                {
                    null_digit = true;
                }
                if (true)//if (null_digit == true)
                {
                    Console.Write("{0}", result[i]);
                }
            }
            Console.WriteLine();
            result = Subtrack(polinom1, polinom2);
            Console.WriteLine("Substraction is : ");
            for (int i = 0; i < result.Length; i++)
            {
                if (false)//if (result[i] != 0)
                {
                    null_digit = true;
                }
                if (true)//if (null_digit == true)
                {
                    Console.Write("{0}", result[i]);
                }
            }
            Console.WriteLine();
        }
        static int[] Sum(int[] pol1, int[] pol2)
        {
            int coef;
            int carage = 0;
            int[] result = new int[10];
            for (int i = 0; i < pol1.Length - 1; i++)
            {
                coef = pol1[i] + pol2[i] + carage;
                carage = 0;
                if (coef < 9)
                {
                    result[i] = coef;
                }
                else
                {
                    result[i] = coef % 10;
                    coef -= result[i];
                    carage = coef / 10;
                }
            }
            return result;
        }
        static int[] Multiply(int[] pol1, int[] pol2)
        {
            int coef;
            int carage = 0;
            int[] result = new int[10];
            for (int i = 0; i < pol1.Length - 1; i++)
            {
                coef = pol1[i] * pol2[i] + carage;
                carage = 0;
                if (coef < 9)
                {
                    result[i] = coef;
                }
                else
                {
                    result[i] = coef % 10;
                    coef -= result[i];
                    carage = coef / 10;
                }
            }
            return result;
        }
        static int[] Subtrack(int[] pol1, int[] pol2)
        {
            int coef;
            int temp;
            int carage = 0;
            int[] result = new int[10];
            for (int i = pol1.Length - 2; i < 0; i++)
            {
                coef = pol1[i] - pol2[i];
                if (coef > 0)
                {
                    result[i] = coef;
                }
                else
                {
               //     temp = result[i] + result[i + 1] * 10;
               //     coef = temp - pol2[i];
               //     result[i] = coef % 10;
               //     coef -= result[i];
               //     carage = coef / 10;
                }
            }
            return result;
        }
    }
}
