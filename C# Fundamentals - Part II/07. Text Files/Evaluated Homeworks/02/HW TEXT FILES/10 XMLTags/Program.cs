using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Write a program that extracts from given XML file all the text without the tags. Example:

namespace _10_XMLTags
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("test.txt");

            string text = reader.ReadToEnd();
            bool outTag = false;
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '<')
                {
                    outTag = false;
                }
                else if (text[i] == '>')
                {
                    outTag = true;
                }
                else if (outTag)
                {
                    output.Append(text[i]);
                }
            }
            StreamWriter writer = new StreamWriter("text.txt");
            writer.WriteLine(output.ToString());

            reader.Dispose();
            writer.Dispose();
        }
    }
}
