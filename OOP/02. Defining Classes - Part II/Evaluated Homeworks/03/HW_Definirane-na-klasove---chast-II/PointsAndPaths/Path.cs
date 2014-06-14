using System;
using System.Collections.Generic;
using System.Text;

class Path 
{
    //Create a class Path to hold a sequence of points in the 3D space.

    private List<Point3D> path = new List<Point3D>();

    //For a path to exist it needs at least 2 points
    public Path(Point3D start, Point3D finish)
    {
        this.Add(start);
        this.Add(finish);
    }

    //We will add/remove points with methods, we don't want direct set function here
    public List<Point3D> CurrentPath
    {
        get { return this.path; }
    }

    public void ListPoints()
    {
        StringBuilder print = new StringBuilder();

        foreach (var point in this.CurrentPath)
        {
            print.AppendFormat("Point with coordinates {0}\n", point.ToString());
        }

        string toPrint = print.ToString();

        Console.WriteLine("List of points in current path:\n{0}", toPrint);
    }

    //The task is just to create and store paths
    //I will skip writing methods about path's length, comparing paths etc.
    public void Add(Point3D point)
    {
        this.CurrentPath.Add(point);
    }

    public void RemoveAt(int index)
    {
        this.CurrentPath.RemoveAt(index);
    }

    public void Remove(Point3D point)
    {
        this.CurrentPath.Remove(point);
    }
}

