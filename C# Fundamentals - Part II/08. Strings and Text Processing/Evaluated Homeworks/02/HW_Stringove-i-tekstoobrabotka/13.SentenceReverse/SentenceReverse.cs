using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class SentenceReverse
{
    static void Main()
    {
        string input = "C# is not C++, not PHP and not Delphi!";
        string[] wordsmatch = Regex.Split( input, " |,|!");
        string separators = Regex.Replace(input,@"[\w\s(#+)]","");

        List<string> words = new List<string>();
        foreach (var item in wordsmatch)
        {
            words.Add(item);
        }
        
        int[] separatorsIndex = new int[separators.Length];
        int counter = 0;
        for (int i = 0; i < words.Count; i++)
        {
            if (words[i]=="")
            {
                separatorsIndex[counter] = i;
                counter++;
            }
        }
        words.Reverse();
        counter = 0;
        for (int i = 0; i < words.Count; i++)
        {
            if (i==separatorsIndex[counter])
            {
                Console.Write(words[i]); 
                Console.Write(separators[counter]+" ");
                counter++;
            }
            else if (words[i]!="")
            {
               Console.Write(words[i]+" "); 
            }
            
        }

    }
}

