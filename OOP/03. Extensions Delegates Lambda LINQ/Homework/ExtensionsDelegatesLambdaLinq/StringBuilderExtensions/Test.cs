namespace StringBuilderExtensions
{
    using System;
    using System.Text;

    /// <summary>
    /// Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder 
    /// and has the same functionality as Substring in the class String.
    /// </summary>
    class Test
    {
        static void Main(string[] args)
        {
            StringBuilder fullString = new StringBuilder("Hi, how are you?");

            StringBuilder substring = fullString.Substring(4, 12);
            Console.WriteLine(substring);

            substring = fullString.Substring(4);
            Console.WriteLine(substring);
        }
    }
}
