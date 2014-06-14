namespace Matrix
{
    using System;
    
    public class Matrix
    {
        protected int[,] matrix;

        protected int rows;
        protected int columns;
        
        // Constructor
        public Matrix(int rows, int columns)
        {
            matrix = new int[rows, columns];

            this.rows = rows;
            this.columns = columns;
        }
        
        // Indexator
        public int this[int x, int y]
        {
            get 
            { 
                return matrix[x, y]; 
            }
            set 
            { 
                matrix[x, y] = value; 
            }
        }

        // Properties
        public int Rows
        {
            get
            {
                return rows;
            }
        }

        public int Columns
        {
            get
            {
                return columns;
            }
        }

        // Addition
        public static Matrix operator +(Matrix matrixOne, Matrix matrixTwo)
        {
            Matrix addition = new Matrix(matrixOne.Rows, matrixOne.Columns);

            for (int i = 0; i < matrixOne.Rows; i++)
            {
                for (int j = 0; j < matrixOne.Columns; j++)
                {
                    addition[i, j] = matrixOne[i, j] + matrixTwo[i, j];
                }
            }

            return addition;
        }

        // Subtraction
        public static Matrix operator -(Matrix matrixOne, Matrix matrixTwo)
        {
            Matrix subtraction = new Matrix(matrixOne.Rows, matrixOne.Columns);

            for (int i = 0; i < matrixOne.Rows; i++)
            {
                for (int j = 0; j < matrixOne.Columns; j++)
                {
                    subtraction[i, j] = matrixOne[i, j] - matrixTwo[i, j];
                }
            }

            return subtraction;
        }

        // Multiplication
        public static Matrix operator *(Matrix matrixOne, Matrix matrixTwo)
        {
            Matrix m = new Matrix(matrixOne.Rows, matrixTwo.Columns);

            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    for (int k = 0; k < matrixOne.Columns; k++)
                    {
                        m[i, j] += matrixOne[i, k] * matrixTwo[k, j];
                    }
                }
            }

            return m;
        }
        
        // ToString
        public override string ToString()
        {
            int maxElement = matrix[0, 0];

            foreach (int cell in matrix)
            {
                maxElement = Math.Max(maxElement, cell);
            }

            int maxCellSize = Convert.ToString(maxElement + " ").Length;

            string str = String.Empty;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    str += (Convert.ToString(matrix[i, j]).PadRight(maxCellSize, ' ') + (j != columns - 1 ? " " : "\n"));
                }
            }

            return str;
        }
    }
}
