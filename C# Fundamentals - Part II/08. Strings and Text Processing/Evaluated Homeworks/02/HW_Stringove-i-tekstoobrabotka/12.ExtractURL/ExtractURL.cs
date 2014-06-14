using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ExtractURL
{
    static void Main()
    {
        string input = "http://www.devbg.org/forum/index.php ";

        Console.WriteLine("[protocol] = \"{0}\"",Regex.Match(input,@"\w*"));
        Console.WriteLine("[server] = \"{0}\"",Regex.Match(input,@"//([^/]*)").Groups[1].Value);
        Console.WriteLine("[resource] = \"{0}\"", Regex.Match(input, @"//([^/]*)(.*)").Groups[2].Value);
    }
}

