namespace CohesionAndCoupling
{
    using System;

    internal static class MathUtils
    {
        private static double width;
        private static double height;
        private static double depth;

        public static double Width
        {
            get
            {
                return width;
            }

            set
            {
                try
                {
                    width = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("The width type is incorrect or missing. Details: {0}", ex);
                }
            }
        }

        public static double Height
        {
            get
            {
                return height;
            }

            set
            {
                try
                {
                    height = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("The height type is incorrect or missing. Details: {0}", ex);
                }
            }
        }

        public static double Depth
        {
            get
            {
                return depth;
            }

            set
            {
                try
                {
                    depth = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("The depth type is incorrect or missing. Details: {0}", ex);
                }
            }
        }

        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));

            return distance;
        }

        public static double CalcVolume()
        {
            double volume = width * height * depth;

            return volume;
        }

        public static double CalcDiagonalXYZ()
        {
            double distance = CalcDistance3D(0, 0, 0, width, height, depth);

            return distance;
        }

        public static double CalcDiagonalXY()
        {
            double distance = CalcDistance2D(0, 0, width, height);

            return distance;
        }

        public static double CalcDiagonalXZ()
        {
            double distance = CalcDistance2D(0, 0, width, depth);

            return distance;
        }

        public static double CalcDiagonalYZ()
        {
            double distance = CalcDistance2D(0, 0, height, depth);

            return distance;
        }
    }
}
