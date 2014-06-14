
// Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

using System;

class Ex01CPrintMatrix
{
    static void Main(string[] args)
    {
        Console.Write("Enter matrix size: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int start;
        int step = 1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i > 0)
                start = matrix[i - 1, 1] + 1;
            else
                start = 1;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                
                if (i + j > n)
                {
                    if (step > n - 1)
                        step = n - 2;                    
                    matrix[i, j] = matrix[i, j - 1] + step;
                    step--;
                }
                else
                {
                    if (step > n - 1)
                        step = n - 1;
                    matrix[i, j] = start;
                    start = start + step;
                    step++;
                }
            }
            step = matrix[i, 2] - matrix[i, 1];
        }

        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write("{0, -3}", matrix[j, i]);
            Console.WriteLine();
        }
    }
}

