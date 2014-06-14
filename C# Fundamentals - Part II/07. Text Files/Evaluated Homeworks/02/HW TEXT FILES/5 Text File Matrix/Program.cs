using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of
//size 2 x 2 with a maximal sum of its elements. The first line in the input file contains the size of matrix N. 
//Each of the next N lines contain N numbers separated by space. The output should be a single number in a separate text file. Example:


namespace _5_Text_File_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("matrix.txt");

            int N = int.Parse(reader.ReadLine());
            int[,] matrix = new int[N, N];

            string line = reader.ReadLine();
            int lineNum = 0;

            while (line != null)
            {
                string[] nums = line.Split(' ');
                for (int i = 0; i < N; i++)
                {
                    matrix[lineNum, i] = int.Parse(nums[i]);
                }
                lineNum++;

                line = reader.ReadLine();

            }
            Print(matrix, N);
            Console.WriteLine(" {0} ",Calculate(matrix, N));
            reader.Dispose();

        }

        private static int Calculate(int[,] matrix, int N)
        {
            int maxsum = 0;
            for (int i = 0; i < N-1; i++)
            {
                for (int j = 0; j < N-1; j++)
                {
                    int sum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (sum > maxsum)
                    {
                        maxsum = sum;
                    }

                }
                
            }
            return maxsum;
        }

        private static void Print(int[,] matrix, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }


    }
}