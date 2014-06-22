namespace WalkInMatrix
{
    using System;
    using System.Text;

    /// <summary>
    /// A Matrix representation
    /// </summary>
    public class Matrix
    {
        private readonly int[,] elements;

        private readonly int rows;
        private readonly int columns;

        /// <summary>
        /// Create new matrix with given rows and columns
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Matrix(int rows, int columns)
        {
            this.elements = new int[rows, columns];

            this.rows = rows;
            this.columns = columns;
        }

        /// <summary>
        /// Get rows
        /// </summary>
        public int Rows
        {
            get
            {
                return this.rows;
            }
        }

        /// <summary>
        /// Get columns
        /// </summary>
        public int Columns
        {
            get
            {
                return this.columns;
            }
        }

        /// <summary>
        /// Set or get the element at the given indexes
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int this[int x, int y]
        {
            get
            {
                return this.elements[x, y];
            }

            set
            {
                this.elements[x, y] = value;
            }
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int maxElement = this.elements[0, 0];

            foreach (int element in this.elements)
            {
                maxElement = Math.Max(maxElement, element);
            }

            int maxCellSize = Convert.ToString(maxElement).Length;

            StringBuilder info = new StringBuilder();

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    info.Append(Convert.ToString(this.elements[i, j]).PadLeft(maxCellSize, ' ') + 
                        (j != this.columns - 1 ? "  " : Environment.NewLine));
                }
            }

            return info.ToString().TrimEnd();
        }
    }
}
