using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:

namespace _6_ReadSortSave
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt");
            StreamWriter writer = new StreamWriter("test.txt");
            string line = "";
            List<string> lines = new List<string>();
            while (line != null)
            {
                line = reader.ReadLine();
                lines.Add(line);

            }
            lines.Sort();
            foreach (var item in lines)
            {
                writer.WriteLine(item);
            }
            reader.Dispose();
            writer.Dispose();


        }
    }
}
