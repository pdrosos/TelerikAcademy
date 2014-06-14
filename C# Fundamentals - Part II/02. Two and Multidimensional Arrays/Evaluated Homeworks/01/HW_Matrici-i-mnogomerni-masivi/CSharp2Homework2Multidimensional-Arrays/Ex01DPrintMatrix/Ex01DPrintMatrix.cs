
// Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

using System;

class Ex01DPrintMatrix
{
    static void PrintMatrix(int[,] matrix)
    {
        int cellSize = (int)Math.Log10(matrix.Length) + 1;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(Convert.ToString(matrix[i, j]).PadRight(cellSize, ' ') + (j != matrix.GetLength(1) - 1 ? " " : "\n"));
    }

    static bool IsTraversable(int[,] matrix, int x, int y)
    {
        return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1) && matrix[x, y] == 0;
    }

    static int direction = 0;
    static int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
    static void DFS(int[,] matrix, int row, int col, int current)
    {
        matrix[row, col] = current; // Set level

        if (current == matrix.Length) return; // End of recursion

        // Find the next cell, we should visit
        int _row = row + directions[direction, 0];
        int _col = col + directions[direction, 1];

        // Check if the next cell is traversable
        // Reset the direction and find the first free one if it isn't
        if (!IsTraversable(matrix, _row, _col)) direction = -1;
        while (!IsTraversable(matrix, _row, _col))
        {
            direction++;
            _row = row + directions[direction, 0];
            _col = col + directions[direction, 1];
        }

        DFS(matrix, _row, _col, current + 1); // Go to the next cell and increment level
    }

    static void Main()
    {
        Console.Write("Enter matrix size: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        DFS(matrix, 0, 0, 1);

        PrintMatrix(matrix);
    }
}

