using System;

    class YourName
    {
        static void PrintName()
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name +"!");
        }
        static void Main()
        {
            PrintName();
        }
    }
