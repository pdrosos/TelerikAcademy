using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryOfShort
{
    /* Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
 */

    class BinaryOfShort
    {
        static void Main()
        {
            Console.Write("Enter short-integer number: ");
            short number = short.Parse(Console.ReadLine());

            Console.Write("Binary representation is: ");
            BinRepresentationOfShort(number);
        }

        static void BinRepresentationOfShort(short num)
        {
            string bin = "";

            for (int bitNum = 15; bitNum >= 0; bitNum--)
            {
                int bitValue = (num >> bitNum) & 1;
                bin += bitValue;
            }

            Console.WriteLine(bin);

        }
    }

}
