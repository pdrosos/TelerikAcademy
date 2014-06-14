using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* Write a program that reads a text file containing a square matrix of numbers and
 * finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. The 
 * first line in the input file contains the size of matrix N. Each of the next N 
 * lines contain N numbers separated by space. The output should be a single number 
 * in a separate text file. Example:
 * -> 4
 * 2 3 3 4
 * 0 2 3 4
 * 3 7 1 2
 * 4 3 3 2
 * -> 17
 */
class FindMaximalSubmatrixSum
{
    static void Main(string[] args)
    {
        // if you want to read a bigger matrix than 4x4, you will have to write it to the input.txt
        Console.WriteLine("Enter the side of the matrix:");
        int n = int.Parse(Console.ReadLine());

        int max = GetMax(ReadSquareMatrixFromFile(n));
        WriteRsultToFile(max);
    }

    static int[,] ReadSquareMatrixFromFile(int n)
    {
        int[,] result = new int[n, n];
        StreamReader reader = new StreamReader("../../input.txt");
        using (reader)
        {
            for (int line = 0; line < result.GetLength(0); line++)
            {
                string[] lineNumbers = reader.ReadLine().Split(' ');
                for (int number = 0; number < result.GetLength(1); number++)
                {
                    result[line, number] = int.Parse(lineNumbers[number]);
                }
            }
        }
        return result;
    }

    static int GetMax(int[,] matrix)
    {
        int result = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int tempSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (result <= tempSum)
                {
                    result = tempSum;
                }
                
            }   
        }

        return result;
    }

    static void WriteRsultToFile(int num)
    {
        StreamWriter writer = new StreamWriter("../../output.txt");
        using (writer)
        {
            writer.WriteLine(num);
        }
    }
}

