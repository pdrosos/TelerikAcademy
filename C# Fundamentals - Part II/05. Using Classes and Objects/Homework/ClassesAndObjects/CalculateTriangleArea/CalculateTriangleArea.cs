namespace CalculateTriangleArea
{
    using System;

    public class CalculateTriangleArea
    {
        /// <summary>
        /// Write methods that calculate the surface of a triangle by given:
        /// Side and an altitude to it; Three sides; Two sides and an angle between them. 
        /// Use System.Math.
        /// </summary>
        public static void Main(string[] args)
        {
            double trBase = 5d;
            double trAltitude = 3d;

            double area = TriangleAreaByBaseAndAltitude(trBase, trAltitude);
            Console.WriteLine("Triangle 1 area (given base and altitude): {0}", area);

            double side1 = 15d, side2 = 16d, side3 = 9d;

            area = TriangleAreaByThreeSides(side1, side2, side3);
            Console.WriteLine("Triangle 2 area (given 3 sides): {0}", area);

            side1 = 4d; side2 = 4d;
            double angle = 50d;

            area = TriangleAreaSideAngleSideMethod(side1, side2, angle);
            Console.WriteLine("Triangle 3 area (given 2 sides and angle): {0}", area);
        }

        // http://www.mathopenref.com/trianglearea.html
        public static double TriangleAreaByBaseAndAltitude(double trBase, double trAltitude)
        {
            double area = trBase * trAltitude / 2;

            return area;
        }

        // Heron's formula: http://www.mathopenref.com/heronsformula.html
        public static double TriangleAreaByThreeSides(double side1, double side2, double side3)
        {
            double perimeterHalf = (side1 + side2 + side3) / 2d;
            double area = Math.Sqrt(perimeterHalf * (perimeterHalf - side1) * (perimeterHalf - side2) * (perimeterHalf - side3));

            return area;
        }

        // http://www.mathopenref.com/triangleareasas.html; http://www.mathsisfun.com/algebra/trig-solving-sas-triangles.html
        public static double TriangleAreaSideAngleSideMethod(double side1, double side2, double angleInDegrees)
        {
            double angleInRadians = (Math.PI / 180) * angleInDegrees;
            double area = (side1 * side2 * Math.Sin(angleInRadians)) / 2d;

            return area;
        }
    }
}
