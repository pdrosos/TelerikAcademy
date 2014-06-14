namespace Points3D
{
    using System;
    using System.Collections.Generic;

    class Test
    {
        static void Main(string[] args)
        {
            Point3D pointOne = new Point3D(2, 3, 5);
            Point3D pointTwo = new Point3D(4, -7, -9);
            Console.WriteLine(pointOne);
            Console.WriteLine(pointTwo);

            double distance = Distance.CalculateDistance(pointOne, pointTwo);
            Console.WriteLine("Distance: " + Math.Round(distance, 2));
            Console.WriteLine();

            // load and print paths
            List<Path> paths = PathStorage.LoadStorage();
            PrintPaths(paths);
            Console.WriteLine();

            // add new path
            Path path = new Path();
            path.AddPoint(pointOne);
            path.AddPoint(pointTwo);
            PathStorage.SavePath(path);

            // load and print paths again
            paths = PathStorage.LoadStorage();
            PrintPaths(paths);
        }

        static void PrintPaths(List<Path> paths)
        {
            Console.WriteLine("Paths:");
            for (int i = 0; i < paths.Count; i++)
            {
                Console.WriteLine("Path " + (i + 1));
                foreach (Point3D point in paths[i].Points)
                {
                    Console.WriteLine(point);
                }
            }            
        }
    }
}
