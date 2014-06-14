using System;
using System.Text;


struct Point3D
{
    //Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
    //Implement the ToString() to enable printing a 3D point.

    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    //Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
    private static readonly Point3D point0 = new Point3D(0,0,0);

    public Point3D(int x, int y, int z) : this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public Point3D(string coordinates) : this()
    {
        //We must trim any brackets - since I use only ( and ) I trim only those
        coordinates = coordinates.Trim(new char[] {'(',')'});

        //Now we take the numbers for X,Y,Z 
        //Since we son't know their length we must first extract them
        //Doing straight coordiantes[0] will take just 1 out ot 10 for example
        string[] seperateCoordiantes = coordinates.Split(new char[] { ',' });

        this.X = int.Parse(seperateCoordiantes[0]);
        this.Y = int.Parse(seperateCoordiantes[1]);
        this.Z = int.Parse(seperateCoordiantes[2]);
    }

    //Add a static property to return the point O.
    public static Point3D Point0
    {
        get { return Point3D.point0; }
    }

    public override string ToString()
    {
        StringBuilder print = new StringBuilder();

        print.AppendFormat("({0},{1},{2})",
            this.X, this.Y, this.Z);

        string toPrint = print.ToString();

        return toPrint;
    }
}  

