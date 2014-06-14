namespace StringPadRight
{
    using System;

    public class StringPadRight
    {
        /// <summary>
        /// Write a program that reads from the console a string of maximum 20 characters. 
        /// If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
        /// Print the result string into the console.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter string of maximum 20 characters");
            string text = Console.ReadLine().PadRight(20, '*');
            Console.WriteLine(text);
        }
    }
}
