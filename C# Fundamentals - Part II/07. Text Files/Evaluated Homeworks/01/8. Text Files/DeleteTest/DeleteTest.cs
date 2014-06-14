using System;
using System.IO;
using System.Text.RegularExpressions;

class DeleteTest
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("test.txt"))
        {
            using (StreamWriter writer = new StreamWriter("temp.txt"))
            {
                string pattern = @"\b(test)[\w_]*\b";
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
}
