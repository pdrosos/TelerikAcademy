using System;
using System.IO;
using System.Collections.Generic;

class DeleteOddLines
{
    public static void WriteEvenLines(List<string> lines, string fileName)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (string line in lines) sw.WriteLine(line);
        }
    }

    public static List<string> GetEvenLines(string fileName)
    {
        using (StreamReader sr = new StreamReader(fileName))
        {
            int lineNumber = 1;
            string line;
            List<string> evenLines = new List<string>();

            while ((line = sr.ReadLine()) != null)
            {
                if (lineNumber % 2 == 0) evenLines.Add(line);
                lineNumber++;
            }

            return evenLines;
        }
    }

    static void Main()
    {
        List<string> evenLines = GetEvenLines("test.txt");
        WriteEvenLines(evenLines, "test.txt");
    }
}
