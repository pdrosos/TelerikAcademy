using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise3
{
    /* 3. Write a method that returns the last digit of given integer as an 
     *    English word. Examples: 512  "two", 1024  "four", 12309  "nine".
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter a num : ");
            int N = int.Parse(Console.ReadLine());

            Console.WriteLine("Last ditit of your num is: {0}", lastdigit(N));
        }
        static string lastdigit(int num)
        {
            int lastdigit = num % 10;
            switch (lastdigit)
            { 
                case 0:
                    return "null";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "error";
            }
        }
    }
}
