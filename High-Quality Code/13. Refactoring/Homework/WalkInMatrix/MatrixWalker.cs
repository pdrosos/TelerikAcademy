namespace WalkInMatrix
{
    using System;

    public class MatrixWalker
    {
        private int step = 1;

        public MatrixWalker(Matrix matrix)
        {
            this.Matrix = matrix;
        }

        public Matrix Matrix { get; private set; }

        public MatrixWalker FillMatrix()
        {
            int row = 0;
            int col = 0;

            do
            {
                this.MatrixWalk(this.Matrix, row, col);
                this.FindEmptyCell(this.Matrix, out row, out col);
            }
            while (row != 0 && col != 0);

            return this;
        }

        private void ChangeDirection(ref int directionX, ref int directionY)
        {
            Directions possibleDirections = new Directions();

            int currentDirection = 0;

            for (int count = 0; count < possibleDirections.X.Length; count++)
            {
                if (possibleDirections.X[count] == directionX && possibleDirections.Y[count] == directionY)
                {
                    currentDirection = count;
                    break;
                }
            }

            if (currentDirection == possibleDirections.X.Length - 1)
            {
                directionX = possibleDirections.X[0];
                directionY = possibleDirections.Y[0];
                return;
            }

            directionX = possibleDirections.X[currentDirection + 1];
            directionY = possibleDirections.Y[currentDirection + 1];
        }

        private bool CheckDirection(Matrix matrix, int directionX, int directionY)
        {
            Directions possibleDirections = new Directions();

            for (int i = 0; i < possibleDirections.X.Length; i++)
            {
                if (this.IsLessThanZeroAndGreaterThanLimit(directionX + possibleDirections.X[i], matrix.Rows))
                {
                    possibleDirections.X[i] = 0;
                }

                if (this.IsLessThanZeroAndGreaterThanLimit(directionY + possibleDirections.Y[i], matrix.Columns))
                {
                    possibleDirections.Y[i] = 0;
                }
            }

            for (int i = 0; i < possibleDirections.X.Length; i++)
            {
                if (matrix[directionX + possibleDirections.X[i], directionY + possibleDirections.Y[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FindEmptyCell(Matrix matrix, out int row, out int col)
        {
            row = 0;
            col = 0;

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        col = j;

                        return;
                    }
                }
            }
        }

        private void MatrixWalk(Matrix matrix, int row, int col)
        {
            int curentDirectionX = 1;
            int currentDirectionY = 1;

            while (true)
            {
                this.Matrix[row, col] = this.step;
                this.step++;

                if (!this.CheckDirection(matrix, row, col))
                {
                    break;
                }

                while (this.IsCellTaken(matrix, row + curentDirectionX, col + currentDirectionY))
                {
                    this.ChangeDirection(ref curentDirectionX, ref currentDirectionY);
                }

                row += curentDirectionX;
                col += currentDirectionY;
            }
        }

        private bool IsCellTaken(Matrix matrix, int row, int col)
        {
            bool result = this.IsCellOutsideMatrix(matrix, row, col) || matrix[row, col] != 0;

            return result;
        }

        private bool IsCellOutsideMatrix(Matrix matrix, int row, int col)
        {
            bool rowCondition = this.IsLessThanZeroAndGreaterThanLimit(row, matrix.Rows);
            bool colCondition = this.IsLessThanZeroAndGreaterThanLimit(col, matrix.Columns);
            bool result = rowCondition || colCondition;

            return result;
        }

        private bool IsLessThanZeroAndGreaterThanLimit(int value, int limit)
        {
            bool result = value < 0 || value >= limit;

            return result;
        }
    }
}
