
// Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class Ex02MaxSum3x3
{
    static void Main(string[] args)
    {
        Console.Write("Rows: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Cols: ");
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];
        int maxSum = int.MinValue;
        int currentSum = 0;
        int startRow = 0;
        int startCol = 0;

        // Въвеждане на матрицата
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("matrix[{0}, {1}] = ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        // Търсене на максималната стойност
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                for (int i = row; i < row + 3; i++)
                {
                    for (int j = col; j < col + 3; j++)
                    {
                        currentSum += matrix[i, j];
                    }
                }
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    startRow = row;
                    startCol = col;
                }
                currentSum = 0;
            }
        }

        // Отпечатване на квадрата с максималната стойност
        for (int i = startRow; i < startRow + 3; i++)
        {
            for (int j = startCol; j < startCol + 3; j++)
            {
                Console.Write("{0, -3}", matrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("The max sum is: {0}", maxSum);
    }
}

