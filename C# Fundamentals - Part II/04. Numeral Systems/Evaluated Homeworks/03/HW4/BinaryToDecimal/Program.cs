using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToDecimal
{/*Write a program to convert binary numbers to their decimal representation.*/

    class BinToDecimal
    {
        static void Main()
        {
            Console.WriteLine("Please insert a binary number:");
            string bin = Console.ReadLine();
            Console.Write("The decimal representation of {0} is ", bin );
            BinToDec(bin);

        }

        static void BinToDec(string bin)
        {
            int dec = 0;
            int j = bin.Length - 1;

            for (int i = 0; i < bin.Length; i++)
            {
                dec += ((bin[i] - '0') * ((int)Math.Pow(2, j)));
                j--;
            }

            Console.WriteLine(dec);
        
        }
    }
}
