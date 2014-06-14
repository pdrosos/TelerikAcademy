namespace Methods
{
    using System;
    using System.Linq;
    using System.Text;

    public class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                try
                {
                    this.x = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Invalid x coordinate value. Details: {0}", ex);
                }
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                try
                {
                    this.y = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Invalid y coordinate value. Details: {0}", ex);
                }
            }
        }

        public override string ToString()
        {
            string pointAsString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("({0}, {1})", this.x, this.y);
            pointAsString = stringBuilder.ToString();

            return pointAsString;
        }

        public double DistanceTo(Point b)
        {
            double distance = Math.Sqrt(Math.Pow(this.x - b.x, 2) + Math.Pow(this.y - b.y, 2));

            return distance;
        }
    }
}