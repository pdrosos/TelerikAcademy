using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program that compares two text files line by line and prints the number of lines that are the same and the number 
//of lines that are different. Assume the files have equal number of lines.


namespace _4.CompareLineByLine
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader("text.txt");
            StreamReader reader2 = new StreamReader("tex.txt");

            string line1 = "";
            string line2 = "";
            int num = 0;
            int not = 0;


            while (line1 != null || line2 != null)
            {
                line1 = reader1.ReadLine();
                line2 = reader2.ReadLine();

                if (line1.CompareTo(line2) == 0)
                {
                    num++;
                }
                else
                {
                    not++;
                }
            }
            Console.WriteLine(num);
            Console.WriteLine(not);
        }
    }
}
