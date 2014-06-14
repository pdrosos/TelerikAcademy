using System;
using System.Linq;

class StringReverse
{
    static void Main()
    {
        Console.WriteLine("Type string:");
        string str = Console.ReadLine();
        //string str = "abcd";
        char[] strArr = str.ToCharArray();
        Array.Reverse(strArr);

        Console.WriteLine(strArr);

    }
}
