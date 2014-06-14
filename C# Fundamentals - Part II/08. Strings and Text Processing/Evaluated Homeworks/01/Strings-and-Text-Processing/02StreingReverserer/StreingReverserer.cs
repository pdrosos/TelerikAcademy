namespace _02StreingReverserer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class StreingReverserer
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string:");
            string consoleEntrance = Console.ReadLine();
            for( int i = consoleEntrance.Length - 1; i >= 0; i--)
            {
                Console.Write(consoleEntrance[i]); 
            }
            Console.WriteLine();
        }
    }
}
// Write a program that reads a string, reverses it and prints the result at the console.
// Example: "sample"  "elpmas".
