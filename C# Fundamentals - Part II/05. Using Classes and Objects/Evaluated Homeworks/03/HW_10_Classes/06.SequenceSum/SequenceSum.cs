/*You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. Example:
		string = "43 68 9 23 318"  result = 461 */

using System;


class SequenceSum
{
    static void Main(string[] args)
    {
        Console.Write("Please, enter the number, separate each number with a space: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        int sum = 0;
        foreach (string number in numbers)
        {
            sum += int.Parse(number);
        }
        Console.WriteLine("Result {0}", sum);
    }
}


