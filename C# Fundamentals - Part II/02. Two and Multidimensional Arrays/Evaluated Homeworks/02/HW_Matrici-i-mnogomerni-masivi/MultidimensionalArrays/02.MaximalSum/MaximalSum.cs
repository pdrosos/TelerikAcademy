//2. Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 
//that has maximal sum of its elements.


using System;

class MaximalSum
{
    static void Main()
    {
        Console.Write("Please enter matrix's size: N= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please enter matrix's size: M= ");
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];

        Console.WriteLine("Please enter the elements: ");

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("The matrix you have entered is: ");
        PrintMatrix(matrix);

        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                    matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                    matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        // Print the result
        Console.WriteLine("The best platform is:");
        Console.WriteLine("  {0}  {1}  {2}",
            matrix[bestRow, bestCol],
            matrix[bestRow, bestCol + 1],
            matrix[bestRow, bestCol + 2]);
        Console.WriteLine("  {0}  {1}  {2}",
            matrix[bestRow + 1, bestCol],
            matrix[bestRow + 1, bestCol + 1],
            matrix[bestRow + 1, bestCol + 2]);
        Console.WriteLine("  {0}  {1}  {2}",
            matrix[bestRow + 2, bestCol],
            matrix[bestRow + 2, bestCol + 1],
            matrix[bestRow + 2, bestCol + 2]);
        Console.WriteLine("The maximal sum is: {0}", bestSum);
    }

    static void PrintMatrix(int[,] matrix) // print method, used to print  the values of the matrix 
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(" {0, -3} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

