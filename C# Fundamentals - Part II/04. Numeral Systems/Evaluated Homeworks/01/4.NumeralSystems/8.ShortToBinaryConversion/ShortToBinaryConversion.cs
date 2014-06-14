// 8. Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System;
using System.Text;

class BinaryOfShort
{
    static void Main()
    {
        short shortNumber = short.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();

        for (int bitNum = 15; bitNum >= 0; bitNum--)
        {
            int bitValue = (shortNumber >> bitNum) & 1;
            builder.Append(bitValue);
        }

        Console.WriteLine(builder);
    }
}