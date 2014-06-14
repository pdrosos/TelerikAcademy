namespace Matrices
{
    using System;

    class Test
    {
        static void Main(string[] args)
        {
            // create two matrices with random numbers
            Matrix<int> matrixOne = new Matrix<int>(3, 3);
            Matrix<int> matrixTwo = new Matrix<int>(3, 3);

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

            // true/false operators
            Console.WriteLine(matrixOne ? "Not empty" : "Empty");

            if (new Matrix<int>(3, 3))
            {
            }
            else
            {
                Console.WriteLine("Empty"); 
                Console.WriteLine(matrixOne ? "Not empty" : "Empty");
            }

            if (new Matrix<int>(3, 3))
            {
            }
            else
            {
                Console.WriteLine("Empty");
            }
        }
    }
}
