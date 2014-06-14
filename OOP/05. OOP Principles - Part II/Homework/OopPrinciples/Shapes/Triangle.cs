namespace Shapes
{
    /// <summary>
    /// Triangle
    /// </summary>
    public class Triangle : Shape
    {
        public Triangle(double height, double width) : base(height, width)
        {
        }

        public override double CalculateSurface()
        {
            return (this.Height * this.Width) / 2;
        }
    }
}
