using System;
using System.Linq;

class ReadTwentyChars
{
    static void Main()
    {
        Console.WriteLine("Type a string with 20 characters:");
        string myStr = Console.ReadLine();

        string str = "";
       
        if (myStr.Length < 20)
        {
            str = new string('*', 20 - myStr.Length);
        }
        Console.WriteLine("{0}{1}", myStr, str);
    }
}

