using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class StringBuilderExtensionMethods
{
    //test

    static void Main()
    {
        StringBuilder str = new StringBuilder();
        str.Append("stringbuilder");
        StringBuilder res = str.Substring(4, 9);
        Console.WriteLine(res);
    }
}

