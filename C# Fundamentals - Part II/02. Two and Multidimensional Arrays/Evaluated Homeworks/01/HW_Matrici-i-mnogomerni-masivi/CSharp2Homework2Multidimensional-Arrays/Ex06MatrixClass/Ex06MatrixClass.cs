
//Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, 
// indexer for accessing the matrix content and ToString().

using System;

class Program
{
    class Matrix
    {
        public int Rows, Cols;
        private int[,] matrix;

        // Constructor
        public Matrix(int x, int y)
        {
            matrix = new int[x, y];
            Rows = x;
            Cols = y;
        }

        // Getter/Setter
        public int this[int x, int y]
        {
            get { return matrix[x, y]; }
            set { matrix[x, y] = value; }
        }

        // Addition
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix m = new Matrix(m1.Rows, m1.Cols);

            for (int i = 0; i < m.Rows; i++)
                for (int j = 0; j < m.Cols; j++)
                    m[i, j] = m1[i, j] + m2[i, j];

            return m;
        }

        // Subtraction
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix m = new Matrix(m1.Rows, m1.Cols);

            for (int i = 0; i < m.Rows; i++)
                for (int j = 0; j < m.Cols; j++)
                    m[i, j] = m1[i, j] - m2[i, j];

            return m;
        }

        // Naive multiplication
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix m = new Matrix(m1.Rows, m2.Cols);

            for (int i = 0; i < m.Rows; i++)
                for (int j = 0; j < m.Cols; j++)
                    for (int k = 0; k < m1.Cols; k++)
                        m[i, j] += m1[i, k] * m2[k, j];

            return m;
        }

        // Print
        public override string ToString()
        {
            int max = this.matrix[0, 0];
            foreach (int cell in this.matrix) max = Math.Max(max, cell);
            int cellSize = Convert.ToString(max).Length;

            string s = String.Empty;

            for (int i = 0; i < this.Rows; i++)
                for (int j = 0; j < this.Cols; j++)
                    s += (Convert.ToString(this.matrix[i, j]).PadRight(cellSize, ' ') + (j != this.Cols - 1 ? " " : "\n"));

            return s;
        }
    }

    class Ex06MatrixClass
    {
        static void Main()
        {
            Matrix m1 = new Matrix(3, 3);
            Matrix m2 = new Matrix(3, 3);

            // Fill with random numbers
            Random randomGenerator = new Random();
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    m1[i, j] = randomGenerator.Next(20);
                    m2[i, j] = randomGenerator.Next(20);
                }
            }

            Console.WriteLine("Matrix 1");
            Console.WriteLine(m1);

            Console.WriteLine("Matrix 2");
            Console.WriteLine(m2);

            Console.WriteLine("Matrix 1 + Matrix 2");
            Console.WriteLine(m1 + m2);

            Console.WriteLine("Matrix 1 - Matrix 2");
            Console.WriteLine(m1 - m2);

            Console.WriteLine("Matrix 1 * Matrix 2");
            Console.WriteLine(m1 * m2);
        }
    }
}

