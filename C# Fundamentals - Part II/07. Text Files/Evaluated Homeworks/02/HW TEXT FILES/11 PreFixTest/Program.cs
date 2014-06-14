using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
//Write a program that deletes from a text file all words that start with the prefix "test".
//Words contain only the symbols 0...9, a...z, A…Z, _.

namespace _11_PreFixTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt");
            string text = reader.ReadToEnd();
            string result = Regex.Replace(text, @"\btest\w*\b", "");
            reader.Dispose();
            StreamWriter writer = new StreamWriter("test.txt");
            writer.Write(result);
            writer.Dispose();

        }
    }
}
