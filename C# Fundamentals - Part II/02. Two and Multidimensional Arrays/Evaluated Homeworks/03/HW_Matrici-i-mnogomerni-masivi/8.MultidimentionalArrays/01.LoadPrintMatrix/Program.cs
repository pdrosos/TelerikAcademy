using System;
using System.Collections.Generic;

class ReadMatrix
{
    static void PrintArr(int[,] arr, int n)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,2} ", arr[row, col]);
            }
            Console.WriteLine();
        }
    }
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[,] arrA = new int[n, n];
        int cellValue = 1;
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                arrA[row, col] = cellValue++;

            }
        }
        PrintArr(arrA, n);
        Console.WriteLine();
        int[,] arrB = new int[n, n];
        cellValue = 1;
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    arrB[row, col] = cellValue++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    arrB[row, col] = cellValue++;
                }
            }
        }
        PrintArr(arrB, n);
        Console.WriteLine();
        int[,] arrC = new int[n, n];
        cellValue = 1;

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = 0; j <= n - 1 - i; j++)
            {
                arrC[i + j, j] = cellValue;
                cellValue++;
            }
        }
        for (int i = 0; i <= n - 2; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                arrC[j - i - 1, j] = cellValue;
                cellValue++;
            }
        }
        PrintArr(arrC, n);

    }
}

