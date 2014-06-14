using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Write a program that deletes from given text file all odd lines. The result should be in the same file.


namespace _9_OddLinesDel
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("test.txt");
            string line = "";
            List<string>  lines = new List<string>();

            while (line!=null)
            {
                line = reader.ReadLine();
                lines.Add(line);
            }
            reader.Dispose();
            StreamWriter writer = new StreamWriter("test.txt");
            for (int i = 0; i < lines.Count; i++)
			{
			    if (i % 2 == 0)
	            {
		            writer.WriteLine(lines[i]);
	            }
			}
            writer.Dispose();

        }
    }
}
