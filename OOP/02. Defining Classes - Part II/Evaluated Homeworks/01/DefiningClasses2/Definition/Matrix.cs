using System;

class Matrix<T>
    where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
{
    public int rows;
    public int cols;
    public T[,] data;

    public Matrix(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        this.rows = rows;
        this.cols = cols;
        this.data = new T[rows, cols];
    }

    public T this[int row,int col]
    {
        get
        {
            if (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                return data[row, col];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        set
        {
            if (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                data[row, col] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
    {
        return Multiply(m1, m2);
    }

    private static Matrix<T> Multiply(Matrix<T> m1, Matrix<T> m2)
    {
        if (m1 == null || m2 == null)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (m1.cols != m2.rows)
        {
            throw new ArgumentOutOfRangeException();
        }

        try
        {
            Matrix<T> result = new Matrix<T>(m1.rows, m2.cols);

            for (int row = 0; row < result.rows; row++)
            {
                for (int col = 0; col < result.cols; col++)
                {
                    result[row, col] = default(T);
                    for (int i = 0; i < m1.cols; i++)
                    {
                        checked
                        {
                            result[row, col] += (dynamic)m1[row, i] * m2[i, col];
                        }
                    }
                }
            }

            return result;
        }
        catch (OverflowException)
        {
            throw new OverflowException();
        }
    }
    public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
    {
        return Add(m1, m2);
    }
    public static Matrix<T> operator -(Matrix<T> m)
    {
        return Multiply(-1, m);
    }
    private static Matrix<T> Multiply(int c, Matrix<T> m)
    {
        if (m == null)
        {
            throw new ArgumentOutOfRangeException();
        }

        try
        {
            Matrix<T> result = new Matrix<T>(m.rows, m.cols);

            for (int row = 0; row < m.rows; row++)
            {
                for (int col = 0; col < m.cols; col++)
                {
                    checked
                    {
                        result[row, col] = (dynamic)m[row, col] * c;
                    }
                }
            }

            return result;
        }
        catch (OverflowException)
        {
            throw new OverflowException();
        }
    }
    public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
    {
        return Add(m1, -m2);
    }
    private static Matrix<T> Add(Matrix<T> m1, Matrix<T> m2)
    {
        if (m1 == null || m2 == null)
        {
            throw new ArgumentOutOfRangeException("Matrices are not initialized.");
        }

        if (m1.rows != m2.rows || m1.cols != m2.cols)
        {
            throw new ArgumentOutOfRangeException("Matrices must have the same dimensions.");
        }
        try
        {
            Matrix<T> result = new Matrix<T>(m1.rows, m1.cols);

            for (int row = 0; row < result.rows; row++)
            {
                for (int col = 0; col < result.cols; col++)
                {
                    checked
                    {
                        result[row, col] = (dynamic)m1[row, col] + m2[row, col];
                    }
                }
            }

            return result;
        }
        catch (OverflowException)
        {
            throw new OverflowException();
        }
    }

    public static bool operator true(Matrix<T> m)
    {
        if (m == null || m.rows == 0 || m.cols == 0)
        {
            return false;
        }

        for (int row = 0; row < m.rows; row++)
        {
            for (int col = 0; col < m.cols; col++)
            {
                if (!m[row, col].Equals(default(T)))
                {
                    return true;
                }
            }
        }

        return false;
    }
    public static bool operator false(Matrix<T> m)
    {
        if (m == null || m.rows == 0 || m.cols == 0)
        {
            return true;
        }

        for (int row = 0; row < m.rows; row++)
        {
            for (int col = 0; col < m.cols; col++)
            {
                if (!m[row, col].Equals(default(T)))
                {
                    return false;
                }
            }
        }

        return true;
    }
}