using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Write a program that concatenates two text files into another text file.

class ConcatenatesTwoTextFiles
{
    static void Main(string[] args)
    {
        //you can find the the .txt files in the directory of the project
        StreamReader reader1 = new StreamReader(@"..\..\input1.txt");
        StreamReader reader2 = new StreamReader(@"..\..\input2.txt");
        StreamWriter writer = new StreamWriter(@"..\..\newFile.txt");

        // Print the content of the first text file
        Console.WriteLine("\nFIRST FILE CONTENT:");
        ReadAndPrintTextFile(@"..\..\input1.txt");

        // Print the content of the second text file
        Console.WriteLine("\nSECOND FILE CONTENT:");
        ReadAndPrintTextFile(@"..\..\input2.txt");

        int newFileLineNumber = 0;
        int reader1LineNumber = 0;
        string reader1Line = reader1.ReadLine();
        while (reader1Line != null)
        {
            reader1LineNumber++;
            writer.WriteLine(reader1Line);
            reader1Line = reader1.ReadLine();
            newFileLineNumber++;
        }
        reader1.Close();

        int reader2LineNumber = 0;
        string reader2Line = reader2.ReadLine();
        while (reader2Line != null)
        {
            reader2LineNumber++;
            writer.WriteLine(reader2Line);
            reader2Line = reader2.ReadLine();
            newFileLineNumber++;
        }
        reader2.Close();
        writer.Close();
        // Print the content of the new text file
        Console.WriteLine("\nNEW FILE CONTENT:");
        ReadAndPrintTextFile(@"..\..\newFile.txt");

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

