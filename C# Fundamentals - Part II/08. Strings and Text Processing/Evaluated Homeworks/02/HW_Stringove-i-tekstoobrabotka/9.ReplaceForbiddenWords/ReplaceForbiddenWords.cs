using System;

class ReplaceForbiddenWords
{
    static void Main()
    {
        string input = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string[] forbidden = { "PHP", "CLR", "Microsoft" };
        string output = "";
        foreach (var item in forbidden)
        {
            string replacement = "";
            for (int i = 0; i < item.Length; i++)
            {
                replacement = replacement + "*";
            }
            output = input.Replace(item, replacement);
            input = output;
         }
        Console.WriteLine("Output:\n"+output);
    }
}

