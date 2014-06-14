using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertAny
{/* Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
 */
    class Convert
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            string number = Console.ReadLine();
            Console.Write("Enter input base: ");
            int inputBase = int.Parse(Console.ReadLine());
            Console.Write("Enter output base: ");
            int outputBase = int.Parse(Console.ReadLine());

            Console.WriteLine("Number is: {0}, InputBase is: {1}, Output base is: {2} and Output number is: ", number, inputBase, outputBase);
            DecToOutputBase(SSystemToDec(number, inputBase), outputBase);

        }

        static int SSystemToDec(string number, int input)
        {
            int num = 0;
            int j = number.Length - 1;


            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsLetter(number[i]))
                {
                    switch (number[i])
                    {
                        case 'A':
                            num += (10 * ((int)Math.Pow(input, j)));
                            j--;
                            break;
                        case 'B':
                            num += (11 * ((int)Math.Pow(input, j)));
                            j--;
                            break;
                        case 'C':
                            num += (12 * ((int)Math.Pow(input, j)));
                            j--;
                            break;
                        case 'D':
                            num += (13 * ((int)Math.Pow(input, j)));
                            j--;
                            break;
                        case 'E':
                            num += (14 * ((int)Math.Pow(input, j)));
                            j--;
                            break;
                        case 'F':
                            num += (15 * ((int)Math.Pow(input, j)));
                            j--;
                            break;
                    }

                }
                else
                {
                    num += ((number[i] - '0') * ((int)Math.Pow(input, j)));
                    j--;
                }
            }

            return num;
        }

        static void DecToOutputBase(int num, int output)
        {
            int newNumber = 0;
            string bin = "";

            while (num > 0)
            {
                newNumber = num % output;
                num = num / output;
                if (newNumber >= 10 && (output == 16))
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
