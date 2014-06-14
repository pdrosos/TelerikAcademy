using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        //Filds
        private double width;
        private double height;

        //Properties
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

        //Consturctor
        public Rectangle()
            : base()
        { 
        
        }
         public Rectangle(double width, double height)
            : base(width,height)
        {
            this.Width = width;
            this.Height = height;
        }

        //Methods
        public override double CalculateSurface() 
        {
            return this.Height * this.Width;
        }
    }
}
