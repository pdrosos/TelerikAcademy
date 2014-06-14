using System;

class Circle : Shape
{
    public Circle(double radius)
        : base(radius, radius)
    {
    }

    public override double CalculateSurface()
    {
        double surface = Math.PI * this.Width * this.Width;
        return surface;
    }
}
