using System;
using System.Collections.Generic;

class MaxSum
{
    static void Main(string[] args)
    {
        //int n = int.Parse(Console.ReadLine());
        //int m= int.Parse(Console.ReadLine());
        int[,] arr =
            {
                {1,2,3,4,5},
                {3,4,5,6,3},
                {4,5,9,8,1}
            };
        int maxSum = 0;
        int maxRow = 0;
        int maxCol = 0;
        for (int row = 0; row < arr.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < arr.GetLength(1) - 2; col++)
            {
                int sum = arr[row, col] + arr[row, col + 1] + arr[row, col + 2] +
                        arr[row + 1, col] + arr[row + 1, col + 1] + arr[row + 1, col + 2] +
                        arr[row + 2, col] + arr[row + 2, col + 1] + arr[row + 2, col + 2];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxRow = row;
                    maxCol = col;
                }
            }
        }
        Console.WriteLine("The best platform is:");
        Console.WriteLine(" {0} {1} {2}", arr[maxRow, maxCol], arr[maxRow, maxCol + 1], arr[maxRow, maxCol + 2]);
        Console.WriteLine(" {0} {1} {2}", arr[maxRow + 1, maxCol], arr[maxRow + 1, maxCol + 1], arr[maxRow + 1, maxCol + 2]);
        Console.WriteLine(" {0} {1} {2}", arr[maxRow + 2, maxCol], arr[maxRow + 2, maxCol + 1], arr[maxRow + 2, maxCol + 2]);
        Console.WriteLine("The maximal sum is: {0}", maxSum);
    }
}

