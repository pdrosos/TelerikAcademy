using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07._08.ReplaceSubstrings
{
    class Program
    {
        static void Main()
        {
            StreamReader reader = new StreamReader(@"..\..\input.txt");
            StreamWriter writer = new StreamWriter(@"..\..\output.txt");

            using (reader)
            {
                using (writer)
                {
                    string lineContent = reader.ReadLine();

                    while (lineContent != null)
                    {
                        // problem 7
                        writer.WriteLine(lineContent.Replace("start", "finish"));
                        // problem 8
                        //writer.WriteLine(Regex.Replace(lineContent, @"\bstart\b", "finish"));

                        lineContent = reader.ReadLine();
                    }
                }
            }
        }
    }
}
