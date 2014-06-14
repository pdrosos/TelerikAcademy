using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Modify the solution of the previous problem to replace only whole words (not substrings).



using System.Text.RegularExpressions;namespace _7_Replacing
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("test.txt");
            StreamWriter writer = new StreamWriter("test.txt");

            string line = "";
            StringBuilder lines = new StringBuilder();

            while (line != null)
            {
                line = reader.ReadLine();
                lines.Append(line);
                Regex.Replace(lines.ToString(),"\bstart\b","finish");
                writer.WriteLine(lines.ToString());
                lines.Clear();
            }
            reader.Dispose();
            writer.Dispose();


        }
    }
}
