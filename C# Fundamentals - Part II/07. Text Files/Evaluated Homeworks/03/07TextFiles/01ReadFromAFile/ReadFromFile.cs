using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Write a program that reads a text file and prints on the console its odd lines.
class Program
{
    static void Main(string[] args)
    {
        //you can find the the .txt file in the directory of the project
        ReadAndPrintTextFile(@"..\..\input.txt");
    }

    static void ReadAndPrintTextFile(string filePath)
    {
        StreamReader reader = new StreamReader(@"..\..\input.txt");
        using (reader)
        {
            int lineNum = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                if (lineNum % 2 == 1)
                {
                    Console.WriteLine("Line {0}: {1}", lineNum, line);
                }
                lineNum++;
                line = reader.ReadLine();
            }
        }
    }
}

