using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from 
//given string and calculates their sum.
//Example: string = "43 68 9 23 318"  result = 461

namespace _06CalculateSumFromString
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToCalculate = "43 68 9 23 318"; //here is the string with numbers
            Console.Write("The sum of the numbers in the string is: ");
            Console.WriteLine(CalculateIntsFromString(stringToCalculate)); //call the method to calculate the sum and 
            //print to the console the result numbers
        }
        static int CalculateIntsFromString(string jointNumbers)
        {
            string[] splitNumbers = jointNumbers.Split(new Char[] { ' ' }); //split the string to array of strings, using as separater "white spaces"

            int Sum = 0;
            for (int number = 0; number < splitNumbers.Length; number++) //for all strings in the string array 
            {
                Sum += int.Parse(splitNumbers[number]);                //acumulate the result by adding every number parse to int first
            }

            return Sum; //return the calculated sum
        }
    }
}
