using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Write a program that compares two text files line by line and prints the number of 
// lines that are the same and the number of lines that are different. Assume the 
// files have equal number of lines.

class CompareFiles
{
    static void Main(string[] args)
    {
        //you can find the the .txt files in the directory of the project
        StreamReader reader1 = new StreamReader(@"..\..\input1.txt");
        StreamReader reader2 = new StreamReader(@"..\..\input2.txt");

        int readerLineNum = 0;
        string reader1Line = reader1.ReadLine();
        string reader2Line = reader2.ReadLine();
        int matchCounter = 0;
        int mismatchCounter = 0;
        while (reader1Line != null)
        {
            if (reader1Line == reader2Line)
            {
                mismatchCounter++;
            }
            else
            {
                matchCounter++;
            }
            readerLineNum++;
            reader1Line = reader1.ReadLine();
            reader2Line = reader2.ReadLine();
        }
        reader1.Close();

        Console.WriteLine("The number of the lines which are equal is {0}", mismatchCounter);
        Console.WriteLine("The number of the lines which are not equal is {0}", matchCounter);
    }
}

