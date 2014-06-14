using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Write a program that deletes from given text file all odd lines. The result should be in the same file.


namespace _09DeleteAllOddLines
{
    class Program
    {
        static void Main()
        {
            string filePath = @"..\..\input.txt";
            List<string> listStr = ReadTxtFileEvenLinesToArray(filePath);
            WriteArrayToTxtFile(filePath, listStr);
        }

        static List<string> ReadTxtFileEvenLinesToArray(string path)
        {
            List<string> listStr = new List<string>();
            StreamReader reader = new StreamReader(path);
            string lineContent = string.Empty;
            int lineNumber = 0;
            using (reader)
            {
                while (lineContent != null)
                {
                    lineContent = reader.ReadLine();
                    if (lineNumber % 2 == 0)
                    {
                        listStr.Add(lineContent);
                    }
                    lineNumber++;
                }
            }
            return listStr;
        }

        static void WriteArrayToTxtFile(string filePath, List<string> arr)
        {
            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                for (int index = 0; index < arr.Count; index++)
                {
                    writer.WriteLine(arr[index]);
                }
            }
        }
    }
}
