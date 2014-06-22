namespace WalkInMatrix
{
    using System;

    public class Program
    {
        public const int MaxSize = 100;

        public static int ReadMatrixDimensions()
        {
            Console.WriteLine("Enter a positive number: ");
            string input = Console.ReadLine();

            int number = 0;

            while (!int.TryParse(input, out number) || number < 0 || number > MaxSize)
            {
                Console.WriteLine("Please enter a number between 0 and {0}", MaxSize);
                input = Console.ReadLine();
            }

            return number;
        }

        public static void Main(string[] args)
        {
            int size = ReadMatrixDimensions();

            Matrix matrix = new Matrix(size, size);
            MatrixWalker walker = new MatrixWalker(matrix);
            walker.FillMatrix();

            Console.WriteLine(matrix);
        }
    }
}