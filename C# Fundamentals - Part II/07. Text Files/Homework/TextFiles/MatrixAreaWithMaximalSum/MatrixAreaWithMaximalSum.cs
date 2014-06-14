namespace MatrixAreaWithMaximalSum
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class MatrixAreaWithMaximalSum
    {
        /// <summary>
        /// Write a program that reads a text file containing a square matrix of numbers 
        /// and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. 
        /// The first line in the input file contains the size of matrix N. 
        /// Each of the next N lines contain N numbers separated by space. 
        /// The output should be a single number in a separate text file. 
        /// </summary>
        public static void Main(string[] args)
        {
            StreamReader reader;
            StreamWriter writer;

            OpenFile("../../file.txt", out reader);
            CreateFile("../../result.txt", out writer);

            if (reader != null && writer != null)
            {
                using (reader)
                {
                    // read first line
                    int matrixLength = Convert.ToInt32(reader.ReadLine());

                    int[,] matrix = new int[matrixLength, matrixLength];

                    // read next matrixLength lines
                    List<string> numbers = new List<string>();
                    for (int i = 0; i < matrixLength; i++)
                    {
                        numbers.AddRange(reader.ReadLine().Split(' '));
                        for (int j = 0; j < matrixLength; j++)
                        {
                            matrix[i, j] = Convert.ToInt32(numbers[j]);
                        }
                        numbers.Clear();
                    }

                    int subMatrixMaxSum = SubMatrixElementsMaxSum(matrix, 2, 2);

                    using (writer)
                    {
                        writer.Write(subMatrixMaxSum);
                    }
                }

                Console.WriteLine("Done. Please, check the text file.");
            }
            else
            {
                Console.WriteLine("Cannot open files.");
            }
        }

        public static int SubMatrixElementsMaxSum(int[,] matrix, int subMatrixRows, int subMatrixCols)
        {
            int maxSum = int.MinValue;
            int currentSum = 0;
            for (int i = 0; i <= matrix.GetLength(0) - subMatrixRows; i++)
            {
                for (int j = 0; j <= matrix.GetLength(1) - subMatrixCols; j++)
                {
                    currentSum = SubMatrixSum(matrix, i, j, subMatrixRows, subMatrixCols);
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }

            }
            return maxSum;
        }

        public static int SubMatrixSum(int[,] matrix, int firstElementRow, int firstElementCol, int subMatrixRows, int subMatrixCols)
        {
            int subMatrixSum = 0;
            for (int i = firstElementRow; i < firstElementRow + subMatrixRows; i++)
            {
                for (int j = firstElementCol; j < firstElementCol + subMatrixCols; j++)
                {
                    subMatrixSum += matrix[i, j];
                }

            }
            return subMatrixSum;
        }

        public static bool OpenFile(string fileName, out StreamReader streamReader)
        {
            try
            {
                streamReader = new StreamReader(fileName);
                return true;
            }
            catch (FileNotFoundException)
            {
                streamReader = null;
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                streamReader = null;
                return false;
            }
            catch (IOException)
            {
                streamReader = null;
                return false;
            }
        }

        public static bool CreateFile(string fileName, out StreamWriter streamWriter)
        {
            try
            {
                streamWriter = new StreamWriter(fileName);
                return true;
            }
            catch (DirectoryNotFoundException)
            {
                streamWriter = null;
                return false;
            }
            catch (IOException)
            {
                streamWriter = null;
                return false;
            }
        }
    }
}
