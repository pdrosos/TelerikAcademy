using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Security;

class RemoveWords
{
    public static List<string> ReadWordsToDelete()
    {
        List<string> words = new List<string>();

        using (StreamReader reader = new StreamReader("words.txt"))
        {
            for (string line; (line = reader.ReadLine()) != null; ) words.Add(line);
        }

        return words;
    }

    public static void ReplaceTarget(List<string> words)
    {
        using (StreamReader reader = new StreamReader("test.txt"))
        {
            using (StreamWriter writer = new StreamWriter("temp.txt"))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"\b(");
                foreach (string word in words) sb.Append(word + "|");

                sb.Remove(sb.Length - 1, 1);
                sb.Append(@")\b");

                string pattern = @sb.ToString();
                Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);

                for (string line; (line = reader.ReadLine()) != null; )
                {
                    string newLine = rgx.Replace(line, "");
                    writer.WriteLine(newLine);
                }
            }         
        }

        File.Delete("test.txt");
        File.Move("temp.txt", "test.txt");
    }

    static void Main()
    {
        try
        {
            List<string> words = ReadWordsToDelete();
            ReplaceTarget(words);
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
