namespace IntegerLastDigitAsWord
{
    using System;

    public class IntegerLastDigitAsWord
    {
        /// <summary>
        /// Write a method that returns the last digit of given integer as an English word. 
        /// Examples: 512 - "two", 1024 - "four", 12309 - "nine".
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter integer number:");
            int number = int.Parse(Console.ReadLine());
            
            Console.WriteLine(DisplayIntNthDigitAsWord(number, 0));
        }

        public static string DisplayIntNthDigitAsWord(int number, int digitPosition)
        {
            string[] digitsNames = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int nthDigit = Math.Abs((number / (int)Math.Pow(10, digitPosition)) % 10);

            return digitsNames[nthDigit];
        }
    }
}
