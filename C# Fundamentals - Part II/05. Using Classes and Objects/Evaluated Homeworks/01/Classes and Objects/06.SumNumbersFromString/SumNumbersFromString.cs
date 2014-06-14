using System;

/* You are given a sequence of positive integer values written into a string, separated by spaces. 
 Write a function that reads these values from given string and calculates their sum. */

class SumNumbersFromString
{
        
    static void Main()
    {
        Console.Write("Enter a sequence of numbers, separated by \" \" : ");
        string sequence = Console.ReadLine();
        string[] numbers = sequence.Split(' ');
        int sum = 0;
        foreach (string number in numbers)
        {
            sum += int.Parse(number);
        }
        Console.WriteLine("Sum of the numbers: {0}", sum);
    }
}
