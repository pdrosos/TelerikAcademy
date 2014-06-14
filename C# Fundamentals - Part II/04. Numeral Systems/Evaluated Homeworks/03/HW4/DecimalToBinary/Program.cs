using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToBinary
{/*Write a program to convert decimal numbers to their binary representation.*/

    class DecToBin
    {
        static void Main()
        {
            Console.WriteLine("Please insert a decimal number:");
            int number = int.Parse(Console.ReadLine());
            DecimalToBin(number);

        }

        static void DecimalToBin(int num)
        {
            Console.WriteLine("The binary representation of {0} is: ", num);
            int newNumber = 0;
            string bin = "";

            while (num > 0)
            {
                newNumber = num % 2;
                num = num / 2;
                bin += newNumber;
            }

            for (int i = bin.Length - 1; i >= 0; i--)
            {
                Console.Write(bin[i]);
            }
            Console.WriteLine();

        }
    }
}
