using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape
    {
        private double width;
        private double height;

        public abstract double Width { get; set; }
        public abstract double Height { get; set; }
        public abstract double CalculateSurface();

        public Shape() 
        {
            this.height = 0;
            this.width = 0;
        }
        public Shape(double width, double height) 
        {
            this.width = width;
            this.height = height;
        }
    }
}
