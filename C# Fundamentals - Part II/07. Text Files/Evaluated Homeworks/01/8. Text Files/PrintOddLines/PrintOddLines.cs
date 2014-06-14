using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        try
        {
            using (StreamReader reader = new StreamReader("file.txt"))
            {
                string line = reader.ReadLine();
                int lineNumber = 1;

                while (line != null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    lineNumber++;
                    line = reader.ReadLine();
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found.");
        }
        catch (IOException e)
        {
            Console.WriteLine("I/O error.");
        }
    }
}
