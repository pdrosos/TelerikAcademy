namespace Abstraction
{
    using System;

    internal class Circle : IFigure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                try
                {
                    this.radius = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error: Radius missing or type not correct. Details: {0}", ex);
                }
            }
        }

        public double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}
