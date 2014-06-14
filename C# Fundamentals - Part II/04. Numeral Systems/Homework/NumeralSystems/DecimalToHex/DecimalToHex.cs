namespace DecimalToHex
{
    using System;
    using System.Text;

    public class DecimalToHex
    {
        /// <summary>
        /// Write a program to convert decimal numbers to their hexadecimal representation.
        /// </summary>
        public static void Main(string[] args)
        {
            int numberOne = 123;
            int numberTwo = 234;
            int numberThree = 340;

            // two ways of conversion - custom method and with formatted string
            Console.WriteLine(numberOne + ": " + IntToHex(numberOne) + " " + numberOne.ToString("X"));
            Console.WriteLine(numberTwo + ": " + IntToHex(numberTwo) + " " + numberTwo.ToString("X"));
            Console.WriteLine(numberThree + ": " + IntToHex(numberThree) + " " + numberThree.ToString("X"));
        }

        public static string IntToHex(int number)
        {
            StringBuilder hex = new StringBuilder();
            string[] letter = { "A", "B", "C", "D", "E", "F" };

            int reminder = 0;
            int dividend = number;

            do
            {
                reminder = dividend % 16;
                dividend = dividend / 16;
                hex = hex.Insert(0, (reminder > 9) ? letter[reminder - 10] : reminder.ToString());
            } while (dividend != 0);

            return hex.ToString();
        }
    }
}
