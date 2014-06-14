//5.You are given an array of strings. Write a method that sorts the array by the length 
//of its elements (the number of characters composing them).


using System;
using System.Collections.Generic;
using System.Linq;

class SortArrayByLenght
{

    static void Main()
    {
        List<string> listOfStrings = new List<string> { "Hey friend,", "Don't", "...be ", "lalalaa", "worry", "Have a nice day!", "happy!" };

        foreach (string myArray in LenghtSort(listOfStrings))
        {
            Console.WriteLine(myArray); //print the values of the sorted array
        }
    }

    static IEnumerable<string> LenghtSort(IEnumerable<string> elements)
    {
        var sortedString = from myString in elements
                           orderby myString.Length ascending
                           select myString;
        return sortedString;
    }
}


