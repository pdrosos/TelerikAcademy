using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Write a program that deletes from a text file all words that start with the 
// prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.

namespace _11DeletePrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "test";
            using (StreamReader reader = new StreamReader(@"..\..\textFile.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\resultFile.txt"))
                {
                    string text = reader.ReadToEnd();
                    int startIndex = 0;
                    while (startIndex != -1)
                    {
                        // get the starting index of the word
                        if (startIndex == 0 || text[startIndex - 1] == ' ')
                        {
                            startIndex = text.IndexOf(word, startIndex);
                        }
                        else
                        {
                            break;
                        }
                        // get hte ending index of the word
                        int endIndex = text.IndexOf(" ", startIndex);
                        if (endIndex == -1)
                        {
                            break;
                        }
                        // remove the word
                        text = text.Remove(startIndex, endIndex - startIndex);
                    }
                    writer.Write(text);
                }
            }
        }
    }  
}
