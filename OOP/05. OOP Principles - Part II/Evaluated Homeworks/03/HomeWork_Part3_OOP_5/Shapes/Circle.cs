using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        //Filds
        private double radius;

        //Properties
        public override double Height
        {
            get { return this.radius; }
            set { this.radius = value; }
        }
        public override double Width
        {
            get { return this.radius; }
            set { this.radius = value; }
        }

        //Constructor
        public Circle(double radius):base() 
        {
            this.radius = radius;
        }

        //Methods
        public override double CalculateSurface()
        {
            return (radius * radius) * Math.PI;
        } 
    }
}
