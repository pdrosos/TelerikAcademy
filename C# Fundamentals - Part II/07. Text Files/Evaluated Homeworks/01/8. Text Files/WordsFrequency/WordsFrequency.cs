using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security;

class WordsFrequency
{
    public static List<string> ReadWords()
    {
        using (StreamReader reader = new StreamReader("words.txt"))
        {
            List<string> words = new List<string>();
            for (string line; (line = reader.ReadLine()) != null; ) words.Add(line);
            return words;
        }
    }

    public static Dictionary<string, int> FindOccurences(List<string> words)
    {
        using (StreamReader reader = new StreamReader("test.txt"))
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for (string line; (line = reader.ReadLine()) != null; )
            {
                string[] wordsOnLine = line.ToLower().Split(' ', '.', ';', ':');

                foreach (string word in wordsOnLine)
                {
                    if (words.Contains(word))
                    {
                        if (!dictionary.ContainsKey(word))
                        {
                            dictionary.Add(word, 1);
                        }
                        else ++dictionary[word];
                    }
                }
            }

            return dictionary;
        }
    }

    public static void WriteResultToFile(Dictionary<string, int> dictionary)
    {
        using (StreamWriter writer = new StreamWriter("result.txt"))
        {
            var sortedDictionary = (from d in dictionary
                                    orderby d.Value descending
                                    select d);

            foreach (var pair in dictionary)
            {
                writer.WriteLine(pair.Key + " " + pair.Value);
            }
        }
    }

    static void Main()
    {
        try
        {
            List<string> words = ReadWords();
            Dictionary<string, int> dictionary = FindOccurences(words);
            WriteResultToFile(dictionary);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

