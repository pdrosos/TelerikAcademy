using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program that concatenates two text files into another text file.


namespace _2_Add_two_text_in_file
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader("text.txt");
            StreamReader reader2 = new StreamReader("tex.txt");

            StreamWriter writer = new StreamWriter("test.txt");

            string line = "";

            while (line!=null)
            {
                line = reader1.ReadLine();
                writer.WriteLine(line);
            }
            line = "";
            while (line != null)
            {
                line = reader2.ReadLine();
                writer.WriteLine(line);
            }

            reader1.Dispose();
            reader2.Dispose();
            writer.Dispose();



        }
    }
}
