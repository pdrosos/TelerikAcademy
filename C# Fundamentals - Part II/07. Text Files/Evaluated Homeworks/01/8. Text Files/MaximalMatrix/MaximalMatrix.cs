using System;
using System.IO;

class MaximalMatrix
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("matrix.txt"))
        {
            int N = int.Parse(reader.ReadLine());
            int[,] matrix = new int[N, N];
            string line;
            int matrixLine = 0;

            while ((line = reader.ReadLine()) != null)
            {
                string[] nums = line.Split(' ');

                for (int i = 0; i < nums.Length; i++)
                {
                    matrix[matrixLine, i] = int.Parse(nums[i]);
                }
                matrixLine++;
            }

            int bestSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > bestSum)
                        bestSum = sum;
                }

            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                writer.WriteLine(bestSum);
            }
        }
    }
}
