using System;

/* Write methods that calculate the surface of a triangle by given:
Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.*/

    class TriangleSurface
    {
        static void SurfaceSideAltitude()
        {
            Console.WriteLine("Enter triangle side: ");
            double side = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter altitude: ");
            double altitude = double.Parse(Console.ReadLine());
            double surface = (side * altitude) / 2;
            Console.WriteLine("The surface of the triangle is {0}. ", surface);
        }

        static void SurfaceThreeSides()
        {
            Console.WriteLine("Enter first side: ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter second side: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter third side: ");
            double c = double.Parse(Console.ReadLine());
            double p = (a + b + c) / 2;
            double surface = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("The surface of the triangle is {0}. ", surface);
        }

        static void SurfaceTwoSidesAngle()
        {
            Console.WriteLine("Enter first side: ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter second side: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter angle: ");
            double angle = double.Parse(Console.ReadLine());
            double surface = (a * b * Math.Sin(Math.PI * angle / 180)) / 2;
            Console.WriteLine("The surface of the triangle is {0}. ", surface);
        }
        static void Main()
        {
            Console.WriteLine("Choose a method to calculate the surface: ");
            Console.WriteLine("Press 1 for side and altitude to it; ");
            Console.WriteLine("Press 2 for three sides; ");
            Console.WriteLine("Press 3 for two sides and angle between them. ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: SurfaceSideAltitude();
                    break;
                case 2: SurfaceThreeSides();
                    break;
                case 3: SurfaceTwoSidesAngle();
                    break;
                default: Console.WriteLine("Enter correct number!");
                    break;

            }
        }
    }

