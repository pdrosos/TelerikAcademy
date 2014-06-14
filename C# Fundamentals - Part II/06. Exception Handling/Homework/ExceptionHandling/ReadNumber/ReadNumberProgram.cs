namespace ReadNumberProgram
{
    using System;

    public class ReadNumberProgram
    {
        /// <summary>
        /// Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
        /// If an invalid number or non-number text is entered, the method should throw an exception. 
        /// Using this method write a program that enters 10 numbers:
		/// a1, a2, … a10, such that 1 < a1 < … < a10 < 100
        /// </summary>
        public static void Main(string[] args)
        {
            int startNumber = 1;
            int endNumber = 100;

            for (int i = 0; i < 10; i++)
            {
                startNumber = ReadNumber(startNumber, endNumber);
            }
        }

        public static int ReadNumber(int startNumber, int endNumber)
        {
            int number = 0;
            bool isInt = int.TryParse(Console.ReadLine(), out number);

            if (!isInt)
            {
                throw new FormatException();
            }

            if (number <= startNumber || number >= endNumber)
            {
                throw new ArgumentOutOfRangeException();
            }

            return number;
        } 
    }
}
