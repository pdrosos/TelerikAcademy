using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//4. Write methods that calculate the surface of a triangle by given: 
//   Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.


namespace _04SurfaceOfTriangle
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How do you want to calculate the surface of triangle: ");  //simple menu from which the user to choose 
            Console.WriteLine("1. By given side and an altitude to it.");                 //how he wants to caluculate the area of triangle
            Console.WriteLine("2. By given three sides.");
            Console.WriteLine("3. By given two sides and an angle between them.");
            Console.Write("Your choice is: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)          // switch between diffrent choices
            {
                case 1:
                    CalcAreaBySideAndAltitude(); //call the method for this choice (calculate area by given side and altitude)
                    break;
                case 2:
                    CalcAreaBy3Sides();         //call the method for this choice (calculate area by given 3 sides )
                    break;
                case 3:
                    CalcAreaBy2SidesAndAngel(); //call the method for this choice (calculate area by given 2 sides and angle between them )
                    break;
                default:
                    Console.WriteLine("Your choice is invalid."); //if the entered choice is not in these 3 options print to the console
                    break;                                        //messege that the entered choice is in invalid
            }
        }

        static void CalcAreaBySideAndAltitude() 
        {
            Console.Write("Enter value for the side: ");      //get the needen information from the user from the console
            double side = double.Parse(Console.ReadLine());

            Console.Write("Enter value for the altitude to the side: ");
            double altitude = double.Parse(Console.ReadLine());

            //calculate the actual area when we have the values for side and altitude and write the result area on the console
            Console.WriteLine("The area of the triangle withe side {0} and altitude to it {1} is:  Area= {2}", side, altitude, (side * altitude) / 2);
        }   

        static void CalcAreaBy3Sides()
        {
            Console.Write("Enter value for the first side: ");  //get the needen information from the user from the console
            double firstSide = double.Parse(Console.ReadLine());

            Console.Write("Enter value for the second side: ");
            double secondSide = double.Parse(Console.ReadLine());

            Console.Write("Enter value for the third side: ");
            double thirdSide = double.Parse(Console.ReadLine());

            double perimeter = (firstSide + secondSide + thirdSide) / 2; //calculate the sami perimeter of the triangle
                                                                        //calculate the actual area when we have the values for the 3 sides
            double area= Math.Sqrt(perimeter*(perimeter-firstSide)*(perimeter-secondSide)*(perimeter-thirdSide));
            //calculate the actual area when we have the values for the 3 sides and write result area on the console
            Console.WriteLine("The area of the triangle withe sides {0}, {1} and {2} is: Area= {3}",firstSide, secondSide, thirdSide, area);
        }

        static void CalcAreaBy2SidesAndAngel()
        {
            Console.Write("Enter value for the first side: ");
            double firstSide = double.Parse(Console.ReadLine());

            Console.Write("Enter value for the second side: ");
            double secondSide = double.Parse(Console.ReadLine());

            Console.Write("Enter value for the angle in degree (0,180): ");
            double angle = double.Parse(Console.ReadLine());

            //calculate the actual area when we have the values for sides and angle and write the result area on the console if it is positive
            //if it's not then print to the console that the entered values for the triangle wasn't correct
            double area = (firstSide * secondSide * Math.Sin(angle)) / 2;
            if (area > 0)
            {
                Console.WriteLine("The area of the triangle withe sides {0}, {1} and angle {2} is:  Area= {3}", firstSide, secondSide, angle, area);
            }
            else
            {
                Console.WriteLine("The values that you entered for the triangle properties are invalid.");
            }
        }

    }
}
