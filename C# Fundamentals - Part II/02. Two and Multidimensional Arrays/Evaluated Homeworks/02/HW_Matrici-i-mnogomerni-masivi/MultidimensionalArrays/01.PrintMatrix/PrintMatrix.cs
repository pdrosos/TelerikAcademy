//1.Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

using System;

class PrintMatrix
{
    static void Main()
    {
        Console.Write("Please enter matrix's size: n= ");
        int n = int.Parse(Console.ReadLine());
        int[,] arrayMatrixA = new int[n, n];


        //a
        int currentRow = 1;
        int currentCol = 0;
        int currentSum = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                arrayMatrixA[i, j] = currentRow + currentSum;
                currentCol++;
                currentSum = n * currentCol;
            }
            currentSum = 0;
            currentCol = 0;
            currentRow++;
        }
        Console.WriteLine(Environment.NewLine + "Solution A:" + Environment.NewLine);
        PrintCurrentMatrix(arrayMatrixA); ;

        //b

        int[,] arrayMatrixB = new int[n, n];

        for (int i = 0; i < n; i++)
        {

            int currentElement = 1;

            for (int col = 0; col < arrayMatrixB.GetLength(1); col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < arrayMatrixB.GetLength(0); row++)
                    {
                        arrayMatrixB[row, col] = currentElement;
                        currentElement++;
                    }
                }
                else
                {
                    for (int row = arrayMatrixB.GetLength(0) - 1; row >= 0; row--)
                    {
                        arrayMatrixB[row, col] = currentElement;
                        currentElement++;
                    }
                }
            }
        }
        Console.WriteLine(Environment.NewLine + "Solution B:" + Environment.NewLine);
        PrintCurrentMatrix(arrayMatrixB);



        //c 

        int[,] arrayMatrixC = new int[n, n];
        int elementMatrix = 1;

        for (int row = 0; row <= n - 1; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                arrayMatrixC[n - row + col - 1, col] = elementMatrix;
                elementMatrix++;
            }
        }

        for (int row = n - 2; row >= 0; row--)
        {
            for (int col = row; col >= 0; col--)
            {
                arrayMatrixC[row - col, n - col - 1] = elementMatrix;
                elementMatrix++;
            }
        }
        Console.WriteLine(Environment.NewLine + "Solution C:" + Environment.NewLine);
        PrintCurrentMatrix(arrayMatrixC);


        //d
        int[,] arrayMatrixD = new int[n, n];

        string[] direction = new string[] { "down", "right", "up", "left" };
        string currentDirection = direction[0];

        int currentNumber = 1;
        int rowCurrent = 0;
        int colCurrent = 0;

        while (currentNumber <= arrayMatrixD.GetLength(0) * arrayMatrixD.GetLength(0))
        {
            if (currentDirection == "down")
            {
                while (rowCurrent < arrayMatrixD.GetLength(0) && currentNumber <= arrayMatrixD.GetLength(0) *
                    arrayMatrixD.GetLength(0))
                {
                    arrayMatrixD[rowCurrent, colCurrent] = currentNumber;
                    currentNumber++;
                    rowCurrent++;

                    if (rowCurrent == arrayMatrixD.GetLength(0) || arrayMatrixD[rowCurrent, colCurrent] != 0)
                    {
                        currentDirection = direction[1];
                        rowCurrent--;
                        colCurrent++;
                        break;
                    }
                }
            }

            if (currentDirection == "right")
            {
                while (colCurrent < arrayMatrixD.GetLength(1) && currentNumber <= arrayMatrixD.GetLength(0) *
                    arrayMatrixD.GetLength(0))
                {
                    arrayMatrixD[rowCurrent, colCurrent] = currentNumber;
                    currentNumber++;
                    colCurrent++;

                    if (colCurrent == arrayMatrixD.GetLength(1) || arrayMatrixD[rowCurrent, colCurrent] != 0)
                    {
                        currentDirection = direction[2];
                        colCurrent--;
                        rowCurrent--;
                        break;
                    }
                }
            }

            if (currentDirection == "up")
            {
                while (rowCurrent >= 0 && currentNumber <= arrayMatrixD.GetLength(0) * arrayMatrixD.GetLength(0))
                {
                    arrayMatrixD[rowCurrent, colCurrent] = currentNumber;
                    currentNumber++;
                    rowCurrent--;

                    if (rowCurrent == -1 || arrayMatrixD[rowCurrent, colCurrent] != 0)
                    {
                        currentDirection = direction[3];
                        rowCurrent++;
                        colCurrent--;
                        break;
                    }
                }
            }

            if (currentDirection == "left")
            {
                while (colCurrent >= 0 && currentNumber <= arrayMatrixD.GetLength(0) * arrayMatrixD.GetLength(0))
                {
                    arrayMatrixD[rowCurrent, colCurrent] = currentNumber;
                    currentNumber++;
                    colCurrent--;

                    if (colCurrent == -1 || colCurrent == 0 || arrayMatrixD[rowCurrent, colCurrent] != 0)
                    {
                        currentDirection = direction[0];
                        colCurrent++;
                        rowCurrent++;
                        break;
                    }
                }
            }
        }
        Console.WriteLine(Environment.NewLine + "Solution D:");
        PrintCurrentMatrix(arrayMatrixD);

    }

    // print method, used to print matrix 1 to 4
    static void PrintCurrentMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            Console.Write("|");
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(" {0, -3} |", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

