namespace HelloUser
{
    using System;

    class HelloUser
    {
        /// <summary>
        /// Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). 
        /// Write a program to test this method.
        /// </summary>
        public static void Main(string[] args)
        {
            GetName();
        }

        public static void GetName()
        {
            Console.WriteLine("What is your name?");
            Console.WriteLine("Hello, {0}!", Console.ReadLine());
        }
    }
}
