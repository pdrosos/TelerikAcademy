using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("test.txt"))
        {
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                string line;
                int lineNumber = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(++lineNumber + " " + line);
                }
            }
        }

        Console.WriteLine("File successfully writen!");
    }
}
