using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. 
//Ensure it will work with large files (e.g. 100 MB).


namespace _7_Replacing
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt");
            StreamWriter writer = new StreamWriter("test.txt");

            string line = "";
            StringBuilder lines = new StringBuilder();

            while (line != null)
            {
                line = reader.ReadLine();
                lines.Append(line);
                lines.Replace("start", "finish");
                writer.WriteLine(lines.ToString());
                lines.Clear();
            }
            reader.Dispose();
            writer.Dispose();

            
        }
    }
}
