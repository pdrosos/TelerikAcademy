using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise1
{
    /* 1. Write a method that asks the user for his 
     *    name and prints “Hello, <name>” (for example, “Hello, Peter!”). 
     *    Write a program to test this method.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Congratulation();
            Console.WriteLine("Nice to meet you!");
        }
        static void Congratulation()
        {
            string name;
            Console.WriteLine("What is your name ?");
            name = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
