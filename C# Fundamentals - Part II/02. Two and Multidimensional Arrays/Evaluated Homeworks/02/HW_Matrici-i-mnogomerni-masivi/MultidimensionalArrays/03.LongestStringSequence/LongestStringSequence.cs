//3.We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of 
//several neighbor elements located on the same line, column or diagonal. 
//Write a program that finds the longest sequence of equal strings in the matrix.

using System;
class LongestStringSequence
{
    static void Main()
    {
        Console.Write("Please enter matrix's size: N= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please enter matrix's size: M= ");
        int m = int.Parse(Console.ReadLine());
        string[,] matrix = new string[n, m];

        Console.WriteLine("Please enter the elements: ");

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }

        PrintMatrix(matrix); //print the entered strings of the matrix

        int counter = 1;
        int bestCounter = int.MinValue;
        string element = "";

        //horizontal check
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                if (matrix[row, col] == matrix[row, col + 1])
                {
                    counter++;

                    if (counter > bestCounter)
                    {
                        bestCounter = counter;
                        element = matrix[row, col];
                    }
                }
            }
            counter = 1;
        }

        //vertical check
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row, col] == matrix[row + 1, col])
                {
                    counter++;

                    if (counter > bestCounter)
                    {
                        bestCounter = counter;
                        element = matrix[row, col];
                    }
                }
            }
            counter = 1;
        }

        //diagonal check from top left to bottom right

        for (int col = 0, row = 0; col < matrix.GetLength(1) - 1 && row < matrix.GetLength(0) - 1; col++, row++)
        {
            if (matrix[row, col] == matrix[row + 1, col + 1])
            {
                counter++;

                if (counter > bestCounter)
                {
                    bestCounter = counter;
                    element = matrix[row, col];
                }
            }
            else
            {
                counter = 1;
            }
        }
        counter = 1;

        //diagonal check from top right to bottom left.

        for (int row = 0, col = matrix.GetLength(1) - 1; row < matrix.GetLength(0) - 1 && col > 0; row++, col--)
        {
            if (matrix[row, col] == matrix[row + 1, col - 1])
            {
                counter++;

                if (counter > bestCounter)
                {
                    bestCounter = counter;
                    element = matrix[row, col];
                }
            }
            else
            {
                counter = 1;
            }
        }
        counter = 1;

        Console.Write("{0} times is repeated element -> ", bestCounter);

        for (int j = 0; j < bestCounter; j++)
        {
            Console.Write("{0} ", element);
        }
        Console.WriteLine();

    }


    static void PrintMatrix(string[,] matrix) // print method, used to print  the values of the matrix 
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(" {0, -3} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

