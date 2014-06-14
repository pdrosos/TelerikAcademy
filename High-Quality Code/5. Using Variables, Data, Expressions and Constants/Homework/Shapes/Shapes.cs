namespace Shapes
{
    using System;

    public class Shapes
    {
        public static void Main(string[] args)
        {
            Size size = new Size(5, 10);
            Console.WriteLine("Initial figure size: {0}", size);

            Size rotatedSize = GetRotatedSize(size, 30);
            Console.WriteLine("Rotated figure size: {0}", rotatedSize);
        }

        public static Size GetRotatedSize(Size size, double rotationAngle)
        {
            double newWidth = (Math.Abs(Math.Cos(rotationAngle)) * size.Width) + 
                (Math.Abs(Math.Sin(rotationAngle)) * size.Height);

            double newHeight = (Math.Abs(Math.Sin(rotationAngle)) * size.Width) + 
                (Math.Abs(Math.Cos(rotationAngle)) * size.Height);

            Size rotated = new Size(newWidth, newHeight);

            return rotated;
        }
    }
}
