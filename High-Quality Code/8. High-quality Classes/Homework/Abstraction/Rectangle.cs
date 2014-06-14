namespace Abstraction
{
    using System;

    public class Rectangle : IFigure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                try
                {
                    this.width = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error: Width missing or type not correct. Details: {0}", ex);
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                try
                {
                    this.height = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error: Height missing or type not correct. Details: {0}", ex);
                }
            }
        }

        public double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public double CalculateSurface()
        {
            double surface = this.Width * this.Height;

            return surface;
        }
    }
}