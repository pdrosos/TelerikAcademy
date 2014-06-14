using System;

namespace Definition
{
    public struct Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        private static Point CordinateStart=new Point(0,0,0);
        public static Point ZeroPoint { get { return CordinateStart; } }
        public Point(int x,int y,int z) :this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override string ToString()
        {
            return "X:" + x + " Y:" + y + " Z:" + z;
        }
    }
    [VersionClass(4, 11)]
    class Definition
    {
        static void Main()
        {
            Point p = new Point(3, 2, 1);
            Point p2 = new Point(3, 2, 1);
            Console.WriteLine(p.ToString());
            Console.WriteLine(Point.ZeroPoint.ToString());
            Console.WriteLine(Distance.Calculation(p, p2));

        Type type = typeof(Definition);
        object[] versions = type.GetCustomAttributes(false);
        foreach (VersionClass version in versions)
        {
            Console.WriteLine("The version is {0}.{1}",
                version.Major, version.Minor);
        }
        Console.WriteLine();
}
    }
}
