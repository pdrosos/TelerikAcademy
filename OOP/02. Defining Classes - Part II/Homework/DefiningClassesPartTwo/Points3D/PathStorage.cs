namespace Points3D
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public static class PathStorage
    {
        private static readonly string fileName = "paths.txt";

        public static List<Path> LoadStorage()
        {
            StreamReader reader = new StreamReader(fileName);
            List<Path> storage = new List<Path>();

            using (reader)
            {
                StringBuilder line = new StringBuilder();
                line.Append(reader.ReadLine());
                while (line.ToString() != string.Empty)
                {
                    Path path = new Path();

                    string[] points = line.ToString().Split(new string[] { ", " }, StringSplitOptions.None);
                    foreach (string coordinatesStr in points)
                    {
                        string[] coordinates = coordinatesStr.Split(new char[] { ' ' });
                        Point3D point = new Point3D(float.Parse(coordinates[0]), float.Parse(coordinates[1]), float.Parse(coordinates[2]));
                        path.AddPoint(point);
                    }

                    storage.Add(path);
                    line.Clear();
                    line.Append(reader.ReadLine());
                }  
            }

            return storage;
        }

        public static void SavePath(Path path)
        {
            StreamWriter writer = new StreamWriter(fileName, true);

            using (writer)
            {
                StringBuilder line = new StringBuilder();
                foreach (Point3D point in path.Points)
                {
                    line.Append(point.X).Append(' ').Append(point.Y).Append(' ').Append(point.Z).Append(", ");
                }
                // remove the last " ,"
                line.Remove(line.Length - 2, 2);

                writer.WriteLine(line.ToString());
            }
        }
    }
}
