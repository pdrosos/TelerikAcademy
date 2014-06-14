namespace SumOfNumbersString
{
    using System;

    public class SumOfNumbersString
    {
        /// <summary>
        /// You are given a sequence of positive integer values written into a string, separated by spaces. 
        /// Write a function that reads these values from given string and calculates their sum. 
        /// Example: string = "43 68 9 23 318" -> result = 46
        /// </summary>
        public static void Main(string[] args)
        {
            string numbersString = "43 68 9 23 318";
            string[] numbersArray = numbersString.Split(' ');

            int sum = 0;
            for (int i = 0; i < numbersArray.Length; i++)
            {
                sum += Convert.ToInt32(numbersArray[i]);
            }

            Console.WriteLine("Sum of " + numbersString + " = " + sum);
        }
    }
}
