namespace MatrixDFS
{
    using System;

    public class MatrixDFS
    {
        static int currentSum = 0;
        static int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

        /// <summary>
        /// Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.
        /// </summary>
        public static void Main(string[] args)
        {
            int[,] matrix = { { 1, 3, 2, 2, 2, 4 }, { 3, 3, 3, 2, 4, 4 }, { 4, 3, 1, 2, 3, 3 }, { 4, 3, 1, 3, 3, 1 }, { 4, 3, 3, 3, 1, 1 } };

            int maxSum = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0) // not visited
                    {
                        currentSum = 0;
                        DepthFirstSearch(matrix, i, j);

                        maxSum = Math.Max(currentSum, maxSum);
                    }
                }
            }

            Console.WriteLine("The largest area of equal neighbour elements is: {0}", maxSum);
        }

        public static void DepthFirstSearch(int[,] matrix, int row, int column)
        {
            int value = matrix[row, column];
            matrix[row, column] = 0; // Mark visited

            currentSum++;

            // Check neighbours
            for (int direction = 0; direction < directions.GetLength(0); direction++)
            {
                int adjacentCellRow = row + directions[direction, 0];
                int adjacentCellColumn = column + directions[direction, 1];

                if (IsTraversable(matrix, adjacentCellRow, adjacentCellColumn) && matrix[adjacentCellRow, adjacentCellColumn] == value)
                {
                    DepthFirstSearch(matrix, adjacentCellRow, adjacentCellColumn);
                }
            }
        }

        public static bool IsTraversable(int[,] matrix, int x, int y)
        {
            return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1);
        }
    }
}
