using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWordsOnly
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("test.txt"))
        {
            using (StreamWriter writer = new StreamWriter("temp.txt"))
            {
                string pattern = @"\b(start)\b";
                Regex rgx = new Regex(pattern);

                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    string newLine = rgx.Replace(line, "finish");
                    writer.WriteLine(newLine);
                }
            }
        }
        File.Delete("test.txt");
        File.Move("temp.txt", "test.txt");
    }
}
