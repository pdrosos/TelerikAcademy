/* Write methods that calculate the surface of a triangle by given:
Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math. */

using System;

class TriangleSurface
{
    static void Main()
    {
        Console.WriteLine("Please, choose how you want to calculate the area of triangle?\n");
        Console.WriteLine("1. By side and altitude.\n2. By three sides\n3. Two sides and an angle between them.");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1: SideAndAltitude();
                break;
            case 2: ThreeSides();
                break;
            case 3: TwoSidesAndAngle();
                break;
            default: Console.WriteLine("Please use number between 1 and 3!");
                break;
        }
    }

    private static void SideAndAltitude()
    {
        Console.WriteLine("Please, enter the lenght of the side:");
        double side = double.Parse(Console.ReadLine());
        Console.WriteLine("Please, enter the lenght of the altitude:");
        double altitude = double.Parse(Console.ReadLine());
        Console.WriteLine("S = {0}", side * altitude / 2);
    }

    private static void ThreeSides()
    {
        Console.WriteLine("Please, enter the lenght of the firs side:");
        double sideOne = double.Parse(Console.ReadLine());
        Console.WriteLine("Please, enter the lenght of the second side:");
        double sideTwo = double.Parse(Console.ReadLine());
        Console.WriteLine("Please, enter the lenght of the third side:");
        double sideThree = double.Parse(Console.ReadLine());
        double s = (sideOne + sideTwo + sideThree) / 2;
        Console.WriteLine("S = {0}", Math.Sqrt(s * (s - sideOne) * (s - sideTwo) * (s - sideThree)));
    }

    private static void TwoSidesAndAngle()
    {
        Console.WriteLine("Please, enter the lenght of the firs side:");
        double sideOne = double.Parse(Console.ReadLine());
        Console.WriteLine("Please, enter the lenght of the second side:");
        double sideTwo = double.Parse(Console.ReadLine());
        Console.WriteLine("Please, enter an angle:");
        double angle = double.Parse(Console.ReadLine());
        Console.WriteLine("S = {0}", sideOne * sideTwo * Math.Sin(Math.PI * angle / 180) / 2);
    }

}