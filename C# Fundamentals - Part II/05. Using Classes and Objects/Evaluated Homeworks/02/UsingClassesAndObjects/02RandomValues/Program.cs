using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//2. Write a program that generates and prints to the console 10 random values in the range [100, 200].

namespace _02RandomValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("10 Random numbers in the range [100, 200]."); 

            Random randomNum=new Random(); //create a instance of the random class

            for(int i=1;i<=10;i++)
            {                                                   //generate and print to the console the random numbers
                Console.Write(randomNum.Next(100, 201) + " ");  //the range is till 201 and not 200 because the upper bound is exclusive and
            }                                                   //we want to include 200.
        }
    }
}
