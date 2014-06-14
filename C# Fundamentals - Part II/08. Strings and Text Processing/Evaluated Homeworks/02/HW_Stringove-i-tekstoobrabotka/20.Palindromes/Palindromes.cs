//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Palindromes
{
    public static void checkIfPalindrome(string check)
    {
        bool ispalindrome = true;

        for (int i = 0; i < check.Length / 2; i++)
        {
            if (check[i] != check[check.Length - 1 - i])
            {
                ispalindrome = false;
                return;
            }
        }
        if (ispalindrome == true && check.Length != 1)
        {
            Console.WriteLine(check);
        }
    }
    static void Main()
    {

        string input = "Write a program that extracts from a given text all palindromes, like ABBA, lamal, exe.";
        string[] words = Regex.Split(input, @"\W+");
        foreach (var item in words)
        {
            checkIfPalindrome(item);
        }
    }
}
