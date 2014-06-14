namespace Points3D
{
    using System;

    public static class Distance
    {
        public static double CalculateDistance(Point3D pointOne, Point3D pointTwo) 
        {
            double distance = Math.Sqrt(Math.Pow((pointTwo.X - pointOne.X), 2) +
                Math.Pow((pointTwo.Y - pointOne.Y), 2) + Math.Pow((pointTwo.Z - pointOne.Z), 2));

            return distance;
        }
    }
}
