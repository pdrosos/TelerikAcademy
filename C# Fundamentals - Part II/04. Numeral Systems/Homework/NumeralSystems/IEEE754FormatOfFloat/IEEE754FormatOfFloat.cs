namespace IEEE754FormatOfFloat
{
    using System;
    using System.Threading;

    class IEEE754FormatOfFloat
    {
        /// <summary>
        /// Write a program that shows the internal binary representation of given 32-bit signed floating-point number 
        /// in IEEE 754 format (the C# type float). 
        /// Example: -27,25 -> sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
        /// </summary>
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            float floatNumber = -27.25f;
            string binaryNumber = ConvertFloatToBinary(floatNumber);

            Console.WriteLine("Number: " + floatNumber);
            Console.WriteLine("Binary number: " + binaryNumber);
            Console.WriteLine("Sign: " + binaryNumber[0]);
            Console.WriteLine("Exponent: " + binaryNumber.Substring(1, 8));
            Console.WriteLine("Mantissa: " + binaryNumber.Substring(9));

            Console.WriteLine();

            floatNumber = 27.25f;
            binaryNumber = ConvertFloatToBinary(floatNumber);

            Console.WriteLine("Number: " + floatNumber);
            Console.WriteLine("Binary number: " + binaryNumber);
            Console.WriteLine("Sign: " + binaryNumber[0]);
            Console.WriteLine("Exponent: " + binaryNumber.Substring(1, 8));
            Console.WriteLine("Mantissa: " + binaryNumber.Substring(9));
        }

        public static string ConvertFloatToBinary(float floatNumber)
        {
            string result = "";
            byte[] floatBytes = BitConverter.GetBytes(floatNumber);

            for (int i = 3; i >= 0; --i)
            {
                result += GroupToBinary(GetLeftGroup(floatBytes[i]));
                result += GroupToBinary(GetRightGroup(floatBytes[i]));
            }

            return result;
        }

        public static int GetLeftGroup(byte x)
        {
            return (x >> 4);
        }

        public static int GetRightGroup(byte x)
        {
            return (x & 15);
        }

        public static string GroupToBinary(int x)
        {
            string result = "";

            for (int i = 3; i >= 0; --i)
            {
                result += (x >> i) & 1;
            }

            return result;
        }
    }
}