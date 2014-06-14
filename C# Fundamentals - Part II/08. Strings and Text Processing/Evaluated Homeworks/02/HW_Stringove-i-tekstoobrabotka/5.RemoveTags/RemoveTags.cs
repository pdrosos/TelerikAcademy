using System;

class RemoveTags
{
    static void Main()
    {
        string input = @"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string output = input.Replace("<upcase>", "").Replace("</upcase>", "");
        Console.WriteLine(output);
    }
}

