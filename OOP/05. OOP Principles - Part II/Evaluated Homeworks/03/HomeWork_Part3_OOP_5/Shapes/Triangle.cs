using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : Shape
    {
        private double width;
        private double height;

        public override double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public override double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

         public Triangle()
            : base()
        { 
        
        }
         public Triangle(double width, double height)
            : base(width,height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculateSurface() 
        {
            return (this.Height * this.Width) / 2;
        }
    }
}
