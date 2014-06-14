// 9. * Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float). Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.

using System;

class FloatToBinary
{
    static void Main(string[] args)
    {
        float floatNumber = float.Parse(Console.ReadLine());
        string binaryNumber = ConvertFloatToBinary(floatNumber);

        Console.WriteLine("Binary representation: " + binaryNumber);
        Console.WriteLine("Sign: " + binaryNumber[0]);
        Console.WriteLine("Exponent: " + binaryNumber.Substring(1, 8));
        Console.WriteLine("Mantissa: " + binaryNumber.Substring(9));
    }

    static int GetLeftNibble(int x)
    {
        return (x >> 4);
    }

    static int GetRightNibble(int x)
    {
        return (x & 15);
    }

    static string NibbleToBinary(int x)
    {
        string result = "";

        for (int i = 3; i >= 0; --i)
        {
            result += (x >> i) & 1;
        }

        return result;
    }

    static string ConvertFloatToBinary(float floatNumber)
    {
        string result = "";
        byte[] floatBytes = BitConverter.GetBytes(floatNumber);
        for (int i = 3; i >= 0; --i)
        {
            result += NibbleToBinary(GetLeftNibble(floatBytes[i]));
            result += NibbleToBinary(GetRightNibble(floatBytes[i]));
        }

        return result;
    }
}