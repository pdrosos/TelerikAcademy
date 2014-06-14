namespace Shapes
{
    using System;
    using System.Collections.Generic;

    class Test
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Circle(5));
            shapes.Add(new Triangle(3.5, 2.1));
            shapes.Add(new Rectangle(8, 9.4));

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }
    }
}
