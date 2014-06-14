using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToHex
{/*Write a program to convert decimal numbers to their hexadecimal representation.*/

    class DecimalToHex
    {
        static void Main()
        {
            Console.Write("Enter decimal number: ");
            int number = int.Parse(Console.ReadLine());
            DecimalToH(number);
        }

        static void DecimalToH(int num)
        {
            Console.Write("Hex representation of {0} is: ", num);
            int newNumber = 0;
            string bin = "";

            while (num > 0)
            {
                newNumber = num % 16;
                num = num / 16;
                if (newNumber >= 10)
                {
                    switch (newNumber)
                    {
                        case 10:
                            bin += 'A';
                            break;
                        case 11:
                            bin += 'B';
                            break;
                        case 12:
                            bin += 'C';
                            break;
                        case 13:
                            bin += 'D';
                            break;
                        case 14:
                            bin += 'E';
                            break;
                        case 15:
                            bin += 'F';
                            break;
                    }
                }
                else
                {
                    bin += newNumber;
                }
            }

            for (int i = bin.Length - 1; i >= 0; i--)
            {
                Console.Write(bin[i]);
            }
            Console.WriteLine();
        }
    }
}
