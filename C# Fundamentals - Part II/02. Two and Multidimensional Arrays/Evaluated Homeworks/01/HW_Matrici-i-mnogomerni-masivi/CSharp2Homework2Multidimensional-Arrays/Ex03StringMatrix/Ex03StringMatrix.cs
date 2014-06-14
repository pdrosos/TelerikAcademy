
// We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located  
// on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix.

using System;

class Ex03StringMatrix
{
    static void Main(string[] args)
    {
        string[,] matrix = { 
          { "ox", "yx", "xx", "ff" },
          { "tt", "zz", "ff", "fb" },
          { "xx", "ff", "xx", "yx" },
        };
        string curEl;
        string longestEl = null;
        int maxLength = 1;
        int curLength = 1;

        // Проверяваме за повтарящи елементи по редове
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                if (matrix[row, col] == matrix[row, col + 1])
                {
                    curEl = matrix[row, col];
                    curLength++;
                }
                else
                {
                    curLength = 1;
                    curEl = null;
                }
                if (curLength > maxLength)
                {
                    maxLength = curLength;
                    longestEl = curEl;
                }
            }
            curLength = 1;
            curEl = null;
        }
        curLength = 1;
        curEl = null;

        // Проверяваме за повтарящи елементи по колони
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row, col] == matrix[row + 1, col])
                {
                    curEl = matrix[row, col];
                    curLength++;
                }
                else
                {
                    curLength = 1;
                    curEl = null;
                }
                if (curLength > maxLength)
                {
                    maxLength = curLength;
                    longestEl = curEl;
                }
            }
            curLength = 1;
            curEl = null;
        }
        curLength = 1;
        curEl = null;

        // Проверяваме за повтарящи елементи по диагонал, в увеличаващ ред. Диагоналите от предпоследния ред към първия.
        for (int row = matrix.GetLength(0) - 2; row > -1; row--)
        {
            for (int col = 0, curRow = row; col < matrix.GetLength(1) - 1 && curRow < matrix.GetLength(0) - 1; col++, curRow++)
            {
                if (matrix[curRow, col] == matrix[curRow + 1, col + 1])
                {
                    curEl = matrix[curRow, col];
                    curLength++;
                }
                else
                {
                    curLength = 1;
                    curEl = null;
                }
                if (curLength > maxLength)
                {
                    maxLength = curLength;
                    longestEl = curEl;
                }
            }
        }
        curLength = 1;
        curEl = null;

        // Проверяваме за повтарящи елементи по диагонал, в увеличаващ ред. Диагоналите от първия ред, от колона с индекс едно към предпоследната.
        for (int col = 1; col < matrix.GetLength(1) - 1; col++)
        {
            for (int row = 0, curCol = col; row < matrix.GetLength(0) - 1 && curCol < matrix.GetLength(1) - 1; row++, curCol++)
            {
                if (matrix[row, curCol] == matrix[row + 1, curCol + 1])
                {
                    curEl = matrix[row, curCol];
                    curLength++;
                }
                else
                {
                    curLength = 1;
                    curEl = null;
                }
                if (curLength > maxLength)
                {
                    maxLength = curLength;
                    longestEl = curEl;
                }
            }
        }

        // Проверяваме за повтарящи елементи по диагонал, в намаляващ ред. Диагоналите от ред с индекс едно към последния.
        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            for (int col = 0, curRow = row; col < matrix.GetLength(1) - 1 && curRow > 0; col++, curRow--)
            {
                if (matrix[curRow, col] == matrix[curRow - 1, col + 1])
                {
                    curEl = matrix[curRow, col];
                    curLength++;
                }
                else
                {
                    curLength = 1;
                    curEl = null;
                }
                if (curLength > maxLength)
                {
                    maxLength = curLength;
                    longestEl = curEl;
                }
            }
        }

        // Проверяваме за повтарящи елементи по диагонал, в намаляващ ред. Диагоналите от последния ред, от колона едно до предпоследната.
        for (int col = 1; col < matrix.GetLength(1) - 1; col++)
        {
            for (int row = matrix.GetLength(0) - 1, curCol = col; row > 0 && curCol < matrix.GetLength(1) - 1; row--, curCol++)
            {
                if (matrix[row, curCol] == matrix[row - 1, curCol + 1])
                {
                    curEl = matrix[row, curCol];
                    curLength++;
                }
                else
                {
                    curLength = 1;
                    curEl = null;
                }
                if (curLength > maxLength)
                {
                    maxLength = curLength;
                    longestEl = curEl;
                }
            }
        }

        // Отпечатване на резултата
        for (int i = 0; i < maxLength; i++)
        {
            Console.Write(longestEl + " ");
        }
        Console.WriteLine();
    }
}

