//Write a program that reads a string from the console and prints all different 
//letters in the string along with information how many times each letter is found. 

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class LettersInString
{
    static void Main()
    {
        Console.WriteLine("Enter a string: ");
        string input = Console.ReadLine();
        Dictionary<char, int> letterscounter = new Dictionary<char,int>();
        string pattern = @"[a-z,A-Z]";
        Match singleLetter = Regex.Match(input,pattern);
        while (singleLetter.Success)
        {
            if (letterscounter.ContainsKey(Convert.ToChar(singleLetter.Value)))
            {
                letterscounter[Convert.ToChar(singleLetter.Value)] = letterscounter[Convert.ToChar(singleLetter.Value)] + 1;
            }
            else
            {
                letterscounter.Add(Convert.ToChar(singleLetter.Value),1);
            }
            singleLetter = singleLetter.NextMatch();
        }
        foreach (var item in letterscounter)
        {
            Console.WriteLine("Letter "+item.Key+" - "+item.Value+" times found");
        }
    }
}

