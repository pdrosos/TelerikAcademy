using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class ExtractXML
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("test.xml"))
        {
            int prev = ' ';
            List<string> info = new List<string>();
            StringBuilder temp = new StringBuilder();

            for (int c; (c = reader.Read()) != -1; )
            {
                if (prev == '>' && c != '<')
                {
                    while (c != '<' && c != -1)
                    {
                        if (c != ' ' && c != '\n' && c != '\r' && c != '\t') temp.Append((char)c);
                        c = reader.Read();
                    }

                    if (temp.Length > 0)
                    {
                        info.Add(temp.ToString());
                        temp.Clear();
                    }
                }
                prev = c;
            }

            foreach (string item in info) Console.WriteLine(item);
        }
    }
}
