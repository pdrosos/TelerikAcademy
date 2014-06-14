using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//Write a program that reads a list of words from a file words.txt and finds how many times each of
//the words is contained in another file test.txt. The result should be written in the file result.txt and the words 
//should be sorted by the number of their occurrences in descending order. Handle all possible exceptions in your methods.

//

public class WordsFindAndSort
{
    public static void Main()
    {
        StreamReader wordReader = new StreamReader("words.txt");
        StreamReader testReader = new StreamReader("test.txt");
        StreamWriter resultWriter = new StreamWriter("result.txt");

        Dictionary<string, int> words = new Dictionary<string, int>();
        string allWords = string.Empty;

        using (wordReader)
        {
            allWords = wordReader.ReadToEnd();
        }

        string[] strWords = allWords.Split();

        foreach (var item in strWords)
        {
            if (!words.ContainsKey(item))
            {
                words.Add(item, 0);
            }
        }

        using (testReader)
        {
            allWords = testReader.ReadToEnd();
        }

        string[] text = allWords.Split();

        foreach (var item in text)
        {
            if (words.ContainsKey(item))
            {
                words[item]++;
            }
        }

        var sortedDes = words.OrderByDescending(x => x.Value);

        using (resultWriter)
        {
            foreach (var item in sortedDes)
            {
                resultWriter.WriteLine("{0} {1}", item.Key, item.Value);
                Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
        }
    }
}