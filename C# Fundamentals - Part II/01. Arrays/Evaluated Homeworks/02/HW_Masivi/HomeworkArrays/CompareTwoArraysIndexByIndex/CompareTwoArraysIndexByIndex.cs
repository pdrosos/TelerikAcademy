//Write a program that reads two arrays from the console and compares them element by element.
using System;

class CompareTwoArraysIndexByIndex
{
    static void Main()
    {
        //define variables
        Console.Write("Enter Arrays lenght: ");
        int Lenght = int.Parse(Console.ReadLine());
        int[] FirstArray = new int[Lenght];
        int[] SecondArray = new int[Lenght];

        //define first array indexes from console input
        for (int i = 0; i < FirstArray.Length; i++)
        {
            Console.Write("Enter fisrt array number index " + i + " ");
            FirstArray[i] = int.Parse(Console.ReadLine());
            //Console.WriteLine(FirstArray[i]);   //for debugging
        }

        //define second array indexes from console input        
        for (int i = 0; i < SecondArray.Length; i++)
        {
            Console.Write("Enter second array number index " + i + " ");
            SecondArray
            [i] = int.Parse(Console.ReadLine());
            //Console.WriteLine(SecondArray[i]);    //for debugging
        }
        
        //compare two arrays
        for (int i = 0; i < Lenght; i++)
        {
            if (FirstArray[i] == SecondArray[i])
            {
                Console.WriteLine("Index " + i);
                Console.WriteLine(FirstArray[i] + " is equal to " + SecondArray[i]);
            }
            else
            {
                Console.WriteLine("Index " + i);
                Console.WriteLine(FirstArray[i] + " Not equal to " + SecondArray[i]);
            }
        }

    }
}
