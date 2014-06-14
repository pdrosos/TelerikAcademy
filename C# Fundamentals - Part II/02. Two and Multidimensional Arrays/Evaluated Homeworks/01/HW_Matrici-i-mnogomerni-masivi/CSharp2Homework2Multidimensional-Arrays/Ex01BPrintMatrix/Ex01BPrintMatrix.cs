
// Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

using System;

class Ex01BPrintMatrix
{
    static void Main(string[] args)
    {
        Console.Write("Enter matrix size: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {                
                if (i % 2 != 0 )
                    matrix[i, j] = ((i + 1)* n) - j; 
                else
                    matrix[i, j] = (i * n) + (j + 1);
            }



        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write("{0, -3}", matrix[j, i]);
            Console.WriteLine();
        }
    }
}

