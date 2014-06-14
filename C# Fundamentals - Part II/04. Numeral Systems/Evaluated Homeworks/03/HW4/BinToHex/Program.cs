using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinToHexi
{/*Write a program to convert binary numbers to hexadecimal numbers (directly).*/

    class BinaryToHexidecimal
    {
        static void Main()
        {
            Console.WriteLine("Please insert binary number:");
            string bin = Console.ReadLine();

            Console.WriteLine("The hexidecimal representation of {0} is ", bin);
            BinToHex(bin);
        }

        static void BinToHex(string bin)
        {
            string hex = "";
            string currentStr = "";

            int length = bin.Length;

            while (length % 4 != 0)
            {
                currentStr += 0;
                length++;
                if (length % 4 == 0)
                {
                    break;
                }
            }

            for (int i = 0; i < bin.Length; i++)
            {
                currentStr += bin[i];
                if (currentStr.Length == 4)
                {
                    switch (currentStr)
                    {
                        case "0000":
                            hex += 0;
                            currentStr = "";
                            break;
                        case "0001":
                            hex += 1;
                            currentStr = "";
                            break;
                        case "0010":
                            hex += 2;
                            currentStr = "";
                            break;
                        case "0011":
                            hex += 3;
                            currentStr = "";
                            break;
                        case "0100":
                            hex += 4;
                            currentStr = "";
                            break;
                        case "0101":
                            hex += 5;
                            currentStr = "";
                            break;
                        case "0110":
                            hex += 6;
                            currentStr = "";
                            break;
                        case "0111":
                            hex += 7;
                            currentStr = "";
                            break;
                        case "1000":
                            hex += 8;
                            currentStr = "";
                            break;
                        case "1001":
                            hex += 9;
                            currentStr = "";
                            break;
                        case "1010":
                            hex += 'A';
                            currentStr = "";
                            break;
                        case "1011":
                            hex += 'B';
                            currentStr = "";
                            break;
                        case "1100":
                            hex += 'C';
                            currentStr = "";
                            break;
                        case "1101":
                            hex += 'D';
                            currentStr = "";
                            break;
                        case "1110":
                            hex += 'E';
                            currentStr = "";
                            break;
                        case "1111":
                            hex += 'F';
                            currentStr = "";
                            break;
                    }
                }
            }
            Console.WriteLine(hex);
        }
    
    }
}
