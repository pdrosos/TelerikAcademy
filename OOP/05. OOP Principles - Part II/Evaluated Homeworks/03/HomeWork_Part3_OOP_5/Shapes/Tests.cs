using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Tests
    {
       
        static void Main(string[] args)
        {
           
            List<Shape> shapeList = new List<Shape>(){ 
                new Circle(2),
                new Rectangle(4, 5),
                new Triangle(2, 7)
            };

            Console.WriteLine(shapeList[0].CalculateSurface());
            Console.WriteLine(shapeList[1].CalculateSurface());
            Console.WriteLine(shapeList[2].CalculateSurface());
           

            Triangle testing = new Triangle(5, 4);
            Rectangle testingTwo = new Rectangle(6, 4);
            Circle testingThree = new Circle(5);

            Console.WriteLine(testing.CalculateSurface());
            Console.WriteLine(testingTwo.CalculateSurface());
            Console.WriteLine(testingThree.CalculateSurface());


            
            while (true)
            {
                
            }
        }
    }
}
