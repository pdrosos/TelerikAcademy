using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Dictionary
{
    static void Main()
    {
        string[] dictionary = {
                                  ".NET – platform for applications from Microsoft",
                                  "CLR – managed execution environment for .NET",
                                  "namespace – hierarchical organization of classes"
                              };



        Console.WriteLine("Enter a word(.NET, CLR, namespace): ");
        string input = Console.ReadLine();


        for (int i = 0; i < dictionary.Length; i++)
        {
            Match word = Regex.Match(dictionary[i], @"(.*)( – )(.*)");
            if (input == word.Groups[1].Value)
            {
                Console.WriteLine(Regex.Match(dictionary[i], @"(.*)( – )(.*)").Groups[3]);
            }
        
        }
    }
}

