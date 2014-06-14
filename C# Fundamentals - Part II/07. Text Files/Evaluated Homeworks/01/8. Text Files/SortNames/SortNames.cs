using System;
using System.IO;
using System.Collections.Generic;

class SortNames
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("names.txt"))
        {
            List<string> names = new List<string>();

            for (string currentName = reader.ReadLine(); currentName != null; currentName = reader.ReadLine())
            {
                names.Add(currentName);
            }

            names.Sort();

            using (StreamWriter writer = new StreamWriter("sorted_names.txt"))
            {
                foreach (string name in names) writer.WriteLine(name);
            }
        }
    }
}
