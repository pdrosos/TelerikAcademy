using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04SubstringSearchEngine
{
    class SubstringSearchEngine
    {
        static void Main(string[] args)
        {
            string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day.We will move out of it in 5 days.";
            string search = "in";

            string[] results = Regex.Split(text, search);
            Console.WriteLine(results.Length);
        }
    }
}
/* Write a program that finds how many times a substring is contained in a given text

 (perform case insensitive search).

		Example: The target substring is "in". The text is as follows:

We are living in an yellow submarine. We don't have anything else. Inside the 

submarine is very tight. So we are drinking all the day.

 We will move out of it in 5 days.



The result is: 9.*/
