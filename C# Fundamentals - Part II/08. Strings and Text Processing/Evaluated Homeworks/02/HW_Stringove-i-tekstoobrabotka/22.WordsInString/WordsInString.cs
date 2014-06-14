//Write a program that reads a string from the console and lists all different words 
//in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class WordsInString
{
    static void Main()
    {
        Console.WriteLine("Enter a string: ");
        string input = Console.ReadLine();
        //string input = "Write a program the that, reads a string from the console and lists all different. Words ";
        Dictionary<string, int> letterscounter = new Dictionary<string, int>();
        string pattern = @"[^a-zA-Z]+";
        string[] words = Regex.Split(input, pattern);
        foreach (var singleWord in words)
        {
            if (letterscounter.ContainsKey(singleWord))
            {
                letterscounter[singleWord] = letterscounter[singleWord] + 1;
            }
            else
            {
                letterscounter.Add(singleWord, 1);
            }
            //singleWord = singleWord.NextMatch();
        }
        foreach (var item in letterscounter)
        {
            Console.WriteLine("Word " + item.Key + " - " + item.Value + " times found");
        }
    }
}
