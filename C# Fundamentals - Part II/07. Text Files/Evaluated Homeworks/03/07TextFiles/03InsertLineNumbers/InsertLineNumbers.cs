using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Write a program that reads a text file and inserts line numbers in front of 
// each of its lines. The result should be written to another text file.

class InsertLineNumbers
{
    static void Main(string[] args)
    {
        //you can find the the .txt files in the directory of the project
        InsertLinesNumbers(@"..\..\input.txt", @"..\..\newFile.txt");
        ReadAndPrintTextFile(@"..\..\newFile.txt");
    }

    static void InsertLinesNumbers(string filePath, string newFilePath)
    {
        StreamReader reader = new StreamReader(filePath);
        StreamWriter writer = new StreamWriter(newFilePath);

        int readerLineNum = 0;
        string readerLine = reader.ReadLine();
        while (readerLine != null)
        {
            writer.WriteLine((readerLineNum + 1) + ": " + readerLine);
            readerLineNum++;
            readerLine = reader.ReadLine();
        }
        reader.Close();
        writer.Close();
    }

    static void ReadAndPrintTextFile(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {
            int lineNum = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                lineNum++;
                line = reader.ReadLine();
            }
        }
    }
}

