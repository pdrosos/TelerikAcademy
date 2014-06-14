namespace Methods
{
    using System;

    public class Methods
    { 
        public static void Main()
        {
            Console.WriteLine(MathExtensions.CalculateTriangleArea(3, 4, 5));
            Console.WriteLine(NumberFormatter.DigitToWord(5));
            Console.WriteLine(MathExtensions.FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine(NumberFormatter.FormatNumber(1.3, "fixedPoint"));
            Console.WriteLine(NumberFormatter.FormatNumber(0.75, "percentage"));
            Console.WriteLine(NumberFormatter.FormatNumber(2.30, "roundTrip"));
            
            Point a = new Point(3, -1);
            Point b = new Point(3, 2.5);
            
            Segment segment = new Segment(a, b);

            Console.WriteLine(a.DistanceTo(b));
            Console.WriteLine("Segment {0} is horizontal? {1}", segment, segment.IsHorizontal());
            Console.WriteLine("Segment {0} is vertical? {1}", segment, segment.IsVertical());

            Student firstStudent = new Student("Peter", "Ivanov", "17.03.1992");
            firstStudent.AdditionalDetails = "Location: Sofia";

            Student secondStudent = new Student("Stella", "Markova", "03.11.1993");
            secondStudent.AdditionalDetails = "Location: Vidin, Occupation: gamer, high results";

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                firstStudent.FirstName, 
                secondStudent.FirstName, 
                firstStudent.IsOlderThan(secondStudent));
        }
    }
}