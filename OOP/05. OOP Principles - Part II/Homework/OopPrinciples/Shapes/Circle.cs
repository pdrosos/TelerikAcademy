namespace Shapes
{
    using System;
    using System.Text;

    /// <summary>
    /// Circle
    /// </summary>
    public class Circle : Shape
    {
        protected double radius;

        public Circle(double radius) : base()
        {
            this.Radius = radius;
            this.Width = radius * 2;
            this.Height = radius * 2;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.radius = value;
            }
        }

        public override double CalculateSurface()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(base.ToString());
            info.Append("Radius: ").Append(this.Radius).AppendLine();

            return info.ToString();
        }
    }
}
