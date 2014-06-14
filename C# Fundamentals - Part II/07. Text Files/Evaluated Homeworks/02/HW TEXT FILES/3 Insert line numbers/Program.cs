using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program that reads a text file and inserts line numbers in front of each of its lines.
//The result should be written to another text file.


namespace _3_Insert_line_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader("text.txt");
            StringBuilder lineBuilder = new StringBuilder();
            string line = "";
            StreamWriter writer = new StreamWriter("test.txt");

            int num = 0;
            

            while (line !=null)
            {

                line= reader1.ReadLine();
                lineBuilder.AppendLine(num.ToString() + ". " + line);
                num++;
                
            }
            writer.Write(lineBuilder.ToString());
            reader1.Dispose();
            writer.Dispose();
        }
    }
}
