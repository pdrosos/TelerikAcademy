namespace Matrices
{
    using System;
    using System.Text;

    /// <summary>
    /// Generix matrix, which uses .NET dynamic data type to do calculations
    /// </summary>
    public class Matrix<Number>
    {
        protected Number[,] elements;

        protected int rows;
        protected int columns;

        /// <summary>
        /// Create new matrix with given rows and columns
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Matrix(int rows, int columns)
        {
            elements = new Number[rows, columns];

            this.rows = rows;
            this.columns = columns;
        }

        /// <summary>
        /// Set or get the element at the given indexes
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Number this[int x, int y]
        {
            get
            {
                return elements[x, y];
            }
            set
            {
                elements[x, y] = value;
            }
        }

        /// <summary>
        /// Get rows
        /// </summary>
        public int Rows
        {
            get
            {
                return rows;
            }
        }

        /// <summary>
        /// Get columns
        /// </summary>
        public int Columns
        {
            get
            {
                return columns;
            }
        }

        /// <summary>
        /// Addition
        /// </summary>
        /// <param name="matrixOne"></param>
        /// <param name="matrixTwo"></param>
        /// <returns></returns>
        public static Matrix<Number> operator +(Matrix<Number> matrixOne, Matrix<Number> matrixTwo)
        {
            if (!(matrixOne.Rows == matrixTwo.Rows && matrixOne.Columns == matrixTwo.Columns))
            {
                throw new ArgumentException("Matrices sizes does not match");
            }

            Matrix<Number> addition = new Matrix<Number>(matrixOne.Rows, matrixOne.Columns);

            for (int i = 0; i < matrixOne.Rows; i++)
            {
                for (int j = 0; j < matrixOne.Columns; j++)
                {
                    addition[i, j] = (dynamic)matrixOne[i, j] + matrixTwo[i, j];
                }
            }

            return addition;
        }

        /// <summary>
        /// Subtraction
        /// </summary>
        /// <param name="matrixOne"></param>
        /// <param name="matrixTwo"></param>
        /// <returns></returns>
        public static Matrix<Number> operator -(Matrix<Number> matrixOne, Matrix<Number> matrixTwo)
        {
            if (!(matrixOne.Rows == matrixTwo.Rows && matrixOne.Columns == matrixTwo.Columns))
            {
                throw new ArgumentException("Matrices sizes does not match");
            }

            Matrix<Number> subtraction = new Matrix<Number>(matrixOne.Rows, matrixOne.Columns);

            for (int i = 0; i < matrixOne.Rows; i++)
            {
                for (int j = 0; j < matrixOne.Columns; j++)
                {
                    subtraction[i, j] = (dynamic)matrixOne[i, j] - matrixTwo[i, j];
                }
            }

            return subtraction;
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        /// <param name="matrixOne"></param>
        /// <param name="matrixTwo"></param>
        /// <returns></returns>
        public static Matrix<Number> operator *(Matrix<Number> matrixOne, Matrix<Number> matrixTwo)
        {
            if (!(matrixOne.Columns == matrixTwo.Rows))
            {
                throw new ArgumentException("Matrices sizes does not match");
            }

            Matrix<Number> m = new Matrix<Number>(matrixOne.Rows, matrixTwo.Columns);

            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    for (int k = 0; k < matrixOne.Columns; k++)
                    {
                        m[i, j] += (dynamic)matrixOne[i, k] * matrixTwo[k, j];
                    }
                }
            }

            return m;
        }

        /// <summary>
        /// True / False
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool BoolOperator(Matrix<Number> matrix, bool value)
        {
            foreach (Number item in matrix.elements)
            {
                if ((dynamic)item != 0)
                {
                    return value;
                }
            }

            return !value;
        }

        /// <summary>
        /// True operator
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static bool operator true(Matrix<Number> matrix)
        {
            return BoolOperator(matrix, true);
        }

        /// <summary>
        /// False operator
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static bool operator false(Matrix<Number> matrix)
        {
            return BoolOperator(matrix, false);
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Number maxElement = elements[0, 0];

            foreach (Number element in elements)
            {
                maxElement = Math.Max((dynamic)maxElement, (dynamic)element);
            }

            int maxCellSize = Convert.ToString(maxElement + " ").Length;

            StringBuilder info = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    info.Append(Convert.ToString(elements[i, j]).PadRight(maxCellSize, ' ') + (j != columns - 1 ? " " : Environment.NewLine));
                }
            }

            return info.ToString();
        }
    }
}