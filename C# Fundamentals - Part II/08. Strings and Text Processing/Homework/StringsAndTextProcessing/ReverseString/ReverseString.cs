namespace ReverseString
{
    using System;

    public class ReverseString
    {
        /// <summary>
        /// Write a program that reads a string, reverses it and prints the result at the console.
        /// </summary>
        public static void Main(string[] args)
        {
            string text = "This is some text ...";
            Console.WriteLine(text);
            Console.WriteLine(Reverse(text));
        }

        public static string Reverse(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
