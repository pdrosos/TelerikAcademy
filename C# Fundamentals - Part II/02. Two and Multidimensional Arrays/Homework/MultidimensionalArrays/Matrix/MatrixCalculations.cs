namespace Matrix
{
    using System;

    class MatrixCalculations
    {
        /// <summary>
        /// Write a class Matrix, to holds a matrix of integers. 
        /// Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().
        /// </summary>
        static void Main(string[] args)
        {
            // create two matrices with random numbers
            Matrix matrixOne = new Matrix(3, 3);
            Matrix matrixTwo = new Matrix(3, 3);

            Random randomGenerator = new Random();
            for (int i = 0; i < matrixOne.Rows; i++)
            {
                for (int j = 0; j < matrixOne.Columns; j++)
                {
                    matrixOne[i, j] = randomGenerator.Next(50);
                    matrixTwo[i, j] = randomGenerator.Next(70);
                }
            }

            // do some matix calculations
            Console.WriteLine("Matrix One:");
            Console.WriteLine(matrixOne);

            Console.WriteLine("Matrix Two:");
            Console.WriteLine(matrixTwo);

            Console.WriteLine("Matrix One + Matrix Two:");
            Console.WriteLine(matrixOne + matrixTwo);

            Console.WriteLine("Matrix One - Matrix Two:");
            Console.WriteLine(matrixOne - matrixTwo);

            Console.WriteLine("Matrix One * Matrix Two:");
            Console.WriteLine(matrixOne * matrixTwo);
        }
    }
}