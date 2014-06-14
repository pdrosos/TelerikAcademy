namespace HexToBinary
{
    using System;
    using System.Text;

    public class HexToBinary
    {
        /// <summary>
        /// Write a program to convert hexadecimal numbers to binary numbers (directly).
        /// </summary>
        public static void Main(string[] args)
        {
            string hexNumberOne = "123ABC";
            string hexNumberTwo = "134AF25";
            string hexNumberThree = "FFFAAA111";

            Console.WriteLine(hexNumberOne + ": " + HexadecimalToBinary(hexNumberOne));
            Console.WriteLine(hexNumberTwo + ": " + HexadecimalToBinary(hexNumberTwo));
            Console.WriteLine(hexNumberThree + ": " + HexadecimalToBinary(hexNumberThree));
        }

        public static string HexadecimalToBinary(string hexNumber)
        {
            StringBuilder binaryNumber = new StringBuilder();

            int currentDecimalDigit;

            // Convert each hex digit to 4 binary digits
            for (int i = hexNumber.Length - 1; i >= 0; i--)
            {
                currentDecimalDigit = HexDigitToDecimalDigit(hexNumber[i]);

                // 2 ^ 4 = 16
                for (int j = 0; j < 4; j++)
                {
                    binaryNumber.Insert(0, currentDecimalDigit % 2);
                    currentDecimalDigit /= 2;
                }
            }

            return binaryNumber.ToString().TrimStart('0');
        }

        public static int HexDigitToDecimalDigit(char digit)
        {
            if (digit >= 'A')
            {
                return digit - 'A' + 10;
            }
            else
            {
                return digit - '0';
            }
        }
    }
}
