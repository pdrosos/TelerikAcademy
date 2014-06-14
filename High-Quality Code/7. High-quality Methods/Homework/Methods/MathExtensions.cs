namespace Methods
{
    using System;
    using System.Linq;

    public class MathExtensions
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            // p is half the triangle perimeter
            double p = (a + b + c) / 2;

            // Heron's Formula for the area of a triangle: http://en.wikipedia.org/wiki/Heron%27s_formula
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return area;
        }

        public static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("The argument is null or empty.");
            }

            int maxNumber = int.MinValue;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }

            return maxNumber;
        }
    }
}