namespace Methods
{
    using System;
    using System.Linq;
    using System.Text;

    public class Segment
    {
        // Line segment is defined by two geometric points: http://en.wikipedia.org/wiki/Line_segment
        private Point a;
        private Point b;

        public Segment(Point a, Point b)
        {
            this.A = a;
            this.B = b;
        }

        public Point A
        {
            get
            {
                return this.a;
            }

            set
            {
                try
                {
                    this.a = value;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Point B
        {
            get
            {
                return this.b;
            }

            set
            {
                try
                {
                    this.b = value;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public override string ToString()
        {
            string segmentAsString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("(({0}, {1}), ({2}, {3}))", this.a.X, this.a.Y, this.b.X, this.b.Y);
            segmentAsString = stringBuilder.ToString();

            return segmentAsString;
        }

        public bool IsHorizontal()
        {
            bool isHorizontal;

            if (this.a.Y == this.b.Y)
            {
                isHorizontal = true;
            }
            else
            {
                isHorizontal = false;
            }

            return isHorizontal;
        }

        public bool IsVertical()
        {
            bool isVertical;

            if (this.a.X == this.b.X)
            {
                isVertical = true;
            }
            else
            {
                isVertical = false;
            }

            return isVertical;
        }
    }
}