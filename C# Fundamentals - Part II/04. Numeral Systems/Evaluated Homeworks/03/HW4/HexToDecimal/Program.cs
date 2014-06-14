using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexToDecimal
{/*Write a program to convert hexadecimal numbers to their decimal representation.*/

    class HexToDec
    {
        static void Main()
        {
            Console.WriteLine("Please insert hexidecimal number:");
            string hex = Console.ReadLine();

            Console.Write("The decimal representation of {0} is ", hex);
            HexToDecimal(hex);

        }

        static void HexToDecimal(string hex)
        {

            int dec = 0;
            int j = hex.Length - 1;

            for (int i = 0; i < hex.Length; i++)
            {
                if ((hex[i] - '0') >= 10)
                {
                    switch (hex[i])
                    {
                        case 'A':
                            dec += (10 * ((int)Math.Pow(16, j)));
                            j--;
                            break;
                        case 'B':
                            dec += (11 * ((int)Math.Pow(16, j)));
                            j--;
                            break;
                        case 'C':
                            dec += (12 * ((int)Math.Pow(16, j)));
                            j--;
                            break;
                        case 'D':
                            dec += (13 * ((int)Math.Pow(16, j)));
                            j--;
                            break;
                        case 'E':
                            dec += (14 * ((int)Math.Pow(16, j)));
                            j--;
                            break;
                        case 'F':
                            dec += (15 * ((int)Math.Pow(16, j)));
                            j--;
                            break;
                    }

                }
                else
                {
                    dec += ((hex[i] - '0') * ((int)Math.Pow(16, j)));
                    j--;
                }

               
            }
            Console.WriteLine(dec);
        }
    }
}
