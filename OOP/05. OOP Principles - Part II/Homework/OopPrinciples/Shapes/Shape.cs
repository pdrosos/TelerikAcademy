namespace Shapes
{
    using System;
    using System.Text;

    /// <summary>
    /// Abstract shape
    /// </summary>
    public abstract class Shape
    {
        protected double height;
        protected double width;

        protected Shape()
        { 
        }

        public Shape(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be greater than zero");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width must be greater than zero");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Calculates the shape's surface
        /// </summary>
        /// <returns></returns>
        public abstract double CalculateSurface();

        /// <summary>
        /// String representation of the shape
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append("Type: ").AppendLine(this.GetType().ToString());
            info.Append("Height: ").AppendLine(this.Height.ToString());
            info.Append("Width: ").AppendLine(this.Width.ToString());
            info.Append("Surface: ").AppendLine(this.CalculateSurface().ToString());

            return info.ToString();
        }
    }
}
