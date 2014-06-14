using System;

static class Distance
{    
    //Write a static class with a static method to calculate the distance between two points in the 3D space.
    public static double CalculateDistanceIn3D(Point3D first, Point3D second)
    {
        //Math lesson - d = Sqrt( (x1-x1)^2 + (y1-y2)^2 + (z1-z2)^2)
        double distance = Math.Sqrt((first.X - second.X) * (first.X - second.X) + (first.Y - second.Y) * (first.Y - second.Y) + (first.Z - second.Z) * (first.Z - second.Z));
        return distance;
    }
}

