using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise2
{
    /* 2. Write a method GetMax() with two parameters that returns the 
     *    bigger of two integers. Write a program that reads 3 
     *    integers from the console and prints the biggest of them
     *    using the method GetMax().
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number A :");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter number B :");
            int B = Convert.ToInt32(Console.ReadLine());
            int C;
            C = GetMax(A, B);
            A = C;
            Console.WriteLine("Please enter number C :");
            C = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Biggest number is : " + GetMax(A, C));
        }

        static int GetMax(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else if (num2 > num1)
            {
                return num2;
            }
            else 
            {
                return num1 ;
            }
        }
    }
}
