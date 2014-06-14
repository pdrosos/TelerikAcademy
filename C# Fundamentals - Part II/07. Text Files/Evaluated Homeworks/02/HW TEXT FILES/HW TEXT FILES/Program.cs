using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Write a program that reads a text file and prints on the console its odd lines.

namespace HW_TEXT_FILES
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt");
            string line = "";
            int counter = 0;
            while (line != null)
	        {
	            line = reader.ReadLine();
                counter++;
                if (counter % 2 != 0)
	            {
		            Console.WriteLine(line);
	            }
	        }
            reader.Dispose();
        }
    }
}
