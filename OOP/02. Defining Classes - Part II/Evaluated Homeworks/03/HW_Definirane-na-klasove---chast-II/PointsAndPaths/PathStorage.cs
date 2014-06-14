using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

static class PathStorage
{
    //Create a static class PathStorage with static methods to save and load paths from a text file. 
    //Use a file format of your choice.

    public static void SavePath(Path path)
    {
        Console.WriteLine("Saving current path ...");

        StreamWriter writer = new StreamWriter("save.txt");

        List<Point3D> list = path.CurrentPath;

        using (writer)
        {
            for (int i = 0; i < list.Count; i++)
            {
                writer.Write(list[i].ToString() + ' ');
            }
        }

        Console.Write("Do you want to view the save file (y/n): ");
        char answer = char.Parse(Console.ReadLine());

        if (answer == 'y')
        {
            Process.Start("save.txt");
        }
    }

    public static Path LoadPath(string filePath)
    {
        //We asume correct input - not a phone number or something
        Console.WriteLine("Loading specified path ...");

        StreamReader reader = new StreamReader(filePath);

        //Adding sperate points to a list
        List<Point3D> result = new List<Point3D>();

        using (reader)
        {
            string coordiantes = reader.ReadToEnd();

            //Since in the save method we have one extra ' ' at the end
            //here we need to use StringSplitOptions.RemoveEmptyEntries
            string[] points = coordiantes.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);

            foreach (var point in points)
            {
                result.Add(new Point3D(point));
            }
        }

        if (result.Count < 2)
        {
            throw new ArgumentException("This is not a valid path - you need at least 2 points");
        }

        //Adding points to the final Path
        Path path = new Path(result[0], result[1]);

        for (int i = 2; i < result.Count; i++)
        {
            path.Add(result[i]);
        }

        return path;
    }
}

