using System;
using System.IO;

class ReplaceFile
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("test.txt"))
        {
            using (StreamWriter writer = new StreamWriter("temp.txt"))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    string newLine = line.Replace("start", "finish");
                    writer.WriteLine(newLine);
                }
            }
        }
        File.Delete("test.txt");
        File.Move("temp.txt", "test.txt");

    }
}
