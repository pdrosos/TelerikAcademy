using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
//Write a program that removes from a text file all words listed in given another text file. 
//Handle all possible exceptions in your methods.


namespace _12_RemoveWords
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader("input.txt");
            StreamReader reader2 = new StreamReader("words.txt");

            string text="";
            string words="";

            using (reader1)
            {
                 text = reader1.ReadToEnd();
            }
            using(reader2)
	        {
		         words = reader2.ReadToEnd();
	        }
            
            string[] dict = Regex.Split(words, " ");

           
            foreach (var item in dict)
            {
                text = text.Replace(item, "");
            }
            StreamWriter writer = new StreamWriter("output.txt");

            using (writer)
            {
                 writer.Write(text);
            } 

        }
    }
}
