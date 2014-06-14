
// You are given an array of strings. Write a method that sorts the array by the length of its elements 
// (the number of characters composing them).

using System;

class Ex05SortStringArray
{
    
    static void Main(string[] args)
    {
        string[] arr = { "Botev", "Plovdiv", "vodi", "na", "Astana" };
        Array.Sort(arr, (x, y) => x.Length.CompareTo(y.Length));
        foreach (var name in arr)        
            Console.WriteLine(name);        
    }
}

