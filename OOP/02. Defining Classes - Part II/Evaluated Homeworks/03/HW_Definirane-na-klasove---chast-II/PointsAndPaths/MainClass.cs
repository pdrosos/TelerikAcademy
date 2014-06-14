using System;

class MainClass
{
    static void Main()
    {
        //Generate sample points
        Point3D pointA = new Point3D(1, 1, 1);
        Point3D pointB = new Point3D(2, 2, 2);

        ////Print points info and distance
        Console.WriteLine("Point A has coordinates {0}", pointA.ToString());
        Console.WriteLine("Point B has coordinates {0}", pointB.ToString());
        Console.WriteLine("The distance between point A and point B is {0:F4}", Distance.CalculateDistanceIn3D(pointA, pointB));
        Console.WriteLine();

        //Generate sample path and add a few points
        Path pathA = new Path(pointA, pointB);
        pathA.Add(new Point3D(3, 3, 3));
        pathA.Add(new Point3D(3, 3, 3));
        pathA.Add(new Point3D(5, 5, 5));

        //Test path methods
        pathA.Remove(pointB);
        pathA.RemoveAt(2);

        //Point B and one of the points with coordinates (3,3,3) must be gone
        Console.WriteLine("PathA");
        pathA.ListPoints();

        //Saving path
        PathStorage.SavePath(pathA);
        Console.WriteLine();

        //Loading path
        Console.WriteLine("Default save file is \"save.txt\"");
        Console.Write("Insert file path to save file: ");
        string filePath = Console.ReadLine();
        Path pathB = PathStorage.LoadPath(filePath);

        //Checking pathB - must be the same as pathA
        Console.WriteLine();
        Console.WriteLine("PathB");
        pathB.ListPoints();
    }
}

