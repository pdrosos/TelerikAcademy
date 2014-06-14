using System;
using System.Collections.Generic;
using System.IO;

class Path
{
    List<Definition.Point> path = new List<Definition.Point>();
    static class PathStorage
    {
        static Path LoadPath(string filename)
        {
            Path readed = new Path();
            StreamReader reader = new StreamReader(filename);
            using (reader)
            {
                try
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] nextPoint = reader.ReadLine().Split(',');
                        readed.path.Add(new Definition.Point(int.Parse(nextPoint[0]), int.Parse(nextPoint[1]), int.Parse(nextPoint[2])));
                        line = reader.ReadLine();
                    }
                }
                catch (IOException)
                {
                    throw new IOException();
                }
            }
            return readed;
        }
        static void SavePath(List<Definition.Point> path, string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            using (writer)
            {
                try
                {
                    foreach (var item in path)
                    {
                        writer.Write(item.x + "," + item.y + "," + item.z + "\r\n");
                    }

                }
                catch (IOException)
                {
                    throw new IOException();
                }
            }
        }

    }
}