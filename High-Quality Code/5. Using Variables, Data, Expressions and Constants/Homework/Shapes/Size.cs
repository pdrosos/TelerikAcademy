namespace Shapes
{
    public class Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public override string ToString()
        {
            string sizeString = "Width: " + this.Width + "; Height:" + this.Height;
            return sizeString;
        }
    }
}
