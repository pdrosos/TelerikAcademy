namespace Matrices
{
    using System;

    public class Matrices
    {
        /// <summary>
        /// Write a program that fills and prints a matrix of size (n, n) 
        /// </summary>
        public static void Main(string[] args)
        {
            int n = 4; // number of rows and columns

            int[,] matrix = FillMatrixUpsideDownWithSequentialNumbers(n);
            PrintSquareMatrix(matrix);

            matrix = FillMatrixVerticalCrossSideWithSequentialNumbers(n);
            PrintSquareMatrix(matrix);

            matrix = FillMatrixDiagonallyWithSequentialNumbers(n);
            PrintSquareMatrix(matrix);

            matrix = GenerateSpiralMatrix(n, n);
            PrintSquareMatrix(matrix);
        }

        public static int[,] FillMatrixUpsideDownWithSequentialNumbers(int n)
        {
            int[,] matrix = new int[n, n];
            int counter = 1;
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i, j] = counter;
                    counter++;
                }
            }
            return matrix;
        }

        public static int[,] FillMatrixVerticalCrossSideWithSequentialNumbers(int n)
        {
            int[,] matrix = new int[n, n];
            int counter = 1;
            for (int j = 0; j < n; j++)
            {
                if (j % 2 == 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        matrix[i, j] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int i = n - 1; i >= 0; i--)
                    {
                        matrix[i, j] = counter;
                        counter++;
                    }
                }
            }
            return matrix;
        }

        public static int[,] FillMatrixDiagonallyWithSequentialNumbers(int n)
        {
            int[,] matrix = new int[n, n];
            int elementValue = 1;

            // fills the matrix bottom right-angled triangle inlcuding the diagonal
            for (int i = n - 1; i >= 0; i--)
            {
                int colNumber = 0;
                for (int rowNumber = i; rowNumber <= n - 1; rowNumber++)
                {
                    matrix[rowNumber, colNumber] = elementValue;
                    elementValue++;
                    colNumber++;
                }
            }

            // fills the matrix upper right triangle excluding the diagonal
            for (int i = 1; i <= n - 1; i++)
            {
                int rowNumber = 0;

                for (int colNumber = i; colNumber <= n - 1; colNumber++)
                {
                    matrix[rowNumber, colNumber] = elementValue;
                    elementValue++;
                    rowNumber++;
                }
            }
            return matrix;
        }

        public static int[,] GenerateSpiralMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];

            int lowerRowBound = 0;
            int upperRowBound = rows - 1;

            int lowerColumnBound = 0;
            int upperColumnBound = columns - 1;

            int currentNumber = 1;

            do
            {
                // fill left columns
                for (int leftColumnsRowIndex = lowerRowBound; leftColumnsRowIndex <= upperRowBound; leftColumnsRowIndex++)
                {
                    matrix[leftColumnsRowIndex, lowerColumnBound] = currentNumber;
                    currentNumber++;
                }
                lowerColumnBound++;

                // fill lower rows
                for (int lowerRowsColumnIndex = lowerColumnBound; lowerRowsColumnIndex <= upperColumnBound; lowerRowsColumnIndex++)
                {
                    matrix[upperRowBound, lowerRowsColumnIndex] = currentNumber;
                    currentNumber++;
                }
                upperRowBound--;

                // this check is needed for the algorithm to work correct in some cases when columns != rows
                if (currentNumber > rows * columns)
                {
                    break;
                }

                // fill right columns
                for (int rightColumnsRowIndex = upperRowBound; rightColumnsRowIndex >= lowerRowBound; rightColumnsRowIndex--)
                {
                    matrix[rightColumnsRowIndex, upperColumnBound] = currentNumber;
                    currentNumber++;
                }
                upperColumnBound--;

                // fill upper rows
                for (int upperRowsColumnIndex = upperColumnBound; upperRowsColumnIndex >= lowerColumnBound; upperRowsColumnIndex--)
                {
                    matrix[lowerRowBound, upperRowsColumnIndex] = currentNumber;
                    currentNumber++;
                }
                lowerRowBound++;
            }
            while (currentNumber <= rows * columns);

            return matrix;
        }

        public static void PrintSquareMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 2} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
