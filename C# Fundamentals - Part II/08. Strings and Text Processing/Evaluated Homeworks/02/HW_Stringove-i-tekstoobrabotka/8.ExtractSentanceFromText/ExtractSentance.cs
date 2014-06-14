using System;
using System.Text.RegularExpressions;

class ExtractSentance
    {
        static void Main()
        {
            string input = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            int start = 0,
                index = 0,
                finder=0;
            string check ="",
                   sentance ="";
            while (index != -1)
            {
                index = input.IndexOf(".",start );
                if (index !=-1)
                {
                    sentance = input.Substring(start, index + 1 - start);
                    if( Regex.Match(sentance,@"\bin\b").Success )
                    {
                        check = check + sentance;
                    }
                }
                start = index+1;
            }
            Console.WriteLine("Output:\n"+check);
        }
    }

