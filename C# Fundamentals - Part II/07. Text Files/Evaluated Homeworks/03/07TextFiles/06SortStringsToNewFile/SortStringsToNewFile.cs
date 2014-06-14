using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/* Write a program that reads a text file containing a list of strings, sorts them 
 * and saves them to another text file. Example:
 * Ivan         George
 * Peter    --> Ivan
 * Maria        Maria
 * George       Peter
 */


class SortStringsToNewFile
{
    static void Main(string[] args)
    {
        string inputFilePath = @"..\..\input.txt";
        string outputFilePath = @"..\..\output.txt";
        List<string> listStr = ReadTxtFileToArray(inputFilePath);
        listStr.Sort();
        WriteArrayToTxtFile(outputFilePath, listStr);

    }

    static List<string> ReadTxtFileToArray(string path)
    {
        List<string> listStr = new List<string>();
        StreamReader reader = new StreamReader(path);
        string lineContent = string.Empty;
        using (reader)
        {
            while (lineContent != null)
            {
                lineContent = reader.ReadLine();
                listStr.Add(lineContent);
            }
        }
        return listStr;
    }

    static void WriteArrayToTxtFile(string outputFilePath, List<string> arr)
    {
        StreamWriter writer = new StreamWriter(outputFilePath);
        using (writer)
        {
            for (int index = 0; index < arr.Count; index++)
            {
                writer.WriteLine(arr[index]);
            }
        }
    }

}

